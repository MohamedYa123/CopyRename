using Shell32;
using System.Globalization;

namespace Automated_Phone_Copying_charging_renaming
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //MessageBox.Show("Hello, the app started 09547");
            try
            {
                ApplicationConfiguration.Initialize();
                Loadlogs();
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message : "+ex.ToString());
            }
        }
        public static string LogsFilePath = "Logs.csv";
        public static List<log>logs=new List<log>();
        public static void Loadlogs()
        {
            logs.Clear();
            if(!File.Exists(LogsFilePath))
            {
                File.WriteAllText(LogsFilePath, $@"Date;SF;DF1;DF2;Settings");
            }
            var f = File.ReadAllText(LogsFilePath).Split("~New log~");
            int lineid = 0;
            foreach(var line in f)
            {
                if(lineid == 0)
                {
                    lineid++;
                    continue;
                }
                var ln = line.Replace(",", ";");
                var s = line.Split(';');
                var date = DateTime.Parse(s[0], new CultureInfo("us-US"));
                var SF = s[1];
                var DF1 = s[2];
                var DF2 = s[3];
                var Settings = s[4];
                log log=new log { date = date, SF = SF, DF1 = DF1, DF2 = DF2, Settings = Settings };
                logs.Add(log);
                lineid++;
            }
        }
    }
    public struct log
    {
        public DateTime date;
        public string SF;
        public string DF1;
        public string DF2;
        public string Settings;
        public void Saveme()
        {
            var f = File.ReadAllText(Program.LogsFilePath);
            f += $"~New log~\r\n{date.ToString(new CultureInfo("us-US"))};{SF};{DF1};{DF2};{Settings}";
            File.WriteAllText(Program.LogsFilePath, f);
        }
    }
    public struct file_toselect
    {
        public string name;
        public FolderItem File;
        public Folder Folder;
        public string FolderPath;
        public string FilePath;
        public selectfiles.Filetype filetype;
        public string Foldername;
    }
}