using IronPython.Modules;
using IronPython.Runtime.Operations;
using Microsoft.VisualBasic;
using Shell32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Automated_Phone_Copying_charging_renaming.Shell33;
//using static Community.CsharpSqlite.Sqlite3;
//using System.Windows.Shapes;

namespace Automated_Phone_Copying_charging_renaming
{
    public struct Fileprops
    {
        public string name;
        public DateTime createddate;
        public long size;
        public override string ToString()
        {
            return $"File: {name} , Created Date: {createddate} , Size: {size}";
        }
    }
    public static class details
    {
        static DateTime GetDate(int h,Folder objFolder,FolderItem item)
        {
            string l = objFolder.GetDetailsOf(item, h);
            if (!string.IsNullOrEmpty(l))
            {
                string asAscii = Encoding.ASCII.GetString(
                    Encoding.Convert(
                        Encoding.UTF8,
                        Encoding.GetEncoding(
                            Encoding.ASCII.EncodingName,
                            new EncoderReplacementFallback(string.Empty),
                            new DecoderExceptionFallback()),
                        Encoding.UTF8.GetBytes(l)
                        )
                    );
                try
                {
                  
                    var dt = Convert.ToDateTime(asAscii);
                    return dt;
                  }
                catch { }
            }
            return DateTime.MinValue;
        }
        public static DateTime modifieddate(FolderItem item,Folder f)
        {
            return GetDate(3, f, item);
        }
        public static DateTime Createddate(FolderItem item, Folder f)
        {
            var x= GetDate(4, f, item);
            if (x == DateTime.MinValue)
            {
                return modifieddate(item, f);
            }
            return x;
        }
    }
    public class Manager
    {
        #region
        public Manager(string SF, string DF1, string DF2, string CN, string T1,string AN,string L1) {
            this.SF = SF;
            this.DF1 = DF1;
            this.DF2 = DF2;
            this.CN = CN;
            this.T1 = T1;
            this.AN = AN;
            this.L1 = L1;
        }
        #endregion
        #region Fields
        
