using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PDMAppXamarin
{
    [Table("cursuri_valutare")]
    class CursValutar
    {
        private float valoareMoneda;
        private float multiplicator;
        private string denumireValuta;
        private DateTime dataCurs;

        public CursValutar()
        {
            this.multiplicator = 1.0f;
        }

        public CursValutar(float valoareMoneda, float multiplicator, string denumireValuta, DateTime dataCurs)
        {
            this.valoareMoneda = valoareMoneda;
            this.multiplicator = multiplicator;
            this.denumireValuta = denumireValuta;
            this.dataCurs = dataCurs;
        }

        public CursValutar(float valoareMoneda, string denumireValuta, DateTime dataCurs)
        {
            this.valoareMoneda = valoareMoneda;
            this.multiplicator = 1.0f;
            this.denumireValuta = denumireValuta;
            this.dataCurs = dataCurs;
        }

        [Column("drapel")]
        public String Drapel
        {
            get {
                return denumireValuta.Substring(0, 2).ToLower() + ".png";
            }
        }

        [Column("valoare_moneda")]
        public float ValoareMoneda
        {
            get { return valoareMoneda; }
            set { valoareMoneda = value; }
        }

        [Column("multiplicator")]
        public float Multiplicator
        {
            get { return multiplicator; }
            set { multiplicator = value; }
        }

        [Column("denumire_valuta")]
        public string DenumireValuta
        {
            get { return denumireValuta; }
            set { denumireValuta = value; }
        }

        [Column("data_curs")]
        public DateTime DataCurs
        {
            get { return dataCurs; }
            set { dataCurs = value; }
        }
        
        public override string ToString()
        {
            return multiplicator + " " + denumireValuta + " = " + valoareMoneda + " RON";
        }
    }
}
