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
using libWiiSharp;

namespace Sharpii
{
	partial class WAD_Stuff
	{
		public static void WAD(string[] args)
		{
			if (args.Length < 3)
			{
				WAD_help();
				return;
			}

			//********************* PACK *********************
			if (args[1] == "-p")
			{
				if (args.Length < 4)
				{
					WAD_help();
					return;
				}

				Editor(args, false);
				return;
			}

			//********************* UNPACK *********************
			if (args[1] == "-u")
			{
				if (args.Length < 4)
				{
					WAD_help();
					return;
				}

				Unpack(args);
				return;
			}

			//If the user gets here, they entered something wrong
			Console.WriteLine("ERROR: The argument {0} is invalid", args[1]);

			return;
		}

		private static void Editor(string[] args, bool edit)
		{
			//Setting up variables
			string input_file = args[2];
			string output_folder = args[3];
			// We can set this to true since it's all that'll be used in the patcher
			bool fake = true;

			//Check if file/folder exists
			if (Directory.Exists(input_file) == false)
			{
				Console.WriteLine("ERROR: Unable to open folder: {0}", input_file);
				return;
			}

			//Run main part, and check for exceptions
			try
			{
				WAD wad = new WAD();

				if (edit == true)
				{
					if (Quiet.quiet > 2)
						Console.Write("Loading file...");
					wad.LoadFile(input_file);
				}
				else
				{
					if (Quiet.quiet > 2)
						Console.Write("Loading folder...");
					wad.CreateNew(input_file);
				}

				if (Quiet.quiet > 2)
					Console.Write("Done!\n");
				
				wad.FakeSign = fake;

				if (Quiet.quiet > 2)
					Console.Write("Saving file...");

				if (output_folder.Substring(output_folder.Length - 4, 4).ToUpper() != ".WAD")
					output_folder = output_folder + ".wad";

				wad.Save(output_folder);

				if (Quiet.quiet > 2)
					Console.Write("Done!\n");

				if (Quiet.quiet > 1)
					Console.WriteLine("Operation completed succesfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("An unknown error occured, please try again");
				Console.WriteLine("");
				Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
				return;
			}
		}

		private static void Unpack(string[] args)
		{
			//setting up variables
			string input = args[2];
			string output = args[3];
			bool cid = false;

			//Check if file exists
			if (File.Exists(input) == false)
			{
				Console.WriteLine("ERROR: Unable to open file: {0}", input);
				return;
			}

			//Run main part, and check for exceptions
			try
			{
				WAD wad = new WAD();

				if (Quiet.quiet > 2)
					Console.Write("Loading file...");

				wad.LoadFile(input);

				if (Quiet.quiet > 2)
					Console.Write("Done!\n");

				if (Quiet.quiet > 2)
					Console.Write("Unpacking WAD...");

				wad.Unpack(output, cid);

				if (Quiet.quiet > 2)
					Console.Write("Done!\n");

				if (Quiet.quiet > 1)
					Console.WriteLine("Operation completed succesfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("An unknown error occured, please try again");
				Console.WriteLine("");
				Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
				return;
			}
		}

		public static void WAD_help()
		{
			Console.WriteLine("");
			Console.WriteLine("Sharpii {0} - WAD - A tool by person66, using libWiiSharp.dll by leathl", Version.version);
			Console.WriteLine("This version stripped down by spotlightishere for usage with the RiiConnect24");
			Console.WriteLine("IOS Patcher.");
			Console.WriteLine("");
			Console.WriteLine("  Usage:");
			Console.WriteLine("");
			Console.WriteLine("       Sharpii.exe WAD [-p | -u] input output [arguments]");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("  Arguments:");
			Console.WriteLine("");
			Console.WriteLine("       input          The input file/folder");
			Console.WriteLine("       output         The output file/folder");
			Console.WriteLine("       -p             Pack WAD");
			Console.WriteLine("       -u             Unpack WAD");
		}
	}
}