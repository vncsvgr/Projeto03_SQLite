using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace Projeto03_SQLite.Models
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }
        public string curso { get; set; }
        public string cidade { get; set; }

        SQLiteConnection db;

        public Aluno()
        {
            db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "escola.db"));
            db.CreateTable<Aluno>();
        }

        public void Adicionar(Aluno a)
        {
            db.Insert(a);
        }

        public void Atualizar(Aluno a)
        {
            db.Update(a);
        }

        public void Excluir(Aluno a)
        {
            db.Delete(a);
        }

        public List<Aluno> Listar(string nome)
        {
            return db.Table<Aluno>().Where(i => i.nome.ToUpper().Contains(nome.ToUpper())).ToList();
        }
    }
}
