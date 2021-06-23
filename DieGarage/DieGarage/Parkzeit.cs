using System;

namespace DieGarage
{
    public class Parkzeit
    {
        private DateTime einfahrtszeit;
        private DateTime ausfahrtszeit;

        public Parkzeit()
        {
            einfahrtszeit = DateTime.Now;
        }

        public TimeSpan GibZeitdifferenz()
        {
            ausfahrtszeit = DateTime.Now;
            return ausfahrtszeit - einfahrtszeit;
        }
    }
}