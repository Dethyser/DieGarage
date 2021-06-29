namespace DieGarage
{
    public class Parkplatz
    {
        private int etage;
        private int parkplatz;

        public Parkplatz(int newEtage, int newParkplatz)
        {
            etage = newEtage;
            parkplatz = newParkplatz;
        }

        public string GibPosition()
        {
            return "Etage:" + (etage + 1) + " Parkplatz:" + (parkplatz + 1);
        }

        public int GibEtage()
        {
            return etage;
        }

        public int GibParkPosition()
        {
            return parkplatz;
        }
    }
}