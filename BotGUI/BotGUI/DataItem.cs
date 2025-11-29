using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class DataItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DataItem(int a, String b) { Id = a; Name = b; }
    }
}
