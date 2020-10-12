using ArcAuthentication.Security;
using System.Net.Http;

namespace ArcAuthentication
{
    public static class Global
    {
        public static string UserAgent { get; } = @"ArcConfigViewer/1.0 (Platform WindowsNT/10.0)";
        public static string Gateway { get; set; } = @"192.168.0.1";
        public static string Origin { get; } = $@"http://{Gateway}";
        public static string LoginCgi { get; } = $@"{Origin}/login.cgi";
        public static string LoginHtm { get; } = $@"{Origin}/login.htm";
        public static string IndexHtm { get; } = $@"{Origin}/index.htm";
        public static string HomeHtm { get; } = $@"{Origin}/home.htm";
        public static string SystemLogHtm { get; } = $@"{Origin}/diagnostics_logviewer.htm?m=adv";
        public static string DevicesHtm { get; } = $@"{Origin}/owl_lan_device.htm?m=adv";
        public static string BackupHtm { get; } = $@"{Origin}/sys_backup.htm?m=adv";
        public static string CallLogHtm { get; } = $@"{Origin}/mmpbx_book.htm?m=adv";
        public static ArcToken InitToken { get; set; } = null;
        public static HttpClient GlobalClient { get; set; } = null;
    }
}