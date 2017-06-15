using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBot.Files
{
    interface IExportable
    {
        void Export(StreamWriter file);
        bool Import(StreamReader file);
    }
}
