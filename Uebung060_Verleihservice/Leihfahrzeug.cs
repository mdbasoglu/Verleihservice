using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung060_Verleihservice
{
    class Leihfahrzeug
    {
        public enum Fuehrerschein
        {
            B_Klasse_PKW = 1,
            C_Klasse_LKW
        }

        private string fahrzeugID;
        public string FahrzeugID { get => fahrzeugID; set => fahrzeugID = value; }

        private string bezeichnung;
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }

        private double miettarifProTag;
        public double MiettarifProTag
        {
            get { return miettarifProTag; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Der Miettarif muss > 0 sein !");
                }
                miettarifProTag = value;
            }
        }

        private double versicherungspauschale;
        public double Versicherungspauschale { get => versicherungspauschale; set => versicherungspauschale = value; }

        public Leihfahrzeug(string fahrzeugID,
                            string bezeichnung,
                            double miettarifProTag,
                            double versicherungspauschale)
        {
            FahrzeugID = fahrzeugID;
            Bezeichnung = bezeichnung;
            MiettarifProTag = miettarifProTag;
            Versicherungspauschale = versicherungspauschale;
        }

        public virtual double BerechneMietpreis(TimeSpan dauer)
        {
            double mietpreis = (MiettarifProTag * Math.Ceiling(dauer.TotalDays))
                                + Versicherungspauschale;

            return mietpreis;
        }

        public virtual Fuehrerschein BenoetigterFuehrerschein()
        {
            return Fuehrerschein.B_Klasse_PKW;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [fahrzeugID={FahrzeugID}, " +
                                    $"bezeichnung={Bezeichnung}, " +
                                    $"miettarifProTag={MiettarifProTag}, " +
                                    $"versciherungspauschale={Versicherungspauschale}]";
        }
    }
}
