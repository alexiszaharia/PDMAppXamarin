using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PDMAppXamarin
{
    class CursValutarDAO
    {
        private SQLiteConnection connDB;

        public CursValutarDAO()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            connDB = new SQLiteConnection(System.IO.Path.Combine(folder, "cursValutar.db"));
            connDB.CreateTable<CursValutar>();
        }

        public List<CursValutar> getLista()
        {
            List<CursValutar> listaCursuri = new List<CursValutar>();
            var listaQuery = connDB.Query<CursValutar>("SELECT * FROM cursuri_valutare");
            foreach(var element in listaQuery)
            {
                listaCursuri.Add(element);
            }
            return listaCursuri;
        }

        public void insertCursValutar(CursValutar cursValutar)
        {
            connDB.Insert(cursValutar);
        }
    }
}
