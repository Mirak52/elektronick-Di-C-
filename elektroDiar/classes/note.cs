using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elektroDiar.classes
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int id_note { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
        public string date { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string note { get; set; }
    }
}
