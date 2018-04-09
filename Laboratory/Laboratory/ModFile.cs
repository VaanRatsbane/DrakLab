using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
    public class ModFile
    {
        public string filePath;
        public string virtualPath;
        public Mod parent;

        public ModFile(string fPath, string vPath, Mod parent)
        {
            filePath = fPath;
            virtualPath = vPath;
            this.parent = parent;
        }

    }
}
