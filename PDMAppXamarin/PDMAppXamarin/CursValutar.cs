using System;
using System.Collections.Generic;
using System.Text;

namespace PDMAppXamarin
{
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

        public String Drapel
        {
            get {
                return denumireValuta.Substring(0, 2).ToLower() + ".png";
            }
        }

        public float ValoareMoneda
        {
            get { return valoareMoneda; }
            set { valoareMoneda = value; }
        }

        public float Multiplicator
        {
            get { return multiplicator; }
            set { multiplicator = value; }
        }

        public string DenumireValuta
        {
            get { return denumireValuta; }
            set { denumireValuta = value; }
        }

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
