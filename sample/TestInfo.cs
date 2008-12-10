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
			fileinfo = file.QueryInfo ("time::*",FileQueryInfoFlags.None, null);
			ulong time =fileinfo.GetAttributeULong ("time::changed");
			Console.WriteLine (Mono.Unix.Native.NativeConvert.ToDateTime ((long)time));
			time =fileinfo.GetAttributeULong ("time::created");
			Console.WriteLine (Mono.Unix.Native.NativeConvert.ToDateTime ((long)time));
			time =fileinfo.GetAttributeULong ("time::accessed");
			Console.WriteLine (Mono.Unix.Native.NativeConvert.ToDateTime ((long)time));
			Console.WriteLine (fileinfo.HasAttribute ("time::changed"));
		}
	}
}
