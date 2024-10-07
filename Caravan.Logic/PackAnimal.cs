namespace Caravan.Logic
{
    /// <summary>
    /// Abstrakte Basisklasse, die generelle Eigenschaften und Methoden von 
    /// Packtieren beschreibt.
    /// </summary>
    public abstract class PackAnimal
    {
        /// <summary>
        /// Damit die Vorlage compilierbar bleibt
        /// </summary>
        public PackAnimal()
        {

        }

        /// <summary>
        /// Name des Tiers und Maximalgeschwindigkeit des Tiers
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mp"></param>
        public PackAnimal(string name, int mp)
        {
        }

        public string Name { get { return null;  } }

        /// <summary>
        /// Maximale Geschwindigkeit des Tiers
        /// </summary>
        public int MaxPace { get { return -1; } }

        /// <summary>
        /// Anzahl der Ballen, die das Tier trägt
        /// </summary>
        public int Load 
        {
            get { return -1; }
            set { ; }
        }
        
        /// <summary>
        /// Geschwindigkeit des Tiers
        /// </summary>
        public abstract int Pace { get; }  //! logisch eigentlich ein Property

        /// <summary>
        /// Karawane, in der das Tier mitläuft. Kann einfach durch Zuweisung 
        /// gewechselt werden. Umkettung in Karawanen erfolgt automatisch
        /// </summary>
        public Caravan MyCaravan 
        {
            get { return null; }
            set { ; }
        }
    }
}
