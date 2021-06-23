using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DieGarage
{
    public class Garage
    {
        private Parkvorgang[,] parkplaetze;

        private StringBuilder stringBuilder = new StringBuilder();
        private Regex rx = new Regex(@"^\d$");
        private bool antwortGefunden;
        private int antwortOption;

        public Garage(int etagenAnzahl, int plaetzeProEtage)
        {
            parkplaetze = new Parkvorgang[etagenAnzahl, plaetzeProEtage];
            for (int etage = 0; etage < etagenAnzahl; etage++)
            {
                for (int stellplatz = 0; stellplatz < plaetzeProEtage; stellplatz++)
                {
                    parkplaetze[etage, stellplatz] = new Parkvorgang(etage, stellplatz);
                }
            }
        }

        public void MenueRoutine()
        {
            stringBuilder.Clear();
            stringBuilder.Append("Bitte geben Sie eine Zahl von 1 bis 4 ein. \n\n" +
                                 "1| Fahrzeug parken. \n" +
                                 "2| Fahrzeug parken't. \n" +
                                 "3| Parkplatz von Fahrzeug finden. \n" +
                                 "4| Menu beenden. \n");
            Console.WriteLine(stringBuilder);
            antwortGefunden = false;
            antwortOption = 9;
            while (!antwortGefunden)
            {
                string antwort = Console.ReadLine();
                Match match = rx.Match(antwort);
                antwortGefunden = match.Success;
                if (antwortGefunden)
                {
                    antwortOption = int.Parse(antwort);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Falsche Eingabe. \n" +
                                      stringBuilder);
                }
            }
        }

        private void FahrzeugParken(string fahrzeugID)
        {
            
        }

        private void FahrzeugEntparken(string fahrzeugID)
        {
            
        }

        private Parkvorgang PositionVonFahrzeug(string fahrzeugID)
        {
            return null;
        }
        
        private void ProgrammBeenden()
        {
            
        }
    }
}