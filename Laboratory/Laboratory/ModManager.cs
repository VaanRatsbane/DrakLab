using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Laboratory
{
    class ModManager
    {
        const string MODFOLDER = "mods\\";
        const string VANILLAFILESFOLDER = "mods\\_vanilla\\";
        const string MANAGERSETTINGS = "mods\\modsettings.json";
        const string LOADEDMODS = "mods\\loaded.json";

        List<Mod> mods;

        public ModManager()
        {
            try
            {
                var json = File.ReadAllText(LOADEDMODS);
                mods = JsonConvert.DeserializeObject<List<Mod>>(json);
            }
            catch(Exception)
            {
                mods = new List<Mod>();
            }
        }

        public void Destroy()
        {
            try
            {
                var json = JsonConvert.SerializeObject(mods, Formatting.Indented);
                File.WriteAllText(LOADEDMODS, json);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Couldn't save mod settings!\n{e.ToString()}");
            }
        }

        public void AddMod(string sourceFolder)
        {
            //TODO validate if valid mod
            var fullModPath = Path.GetDirectoryName(MODFOLDER);
            var frags = sourceFolder.Split('\\');
            var prefix = String.Join("\\", frags, 0, frags.Length - 1);
            var modFolder = fullModPath + "\\" + frags.Last();
            if (prefix != fullModPath)
                DirectoryCopy(sourceFolder, modFolder, true);
            //TODO return true if success to update gui
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

    }
}
