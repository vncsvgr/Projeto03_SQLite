using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace Projeto03_SQLite.Models
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }

        SQLiteConnection db;

        public Curso()
        {
            db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "escola.db"));
            db.CreateTable<Curso>();
        }

        public void Adicionar(Curso c)
        {
            db.Insert(c);
        }

        public List<Curso> Listar(string nome)
        {
            return db.Table<Curso>().Where(i => i.nome.ToUpper().Contains(nome.ToUpper())).ToList();
        }

        public Curso Consultar(string nome)
        {
            return db.Table<Curso>().Where(i => i.nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
        }
    }
}
