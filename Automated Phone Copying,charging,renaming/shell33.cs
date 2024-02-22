    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Runtime.InteropServices;
using Shell32;

    namespace Automated_Phone_Copying_charging_renaming
    {

        public class Shell33
        {
            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbSizeFileInfo, int dwFlags);

           
        }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public int dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
        public long ftCreationTime, ftLastAccessTime, ftLastWriteTime;
        public int cbSizeFileInfo;
        public int dwFileAttributes;
    }
   
}
