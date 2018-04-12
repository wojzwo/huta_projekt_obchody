using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SteelWorks_Admin.View
{
	public partial class _64buttonUserControl : UserControl
	{
		List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();
		List<System.Windows.Forms.Button> buttons = new List<System.Windows.Forms.Button>();

		int[] mask = new int[64];
		int len = 64;

		public ulong get_mask()
		{
			ulong intmask= 0;
			for(int i =0; i < 64; i++)
			{
				if (mask[i] == 1)
				{
					intmask |= (ulong) (1 << i);
				}
			}
			return intmask;
		}

		public void set_mask(ulong intmask)
		{
			for (int i = 0; i < 64; i++)
			{
				mask[i] = (int)(1 & (intmask >> i));
			}
			refreshUC();
		}

		public void set_buttons_active(int lenN)
		{
			len = lenN;
			foreach(Button button in buttons)
			{
				button.Enabled = false;
			}
			for(int i=1; i<=((len<=64)?len:64); i++)
			{
				buttons[translate_number(i) - 1].Enabled = true;
			}
			refreshUC();
		}
		
		public _64buttonUserControl()
		{
			InitializeComponent();
			prepareUC();
			refreshUC();
		}

		private int translate_number(int x)
		{
			if (x >= 3 && x <= 4) return 3 + 4 - x;
			if (x >= 5 && x <= 8) return 5+8 - x;
			if (x >= 9 && x <= 16) return 9+16 - x;
			if (x >= 17 && x <= 32) return 17+32 - x;
			if (x >= 33 && x <= 64) return 33+64 - x;
			return x;
		}

		private void buttonClickHandler(object sender, EventArgs e)
		{
			String name = ((System.Windows.Forms.Button) sender).Name.ToString();
			int n0old = Int32.Parse(Regex.Match(name, @"\d+").Value);
			int n0correct = translate_number(n0old);
			if (mask[n0correct-1] == 0)
			{
				mask[n0correct-1] = 1;
				((System.Windows.Forms.Button)sender).BackColor= System.Drawing.Color.LightBlue;

			}
			else
			{
				mask[n0correct-1] = 0;
				((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.WhiteSmoke;
			}
		}
		

		private void fill_lists()
		{
			labels.Add(label1);
			labels.Add(label2);
			labels.Add(label3);
			labels.Add(label4);
			labels.Add(label5);
			labels.Add(label6);
			labels.Add(label7);
			labels.Add(label8);
			labels.Add(label9);
			labels.Add(label10);
			labels.Add(label11);
			labels.Add(label12);
			labels.Add(label13);
			labels.Add(label14);
			labels.Add(label15);
			labels.Add(label16);
			labels.Add(label17);
			labels.Add(label18);
			labels.Add(label19);
			labels.Add(label20);
			labels.Add(label21);
			labels.Add(label22);
			labels.Add(label23);
			labels.Add(label24);
			labels.Add(label25);
			labels.Add(label26);
			labels.Add(label27);
			labels.Add(label28);
			labels.Add(label29);
			labels.Add(label30);
			labels.Add(label31);
			labels.Add(label32);
			labels.Add(label34);
			labels.Add(label35);
			labels.Add(label36);
			labels.Add(label37);
			labels.Add(label38);
			labels.Add(label39);
			labels.Add(label40);
			labels.Add(label41);
			labels.Add(label42);
			labels.Add(label43);
			labels.Add(label44);
			labels.Add(label45);
			labels.Add(label46);
			labels.Add(label47);
			labels.Add(label48);
			labels.Add(label49);
			labels.Add(label50);
			labels.Add(label51);
			labels.Add(label52);
			labels.Add(label53);
			labels.Add(label54);
			labels.Add(label55);
			labels.Add(label56);
			labels.Add(label57);
			labels.Add(label58);
			labels.Add(label59);
			labels.Add(label60);
			labels.Add(label61);
			labels.Add(label62);
			labels.Add(label63);
			labels.Add(label64);
			buttons.Add(button1);
			buttons.Add(button2);
			buttons.Add(button3);
			buttons.Add(button4);
			buttons.Add(button5);
			buttons.Add(button6);
			buttons.Add(button7);
			buttons.Add(button8);
			buttons.Add(button9);
			buttons.Add(button10);
			buttons.Add(button11);
			buttons.Add(button12);
			buttons.Add(button13);
			buttons.Add(button14);
			buttons.Add(button15);
			buttons.Add(button16);
			buttons.Add(button17);
			buttons.Add(button18);
			buttons.Add(button19);
			buttons.Add(button20);
			buttons.Add(button21);
			buttons.Add(button22);
			buttons.Add(button23);
			buttons.Add(button24);
			buttons.Add(button25);
			buttons.Add(button26);
			buttons.Add(button27);
			buttons.Add(button28);
			buttons.Add(button29);
			buttons.Add(button30);
			buttons.Add(button31);
			buttons.Add(button32);
			buttons.Add(button34);
			buttons.Add(button35);
			buttons.Add(button36);
			buttons.Add(button37);
			buttons.Add(button38);
			buttons.Add(button39);
			buttons.Add(button40);
			buttons.Add(button41);
			buttons.Add(button42);
			buttons.Add(button43);
			buttons.Add(button44);
			buttons.Add(button45);
			buttons.Add(button46);
			buttons.Add(button47);
			buttons.Add(button48);
			buttons.Add(button49);
			buttons.Add(button50);
			buttons.Add(button51);
			buttons.Add(button52);
			buttons.Add(button53);
			buttons.Add(button54);
			buttons.Add(button55);
			buttons.Add(button56);
			buttons.Add(button57);
			buttons.Add(button58);
			buttons.Add(button59);
			buttons.Add(button60);
			buttons.Add(button61);
			buttons.Add(button62);
			buttons.Add(button63);
			buttons.Add(button64);

		}

		private void prepareUC()
		{
			fill_lists();
			foreach(System.Windows.Forms.Label lbl in labels)
			{
				String name= lbl.Name.ToString();
				int n0old = Int32.Parse(Regex.Match(name, @"\d+").Value);
				int n0correct = translate_number(n0old);
				lbl.Text = n0correct.ToString();
			}
			foreach (System.Windows.Forms.Button button in buttons)
			{
				button.Text = "";
				button.Click += buttonClickHandler;
			}
		}

		private void refreshUC()
		{
			foreach (System.Windows.Forms.Button button in buttons)
			{
				if (button.Enabled == false)
				{
					button.BackColor = System.Drawing.Color.Gray;
					continue;
				}
				String name = button.Name.ToString();
				int n0old = Int32.Parse(Regex.Match(name, @"\d+").Value);
				int n0correct = translate_number(n0old);
				if (mask[n0correct - 1] == 0)
				{
					button.BackColor = System.Drawing.Color.WhiteSmoke;

				}
				else
				{
					button.BackColor = System.Drawing.Color.LightBlue;
				}
			}
		}

        private void _64buttonUserControl_Load(object sender, EventArgs e) {

        }
    }
}
