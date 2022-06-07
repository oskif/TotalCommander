using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Model
{
    public class FileModel
    {
        public string Name { get; set; }

        public Types.types Type { get; }

        public FileModel(string name, Types.types type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            if (Type == Types.types.DIR)
            {
                return "<DIR>" + Name;
            }
            else if (Type == Types.types.BACK)
            {
                return "...";
            }
            else
            {
                return Name;
            } 
        }
    }
}
