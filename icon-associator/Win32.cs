using System;
using System.Runtime.InteropServices;

namespace icon_associator
{
	internal struct Win32
	{
		[DllImport("shell32.dll")]
		private static extern void SHChangeNotify(HChangeNotifyEventID wEventId, HChangeNotifyFlags uFlags, IntPtr dwItem1, IntPtr dwItem2);

		[Flags]
		private enum HChangeNotifyEventID
		{
			SHCNE_ALLEVENTS = 0x7FFFFFFF,
			SHCNE_ASSOCCHANGED = 0x08000000,
			SHCNE_ATTRIBUTES = 0x00000800,
			SHCNE_CREATE = 0x00000002,
			SHCNE_DELETE = 0x00000004,
			SHCNE_DRIVEADD = 0x00000100,
			SHCNE_DRIVEADDGUI = 0x00010000,
			SHCNE_DRIVEREMOVED = 0x00000080,
			SHCNE_EXTENDED_EVENT = 0x04000000,
			SHCNE_FREESPACE = 0x00040000,
			SHCNE_MEDIAINSERTED = 0x00000020,
			SHCNE_MEDIAREMOVED = 0x00000040,
			SHCNE_MKDIR = 0x00000008,
			SHCNE_NETSHARE = 0x00000200,
			SHCNE_NETUNSHARE = 0x00000400,
			SHCNE_RENAMEFOLDER = 0x00020000,
			SHCNE_RENAMEITEM = 0x00000001,
			SHCNE_RMDIR = 0x00000010,
			SHCNE_SERVERDISCONNECT = 0x00004000,
			SHCNE_UPDATEDIR = 0x00001000,
			SHCNE_UPDATEIMAGE = 0x00008000
		}

		[Flags]
		private enum HChangeNotifyFlags
		{
			SHCNF_NONE = 0,
			SHCNF_DWORD = 0x0003,
			SHCNF_IDLIST = 0x0000,
			SHCNF_PATHA = 0x0001,
			SHCNF_PATHW = 0x0005,
			SHCNF_PRINTERA = 0x0002,
			SHCNF_PRINTERW = 0x0006,
			SHCNF_FLUSH = 0x1000,
			SHCNF_FLUSHNOWAIT = 0x2000
		}

		public static void UpdateAssociations() => SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_NONE, IntPtr.Zero, IntPtr.Zero);
	}
}
