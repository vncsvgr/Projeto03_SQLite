using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace Projeto03_SQLite.Models
{
    internal class Cidade
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
    }
}
