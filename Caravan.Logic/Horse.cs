namespace Caravan.Logic
{
    public class Horse : PackAnimal
    {
        #region fields
        #endregion fields
        /// <summary>
        /// Pferd mit Maximalgeschwindigkeit 70 erzeugen
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maxPace"></param>
        public Horse(string name, int maxPace)
            : base(name, Math.Min(Math.Max(maxPace, 0), 70))
        {

        }

        /// <summary>
        /// Geschwindigkeit in Abhängigkeit der Ladung (Reduktion um 10 je Ballen)
        /// </summary>
        public override int Pace
        {
            get
            {
                return Math.Max(MaxPace - (Load * 10), 0);
            }
        }

    }
}
