using GLib;
using System;
using System.Text;

namespace TestGio {
	public class TestInfo {
		static void Main (string[] args)
		{
			if (args.Length != 1) {
				Console.WriteLine ("Usage: TestInfo <uri>");
				return;
			}
		
			Gtk.Application.Init ();

			File file = FileFactory.NewForUri (args[0]);
			FileInfo fileinfo = file.QueryInfo ("*",FileQueryInfoFlags.None, null);
			Console.WriteLine (fileinfo.Name);
			Console.WriteLine (fileinfo.EditName);
			Console.WriteLine (fileinfo.ContentType);
			Console.WriteLine (fileinfo.Size);
			Console.WriteLine (fileinfo.IsHidden);
			Console.WriteLine (fileinfo.IsSymlink);
		}
	}
}
