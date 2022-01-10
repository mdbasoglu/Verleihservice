using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Uebung060_Verleihservice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Zeitspanne 6 Stunden, 0 Minuten und 0 Sekunden
            TimeSpan dauer = new TimeSpan(6, 0, 0);

            Baumaschine b1 = new Baumaschine(true, 42, "B20258", "Mobilbagger 17,5 t", 280, 30);
            Baumaschine b2 = new Baumaschine(false, 25, "B20533", "Radlader 4,9 t", 157, 25);

            Transporter t1 = new Transporter(2.8, "T30124", "VW Transporter T5 Pritschenwagen", 95, 32);
            Transporter t2 = new Transporter(7.5, "T31123", "Mercedes-Benz Atego Kipper", 215, 55);

            Leihfahrzeug[] fuhrpark = { b1, b2, t1, t2 };

            for (int i = 0; i < fuhrpark.Length; i++)
            {
                Console.WriteLine($"Mietpreis: {fuhrpark[i].BerechneMietpreis(dauer)}" +
                                  $"\tFuehrerschein: {fuhrpark[i].BenoetigterFuehrerschein()}\n");
            }
            */






            Leihfahrzeug[] fahrzeuge = LeseTestDaten();
            for (int i = 0; i < fahrzeuge.Length; i++)
            {
                Console.WriteLine(fahrzeuge[i]);
                Console.WriteLine(fahrzeuge[i].BenoetigterFuehrerschein());
                Console.WriteLine(fahrzeuge[i].BerechneMietpreis(new TimeSpan(6, 0, 0)));
            }


        }

        public static Leihfahrzeug[] LeseTestDaten()
        {
            string[] lines = File.ReadAllLines(@"Uebung060_Verleihservice\Leihfahrzeuge.csv");
            //Console.WriteLine(string.Join("\n", lines)); kontrol etmek icin yaz


            Leihfahrzeug[] leihfahrzeugs = new Leihfahrzeug[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');

                string fahrzeugID = data[1];
                string beschreibung = data[2];
                double miettarifproTag = Convert.ToDouble(data[3]);
                double versicherungspauschale = Convert.ToDouble(data[5]);


                if (data[0] == "Baumaschine")
                {
                    double miettarifProstunde = Convert.ToDouble(data[4]);
                    bool lieferservice = (data[6] == "ja");
                    leihfahrzeugs[i] = new Baumaschine(fahrzeugID, beschreibung, miettarifproTag, versicherungspauschale, zu)
                }
                else if (data[0] == "Transporter")
                {

                    double zuleassigesGesamtgewicht = Convert.ToDouble(data[7]);
                }




            }
            return leihfahrzeugs;




        }

    }
}
