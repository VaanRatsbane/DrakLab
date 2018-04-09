using Laboratory.VBFTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
    static class Program
    {

        public static VirtuosBigFileReader reader;
        public static VFileSystem fileSystem;
        public static ModManager manager;
        public static Queue<string> consoleLog;
        public static List<string> injectionLog;

        public static Settings settings;

        const int LOGSIZE = 50;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            consoleLog = new Queue<string>(LOGSIZE);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Lab());
        }

        public static void Log(string message)
        {
            if (consoleLog.Count == LOGSIZE)
                consoleLog.Dequeue();
            consoleLog.Enqueue(message);
            if (reader != null && settings != null && settings.saveLog)
                File.AppendAllText($"{reader.mBigFileFolder}\\log.txt", $"{message}\n");
        }

        public static void InjectionLog(List<string> list)
        {
            if (reader != null && settings != null && settings.saveLog)
                File.AppendAllLines($"{reader.mBigFileFolder}\\log.txt", list);
            injectionLog = list;
        }

        public static bool LoadVBF(string path)
        {
            reader = new VirtuosBigFileReader();
            try
            {
                reader.LoadBigFileFile(path);
                fileSystem = new VFileSystem(path.Split('/').Last(), reader);
                return true;
            }
            catch (Exception e)
            {
                fileSystem = null;
                Log(e.ToString());
                return false;
            }
        }

    }
}
