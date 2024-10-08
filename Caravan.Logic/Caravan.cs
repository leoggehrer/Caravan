namespace Caravan.Logic
{
    public class Caravan
    {
        #region embedded types
        private class Element
        {
            public Element(PackAnimal animal, Element? next)
            {
                Animal = animal;
                Next = next;
            }
            public PackAnimal Animal;
            public Element? Next;
        }
        #endregion embedded types

        #region fields
        private Element? _first = null;    
        #endregion fields

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
                int result = 0;
                Element? run = _first;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Anzahl der Ballen der gesamten Karawane
        /// </summary>
        public int Load
        {
            get
            {
                int result = 0;
                Element? run = _first;

                while (run != null)
                {
                    result += run.Animal.Load;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier nach Namen sucht und zurückgibt.
        /// Existiert das Packtier nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="name">Name des Packtiers</param>
        /// <returns>Packtier</returns>
        public PackAnimal? this[string name]
        {
            get
            {
                Element? run = _first;

                while (run != null && run.Animal.Name.Equals(name) == false)
                {
                    run = run.Next;
                }
                return run?.Animal;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier entsprechend der Position in der Karawane sucht 
        /// und zurückgibt (0 --> Erstes Tier in der Karawane)
        /// Existiert die Position nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PackAnimal? this[int index]
        {
            get
            {
                int count = 0;
                Element? run = _first;

                while (run != null && count != index)
                {
                    count++;
                    run = run.Next;
                }
                return run?.Animal;
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
                int result = _first == null ? 0 : int.MaxValue;
                Element? run = _first;

                while (run != null)
                {
                    result = Math.Min(result, run.Animal.Pace);
                    run = run.Next;
                }

                return result;
            }
        }

        /// <summary>
        /// Fügt ein Tragtier in die Karawane ein.
        /// Dem Tragtier wird mitgeteilt, in welcher Karawane es sich nun befindet.
        /// </summary>
        /// <param name="packAnimal">einzufügendes Tragtier</param>
        public void AddPackAnimal(PackAnimal? packAnimal)
        {
            if (packAnimal != null && IsInCaravan(packAnimal) == false)
            {
                if (_first == null)
                {
                    _first = new Element(packAnimal, null);
                    packAnimal.MyCaravan = this;
                }
                else
                {
                    Element? run = _first;

                    while (run.Next != null)
                    {
                        run = run.Next;
                    }
                    run.Next = new Element(packAnimal, null);
                    packAnimal.MyCaravan = this;
                }
            }
        }

        /// <summary>
        /// Nimmt das Tragtier o aus dieser Karawane heraus
        /// </summary>
        /// <param name="packAnimal">Tragtier, das die Karawane verläßt</param>
        public void RemovePackAnimal(PackAnimal packAnimal)
        {
            if (_first != null && _first.Animal == packAnimal)
            {
                _first = _first.Next;
                packAnimal.MyCaravan = null;
            }
            else
            {
                Element? run = _first;

                while (run != null && run.Next != null && run.Next.Animal != packAnimal)
                {
                    run = run.Next;
                }
                if (run != null && run.Next != null)
                {
                    run.Next = run.Next.Next;
                    packAnimal.MyCaravan = null;
                }
            }
        }

        /// <summary>
        /// Entlädt alle Tragtiere dieser Karawane
        /// </summary>
        public void Unload()
        {
            Element? run = _first;

            while (run != null)
            {
                run.Animal.Load = 0;
                run = run.Next;
            }
        }

        /// <summary>
        /// Verteilt zusätzliche Ballen Ladung so auf die Tragtiere 
        /// der Karawane, dass die Reisegeschwindigkeit möglichst hoch bleibt
        /// Tipp: Gib immer einen Ballen auf das belastbarste (schnellste) Tier bis alle Ballen vergeben sind
        /// </summary>
        /// <param name="load">Anzahl der Ballen Ladung</param>
        public void AddLoad(int load)
        {
            while (_first != null && load > 0)
            {
                Element? run = _first;
                Element? max = _first;
                int savePace = Int32.MinValue;

                while (run != null)
                {
                    run.Animal.Load++;
                    if (Pace > savePace)
                    {
                        savePace = Pace;
                        max = run;
                    }
                    run.Animal.Load--;
                    run = run.Next;
                }
                max.Animal.Load++;
                load--;
            }
        }

        private bool IsInCaravan(PackAnimal packAnimal)
        {
            Element? run = _first;

            while (run != null && run.Animal != packAnimal)
            {
                run = run.Next;
            }
            return run != null;
        }
    }
}
