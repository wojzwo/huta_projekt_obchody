using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomst
{
    public class Tengine
    {
        static byte[] crctable = new byte[]
        {  0,  94, 188, 226,  97,  63, 221, 131, 194, 156, 126,  32, 163, 253,  31,  65,
         157, 195,  33, 127, 252, 162,  64,  30,  95,   1, 227, 189,  62,  96, 130, 220,
         35, 125, 159, 193,  66,  28, 254, 160, 225, 191,  93,   3, 128, 222,  60,  98,
         190, 224,   2,  92, 223, 129,  99,  61, 124,  34, 192, 158,  29,  67, 161, 255,
         70,  24, 250, 164,  39, 121, 155, 197, 132, 218,  56, 102, 229, 187,  89,   7,
         219, 133, 103,  57, 186, 228,   6,  88,  25,  71, 165, 251, 120,  38, 196, 154,
         101,  59, 217, 135,   4,  90, 184, 230, 167, 249,  27,  69, 198, 152, 122,  36,
         248, 166,  68,  26, 153, 199,  37, 123,  58, 100, 134, 216,  91,   5, 231, 185,
         140, 210,  48, 110, 237, 179,  81,  15,  78,  16, 242, 172,  47, 113, 147, 205,
         17,  79, 173, 243, 112,  46, 204, 146, 211, 141, 111,  49, 178, 236,  14,  80,
         175, 241,  19,  77, 206, 144, 114,  44, 109,  51, 209, 143,  12,  82, 176, 238,
         50, 108, 142, 208,  83,  13, 239, 177, 240, 174,  76,  18, 145, 207,  45, 115,
         202, 148, 118,  40, 171, 245,  23,  73,   8,  86, 180, 234, 105,  55, 213, 139,
         87,   9, 235, 181,  54, 104, 138, 212, 149, 203,  41, 119, 244, 170,  72,  22,
         233, 183,  85,  11, 136, 214,  52, 106,  43, 117, 151, 201,  74,  20, 246, 168,
         116,  42, 200, 150,  21,  75, 169, 247, 182, 232,  10,  84, 215, 137, 107,  53
        };

        public struct p3_header
        {
            public uint serial;
            public byte hardware, firmware;
            public ushort transferdata, transfertmd;
            public uint touch, wakeups, winkontrol;
            public byte battery;
            public ushort eeprom;
            public byte AV0_Points, AV1_Points, AV2_Points, AV3_Points, AV4_Points, AV5_Points, AV6_Points, AV7_Points;
            public ushort AV0_count, AV1_count, AV2_count, AV3_count, AV4_count, AV5_count, AV6_count, AV7_count;
            public ushort AVCurrent, AVPoints, AVPointsMax;
            public byte AVLost;
            public ushort Addr90, AddrMax, Cap90, CapMax;
            public byte TempLo, TempHi, Lock, Seconds, ID, DataChip;
            public byte Volume, Keypad, TempWarnLO, TempWarnHI;
            public string description;  // string has 19 characters
        }

        public p3_header fp3header;

        // i want to trace buffer when sending data forth and back
        // private static readonly log4net.ILog log =
        //     log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // constants
        private const int BUF_SIZE = 100;
        private const int RST_TIME = 600;

        private FTDI ftdi;
        private FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OTHER_ERROR;
        private byte[] fid = new byte[8];

        private byte[] fbuf = new byte[BUF_SIZE];

        public Tengine() {
            ftdi = new FTDI();
        }

        private byte calc8(byte[] ID) {
            byte crc;
            int j;
            crc = 0;
            crc = crctable[crc ^ ID[0]];
            for (j = 6; j > 0; j--)
                crc = crctable[crc ^ ID[j]];
            return (crc);
        }

        public bool opendev() {

            ftStatus = ftdi.OpenBySerialNumber("FTOY5L43");
            if (ftStatus == FTDI.FT_STATUS.FT_OK) {
                return true;
            }

            return (false);
        }

        public bool closedev() {

            if (ftdi.Close() != FTDI.FT_STATUS.FT_OK)
                return (false);

            return (true);
        }

        // wait for cnt bytes in queue
        private bool wait_for_queue(uint cnt) {
            int start = Environment.TickCount;
            bool ret;
            UInt32 wcnt = 0;

            do {
                ret = (ftdi.GetRxBytesAvailable(ref wcnt) == FTDI.FT_STATUS.FT_OK);
            } while ((wcnt < cnt) && ((Environment.TickCount - start) < RST_TIME));

            return (wcnt >= cnt); ;
        }

        private void input_check(ref byte j) {
            byte i;
            uint d;
            d = 0;
            for (i = 2; i < j; i++)
                d = d + fbuf[i];

            d = d % 256;
            d = 0x100 - d;
            d = d % 256;
            fbuf[j] = (byte)d;
            j++;
        }

        // cmd   ... command
        // check ... used only in p3_connect, when package for write is too large, 
        //       ... the function requires last byte serving as a check 
        private bool writebuf(string cmd, bool check) {
            bool ret;
            byte j = 0, i = 0;
            UInt32 numBytesWritten = 0;

            // make array from string tokens
            string[] tokens = cmd.Split(';');
            foreach (string token in tokens) {
                string s = token;
                if (token[0] == '$') {
                    s = token.Substring(1);
                    i = Convert.ToByte(s, 16);
                } else
                    i = Convert.ToByte(s);
                fbuf[j++] = i;
            }

            // for large input buffer tmd requires safety check on the end
            // used only in p3_reconnect
            if (check) {
                j--;
                input_check(ref j);
            }
            // send 
            ret = (ftdi.Write(fbuf, j, ref numBytesWritten) == FTDI.FT_STATUS.FT_OK);
            if (!ret)
                return (false);

            // wait for first byte in queue
            //ret = wait_for_queue(1);

            return (ret);
            // ftdi.Read(fbuf,)

        }

        private void clearbuffer(byte[] abuf) {
            for (int i = 0; i < abuf.Length; i++)
                abuf[i] = 0;
        }

        private bool readbuf(uint cnt) {
            bool ret;
            uint dwRead = 0;

            ret = (ftdi.Read(fbuf, cnt, ref dwRead) == FTDI.FT_STATUS.FT_OK);
            return (ret);
        }


        private byte readbyte() {
            byte[] b = new byte[1];

            uint dwRead = 0;
            if (ftdi.Read(b, 1, ref dwRead) == FTDI.FT_STATUS.FT_OK)
                return (b[0]);

            throw new Exception("Failed in engine.readbyte");
        }

        private bool cmdsim(string cmd, uint cnt, bool check) {
            bool ret;
            ret = writebuf(cmd, check);
            if (!ret)
                return (false);

            System.Threading.Thread.Sleep(10);
            ret = wait_for_queue(cnt);
            if (!ret)
                return (false);

            ret = readbuf(cnt);
            if (!ret)
                return (false);

            return (true);
        }

        private bool cmdapi(string cmd, uint cnt, bool check) {
            bool ret;

            ret = writebuf(cmd, check);
            if (!ret)
                return (false);

            // test first byte of response
            ret = wait_for_queue(1);
            if (!ret)
                return (false);

            // first byte=0 indicates that command was processed correctly
            byte b = readbyte();
            if (b > 0)
                return (false);

            ret = wait_for_queue(cnt - 1);
            ret = readbuf(cnt - 1);
            if (!ret)
                return (false);

            // shift data back
            for (uint i = cnt; i-- > 1;)
                fbuf[i] = fbuf[i - 1];
            fbuf[0] = b;

            return (true);
        }

        private bool _poweroff() {
            if (ftdi.SetRTS(false) == FTDI.FT_STATUS.FT_OK)
                return (false);
            if (ftdi.SetDTR(false) == FTDI.FT_STATUS.FT_OK)
                return (false);
            return (true);
        }

        private bool _poweron() {
            //FTDI.FT_STATUS ret = FTDI.FT_STATUS.FT_OTHER_ERROR;

            //ret = ftdi.SetRTS(false);
            //if (ret != FTDI.FT_STATUS.FT_OK)
            //    return (false);

            if (ftdi.SetRTS(false) != FTDI.FT_STATUS.FT_OK)
                return (false);
            if (ftdi.SetDTR(false) != FTDI.FT_STATUS.FT_OK)
                return (false);
            System.Threading.Thread.Sleep(50);
            if (ftdi.SetRTS(true) != FTDI.FT_STATUS.FT_OK)
                return (false);
            if (ftdi.SetDTR(true) != FTDI.FT_STATUS.FT_OK)
                return (false);
            System.Threading.Thread.Sleep(1);

            return (true);
        }

        public bool tmd_version(out byte hw, out byte fw) {
            hw = 0;
            fw = 0;

            bool ret;
            ret = cmdapi("1;$F1", 3, false);
            if (!ret)
                return (false);

            if (fbuf[0] > 0)        // first byte has to be zero
                return (false);

            hw = fbuf[1];
            fw = fbuf[2];

            return (ret);
        }


        public bool read_id(out string number) {
            bool ret;
            number = "";
            byte[] fid = new byte[8];

            //ret = cmdapi("1;$DC", 9, false);
            ret = cmdsim("1;$DC", 9, false);
            if (!ret)
                return (false);

            fid[0] = fbuf[1];
            for (int j = 1; j < 7; j++)
                fid[j] = fbuf[9 - j - 1];
            fid[7] = fbuf[8];

            if (fid[7] != calc8(fid))
                return (false);

            //fid[7] = calc8(fid);
            number = string.Format("{0:X2}-{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}*{7:X2}", fid[0], fid[1], fid[2], fid[3], fid[4], fid[5], fid[6], fid[7]);
            return (true);
        }


        // reads either sensor id or dallas id
        public bool chip_touch(out string number, out bool IsP3) {
            bool ret;
            number = "";
            byte hw, fw;

            IsP3 = false;

            ret = tmd_version(out hw, out fw);

            ret = cmdsim("1;$C0", 1, false);
            if (!ret)
                return (false);

            // it was a dallas id chip
            if (fbuf[0] == 0) {
                ret = read_id(out number);
                return (ret);
            }

            // it was a P3 sensor, get sensor ID
            if (fbuf[0] == 1) {
                ret = p3_reconnect();
                if (!ret)
                    return (false);

                ret = p3_readeeprom();
                if (!ret)
                    return (false);

                System.Threading.Thread.Sleep(10);
                number = fp3header.serial.ToString();
                IsP3 = true;
                return (true);
            }
            return (false);
        }

        public bool adapternumber(out string number) {
            number = "";
            if (!_poweron())
                return (false);

            if (!cmdapi("1;$F0", 5, false))    // awaiting 5 bytes back as result
                return (false);

            // permut fields and prepare for formatting
            fid[0] = 0;
            fid[1] = 0;
            fid[2] = 0;
            fid[3] = fbuf[1];
            fid[4] = fbuf[2];
            fid[5] = fbuf[3];
            fid[6] = fbuf[4];
            fid[7] = 0;

            // compute crc8
            fid[7] = calc8(fid);
            number = string.Format("{0:X2}-{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}*{7:X2}", fid[0], fid[1], fid[2], fid[3], fid[4], fid[5], fid[6], fid[7]);
            return (true);
        }

        public bool medium_type(out byte medium) {
            medium = 0;
            if (!cmdsim("1;$C0", 1, false))
                return (false);

            medium = fbuf[0];
            return (true);
        }

        public bool p3_reconnect() {
            // medium type
            if (!cmdsim("1;$C0", 1, false))
                return (false);

            // is sensor present on TMD
            if (fbuf[0] == 1)
                if (!cmdsim("1;$D0", 1, false))
                    return false;

            if (fbuf[0] == 3)
                return (true);

            return (false);
        }

        public bool p3_eventcount(out int firstfree, out byte bank) {
            firstfree = 0;
            bank = 0;
            if (!cmdapi("14;48;65;85;85;85;0;0;0;85;85;85;85;85;23", 16, true)) {
                return (false);
            }
            firstfree = fbuf[4] + fbuf[5] * 256;
            bank = fbuf[6];
            return (true);
        }

        public bool _purgerxtx() {
            FTDI.FT_STATUS ret = FTDI.FT_STATUS.FT_OTHER_ERROR;
            ret = ftdi.Purge((FTDI.FT_PURGE.FT_PURGE_RX | (FTDI.FT_PURGE.FT_PURGE_TX)));
            return (ret == FTDI.FT_STATUS.FT_OK);
        }

        private byte ToBCD(int byt) {
            // 53 -> 0x53
            int ret;
            ret = byt % 10 + (((byt / 10) & 0x0F) << 4);
            if (ret > 256)
                throw new Exception("Failed in engine.ByteToBcd>256");
            return ((byte)ret);
        }


        public bool p3_settime() {
            DateTime tm = new DateTime();
            tm = DateTime.Now;
            bool ret = false;

            string cmd = string.Format("14;48;32;85;85;85;{0};{1};{2};{3};{4};{5};{6};{7}",
                ToBCD(tm.Second), ToBCD(tm.Minute),
                ToBCD(tm.Hour), ToBCD(tm.Day),
                ToBCD((int)(tm.DayOfWeek)), ToBCD(tm.Month),
                ToBCD(tm.Year - 1000), 0x55);

            // log.Info("p3_settime" + cmd);
            ret = cmdsim(cmd, 16, true);
            return (ret);
        }

        public bool p3_beep_ok() {
            bool ret = false;
            string cmd = "14;$30;$07;$55;$55;$55;$55;$55;$55;$55;$55;$55;$55;$55;$55";
            ret = cmdsim(cmd, 16, true);
            return (ret);
        }

        public bool p3_beep_common() {
            bool ret;

            string cmd = "14;$30;$02;$55;$55;$55;$55;$55;$55;$55;$55;$55;$55;$55";
            ret = cmdsim(cmd, 16, true);
            return (ret);
        }

        private bool p3_delatom() {
            bool ret;

            string cmd = "14;$30;$40;$01;$55;$55;0;0;0;$55;$55;$55;$55;$55;$0";
            ret = cmdsim(cmd, 16, true);
            if (fbuf[15] > 0) {
                if (!p3_reconnect())
                    return (false);
            }
            return (ret);
        }

        private bool p3_delete() {
            bool ret = false;
            int delcount = 0;
            do {
                ret = p3_delatom();
                if (!ret)
                    System.Threading.Thread.Sleep(10);
                delcount++;

            } while ((delcount < 10) && (!ret));


            return (ret);
        }

        public bool p3_deletesensor() {
            bool ret = false;
            const int MAX_TRIALS = 20;
            int trials = 0;

            int ffcount = 0, firstfree = 0, bank = 0;
            do {
                ret = p3_delete();
                if (ret) {
                    ret = p3_eventcount(out firstfree, out bank);
                    if (ret)
                        ret = (firstfree == 0);
                    ffcount++;
                }

                trials++;
            } while ((ffcount < 10) && (!ret) && (trials < MAX_TRIALS));

            return (ret);
        }

        // p3 reads options in configuration eeprom  in 8-byte chunks
        // 
        private bool p3_eechunk(uint addr, byte count) {
            bool ret = false;
            do {
                string cmd = string.Format("14;$30;$11;{0};0;{1};0;0;0;0;0;0;0;0;255", count - 1, addr);
                //clearbuffer(fbuf);
                ret = cmdsim(cmd, 16, true);

                if (ret)
                    // is p3 still attached to the reading probe ?
                    if (fbuf[15] != 0) {
                        // no, detacched, trying to reconnect
                        ret = p3_reconnect();
                        if (!ret)
                            return (false);
                    }
            } while (!ret);

            for (int i = 0; i < 8; i++)
                fid[i] = fbuf[i + 4];

            return (true);
        }

        private bool p3_getheader(ref byte[] mem) {

            fp3header.serial = 0;
            for (int i = 4; i > 0; i--) {
                fp3header.serial = fp3header.serial * 256;
                fp3header.serial = fp3header.serial + mem[0x0C + i - 1];
            }
            return (true);
            //&& ((Environment.TickCount - start) < RST_TIME));
        }

        public bool p3_readeeprom() {
            byte[] mem = new byte[16 * 8];
            byte i;
            uint j;
            bool ret;

            clearbuffer(mem);
            i = 0;
            // int start = Environment.TickCount;
            do {
                j = (uint)(i * 8);
                ret = p3_eechunk(j, 8);
                if (!ret)
                    return (false);

                for (int k = 0; k < 8; k++)
                    mem[j + k] = fid[k];

                i++;
            } while (i < 14);

            // fill fp3header structure
            ret = p3_getheader(ref mem);
            if (!ret)
                return (false);

            return (true);
        }

        public bool p3_eventcount(out int firstfree, out int bank) {
            bool ret = false;
            firstfree = 0;
            bank = 0;
            string cmd = "14;48;65;85;85;85;0;0;0;85;85;85;85;85;23";
            ret = cmdsim(cmd, 16, true);
            if (!ret)
                return (false);

            firstfree = fbuf[4] + fbuf[5] * 256;
            bank = fbuf[6];
            return (true);
        }

        // state machine for reading the data include these states
        // see p3_readtourwork
        enum tw_state
        {
            bgSTART = 0,  // purge rx/tx, then ask if p3 is attached and switching device to bgWRITE mode
            bgWRITE = 1,  // sending order into TMD (and P3). After that we can switch to bgREAD case
            bgREAD = 2,   // tmd is sending data collected from P3. 
            bgItest = 3,
            bgNOP3 = 4,   // device is not P3, we do not support P2 or datachip yet.
            bgTIMEOUT = 5,// timeout error, the device doesnt respond in the expected time
            bgBUFOK = 6,  // buffer checked for integrity, we can read next packet
            bgBUFERR = 7, // buffer error, mostly if you dettach p3 for a while
            bgFINISH = 8, // all went OK, we have fineshed run
            bgERROR = 9   // we cannot recover from this error
        }

        // getting data using state machine
        private bool p3_readtourwork(int firstfree, ref byte[] memdump) {
            int lastpage, curaddr, curcnt;
            string cmd = "";

            lastpage = (firstfree - 1) / 64 + 1;
            // correct lastpage when last event fits exactly to 64 byte page;
            if (((firstfree - 1) % 64) == 0)
                lastpage--;

            byte p3_missing = 0;
            curcnt = lastpage % 256;
            curaddr = 0;
            //erread = 0;
            tw_state twstate = tw_state.bgSTART;
            do {
                switch (twstate) {
                    // start state
                    case tw_state.bgSTART:
                        if (!_purgerxtx())
                            twstate = tw_state.bgERROR;

                        if (!p3_reconnect()) {
                            p3_missing++;
                            break;
                        }
                        curaddr = 0;
                        twstate = tw_state.bgWRITE;
                        break;

                    // write command 
                    case tw_state.bgWRITE:
                        cmd = string.Format("4;$31;{0};{1};{2}", (curaddr >> 8) & 0xff, (curaddr & 0xFF), curcnt);
                        if (!writebuf(cmd, false)) {
                            twstate = tw_state.bgSTART;
                            break;
                        }

                        //erread = 0;
                        twstate = tw_state.bgREAD;
                        break;

                    // respond from P3
                    case tw_state.bgREAD:

                        if (!wait_for_queue(1))
                            break;

                        byte b = readbyte();
                        if ((b == 254) || (b == 255)) {
                            twstate = tw_state.bgWRITE;
                            break;
                        }

                        clearbuffer(fbuf);
                        if (!readbuf(68)) {
                            twstate = tw_state.bgWRITE;
                            break;
                        }
                        for (uint i = 68; i-- > 1;)
                            fbuf[i] = fbuf[i - 1];
                        fbuf[0] = b;

                        twstate = tw_state.bgItest;
                        break;

                    // couple of test ensuring data integrity
                    // we retest buffer 3x times
                    case tw_state.bgItest:
                        int iTest;
                        iTest = 0;

                        // repeat 3x times when bad byte detected
                        // bad package has usually fbuf[68]==0x02;
                        while ((fbuf[68] != 0) && (iTest < 3)) {
                            clearbuffer(fbuf);
                            if (!readbuf(69)) {
                                twstate = tw_state.bgWRITE;
                                break;
                            }
                            iTest++;
                        }

                        if (fbuf[68] != 0) {
                            twstate = tw_state.bgBUFERR; // buffer error
                            break;
                        }

                        // check if adapter returned correc curaddr
                        int tmp = fbuf[0] * 256 + (fbuf[1] & 0xFE);
                        if (tmp != curaddr) {
                            twstate = tw_state.bgBUFERR; // buffer error
                            break;
                        }

                        if ((fbuf[1] & 0x01) > 0) {
                            twstate = tw_state.bgBUFERR; // buffer error
                            break;
                        }

                        twstate = tw_state.bgBUFOK;
                        break;

                    // bgRead went OK, we are going copy whole content of eeprom into memory
                    case tw_state.bgBUFOK:

                        //log.Info("\nncurraddr=");

                        for (int i = 0; i < 64; i++) {
                            //  log.Info(String.Format("{0:2} 0x{1:X2}", i + curaddr, fbuf[i + 2]));
                            memdump[i + curaddr] = fbuf[i + 2];
                        }
                        curcnt--;
                        curaddr = curaddr + 64;

                        if (curcnt > 0)
                            twstate = tw_state.bgREAD;
                        else
                            twstate = tw_state.bgFINISH;
                        break;

                    case tw_state.bgBUFERR:
                        twstate = tw_state.bgERROR;
                        break;
                }

            } while ((twstate != tw_state.bgFINISH) && (twstate != tw_state.bgERROR));

            if (twstate != tw_state.bgFINISH)
                return (false);

            return (true);
        }

        /// <summary>
        ///  Parser section 
        /// </summary>
        /// 
        private const byte CHIP_RESOLUTION = 3;
        private const bool USE_SECONDS = true;



        public struct evstamp
        {
            public byte second, minute, hour, day, month;
            public ushort year;
            public string chipId;

            public DateTime ToDateTime() {
                DateTime date = new DateTime(year, month, day, hour, minute, second);
                return date;
            }
        }

        public evstamp evs;   // timestamp

        private void clearstamp(evstamp evs) {
            evs.hour = 0;
            evs.minute = 0;
            evs.day = 0;
            evs.month = 0;
            evs.second = 0;
        }

        private string PrintTimeStamp(evstamp evs) {
            string ret = String.Format("{0}.{1}.{2} {3}.{4}.{5}", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second);
            //log.Info(ret);
            return (ret);
        }

        enum evtype
        {
            enone = 0,
            eantivandal = 1,
            ekeypad = 2,
            etimechange = 3,
            etouch = 4
        }

        private void update_hhmm(byte b1) {
            evs.minute = (byte)(b1 / 4);
            evs.hour = (byte)((evs.hour / 4) * 4 + (b1 & 3));
        }

        private byte bcdtobyte(byte bcd) {
            int ret;
            ret = bcd % 16 + (bcd / 16) * 10;
            return (byte)(ret);
        }

        private byte bcdtobyte(int v) {
            throw new NotImplementedException();
        }

        private bool update_sec(byte b1) {
            // xsss ssss, seconds are in BCD,
            // x is flag for correct time. 0 ... OK, 1...ERROR
            evs.second = (byte)bcdtobyte((byte)(b1 & 0x7F));
            if ((b1 & 0x80) == 1)
                return (false);

            return (true);
        }

        private void update_datetime(byte b1, byte b2) {
            if (b1 < 0xEF) {
                update_hhmm(b1);
                if (USE_SECONDS)
                    if (!update_sec(b2))
                        evs.second = 88;  // signal, that time conversion was faulty
            }
        }

        public struct antivandal
        {
            public byte evtype;
            public ushort info;
            public string description;
        }
        antivandal avl;


        Dictionary<int, string> avdesc = new Dictionary<int, string>()
        {
            {1,"small crash"},
            {2,"medium crash"},
            {3,"big crash"},
            {4,"short"},
            {5,"overvoltage"},
            {6,"temperature"},
            {7,"microwave"},
            {9,"temp info"}
        };

        private void parse_antivandal(byte b1, byte b2, byte b3, byte b4) {
            if (b1 < 0xEF) {
                update_hhmm(b1);
                if (USE_SECONDS)
                    update_sec(b2);
            }
            avl.evtype = (byte)(b3 & 7);
            avl.info = (byte)((b3 >> 4) * 256 + b4);

            // translate evtype into string description
            string description = "unknown";
            if (avdesc.TryGetValue(avl.evtype, out description))
                avl.description = description;

            string time = PrintTimeStamp(evs);
            //log.Info(String.Format("{0} AVT: {1}, nfo={2}", time,avl.evtype, avl.info));
        }

        // callback section
        public delegate void TOnStartParsing();
        public TOnStartParsing OnStart;

        public delegate void TOnChipTouch(evstamp aevs, string chip);
        public TOnChipTouch OnChipTouch;

        public delegate void TOnAntivandal(evstamp aevs, antivandal avl);
        public TOnAntivandal OnAntivandal;

        public delegate void TOnKeypadTouch(evstamp aevs, int keyCode);
        public TOnKeypadTouch OnKeypadTouch;

        private bool parsedump(int firstfree, ref byte[] image) {
            int curcnt;    // pointer into memory blob
            byte b1, b2, b3, b4;


            evtype evt = evtype.enone;
            clearstamp(evs);
            OnStart();
            curcnt = 0;

            do {
                //log.Info(String.Format("curcnt={0}", curcnt));
                switch (image[curcnt]) {
                    case 0xF6:  // update day
                        evs.day = (byte)(bcdtobyte(image[++curcnt]) & 0x3F);
                        break;

                    case 0xF7:  // update year month
                        evs.year = (ushort)(2000 + bcdtobyte(image[++curcnt]));
                        evs.month = (byte)(bcdtobyte(image[++curcnt]));
                        break;

                    case 0xF8:
                        evt = evtype.eantivandal;
                        break;

                    case 0xF9:
                        evt = evtype.ekeypad;
                        break;

                    case 0xFE:
                        evt = evtype.etimechange;
                        break;

                    // update Hi hour
                    case 0xF0:
                    case 0XF1:
                    case 0xF2:
                    case 0XF3:
                    case 0xF4:
                    case 0XF5:
                        evs.hour = (byte)((evs.hour % 4) + (image[curcnt] & 0x7) * 4);
                        break;

                    case 0xFA:  // reserved
                        break;
                    case 0xFC:  // reserved
                        break;
                    case 0xFD:  // reserved
                        break;

                    case 0xFB:
                        //log.Info("Sensor event, not implemented \r\n");
                        return (false);
                    //break;

                    case 0xFF:  // end of data for this sensor
                        //log.Info(String.Format("End of data for this sensor, ptr=%d \n", curcnt));
                        //curcnt = curcnt + 5;
                        curcnt = curcnt + 4;
                        break;


                    default:
                        if (image[curcnt] > 0xEF)
                            return (false);

                        if (evt == evtype.eantivandal) {
                            b1 = image[curcnt++];
                            b2 = image[curcnt++];
                            b3 = image[curcnt++];
                            b4 = image[curcnt];
                            parse_antivandal(b1, b2, b3, b4);

                            if (OnAntivandal != null)
                                OnAntivandal(evs, avl);

                            evt = evtype.enone;
                            break;
                        }

                        if (evt == evtype.ekeypad) {
                            // get datetime
                            b1 = image[curcnt++];
                            b2 = image[curcnt++];
                            update_datetime(b1, b2);  // result is in evs global variable
                            b3 = image[curcnt];      // keypad number
                            b3 &= 0x0F;

                            OnKeypadTouch?.Invoke(evs, b3);

                            //log.Info(String.Format("Touched keypad={0}", b3));
                            //if (processing->Active)
                            //    (*processing->processKey)(processing->procData, evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, b3);
                            evt = evtype.enone;
                            break;
                        }

                        if (evt == evtype.etimechange) {
                            b1 = image[curcnt++];
                            b2 = image[curcnt];
                            update_datetime(b1, b2);
                            evt = evtype.enone;
                            break;
                        }

                        // chip touch, 99% of the work ends here
                        if (evt == evtype.enone) {
                            update_hhmm(image[curcnt++]);
                            //curcnt++;
                            if (USE_SECONDS)
                                update_sec(image[curcnt++]);

                            string chip = "";
                            for (int i = CHIP_RESOLUTION; i > 0; i--)
                                chip = chip + String.Format("{0:X2}", image[curcnt + i - 1]);
                            OnChipTouch(evs, chip);  // callback to the main form

                            chip = PrintTimeStamp(evs) + " " + chip;
                            //log.Info(chip);
                            curcnt = curcnt + CHIP_RESOLUTION - 1;
                        }

                        break;
                }

                curcnt++;

            } while (curcnt < firstfree);

            return (true);
        }


        public bool p3_readsensor(int firstfree) {
            bool ret = false;

            // allocate memory for the p3 dump
            int minalo = (firstfree / 64 + 1);
            byte[] memset = new byte[minalo * 64];
            for (int i = 0; i < minalo * 64; i++)
                memset[i] = 0;

            ret = p3_readtourwork(firstfree, ref memset);
            if (!ret)
                return (false);

            //for (int i = 0; i < memset.Length; i++)
            //    listBox.Items.Add(String.Format("{0:D2} {1:D3}", i, memset[i]));
            ret = parsedump(firstfree, ref memset);
            if (!ret)
                return (false);

            return (true);
        }
    }


}
