using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DieGarage
{
    public class Garage
    {
        private List<Fahrzeug> alleFahrzeuge = new List<Fahrzeug>();
        private Parkvorgang[,] parkplaetze;

        private Fahrzeug neuesFahrzeug;

        private StringBuilder stringBuilder = new StringBuilder();
        private Regex rx = new Regex(@"^\d$");
        private Match match;

        public Garage(int etagenAnzahl, int plaetzeProEtage)
        {
            parkplaetze = new Parkvorgang[etagenAnzahl, plaetzeProEtage];
            for (int etage = 0; etage < etagenAnzahl; etage++)
            {
                for (int stellplatz = 0; stellplatz < plaetzeProEtage; stellplatz++)
                {
                    parkplaetze[etage, stellplatz] = null;
                }
            }
        }
        //Erster Teil: Nummernschild eingeben.
        public void NummernschildAngeben()
        {
            Console.Clear();
            stringBuilder.Clear();
            stringBuilder.Append("Bitte geben Sie ihr Nummernschild ein. \n");
            Console.WriteLine(stringBuilder);
            bool antwortGefunden = false;
            string nummernschild = null;
            neuesFahrzeug = null;
            while (!antwortGefunden)
            { 
                nummernschild = Console.ReadLine();
                if (nummernschild != null)
                {
                    antwortGefunden = true;
                    foreach (Fahrzeug momentanesFahrzeug in alleFahrzeuge.Where(momentanesFahrzeug => momentanesFahrzeug.GibNummernschild().Equals(nummernschild)))
                    {
                        neuesFahrzeug = momentanesFahrzeug;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Keine Eingabe. \n" +
                                      stringBuilder);
                }
            }

            if (neuesFahrzeug == null)
            {
                FahrzeugAngeben(nummernschild);
            }
            else
            {
                MenueRoutine();
            }
        }
        //Zweiter Teil: Falls neues Fahrzeug, Fahrzeugtypen wählen.
        private void FahrzeugAngeben(string nummernschild)
        {
            Console.Clear();
            stringBuilder.Clear();
            stringBuilder.Append("Bitte geben Sie eine Zahl von 1 bis 2 ein. \n\n" +
                                 "1| Auto \n" +
                                 "2| Motorrad \n");
            Console.WriteLine(stringBuilder);
            bool antwortGefunden = false;
            int modell = 9;
            while (!antwortGefunden)
            { 
                string antwort = Console.ReadLine();
                match = rx.Match(antwort ?? string.Empty);
                antwortGefunden = match.Success;
                if (antwortGefunden)
                {
                    modell = int.Parse(antwort);
                    switch (modell)
                    {
                        case 1:
                            neuesFahrzeug = new Auto(nummernschild);
                            alleFahrzeuge.Add(neuesFahrzeug);
                            MenueRoutine();
                            break;
                        case 2:
                            neuesFahrzeug = new Motorrad(nummernschild);
                            alleFahrzeuge.Add(neuesFahrzeug);
                            MenueRoutine();
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Keine valide Option. Bitte versuchen Sie es erneut. \n" +
                                              "Drücken sie Eingabe zum Fortfahren.");
                            Console.ReadLine();
                            FahrzeugAngeben(nummernschild);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Falsche Eingabe. \n" +
                                      "Bitte geben Sie ihr Nummernschild ein. \n");
                }
            }
        }
        //Dritter Teil: Option was mit Fahrzeug gemacht werden soll.
        private void MenueRoutine()
        {
            Console.Clear();
            stringBuilder.Clear();
            stringBuilder.Append("Bitte geben Sie eine Zahl von 1 bis 5 ein. \n\n" +
                                 "1| Fahrzeug parken. \n" +
                                 "2| Fahrzeug parken't. \n" +
                                 "3| Parkplatz von Fahrzeug finden. \n" +
                                 "4| Fahrzeug wechseln. \n" +
                                 "5| Menu beenden. \n");
            Console.WriteLine(stringBuilder);
            bool antwortGefunden = false;
            int antwortOption = 9;
            while (!antwortGefunden)
            {
                string antwort = Console.ReadLine();
                match = rx.Match(antwort ?? string.Empty);
                antwortGefunden = match.Success;
                if (antwortGefunden)
                {
                    antwortOption = int.Parse(antwort ?? string.Empty);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Falsche Eingabe. \n" +
                                      stringBuilder);
                }
            }

            switch (antwortOption)
            {
                case 1:
                    FahrzeugParken();
                    break;
                case 2:
                    FahrzeugEntparken();
                    break;
                case 3:
                    Parkvorgang parkvorgang;
                    PositionVonFahrzeug(neuesFahrzeug.GibNummernschild(), out parkvorgang);
                    break;
                case 4:
                    NummernschildAngeben();
                    break;
                case 5:
                    ProgrammBeenden();
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 0:
                    Console.Clear();
                    Console.WriteLine("Keine valide Option. Bitte versuchen Sie es erneut. \n" +
                                      "Drücken sie Eingabe zum Fortfahren.");
                    Console.ReadLine();
                    MenueRoutine();
                    break;
            }
        }

        private void FahrzeugParken()
        {
            
        }

        private void FahrzeugEntparken()
        {
            
        }

        private bool PositionVonFahrzeug(string fahrzeugId, out Parkvorgang parkvorgang)
        {
            for (int i = 0; i < parkplaetze.GetLength(0); i++)
            {
                for (int j = 0; j < parkplaetze.GetLength(1); j++)
                {
                    Parkvorgang momentanerParkplatz = parkplaetze[i, j];
                    if (momentanerParkplatz.GibGeparktesFahreug().GibNummernschild().Equals(fahrzeugId))
                    {
                        parkvorgang = momentanerParkplatz;
                        return true;
                    }
                    
                }
            }

            parkvorgang = null;
            return false;
        }
        
        private void ProgrammBeenden()
        {
            
        }
    }
}