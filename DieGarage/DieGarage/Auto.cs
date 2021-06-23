namespace DieGarage
{
    public class Auto : Fahrzeug
    {
        private string nummernschild;

        public Auto(string neuesNummernschild)
        {
            nummernschild = neuesNummernschild;
        }

        public string GibNummernschild()
        {
            return nummernschild;
        }
    }
}