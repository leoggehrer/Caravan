namespace Caravan.Logic
{
    /// <summary>
    /// Abstrakte Basisklasse, die generelle Eigenschaften und Methoden von 
    /// Packtieren beschreibt.
    /// </summary>
    public abstract class PackAnimal
    {
        #region fields
        private string _name = string.Empty;
        private int _maxPace;
        private int _load;
        private Caravan? _myCaravan = null;
        private bool _isSetMyCaravan = false;
        #endregion fields

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
        /// <param name="maxPace"></param>
        public PackAnimal(string name, int maxPace)
        {
            _name = name;
            _maxPace = maxPace;
        }

        public string Name { get { return _name;  } }

        /// <summary>
        /// Maximale Geschwindigkeit des Tiers
        /// </summary>
        public int MaxPace { get { return _maxPace; } }

        /// <summary>
        /// Anzahl der Ballen, die das Tier trägt
        /// </summary>
        public int Load 
        {
            get { return _load; }
            set { _load = value; }
        }
        
        /// <summary>
        /// Geschwindigkeit des Tiers
        /// </summary>
        public abstract int Pace { get; }  //! logisch eigentlich ein Property

        /// <summary>
        /// Karawane, in der das Tier mitläuft. Kann einfach durch Zuweisung 
        /// gewechselt werden. Umkettung in Karawanen erfolgt automatisch
        /// </summary>
        public Caravan? MyCaravan 
        {
            get { return _myCaravan; }
            set 
            {
                if (_isSetMyCaravan == false)
                {
                    _isSetMyCaravan = true;

                    // Wenn das Tier in keiner Karawane ist, kann es einfach
                    // in eine Karawane eingefügt werden
                    if (value != null
                        && _myCaravan == null)
                    {
                        _myCaravan = value;
                        _myCaravan.AddPackAnimal(this);
                    }
                    // Wenn das Tier in einer Karawane ist, wird es aus dieser
                    // entfernt und in die neue Karawane eingefügt
                    // (wenn es nicht die gleiche Karawane ist)
                    // Wenn die neue Karawane NULL ist, wird das Tier aus der
                    // alten Karawane entfernt
                    else if (value != null
                        && _myCaravan != null
                        && value != _myCaravan)
                    {
                        _myCaravan.RemovePackAnimal(this);
                        _myCaravan = value;
                        _myCaravan.AddPackAnimal(this);
                    }
                    // Wenn das Tier in einer Karawane ist und die neue Karawane
                    // NULL ist, wird das Tier aus der alten Karawane entfernt
                    // (wenn es nicht die gleiche Karawane ist)
                    // Wenn die neue Karawane NULL ist, wird das Tier aus der
                    // alten Karawane entfernt
                    // 
                    else if (value == null
                             && _myCaravan != null)
                    {
                        _myCaravan.RemovePackAnimal(this);
                        _myCaravan = value;
                    }

                    _isSetMyCaravan = false;
                }
            }
        }
    }
}
