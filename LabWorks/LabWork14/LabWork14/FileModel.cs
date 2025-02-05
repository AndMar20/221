using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork14
{
    public class FileModel
    {
        public string Fullpath { get; set; }
        public string FileName => Path.GetFileName(Fullpath);

        public FileModel(string fullpath)
        {
            Fullpath = fullpath;
        }
    }
}
