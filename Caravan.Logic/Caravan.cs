namespace Caravan.Logic
{
    public class Caravan
    {
        public Caravan()
        {
        }

        /// <summary>
        /// Gibt die Anzahl der Tragtiere in der Karavane zurück
        /// </summary>
        public int Count
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Anzahl der Ballen der gesamten Karawane
        /// </summary>
        public int Load
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier nach Namen sucht und zurückgibt.
        /// Existiert das Packtier nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="name">Name des Packtiers</param>
        /// <returns>Packtier</returns>
        public PackAnimal this[string name]
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier entsprechend der Position in der Karawane sucht 
        /// und zurückgibt (0 --> Erstes Tier in der Karawane)
        /// Existiert die Position nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PackAnimal this[int index]
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Liefert die Reisegeschwindigkeit dieser Karawane, die
        /// vom langsamsten Tier bestimmt wird. Dabei wird die Ladung 
        /// der Tiere berücksichtigt
        /// </summary>
        public int Pace  
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Fügt ein Tragtier in die Karawane ein.
        /// Dem Tragtier wird mitgeteilt, in welcher Karawane es sich nun befindet.
        /// </summary>
        /// <param name="p">einzufügendes Tragtier</param>
        public void AddPackAnimal(PackAnimal p)
        {
        }

        /// <summary>
        /// Nimmt das Tragtier o aus dieser Karawane heraus
        /// </summary>
        /// <param name="p">Tragtier, das die Karawane verläßt</param>
        public void RemovePackAnimal(PackAnimal p)
        {
        }

        /// <summary>
        /// Entlädt alle Tragtiere dieser Karawane
        /// </summary>
        public void Unload()
        {
        }

        /// <summary>
        /// Verteilt zusätzliche Ballen Ladung so auf die Tragtiere 
        /// der Karawane, dass die Reisegeschwindigkeit möglichst hoch bleibt
        /// Tipp: Gib immer einen Ballen auf das belastbarste (schnellste) Tier bis alle Ballen vergeben sind
        /// </summary>
        /// <param name="load">Anzahl der Ballen Ladung</param>
        public void AddLoad(int load)
        {
        }

    }
}
