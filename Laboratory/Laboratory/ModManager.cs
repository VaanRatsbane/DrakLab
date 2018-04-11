using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Laboratory
{
    class ModManager
    {
        string MODFOLDER = $"\\{Program.fileSystem.systemName}_mods\\";
        string MANAGERSETTINGS = $"\\{Program.fileSystem.systemName}_mods\\modsettings.json";
        string LOADEDMODS = $"\\{Program.fileSystem.systemName}_mods\\loaded.json";
        string SETTINGS = $"\\{Program.fileSystem.systemName}_mods\\settings.json";

        public VanillaTracker vanilla;
        public int modCount { get { return mods.Count; } }
        public int activeCount { get { return mods.Count(mod => mod.state == ModState.ACTIVE); } }

        List<Mod> mods;

        public bool hasChanges;

        public ModManager()
        {
            try
            {
                if (!Directory.Exists(Program.reader.mBigFileFolder + MODFOLDER))
                    Directory.CreateDirectory(Program.reader.mBigFileFolder + MODFOLDER);                    

                var json = File.ReadAllText(Program.reader.mBigFileFolder + LOADEDMODS);
                mods = JsonConvert.DeserializeObject<List<Mod>>(json);
            }
            catch(Exception)
            {
                mods = new List<Mod>();
            }

            try
            {
                var json = File.ReadAllText(Program.reader.mBigFileFolder + SETTINGS);
                Program.settings = JsonConvert.DeserializeObject<Settings>(json);
            }
            catch(Exception)
            {
                Program.settings = new Settings();
            }

            vanilla = new VanillaTracker();
            hasChanges = false;
        }

        public void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(mods, Formatting.Indented);
                File.WriteAllText(Program.reader.mBigFileFolder + LOADEDMODS, json);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Couldn't save mod settings!\n{e.ToString()}");
            }

            try
            {
                var json = JsonConvert.SerializeObject(Program.settings, Formatting.Indented);
                File.WriteAllText(Program.reader.mBigFileFolder + SETTINGS, json);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Couldn't save mod settings!\n{e.ToString()}");
            }
            
            hasChanges = false;
        }

        public void AcknowledgeMods(bool setInactive = false)
        {
            foreach (var mod in mods)
            {
                if (setInactive && mod.newMod)
                        mod.state = ModState.INACTIVE;
                mod.newMod = false;
            }
        }

        public void ApplyChanges(Lab lab)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (!hasChanges)
                {
                    return;
                }

                Save();

                string tempDirectory;

                var usingCustomPath = false;
                if(Program.settings.useCustomTemp)
                {
                    if(Directory.Exists(Program.settings.tempPath))
                    {
                        usingCustomPath = true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Cannot use the given custom temp path. Using the system's default...");
                        Cursor.Current = Cursors.WaitCursor;
                    }
                }

                do
                {
                    tempDirectory = Path.Combine(usingCustomPath ? Program.settings.tempPath : Path.GetTempPath(),
                        "DRAKLAB" + Path.GetRandomFileName());
                } while (Directory.Exists(tempDirectory));

                lab.Log("Calculating files...");
                var scaffold = Scaffold.GetScaffold(mods);

                lab.Log("Making backups...");
                vanilla.Extract(scaffold, tempDirectory, out int backed, out int reverted);
                lab.Log($"Backed up {backed} files.");

                if (scaffold.Length > 0)
                {
                    lab.Log("Preparing injection...");

                    foreach (var modFile in scaffold)
                    {
                        modFile.parent.newMod = false;
                        var newPath = tempDirectory + '\\' + modFile.virtualPath.Replace('/', '\\');
                        var folders = Path.GetDirectoryName(newPath);
                        Directory.CreateDirectory(folders);
                        File.Copy(modFile.filePath, newPath);
                    }

                    lab.Log("Initializing ff12-vbf.exe...");

                    var logList = new List<string>();

                    Process process = new Process();
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.FileName = "ff12-vbf\\ff12-vbf.exe";
                    process.StartInfo.Arguments = $"-r \"{tempDirectory}\" \"{Program.reader.mBigFilePath}\"";

                    process.OutputDataReceived += (sender, args) => logList.Add(args.Data);
                    process.ErrorDataReceived += (sender, args) => logList.Add(args.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    Program.InjectionLog(logList);

                    DeleteFilesAndFoldersRecursively(tempDirectory);

                    lab.Log($"Injected {scaffold.Count()} files and reverted {reverted} original files.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        public Mod AddMod(string sourceFolder, Lab lab)
        {
            var fullModPath = Program.reader.mBigFileFolder + MODFOLDER;
            var frags = sourceFolder.Split('\\');
            var prefix = String.Join("\\", frags, 0, frags.Length - 1) + "\\" + frags.Last();
            var modFolder = fullModPath + frags.Last();

            if(mods.Count(o => o.modFolder == modFolder) == 1 && Directory.Exists(modFolder))
            {
                MessageBox.Show("There already exists a directory with that name in the mods folder.");
                return null;
            }

            var subdirectoryEntries = Directory.GetDirectories(sourceFolder);
            var files = new List<string>();
            foreach(var folder in subdirectoryEntries)
            {
                files.AddRange(GetAllFiles(folder));
            }
            bool isValidInjection = Program.fileSystem.VerifyInjection(prefix, files, out string[] report);

            if(report != null && report.Length > 0)
            {
                foreach (var rep in report)
                    lab.Log(rep);
            }

            if(isValidInjection)
            {
                if (!prefix.Contains(fullModPath))
                    DirectoryCopy(sourceFolder, modFolder, true);

                string author = "";
                string title = frags.Last();
                string version = "";
                string description = "";

                try
                {
                    if (File.Exists(modFolder + "\\mod.ini"))
                    {
                        var lines = File.ReadAllLines(modFolder + "\\mod.ini");
                        foreach (var line in lines)
                        {
                            if (line.StartsWith("#")) continue;

                            var ignoredHash = line.Split('#');
                            var parts = ignoredHash[0].Split('=');
                            switch (parts[0].ToLower().TrimEnd(' '))
                            {
                                case "author":
                                    author = parts[1].TrimStart(' ');
                                    break;

                                case "title":
                                    title = parts[1].TrimStart(' ');
                                    break;

                                case "version":
                                    version = parts[1].TrimStart(' ');
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error reading mod.ini\nNot all metadata will be displayed.");
                }

                try
                {
                    if(File.Exists(modFolder + "\\readme.txt"))
                    {
                        description = File.ReadAllText(modFolder + "\\readme.txt");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error reading mod details. Description will be left blank.");
                }

                var mod = new Mod(modFolder, title, description, author, version, mods.Count + 1);
                mods.Add(mod);
                lab.Log($"Mod {title} loaded.");
                hasChanges = true;

                return mod;
            }
            else
            {
                lab.Log("Failed to load the mod.");
                return null;
            }
        }

        public void RemoveMod(int pos)
        {
            var mod = mods[pos];
            hasChanges = mod.state == ModState.ACTIVE;
            DisableModState(pos);
            Directory.Delete(mod.modFolder, true);
            mods.RemoveAt(pos);
        }

        public void EnableModState(int pos)
        {
            mods[pos].state = ModState.ACTIVE;
            hasChanges = true;
        }

        public void DisableModState(int pos)
        {
            mods[pos].state = ModState.INACTIVE;
            hasChanges = true;
        }

        public static List<string> GetAllFiles(string targetDirectory)
        {
            var files = new List<string>();

            // Process the list of files found in the directory.
            files.AddRange(Directory.GetFiles(targetDirectory));

            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                files.AddRange(GetAllFiles(subdirectory));
            return files;
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

        public IEnumerator<Mod> GetEnumerator()
        {
            return mods.GetEnumerator();
        }

        public Mod GetMod(int pos)
        {
            return mods[pos];
        }

        public void TradePlaces(int i, int j)
        {
            var mod = mods[i];
            mods[i] = mods[j];
            mods[j] = mod;
            hasChanges = mods[i].state == ModState.ACTIVE && mods[i].state == ModState.ACTIVE;
        }

        public List<Mod> ModsAbove(Mod mod)
        {
            var list = new List<Mod>();
            foreach (var m in mods)
                if (mod != m)
                    list.Add(m);
                else
                    break;
            return list;
        }

        public ModFile[] GetScaffold()
        {
            return Scaffold.GetScaffold(mods);
        }

        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                File.Delete(file);
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteFilesAndFoldersRecursively(subDir);
            }

            Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
            Directory.Delete(target_dir);
        }

    }
}
