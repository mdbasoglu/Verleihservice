using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung060_Verleihservice
{
    class Baumaschine : Leihfahrzeug
    {
        private double miettarifProStunde;
        public double MiettarifProStunde
        {
            get { return miettarifProStunde; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Der Miettarif muss > 0 sein !");
                }
                miettarifProStunde = value;
            }
        }

        private bool lieferservice;
        public bool Lieferservice
        {
            get { return lieferservice; }
            set { lieferservice = value; }
        }

        public Baumaschine(bool lieferservice,
                        double miettarifProStunde,
                        string fahrzeugID,
                        string bezeichnung,
                        double miettarifProTag,
                        double versicherungspauschale)
                        : base(fahrzeugID,
                              bezeichnung,
                              miettarifProTag,
                              versicherungspauschale)
        {
            Lieferservice = lieferservice;
            MiettarifProStunde = miettarifProStunde;
        }

        public override double BerechneMietpreis(TimeSpan dauer)
        {
            double mietpreisStunde = 0;

            if (dauer.TotalHours < 8)
            {
                mietpreisStunde = (miettarifProStunde * dauer.Hours)
                                    + Versicherungspauschale;
            }
            else
            {
                mietpreisStunde = base.BerechneMietpreis(dauer);
            }
            if (lieferservice)
            {
                mietpreisStunde += 100;
            }

            return mietpreisStunde;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [fahrzeugID={FahrzeugID}, " +
                                    $"bezeichnung={Bezeichnung}, " +
                                    $"miettarifProTag={MiettarifProTag}, " +
                                    $"versciherungspauschale={Versicherungspauschale}, " +
                                    $"miettarifProStunde={MiettarifProStunde}, " +
                                    $"lieferservice={Lieferservice}]";
        }

    }
}
