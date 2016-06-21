using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCADPlugin
{
    public class BlockInfo
    {
        public string Name { get; set; }
        public Dictionary<string, string> BlockAttributes { get; set; }
    }
}