        public string SF = "";
        private string DF1 = "";
        private string DF2 = "";
        private string CN = "";
        private string T1 = "";
        private string AN = "";
        private string L1 = "";
        #endregion
        #region props
        private string quickreport = "";
        public string QuickReport { get { return quickreport; } }
        private string detailedreport = "";
        public string DetailedReport { get { return detailedreport; } }
        List<string> detailslist = new List<string>();
        public List<string> DetailedReportList { get { return detailslist; } }
        private double progress;
        public string DirectoriesinDF1formula { get; set; } = "^yyMMdd^";//%DirName%
        public string DirectoriesinDF2formula { get; set; } = "^yyMMdd^";//%DirName%
        public string DF1Filesformula { get; set; } = "%NAME%.%EXTENSION%";
        public string DF2Filesformula { get; set; } = "%T1%?T1?'_'%AN%?AN?'_'%L1%?L1?'_'%CN%_^yyMMdd^_%NAME%.%EXTENSION%";
        public bool selectfilesbycreationdate { get; set; }=false;
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public bool copytodf1 { get; set; }=true;
        public bool copytodf2 { get; set; }=true;
        public string TranslateFormula(string formula,string DirName,string Name,string Extension,DateTime dateTime)
        {
            var formula2 = formula.ToUpper().Replace("%DIRNAME%",DirName).Replace("%NAME%", Name).Replace("%EXTENSION%", Extension).
                Replace("%L1%", L1).Replace("%AN%",AN).Replace("%T1%",T1)
                .Replace("%CN%",CN);
            //?AN?'-'
            Regex regex = new Regex(@"\?[^\?]*\?'[^']*'");
            var k=regex.Match(formula2);
            foreach(Match a in regex.Matches(formula))
            {
                var mtch = a.Value;
                var mtch2=new Regex(@"\?.+\?").Match(mtch).Value.Replace("?","");
                mtch = mtch.Replace("?"+mtch2+"?","").Replace("'", "");
                mtch2 = mtch2.Replace("AN", AN).Replace("L1", L1).Replace("T1", T1).Replace("CN", CN);
                if(mtch2.Length > 0)
                {
                    formula2=formula2.Replace(a.Value.ToUpper(), mtch);
                }
                else
                {
                    formula2 = formula2.Replace(a.Value.ToUpper(), "");
                }
            }
            regex = new Regex(@"\^.+\^");
            var rs = regex.Match(formula).Value;
            var sr = regex.Match(formula).Value.Replace("^","");
            var dt = dateTime.ToString(sr);
            formula2 = formula2.Replace("^" + sr.ToUpper() + "^", dt);
            return formula2;
        }
        /// <summary>
        /// indicates how much progress was made
        /// </summary>
        public int Progress { get { return (int)(progress * 100); } }
        #endregion
        #region fields used for calculations 
        double totalsize;
        double copiedsize;
        int filesfound;
        #endregion
        #region Sub functions
        #region phone
        List<FolderItem> list = new List<FolderItem>();
        List<Fileprops>props = new List<Fileprops>();
        List<Folder> list2 = new List<Folder>();
        List<string>listpathes=new List<string>();
        double tempsize = 0;
        Shell32.Shell shell = new Shell32.Shell();
        Folder destinationFolder;
        public bool Process_selected_files = false;
        public Dictionary<FolderItem, file_toselect> files = new Dictionary<FolderItem, file_toselect>();
        void load()
        {
            shell = new Shell32.Shell();
            
            destinationFolder = shell.NameSpace(DF1);
        }
        void loadfromdictionary()
        {
            list.Clear();
            foreach(var file in files)
            {
                list.Add(file.Value.File);
                list2.Add(file.Value.Folder);
                listpathes.Add(file.Value.FolderPath);
            }
        }
        /// <summary>
        /// used to loop all the sub folders in the phone folder
        /// </summary>
        /// <returns></returns>
        /// 
        IEnumerable<FileInfo> getfileswithphone()
        {
            load();
            //int i = 0;
            list.Clear();
            if (!Process_selected_files)
            {

                Folder dir = shell.NameSpace(SF);
                loadfolderPhone(dir, shell, list, list2);
            }
            else
            {
                loadfromdictionary();
            }
            //now let's copy the files to DF1
            totalsize= list.Count;
            copiedsize = 0;
            
            List<string> filenames = new List<string>();
            filesfound = 0;
            int ic= 0;
            fromdate= new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0);// Convert.ToDateTime(fromdate.ToString("MM/dd/yyyy 12:00:00 A\\M"));
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59);// Convert.ToDateTime(fromdate.ToString("MM/dd/yyyy 12:00:00 A\\M"));
            //todate = Convert.ToDateTime(todate.ToString("MM/dd/yyyy 11:59:59 P\\M"));
            int hfd = -1;
            foreach (var a in list)
            {
                var cd= details.Createddate(a, list2[ic]);
                hfd++;
                if (selectfilesbycreationdate)
                {
                    if (cd <= fromdate || cd >= todate)
                    {
                        continue;
                    }
                }
                Fileprops f=new Fileprops { createddate = cd,name=a.Name};
                props.Add(f);
                copy(a.Name,a,filenames,hfd);
                addcopiedstorage(1, 0.5);
                filesfound++;
                flagquickreport("Scanning for files in Source Folder (or selected files) " + filesfound +" out of "+totalsize);
                ic++;
            }
            totalsize = 0;
            copiedsize = 0;
            foreach (var file in filenames)
            {
                var c = new FileInfo(file);
                
                yield return new FileInfo(file);
                filesfound++;
            }
            isdone = true;
        }
        List<int>faileditems = new List<int>();
        Random random = new Random();
        public  void copy(string fname, FolderItem curr,List<string> filenames,int hh)
        {
            string df = DF1;
            if (!copytodf1)
            {
                df = DF2;
            }
            string distination = df+"\\"+fname;
            if (File.Exists(distination))
            {
                var c = random.Next(int.MaxValue / 2, int.MaxValue)+""+ random.Next(int.MaxValue / 2, int.MaxValue) ;
                
                copy(c, curr, filenames,hh);
                c = df + "\\" + c;
                if (new System.IO.FileInfo(c).Length!= new System.IO.FileInfo(distination).Length)
                {
                    flagdetailedreport($"Different files detected with the same name {fname} on phone and {distination}");
                    try
                    {
                        string getrandom()
                        {
                            string all = "ABDEFGHIJKLMNOBQRSTUVWXYZ1234567890";
                            string ans = "";
                            for(int i=0;i<4;i++)
                            { 
                                int y=random.Next(0,all.Length);
                                ans += all[y];
                            }
                            return ans;
                        }
                        var s = fname.Split(".");
                        var rdd= "_C" + getrandom();
                        string n2 = fname + rdd ;
                        if (s.Length > 1)
                        {
                            n2= s[0]+ rdd+"." + s[1];
                        }
                        distination = df +"\\"+ n2;
                        File.Move(c, distination);
                        filenames[hh] = distination;
                        flagdetailedreport("The file was renamed to " + distination);
                    }
                    catch(Exception ex)
                    {
                        flagerror(ex);
                    }
                }
                else
                {
                    try
                    {
                        File.Delete(c);
                    }
                    catch(Exception ex)
                    {
                        flagerror(ex);
                    }
                }
                return;
            }
            if (!File.Exists(distination))
            {
                bool idone=false;

                //solution for multiple disconnections ridiculous !
                Thread thread = new Thread(new ThreadStart(() => { 
                    try {
                        List<FolderItem>list2=new List<FolderItem>();
                        List<Folder>list3=new List<Folder>();
                        //load();
                        Shell32.Shell shell = new Shell32.Shell();
                        Folder dir = null;
                        if (!Process_selected_files)
                        {
                             dir = shell.NameSpace(SF);
                        }
                        else
                        {
                            dir = shell.NameSpace(this.listpathes[hh]);
                        }
                        var dist = shell.NameSpace(df);
                        loadfolderPhone(dir, shell, list2,list3);
                        FolderItem curr2 = null;
                        if (!Process_selected_files)
                        {
                             curr2 = list2[hh];
                        }
                        else
                        {
                            foreach(var a in list2)
                            {
                                if (a.Path == curr.Path)
                                {
                                    curr2=a; break;
                                }
                            }
                        }
                        //curr2.Name = fname;
                        if (curr2.Name != fname)
                        {
                            var gg = df +"\\"+fname.Split(".")[0]+"Folder";
                            Directory.CreateDirectory(gg);
                            dist= shell.NameSpace(gg);
                            dist.CopyHere(curr2, 0);
                            File.Move(gg + "\\" + curr2.Name, df + "\\"+ fname);
                            Directory.Delete(gg);   
                        }
                        else
                        {
                            dist.CopyHere(curr2, 0);
                        }
                         }
                    catch (Exception ex)
                    {
                    }
                    idone = true; }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                //Process.Start(distination); 
                while (!idone)
                {
                    if (SF!=""&&shell.NameSpace(SF) == null)
                    {
                        thread.Interrupt();
                        break;
                    }
                        Thread.Sleep(1);
                }
                //destinationFolder.CopyHere(curr, 0);
                if (!File.Exists(distination))
                {
                    faileditems.Add(hh);
                    flagdetailedreport($"failed to copy file {fname} to {distination} during SF process...");
                    if (SF==""||shell.NameSpace(SF) == null)
                    {
                        flagdetailedreport("Phone disconnected !");
                        flagdetailedreport("retrying to connect ...");
                        int retries = 1;
                        while (true)
                        {
                            flagquickreport("Retrying to connect attempt : " + retries);
                            if (shell.NameSpace(SF) != null)
                            {
                                break;
                            }
                                Thread.Sleep(3000);
                            retries++;
                        }
                        flagdetailedreport("phone is connected :)");
                        flagdetailedreport("Recopying failed files");
                        Thread.Sleep(3000);
                        load();
                        for(int i = 0; i < faileditems.Count; i++)
                        {
                            
                            var cr = list[faileditems[i]];
                            string distination2 = df + "\\" + cr.Name;
                            if (File.Exists(distination2))
                            {
                                File.Delete(distination2);
                            }
                            copy(cr.Name, cr, filenames, faileditems[i]);
                        }
                     //   throw new Exception("Phone disconnected !");
                    }
                }
                else
                {
                    bool True = true;
                    var fsize =new System.IO.FileInfo(distination).Length;
                    byte[] fbytes = new byte[1];
                    for (int i = 0; i < filenames.Count; i++)
                    {
                        var fsize2= new System.IO.FileInfo(filenames[i]).Length;
                        if (fsize == fsize2)
                        {
                            if (fbytes.Length == 1)
                            {
                                fbytes = File.ReadAllBytes(distination);
                            }
                            var fbytes2=File.ReadAllBytes(filenames[i]);
                            for(int u = 0; u < fbytes.Length; u++)
                            {
                                if (fbytes[u] != fbytes2[u])
                                {
                                    True = false;
                                    break;
                                }
                            }
                        }
                        if (!True)
                        {
                            flagquickreport("File duplicated by content !");
                            flagdetailedreport("File duplicated by content !");
                            break;
                        }
                    }
                    if (True)
                    {
                        filenames.Add(distination);
                    }
                }
               
            }
            //filenames.Add(distination);
        }
        
        void loadfolderPhone(Folder dir, Shell32.Shell shell,List<FolderItem>list, List<Folder> list2)
        {
            foreach (FolderItem curr in dir.Items())
            {
                string nm=curr.Name;
                if (!curr.IsFolder)
                {

                    list.Add(curr);
                    list2.Add(dir);
                }
                else
                {
                    var folder = shell.NameSpace(curr.Path);
                    
                    loadfolderPhone(folder, shell,list,list2);
                }
            }
        }
        #endregion
        /// <summary>
        /// used to loop over all sub folders
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<FileInfo> EnumerateFilesRecursively(string path,bool first)
        {
            if (itsphone||true)
            {
                foreach (var a in getfileswithphone())
                {
                    yield return a;
                }
            }
            else
            {
                if (first)
                {
                    filesfound = 0;
                }
                foreach (var file in Directory.EnumerateFiles(path))
                {
                    yield return new FileInfo(file);
                    filesfound++;
                }

                foreach (var directory in Directory.EnumerateDirectories(path))
                {
                    foreach (var file in EnumerateFilesRecursively(directory, false))
                    {
                        yield return file;
                        filesfound++;
                    }
                }
                if (first)
                {
                    isdone = true;
                }
            }
        }
        string getformat(DateTime createddate)
        {
            string format = $"{createddate.ToString("yyMMdd")}";
            return format;
        }
        void flagquickreport(string msg)
        {
            quickreport = msg;
        }
        List<string>lastms = new List<string>();
        void flagdetailedreport(string msg)
        {
            var cc = lastms.Count - lastms.IndexOf(msg);
           
            if (!(lastms.Contains(msg)&&lastms.Count-lastms.IndexOf(msg)<2))
            {
                string s = "\r\n";
                if (lastms.Count == 0)
                {
                    s = "";
                }
                var msg2 = $"{s} [{DateTime.Now:HH:mm:ss:FF}] " + msg;
                detailedreport += msg2;
                detailslist.Add(msg2);
                lastms.Add(msg);
            }
        }
        void flagerror(Exception ex)
        {
            //flagquickreport($"Error ! {ex.Message}");
            flagdetailedreport($"An error occured, Message : {ex.Message} ! ");
        }
        void addcopiedstorage(long size, double factor)
        {
            if (!copytodf1 || !copytodf2)
            {
                factor = 1;
            }
            copiedsize += size;
            if (progress < factor)
            {
                progress = copiedsize / totalsize * factor;
            }
            else
            {
                progress = copiedsize / totalsize * factor + factor;
            }
        }
        string getnewnameforDF2(Fileprops fs)
        {
            
            string fileNamePlusExtension = System.IO.Path.GetFileName(fs.name);
            string name = "";
            string extension = "";
            var sp= fileNamePlusExtension.Split('.');
            if (sp.Length > 1)
            {
                name = sp[0];
                extension = sp[1];
            }
            else
            {
                name = sp[0];
            }
            string sT1 = T1 + "_";
            string sAN = AN + "_";
            string sL1 = L1 + "_";
            if (T1 == "")
            {
                sT1 = "";
            }
            if (AN == "")
            {
                sAN = "";
            }
            if (L1 == "")
            {
                sL1 = "";
            }
            //%T1%?T1?'_'%AN%?AN?'_'%L1%?L1?'_'%CN%_^yyMMdd^_%NAME%.%EXTENSION%
            string plus = $"{sT1}{sAN}{sL1}{CN}_{fs.createddate:yyMMdd}_";//T1_AN_L1_CN_YYMMDD
           // string ans = plus+fileNamePlusExtension;
            string ans = TranslateFormula(DF2Filesformula, "", name, extension, fs.createddate);
            var dtformat = getformat(fs.createddate);
            return DF2 + "\\"+dtformat+"\\" + ans;
        }
        #endregion
        #region main functions
        /// <summary>
        /// used to scan the SF directory for all files and store them in a list
        /// </summary>
        /// <returns></returns>
        bool itsphone = false;
        bool isdone = false;
        List<Fileprops> scanSF()
         {
            if (SF.Contains("{"))
            {
                itsphone=true;
            }
            List<Fileprops> fileprops = new List<Fileprops>();
            // loop over the files in the SF folder
            //var files= Directory.EnumerateFiles(SF);
            IEnumerable<FileInfo> files=null;
            isdone = false;
            if (itsphone)
            {
                flagdetailedreport("Phone detected or Processing custom files is selcted, Files will be copied first to DF1 to retrieve their properties ...");
            }
            Task.Run(() =>
            {
                files = EnumerateFilesRecursively(SF, true);
                isdone = true;
            });
            flagquickreport("Scanning for files in SF ...");
            flagdetailedreport("starting scanning files in SF ...");
           
            Stopwatch sp = Stopwatch.StartNew();
            long last = sp.ElapsedMilliseconds;
            int h = 0;
            while (!isdone)
            {
                long lps = sp.ElapsedMilliseconds;
                string found = $" Found files {filesfound}4.";
                if (lps - last > 100)
                {
                    last = lps;
                    h++;
                    switch (h % 3)
                    {
                        case 0:
                            flagquickreport("Scanning files in Source Folder " + found);
                            break;
                        case 1:
                            flagquickreport("Scanning files in Source Folder " + found);
                            break;
                        case 2:
                            flagquickreport("Scanning files in Source Folder " + found);
                            break;
                    }
                }
                Thread.Sleep(1);
            }
            string found2 = $" Found files {filesfound}";
            flagquickreport("scanning for files in Source folder ..." + found2);
            int y = 0;
            foreach (var file2 in files)
            {
                var file = file2.FullName;
                try
                {
                    //get created date
                    var createddate = File.GetCreationTime(file);
                    if (itsphone)
                    {
                        createddate=File.GetLastWriteTime(file);
                        createddate = props[y].createddate;
                    }
                    //collect file size
                    long size = new System.IO.FileInfo(file).Length;
                    totalsize += size;
                    //store results 
                   
                    Fileprops fs = new Fileprops { createddate = createddate, name = file, size = size };
                    fileprops.Add(fs);
                    File.SetCreationTime(file, createddate);
                }
                catch(Exception ex)
                {
                    flagerror(ex);
                }
                y++;
            }
            sp.Stop();
            flagquickreport($"Scan finished found {fileprops.Count} files");
            flagdetailedreport($"Scan finished found {fileprops.Count} files in {sp.ElapsedMilliseconds/1000.0} seconds");
            return fileprops;
        }
         Dictionary<string, string>  createnewDirectoriesinDF1(List<Fileprops> fileprops)
        {

            flagquickreport("Creating Directories in DF1 and DF2 ...");
            flagdetailedreport("Starting creating Directories in DF1 and DF2 ...");
            //used to store directories that was created for each date instead of regenerating their name again
            Dictionary<string,string>directoriestostroeinDF1 = new Dictionary<string,string>();
            Dictionary<string,string>directoriestostroeinDF2 = new Dictionary<string,string>();
            for(int i=0;i<fileprops.Count;i++)
            {
                try
                {
                    var fs = fileprops[i];
                    //preparing directory name
                    var dtformat = TranslateFormula(DirectoriesinDF1formula,"","","",fs.createddate);// getformat(fs.createddate);
                    var dtformat2 = TranslateFormula(DirectoriesinDF2formula,"","","",fs.createddate);// getformat(fs.createddate);

                    var foldername = $"{DF1}\\" + dtformat;
                    var foldername2 = $"{DF2}\\" + dtformat2;
                    bool exists = false;
                    if (copytodf1)
                    {
                        if (directoriestostroeinDF1.ContainsKey(dtformat))
                        {
                            exists = true;
                        }
                        //DF1
                        //checking if it exists
                        if (exists || Directory.Exists(foldername))
                        {
                            flagdetailedreport($"Directory already exists {foldername}");
                            flagquickreport($"Directory already exists {foldername}");
                        }
                        else
                        {
                            Directory.CreateDirectory(foldername);
                            flagdetailedreport($"Directory created {foldername}");
                            flagquickreport("Creating Directories in DF1 and DF2 ...");
                        }
                    }
                    //
                    //DF2
                    if (directoriestostroeinDF2.ContainsKey(dtformat))
                    {
                        exists = true;
                    }
                    //checking if it exists
                    if (copytodf2)
                    {
                        if (exists || Directory.Exists(foldername2))
                        {
                            flagdetailedreport($"Directory already exists {foldername2}");
                            flagquickreport($"Directory already exists {foldername2}");
                        }
                        else
                        {
                            Directory.CreateDirectory(foldername2);
                            flagdetailedreport($"Directory created {foldername2}");
                            flagquickreport("Creating Directories in DF1 and DF2 ...");
                        }
                    }
                    //
                    //creating cn folder ##
                    if (copytodf1)
                    {
                        var folderCN = foldername + $"\\{CN}";
                        if (exists || Directory.Exists(folderCN))
                        {
                            flagdetailedreport($"Directory already exists {folderCN}");
                            flagquickreport($"Directory already exists {folderCN}");
                        }
                        else
                        {
                            Directory.CreateDirectory(folderCN);
                            flagdetailedreport($"Directory created {folderCN}");
                            flagquickreport("Creating Directories in DF1 and DF2 ...");
                        }
                        directoriestostroeinDF1.TryAdd(dtformat, folderCN);
                    }
                    if (copytodf2)
                    {
                        directoriestostroeinDF2.TryAdd(dtformat, foldername2);
                    }
                }
                catch(Exception ex)
                {
                    flagerror(ex);
                }
            }
            flagquickreport("Creating Directories in DF1 and DF2 is complete !");
            flagdetailedreport($"Creating Directories in DF1 and DF2 is complete , {directoriestostroeinDF1.Count} directories were prepared ");
            return directoriestostroeinDF1;
        }
         List<Fileprops> copyfilestoDF1directory(List<Fileprops> fileprops, Dictionary<string, string> directoriestostroeinDF1)
         {
            //flag quick report that the file copying started ...
            flagquickreport("copying files to DF1 ...");
            flagdetailedreport("Started copying file to DF1 ...");
            //reset copiedsize
            copiedsize = 0;
            Stopwatch sp=Stopwatch.StartNew();
            List<Fileprops> filesinDF1 = new List<Fileprops>();
            Dictionary<string,int> filesinDF1names = new Dictionary<string, int>();
            double totalsz = 0;
            for (int i = 0; i < fileprops.Count; i++)
            {
                try
                {
                    var fs = fileprops[i];
                    //preparing directory name
                    var dtformat = TranslateFormula(DirectoriesinDF1formula,"","","",fs.createddate);// getformat(fs.createddate);
                    var cndirectory = directoriestostroeinDF1[dtformat];

                    string fileNamePlusExtension = System.IO.Path.GetFileName(fs.name);
                    string name = "";
                    string extension = "";
                    var spp= fileNamePlusExtension.Split('.');
                    if (spp.Length > 1)
                    {
                        name = spp[0];
                        extension = spp[1];
                    }
                    else
                    {
                        name = spp[0];
                    }
                    var filenamenew = cndirectory+"\\"+TranslateFormula(DF1Filesformula,"",name,extension,fs.createddate);
                    void add()
                    {
                        Fileprops fs2 = new Fileprops { name = filenamenew, createddate = fs.createddate, size = fs.size };
                        filesinDF1.Add(fs2);
                        addcopiedstorage(fs.size, 0.5);
                        filesinDF1names.Add(filenamenew, 1);
                        totalsz += fs2.size;
                    }
                    if(File.Exists(filenamenew))
                    {
                        
                        if (!filesinDF1names.ContainsKey(filenamenew))
                        {
                            add();
                        }
                        else
                        {
                            addcopiedstorage(fs.size, 0.5);
                        }
                        flagquickreport($"copying files to DF1 , Copied : {i + 1} out of {fileprops.Count} files");
                        throw new Exception($"File already exists at {filenamenew} source {fs.name}");
                    }
                    if (!itsphone)
                    {
                        File.Copy(fs.name, filenamenew);
                    }
                    else
                    {
                        File.Move(fs.name, filenamenew);    
                    }
                    File.SetCreationTime(filenamenew, fs.createddate);
                    add();
                    flagquickreport($"copying files to DF1 , Copied : {i+1} out of {fileprops.Count} files");
                }
                catch(Exception ex)
                {
                    flagerror(ex);
                }
            }
            check1("Check 1 is True Files copied to DF1 are the same as SF");
            Thread.Sleep(500);
            totalsize = totalsz;
            sp.Stop();
            flagquickreport("Done copying files to DF1 ...");
            flagdetailedreport($"Copying Files to DF1 is complete in {sp.ElapsedMilliseconds/1000.0} seconds");
            return filesinDF1;
        }
         /// <summary>
         /// copy files from DF1 to DF2
         /// </summary>
         void copyFilesfromDF1toDF2(List<Fileprops> filesinDF1)
         {
            //loop over all files in DF1
            flagquickreport("Copying files from DF1 to DF2 ...");
            flagdetailedreport("Started copying files from DF1 to DF2");
            Stopwatch sp=Stopwatch.StartNew();
            copiedsize = 0;
            for(int i= 0;i < filesinDF1.Count; i++)
            {
                try
                {
                    var fs = filesinDF1[i];
                    var newfs = getnewnameforDF2(fs);
                    if(File.Exists(newfs))
                    {
                        addcopiedstorage(fs.size, 0.5);
                        flagquickreport($"{i + 1} Files copied from DF1 to DF2 out of {filesinDF1.Count} ...");
                        throw new Exception($"File already exists at {newfs}");
                    }
                    File.Copy(fs.name,newfs);
                    File.SetCreationTime(newfs, fs.createddate);
                    addcopiedstorage(fs.size, 0.5);
                    flagquickreport($"{i + 1} Files copied from DF1 to DF2 out of {filesinDF1.Count} ...");
                }
                catch (Exception ex)
                {
                    flagerror(ex);
                }
            }
            sp.Stop();
            flagquickreport($"Done copying files from DF1 to DF2 !");
            flagdetailedreport($"Copying files from DF1 to DF2 finished in {sp.ElapsedMilliseconds / 1000.0} seconds");

         }
        bool imdone = false;
        //check if files copied to DF1 are the same as the SF
        void check1(string msg)
        {
            msg += $"  {Math.Round(copiedsize/totalsize*100,2)} % Match !";
            if (copiedsize == totalsize)
            {
                flagdetailedreport(msg);
                flagquickreport(msg);
            }
            else
            {
                msg = msg.Replace("True", "False");
                msg = msg.Replace("are", "are not");
                flagerror(new Exception(msg));
            }
        }
        void Doparallelnoerror()
        {
            try
            {
                Stopwatch sp = Stopwatch.StartNew();
                flagquickreport($"Starting ...");
                flagdetailedreport($"Starting ...");
                Thread.Sleep(500);
                if (Process_selected_files)
                {
                    itsphone= true;
                }
                var fileprops = scanSF();
                Thread.Sleep(500);
                var directoriestostroeinDF1 = createnewDirectoriesinDF1(fileprops);
                var fs = fileprops;
                if (copytodf1)
                {
                    Thread.Sleep(500);
                    var filesinDF1 = copyfilestoDF1directory(fileprops, directoriestostroeinDF1);
                    fs= filesinDF1;
                }
                if (copytodf2)
                {
                    Thread.Sleep(500);
                    copyFilesfromDF1toDF2(fs);
                    Thread.Sleep(500);
                    check1("Check 2 is True Files copied to DF2 are the same as DF1");
                }
                Thread.Sleep(1000);
                sp.Stop();
                //final report ##
                flagquickreport($"All tasks completed took time {sp.ElapsedMilliseconds / 1000.0} seconds");
                flagdetailedreport($"All tasks completed took time {sp.ElapsedMilliseconds / 1000.0} seconds");
            }
            catch (Exception ex)
            {
                imdone = true;
                flagerror(ex);
            }
            imdone = true;
        }
        #endregion
        public Thread thread=null;
        #region
        /// <summary>
        /// The main function which calls all other functions
        /// </summary>
        public async  Task DoTheJob()
        {
            //await Task.Run(() => 
            //{
             thread = new Thread(new ThreadStart(()=>Doparallelnoerror()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            await Task.Run(() =>
            {
                while (!imdone)
                {
                    Thread.Sleep(100);
                }
            });
            //}
            //);

        }
        #endregion
    }
}
