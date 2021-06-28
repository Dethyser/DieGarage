using System.Collections.Generic;

namespace DieGarage
{
    public class Motorrad : Fahrzeug
    {
        private string nummernschild;

        public Motorrad(string neuesNummernschild)
        {
            nummernschild = neuesNummernschild;
        }

        public string GibNummernschild()
        {
            return nummernschild;
        }
    }
}