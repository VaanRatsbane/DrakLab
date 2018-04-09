using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
    class Scaffold
    {
        //Gets all top level files from active mods
        public static ModFile[] GetScaffold(List<Mod> mods)
        {
            var list = new List<ModFile>();
            foreach (var m in mods)
                if(m.state == ModState.ACTIVE)
                {
                    var virtuals = m.GetVirtualFiles();
                    foreach (var v in virtuals)
                        if (list.FirstOrDefault(o => o.virtualPath == v) == null)
                            list.Add(m.GetModFile(v));
                }
            return list.ToArray();
        }
    }
}
