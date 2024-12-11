using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KielApp
{
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageSource { get; set; }
        public string? Bio { get; set; }
        public string? Hometown { get; set; }
        public string? Birthday { get; set; }
        public string? ZodiacSign { get; set; }
    }
}
