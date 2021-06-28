namespace DieGarage
{
    public class Parkvorgang
    {
        private Parkplatz parkplatz;
        private Parkzeit parkzeit;
        private Fahrzeug geparktesFahrzeug;

        public Parkvorgang(int etage, int parkPosition, Fahrzeug neuesFahrzeug)
        {
            parkplatz = new Parkplatz(etage, parkPosition);
            parkzeit = new Parkzeit();
            geparktesFahrzeug = neuesFahrzeug;
        }

        public Parkplatz GibParkplatz()
        {
            return parkplatz;
        }

        public Parkzeit GibParkzeit()
        {
            return parkzeit;
        }

        public Fahrzeug GibGeparktesFahreug()
        {
            return geparktesFahrzeug;
        }
    }
}