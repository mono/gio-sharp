using GLib;
using System;

namespace TestGio
{
	public class TestDirectory
	{
		static void Main (string[] args)
		{
			if (args.Length != 1) {
				Console.WriteLine ("Usage: TestDirectory <uri>");
				return;
			}

			Gtk.Application.Init ();
			File dir = FileFactory.NewForUri (args[0]);
			foreach (FileInfo info in dir.EnumerateChildren ("*", FileQueryInfoFlags.None, null)) {
				Console.WriteLine (info.Name);
			}
		}
	}
}
