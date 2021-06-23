namespace DieGarage
{
    public class Parkvorgang
    {
        private Parkplatz parkplatz;
        private Parkzeit parkzeit;
        private Fahrzeug geparktesFahrzeug;

        public Parkvorgang(int etage, int parkplatz)
        {
            new Parkplatz(etage, parkplatz);
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