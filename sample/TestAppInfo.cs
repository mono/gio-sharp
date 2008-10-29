using GLib;
using System;

namespace TestGio
{
	public class TestAppInfo
	{
		static void Main (string[] args)
		{
			if (args.Length != 1) {
				Console.WriteLine ("Usage: TestAppInfo mimetype");
				return;
			}

			Gtk.Application.Init ();
			Console.WriteLine ("Default Handler for {0}: {1}", args[0], AppInfoAdapter.GetDefaultForType (args[0], false).Name);
			Console.WriteLine();
			Console.WriteLine("List of all {0} handlers", args[0]);
			foreach (AppInfo appinfo in AppInfoAdapter.GetAllForType (args[0]))
				Console.WriteLine ("\t{0}: {1} ", appinfo.Name, appinfo.Executable);

		//	Console.WriteLine ("All installed AppInfos:");
		//	foreach (AppInfo appinfo in AppInfoAdapter.All)
		//		Console.WriteLine ("\t{0}: {1} ", appinfo.Name, appinfo.Executable);
		}
	}
}
