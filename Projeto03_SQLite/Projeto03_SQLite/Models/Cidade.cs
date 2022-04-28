using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace Projeto03_SQLite.Models
{
    public class Cidade
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        SQLiteConnection db;

        public Cidade()
        {
            db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "escola.db"));
            db.CreateTable<Cidade>();
        }

        public void Adicionar(Cidade ci)
        {
            db.Insert(ci);
        }

        public List<Cidade> Listar(string nome)
        {
            return db.Table<Cidade>().Where(i => i.nome.ToUpper().Contains(nome.ToUpper())).ToList();
        }

        public Cidade Consultar(string nome)
        {
            return db.Table<Cidade>().Where(i => i.nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
        }
    }
}
