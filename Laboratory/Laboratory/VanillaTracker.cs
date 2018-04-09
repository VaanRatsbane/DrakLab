using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
    class VanillaTracker
    {
        string VANILLAFILESFOLDER = $"\\{Program.fileSystem.systemName}_mods\\_vanilla\\";
        string VANILLATRACKER = $"\\{Program.fileSystem.systemName}_mods\\vanilla.json";
        Dictionary<string, int> fileUsages;

        public VanillaTracker()
        {
            try
            {
                if (!Directory.Exists(Program.reader.mBigFileFolder + VANILLAFILESFOLDER))
                    Directory.CreateDirectory(Program.reader.mBigFileFolder + VANILLAFILESFOLDER);

                var json = File.ReadAllText(Program.reader.mBigFileFolder + VANILLATRACKER);
                fileUsages = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            }
            catch(Exception)
            {
                fileUsages = new Dictionary<string, int>();
            }
        }

        public void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(fileUsages, Formatting.Indented);
                File.WriteAllText(Program.reader.mBigFileFolder + VANILLATRACKER, json);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Couldn't save vanilla file settings!\n{e.ToString()}");
            }
        }

        public void ModEnabled(Mod mod)
        {
            foreach (var file in mod.GetVirtualFiles())
            {
                if (!fileUsages.ContainsKey(file))
                {
                    fileUsages[file] = 1;
                }
                else
                    fileUsages[file]++;
            }
        }

        public void ModDisabled(Mod mod)
        {
            foreach (var file in mod.GetVirtualFiles())
            {
                if (fileUsages.ContainsKey(file))
                {
                    fileUsages[file]--;
                    if (fileUsages[file] == 0)
                    {
                        fileUsages.Remove(file);
                    }
                }
            }
        }

        public void Extract(ModFile[] scaffold, string tempFolder, out int backed, out int reverted)
        {
            var currentFiles = ModManager.GetAllFiles(Program.reader.mBigFileFolder + VANILLAFILESFOLDER);
            var virtualFiles = new List<string>();

            foreach (var file in currentFiles)
                virtualFiles.Add(file.Replace(Program.reader.mBigFileFolder + VANILLAFILESFOLDER, "").Replace('\\', '/'));

            var toExtract = new List<string>();
            var toKeep = new List<string>();

            foreach (var modFile in scaffold)
            {
                if (virtualFiles.Contains(modFile.virtualPath))
                    toKeep.Add(modFile.virtualPath);
                else
                    toExtract.Add(modFile.virtualPath);
            }

            var toDelete = virtualFiles.Except(toKeep);

            if (toDelete.Count() > 0)
            {
                foreach (var toDel in toDelete)
                {
                    var filePath = VANILLAFILESFOLDER + "\\" + toDel.Replace('/', '\\');
                    var newPath = tempFolder + "\\" + toDel.Replace('/', '\\');
                    var folders = Path.GetDirectoryName(newPath);
                    Directory.CreateDirectory(folders);
                    File.Copy(filePath, newPath);
                    File.Delete(filePath);
                }
            }

            reverted = toDelete.Count();
            backed = 0;
            foreach(var toEx in toExtract)
            {
                var path = VANILLAFILESFOLDER + "\\" + toEx.Replace('/', '\\');

                var dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                Program.reader.ExtractFileContents(toEx, path);
                backed++;
            }
            
        }

    }
}
