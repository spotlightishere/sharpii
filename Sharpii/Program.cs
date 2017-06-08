/* This file is part of Sharpii.
 * Copyright (C) 2013 Person66
 *
 * Sharpii is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Sharpii is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Sharpii. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Net;
using libWiiSharp;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sharpii
{
	class MainApp
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				help();
				Environment.Exit(0);
			}

			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "libWiiSharp.dll"))
			{
				Console.WriteLine("ERROR: libWiiSharp.dll not found!");
				Console.WriteLine("Perhaps redownloading the IOS Patcher will help?");
				Environment.Exit(0);
			}

			for (int i = 1; i < args.Length; i++)
			{
				switch (args[i].ToUpper())
				{
					case "-QUIET":
						Quiet.quiet = 1;
						break;
					case "-Q":
						Quiet.quiet = 1;
						break;
					case "-LOTS":
						Quiet.quiet = 3;
						break;
				}
			}

			string Function = args[0].ToUpper();
			bool gotSomewhere = false;

			if (Function == "-H" || Function == "-HELP" || Function == "H" || Function == "HELP")
			{
				help();
				gotSomewhere = true;
			}

			if (Function == "WAD")
			{
				WAD_Stuff.WAD(args);
				gotSomewhere = true;
			}

			if (Function == "NUS" || Function == "NUSD")
			{
				NUS_Stuff.NUS(args);
				gotSomewhere = true;
			}

			if (gotSomewhere == false)
			{
				//If tuser gets here, they entered something wrong
				Console.WriteLine("ERROR: The argument {0} is invalid", args[0]);
			}

			string temp = Path.GetTempPath() + "Sharpii.tmp";
			if (Directory.Exists(temp) == true)
				DeleteDir.DeleteDirectory(temp);

			Environment.Exit(0);
		}

		private static void help()
		{
			Console.WriteLine("");
			Console.WriteLine("Sharpii {0} - A tool by person66, using libWiiSharp.dll by leathl", Version.version);
			Console.WriteLine("This version stripped down by spotlightishere for usage with the RiiConnect24");
			Console.WriteLine("IOS Patcher.");
			Console.WriteLine("  Usage:");
			Console.WriteLine("");
			Console.WriteLine("       Sharpii [function] [parameters] [-quiet | -q | -lots]");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("  Functions:");
			Console.WriteLine("");
			Console.WriteLine("       WAD            Pack/Unpack/Edit a wad file");
			Console.WriteLine("       NUSD           Download files from NUS");
			Console.WriteLine("");
			Console.WriteLine("       NOTE: To see more detailed descriptions of any of the above,");
			Console.WriteLine("             use 'Sharpii [function] -h'");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("  Global Arguments:");
			Console.WriteLine("");
			Console.WriteLine("       -quiet | -q    Try not to display any output");
			Console.WriteLine("       -lots          Display lots of output");
			Console.WriteLine("");


		}

	}
}
public static class DeleteDir
{
	public static bool DeleteDirectory(string target_dir)
	{
		bool result = false;

		string[] files = Directory.GetFiles(target_dir);
		string[] dirs = Directory.GetDirectories(target_dir);

		foreach (string file in files)
		{
			File.SetAttributes(file, FileAttributes.Normal);
			File.Delete(file);
		}

		foreach (string dir in dirs)
		{
			DeleteDirectory(dir);
		}

		Directory.Delete(target_dir, false);

		return result;
	}
}
public class Quiet
{
	//1 = little
	//2 = normal
	//3 = lots
	public static int quiet = 2;
}
public class Version
{
	public static string version = "1.7.3";
}