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

            Parkvorgang parkvorgang;
            switch (antwortOption)
            {
                case 1:
                    Console.Clear();
                    int etage = 0;
                    int parkPosition = 0;
                    if (!PositionVonFahrzeug(neuesFahrzeug.GibNummernschild(), out parkvorgang) && FindeLeerenParkplatz(out etage, out parkPosition))
                    {
                        FahrzeugParken(neuesFahrzeug, etage, parkPosition);
                        Console.WriteLine("Ihr Fahrzeug wurde an dieser Stelle geparkt: \n" +
                                          "Etage: " + etage + 1 + " Parkplatz: " + parkPosition + 1 + " \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    else
                    {
                        Console.WriteLine("Dieses Fahrzeug ist bereits in der Garage oder die Garage ist voll. \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    Console.ReadLine();
                    MenueRoutine();
                    break;
                case 2:
                    Console.Clear();
                    if (PositionVonFahrzeug(neuesFahrzeug.GibNummernschild(), out parkvorgang))
                    {
                        FahrzeugEntparken(parkvorgang.GibParkplatz().GibEtage(), parkvorgang.GibParkplatz().GibParkPosition());
                        TimeSpan parkzeit = parkvorgang.GibParkzeit().GibZeitdifferenz();
                        int tage = parkzeit.Days;
                        int stunden = parkzeit.Days;
                        int minuten = parkzeit.Days;
                        double preis = 0.0;
                        if (tage > 0 || stunden > 9)
                        {
                            preis = 10.0 + 10.0 * tage;
                        }
                        else if(stunden > 0)
                        {
                            preis = 1.5 + 1.0 * (stunden - 1);
                        }
                        else if(minuten > 20)
                        {
                            preis = 1.5;
                        }
                        Console.WriteLine("Ihr Fahrzeug verlässt das Parkhaus. \n" +
                                          "Die Dauer beträgt: \n" +
                                          "Tage: " + tage + " \n" +
                                          "Stunden: " + stunden + " \n" +
                                          "Minuten: " + minuten + " \n" +
                                          "Die Parkkosten betragen: \n" +
                                          "Preis : " + preis + " Euro \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    else
                    {
                        Console.WriteLine("Dieses Fahrzeug ist nicht im Parkhaus vorhanden. \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    Console.ReadLine();
                    MenueRoutine();
                    break;
                case 3:
                    Console.Clear();
                    if (PositionVonFahrzeug(neuesFahrzeug.GibNummernschild(), out parkvorgang))
                    {
                        Console.WriteLine("Ihr Fahrzeug befindet sich hier: \n" +
                                          parkvorgang.GibParkplatz().GibPosition() + " \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    else
                    {
                        Console.WriteLine("Dieses Fahrzeug ist nicht im Parkhaus vorhanden. \n" +
                                          "Drücken sie Eingabe zum Fortfahren.");
                    }
                    Console.ReadLine();
                    MenueRoutine();
                    break;
                case 4:
                    NummernschildAngeben();
                    break;
                case 5:
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

        private void FahrzeugParken(Fahrzeug zuParkendesFahrzeug, int etage, int parkPosition)
        {
            parkplaetze[etage, parkPosition] = new Parkvorgang(etage, parkPosition, zuParkendesFahrzeug);
        }

        private void FahrzeugEntparken(int etage, int parkPosition)
        {
            parkplaetze[etage, parkPosition] = null;
        }

        private bool PositionVonFahrzeug(string fahrzeugId, out Parkvorgang parkvorgang)
        {
            for (int i = 0; i < parkplaetze.GetLength(0); i++)
            {
                for (int j = 0; j < parkplaetze.GetLength(1); j++)
                {
                    Parkvorgang momentanerParkplatz = parkplaetze[i, j];
                    if (momentanerParkplatz != null && momentanerParkplatz.GibGeparktesFahreug().GibNummernschild().Equals(fahrzeugId))
                    {
                        parkvorgang = momentanerParkplatz;
                        return true;
                    }
                    
                }
            }

            parkvorgang = null;
            return false;
        }

        private bool FindeLeerenParkplatz(out int etage, out int parkPosition)
        {
            for (int i = 0; i < parkplaetze.GetLength(0); i++)
            {
                for (int j = 0; j < parkplaetze.GetLength(1); j++)
                {
                    Parkvorgang momentanerParkplatz = parkplaetze[i, j];
                    if (momentanerParkplatz != null) continue;
                    etage = i;
                    parkPosition = j;
                    return true;

                }
            }
            etage = 0;
            parkPosition = 0;
            return false;
        }
    }
}