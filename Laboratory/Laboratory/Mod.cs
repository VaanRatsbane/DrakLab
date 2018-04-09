using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
    public class Mod
    {

        public string modName { get; private set; } //same as modFolder if no mod.ini present
        public string modFolder { get; private set; }
        public string description { get; private set; } //loaded from readme.txt if it exists
        public string author { get; private set; }
        public string version { get; private set; }
        public ModState state;
        public int rank;

        public List<ModFile> files;
        public bool newMod;

        public Mod(string modFolder, string modName, string description, string author, string version, int rank, bool newMod = true)
        {
            this.modFolder = modFolder;
            this.modName = modName;
            this.description = description;
            this.author = author;
            this.version = version;
            this.rank = rank;
            this.newMod = newMod;

            var frags = modFolder.Split('\\');
            var prefix = String.Join("\\", frags, 0, frags.Length - 1) + "\\" + frags.Last();
            var subdirectoryEntries = Directory.GetDirectories(modFolder);
            var filePaths = new List<string>();
            foreach (var folder in subdirectoryEntries)
            {
                filePaths.AddRange(ModManager.GetAllFiles(folder));
            }
            if (!Program.fileSystem.VerifyInjection(prefix, filePaths, out string[] report))
                state = ModState.CORRUPTED;

            if (state != ModState.CORRUPTED)
            {
                files = new List<ModFile>();
                foreach (var file in filePaths)
                {
                    var virtualPath = file.Replace(modFolder + "\\", "").Replace('\\', '/');
                    files.Add(new ModFile(file, virtualPath, this));
                }
            }
        }

        public bool ShouldSerializefiles()
        {
            return false;
        }

        public bool ShouldSerializenewMod()
        {
            return false;
        }

        public List<string> GetPhysicalFiles()
        {
            return GetPhysicalFiles(modFolder);
        }

        private List<string> GetPhysicalFiles(string folder)
        {
            var files = new List<string>();

            // Process the list of files found in the directory.
            files.AddRange(Directory.GetFiles(folder));

            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(folder);
            foreach (string subdirectory in subdirectoryEntries)
                files.AddRange(GetPhysicalFiles(subdirectory));

            files.Remove(modFolder + "\\readme.txt");
            files.Remove(modFolder + "\\mod.ini");

            return files;
        }

        public List<string> GetVirtualFiles()
        {
            var files = GetPhysicalFiles();
            var prefix = modFolder + "\\";
            for(int i = 0; i < files.Count; i++)
            {
                files[i] = files[i].Replace(prefix, "").Replace('\\', '/');
            }
            return files;
        }

        public ListViewItem GetListItem()
        {
            Color color;
            switch(state)
            {
                case ModState.ACTIVE:
                    color = Color.LightGreen;
                    break;
                case ModState.CORRUPTED:
                    color = Color.Orange;
                    break;
                case ModState.INACTIVE:
                default:
                    color = Color.White;
                    break;
            }
            return new ListViewItem(new string[] { $"{rank}", modName, state == ModState.ACTIVE ? "✓" : "" })
            {
                BackColor = color,
                Tag = this
            };
        }

        public ModFile GetModFile(string filename)
        {
            return files.Where(mf => mf.virtualPath == filename).First();
        }

        public void Enable()
        {
            if (state != ModState.CORRUPTED)
                state = ModState.ACTIVE;
        }

        public void Disable()
        {
            if (state != ModState.CORRUPTED)
                state = ModState.INACTIVE;
        }

    }

    public enum ModState
    {
        INACTIVE = 0,
        ACTIVE = 1,
        CORRUPTED = 2
    }
}
