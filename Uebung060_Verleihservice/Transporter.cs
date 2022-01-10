using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung060_Verleihservice
{
    class Transporter : Leihfahrzeug
    {
        private double zulaessigesGesamtgewicht;

        public double ZulaessigesGesamtgewicht
        {
            get { return zulaessigesGesamtgewicht; }
            set
            {
                if (value <= 0)

                    throw new ArgumentException("Ungültiges Gesamtgewicht");
                zulaessigesGesamtgewicht = value;
            }
        }

        public Transporter(double zulaessigesGesamtgewicht,
                            string fahrzeugID,
                            string bezeichnung,
                            double miettarifProTag,
                            double versicherungspauschale)
                            : base(fahrzeugID,
                                  bezeichnung,
                                  miettarifProTag,
                                  versicherungspauschale)
        {
            ZulaessigesGesamtgewicht = zulaessigesGesamtgewicht;
        }

        public override Fuehrerschein BenoetigterFuehrerschein()
        {
            if (ZulaessigesGesamtgewicht >= 3.5)
            {
                return Fuehrerschein.C_Klasse_LKW;
            }

            return base.BenoetigterFuehrerschein();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [fahrzeugID={FahrzeugID}, " +
                $"bezeichnung={Bezeichnung}, " +
                $"miettarifProTag={MiettarifProTag}, " +
                $"versciherungspauschale={Versicherungspauschale}, " +
                $"ZulässigesGesamtgewicht()={zulaessigesGesamtgewicht}]";
        }
    }
}
