using System;
using System.IO;

namespace MasterServer
{
	public static class Logger
	{
		static string path = "./log.txt";
		
		public static bool Append(string text, bool bIsToPrintOnConsole = false) {
			FileStream oStream;
			if( File.Exists( path ) )
				oStream = new FileStream( path, FileMode.Append, FileAccess.Write, FileShare.Read );
			else
				oStream = new FileStream( path, FileMode.CreateNew, FileAccess.Write, FileShare.Read );
			
            StreamWriter sw = new StreamWriter( oStream );
			
			try {
				sw.WriteLine( DateTimeOffset.Now.ToString( ) + " | " + text );
			} catch(IOException) {
				return false;
			} finally {
				sw.Close( );
				oStream.Dispose( );
			}
			
			if (bIsToPrintOnConsole)
				Console.WriteLine(text);
			
			return true;
		}
	}
}