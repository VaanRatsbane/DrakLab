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

        public VanillaTracker()
        {
            try
            {
                if (!Directory.Exists(Program.reader.mBigFileFolder + VANILLAFILESFOLDER))
                    Directory.CreateDirectory(Program.reader.mBigFileFolder + VANILLAFILESFOLDER);
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to create vanilla files folder.");
                throw e;
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
                    var filePath = Program.reader.mBigFileFolder + VANILLAFILESFOLDER + "\\" + toDel.Replace('/', '\\');
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
                var path = Program.reader.mBigFileFolder + VANILLAFILESFOLDER + toEx.Replace('/', '\\');

                var dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                Program.reader.ExtractFileContents(toEx, path);
                backed++;
            }
            
        }

    }
}
