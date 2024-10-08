namespace Caravan.Logic
{
    public class Camel : PackAnimal
    {
        /// <summary>
        /// Kamel mit Maximalgeschwindigkeit 20 erzeugen
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maxPace"></param>
        public Camel(string name, int maxPace)
            : base(name, Math.Min(Math.Max(maxPace, 0), 20))
        {
        }

        /// <summary>
        /// Geschwindigkeit in Abhängigkeit der Ladung (Reduktion um 1 je Ballen)
        /// </summary>
        public override int Pace
        {
            get
            {
                return Math.Max(MaxPace - (Load * 1), 0);
            }
        }
    }
}
