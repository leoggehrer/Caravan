namespace Caravan.UnitTest
{
    [TestClass]
    public class CaravanUnitTest
    {
        /// <summary>
        ///A test for Unload
        ///</summary>
        [TestMethod()]
        public void T01_UnloadTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            Logic.Camel willi = new Logic.Camel("Willi", 15);
            Logic.Horse moritz = new Logic.Horse("Moritz", 35);
            willi.Load = 10;
            moritz.Load = 3;
            Assert.AreEqual(10, willi.Load, "Die Beladung mit 10 ist nicht korrekt");
            Assert.AreEqual(3, moritz.Load, "Die Beladung mit 3 ist nicht korrekt");
            Assert.AreEqual(5, willi.Pace, "Die Geschw. von 5 bei Willi ist nicht korrekt");
            Assert.AreEqual(5, moritz.Pace, "Die Geschw. von 5 bei Moritz ist nicht korrekt");
            saharaExpress.AddPackAnimal(willi);
            saharaExpress.AddPackAnimal(moritz);
            saharaExpress.Unload();
            Assert.AreEqual(0, willi.Load, "Die Entladung von willi ist nicht korrekt");
            Assert.AreEqual(0, moritz.Load, "Die Entladung von moritz ist nicht korrekt");
        }

        /// <summary>
        ///A test for RemovePackAnimal
        ///</summary>
        [TestMethod()]
        public void T02_RemovePackAnimalTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            Logic.Camel willi = new Logic.Camel("Willi", 15);
            willi.Load = 10;
            saharaExpress.AddPackAnimal(willi);
            Assert.AreEqual(saharaExpress, willi.MyCaravan, "Verweis auf eigene Karawane nicht korrekt");
            Assert.AreEqual(1, saharaExpress.Count, "Anzahl der Tragtiere in Karawane nicht korrekt");
            saharaExpress.RemovePackAnimal(willi);
            Assert.AreEqual(null, willi.MyCaravan, "Verweis auf NULL in myCaravan nicht korrekt");
            Assert.AreEqual(0, saharaExpress.Count, "Anzahl der Tragtiere in Karawane nicht korrekt");
        }

        /// <summary>
        ///A test for Indexer nach Namen
        ///</summary>
        [TestMethod()]
        public void T03_IndexerNamenTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(new Logic.Camel("Willi", 15));
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 14));
            Assert.AreEqual("Mitzi", saharaExpress["Mitzi"]!.Name, "Indexer am ANFANG nicht korrekt");
            Assert.AreEqual("Susi", saharaExpress["Susi"]!.Name, "Indexer in der MITTE nicht korrekt");
            Assert.AreEqual("Willi", saharaExpress["Willi"]!.Name, "Indexer am ENDE nicht korrekt");
        }

        /// <summary>
        ///A test for Indexer nach Positionen
        ///</summary>
        [TestMethod()]
        public void T04_IndexerPositionTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(new Logic.Camel("Willi", 15));
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 14));

            Assert.AreEqual("Willi", saharaExpress[0]!.Name, "Indexer am ANFANG nicht korrekt");
            Assert.AreEqual("Susi", saharaExpress[1]!.Name, "Indexer in der MITTE nicht korrekt");
            Assert.AreEqual("Mitzi", saharaExpress[2]!.Name, "Indexer am ENDE nicht korrekt");
        }

        /// <summary>
        ///A test for Pace an Load
        ///</summary>
        [TestMethod()]
        public void T05_PaceTest_LoadTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(new Logic.Camel("Willi", 15));
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 14));
            saharaExpress["Willi"]!.Load = 10;
            saharaExpress["Susi"]!.Load = 8;
            saharaExpress["Mitzi"]!.Load = 5;
            Assert.AreEqual(5, saharaExpress.Pace, "Karawane bewegt sich --> nicht korrekt");
            Assert.AreEqual(23, saharaExpress.Load, "Gesamtbeladung der Karawane stimmt nicht");
            saharaExpress["Willi"]!.Load = 25;
            Assert.AreEqual(0, saharaExpress.Pace, "Karawane steht, weil Last zu hoch --> nicht korrekt");
            Assert.AreEqual(38, saharaExpress.Load, "Gesamtbeladung der Karawane stimmt nicht");
        }

        /// <summary>
        ///A test for AddPackAnimal
        ///</summary>
        [TestMethod()]
        public void T06_AddPackAnimalTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(null);
            Assert.AreEqual(0, saharaExpress.Count);
            Logic.Camel willi = new Logic.Camel("Willi", 15);
            willi.Load = 10;
            saharaExpress.AddPackAnimal(willi);
            Assert.AreEqual(1, saharaExpress.Count);
            Assert.AreEqual(10, saharaExpress.Load);
            // versuch, Willi ein zweites mal in die Karawane aufzunehmen
            saharaExpress.AddPackAnimal(willi);
            Assert.AreEqual(1, saharaExpress.Count);
            Assert.AreEqual(10, saharaExpress.Load);
            // Willi entnehmen und einfügen
            saharaExpress.RemovePackAnimal(willi);
            saharaExpress.AddPackAnimal(willi);
            Assert.AreEqual(1, saharaExpress.Count);
            Assert.AreEqual(10, saharaExpress.Load);
        }

        /// <summary>
        ///A test for AddLoad
        ///</summary>
        [TestMethod()]
        public void T07_AddLoadTest()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(new Logic.Camel("Willi", 15));
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 14));
            saharaExpress.AddPackAnimal(new Logic.Horse("Moritz", 45));
            saharaExpress["Willi"]!.Load = 10;  // --> Geschw. 15- 10    = 5
            saharaExpress["Susi"]!.Load = 9;    // --> Geschw. 16 - 9    = 7
            saharaExpress["Mitzi"]!.Load = 5;   // --> Geschw. 14 - 5    = 9
            saharaExpress["Moritz"]!.Load = 3;  // --> Geschw. 45 - 10*3 = 15
            saharaExpress.AddLoad(3);
            Assert.AreEqual(5, saharaExpress.Pace, "Karawanengeschwindigkeit gesamt nicht korrekt");
            Assert.AreEqual(5, saharaExpress["Willi"]!.Pace, "Geschwindigkeit von Willi nicht korrekt");
            //! Mitzi oder Susi sind auf 6/7 oder 7/6
            // Assert.AreEqual(7, saharaExpress["Susi"].Pace, "Geschwindigkeit von Susi nicht korrekt");
            // Assert.AreEqual(7, saharaExpress["Mitzi"].Pace, "Geschwindigkeit von Mitzi nicht korrekt");
            Assert.AreEqual(15, saharaExpress["Moritz"]!.Pace, "Geschwindigkeit von Moritz nicht korrekt");
        }

        /// <summary>
        ///A test for AddLoad
        ///</summary>
        [TestMethod()]
        public void T08_AddLoadTestResillant()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            saharaExpress.AddPackAnimal(new Logic.Camel("Willi", 17));
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 13));
            saharaExpress.AddPackAnimal(new Logic.Horse("Moritz", 45));
            saharaExpress["Willi"]!.Load = 10;  // --> Geschw. 17 - 10      = 7
            saharaExpress["Susi"]!.Load = 9;    // --> Geschw. 16 - 9       = 7
            saharaExpress["Mitzi"]!.Load = 5;   // --> Geschw. 13 - 5       = 8
            saharaExpress["Moritz"]!.Load = 3;  // --> Geschw. 45 - 10*3    = 15
            saharaExpress.AddLoad(4);
            Assert.AreEqual(6, saharaExpress.Pace, "Karawanengeschwindigkeit gesamt nicht korrekt");
            Assert.AreEqual(6, saharaExpress["Willi"]!.Pace, "Geschwindigkeit von Willi nicht korrekt");
            Assert.AreEqual(6, saharaExpress["Susi"]!.Pace, "Geschwindigkeit von Susi nicht korrekt");
            Assert.AreEqual(6, saharaExpress["Mitzi"]!.Pace, "Geschwindigkeit von Mitzi nicht korrekt");
            Assert.AreEqual(15, saharaExpress["Moritz"]!.Pace, "Geschwindigkeit von Moritz nicht korrekt");
        }


        [TestMethod()]
        public void T12_ChangeCaravane()
        {
            Logic.Caravan saharaExpress = new Logic.Caravan();
            Logic.Caravan secondExpress = new Logic.Caravan();
            Logic.Camel willi = new Logic.Camel("Willi", 15);
            Logic.Horse moritz = new Logic.Horse("Moritz", 35);
            willi.Load = 4;
            moritz.Load = 3;
            saharaExpress.AddPackAnimal(willi);
            saharaExpress.AddPackAnimal(moritz);
            saharaExpress.AddPackAnimal(new Logic.Camel("Susi", 16));
            saharaExpress.AddPackAnimal(new Logic.Camel("Mitzi", 14));
            secondExpress.AddPackAnimal(new Logic.Camel("Franzi", 20));
            saharaExpress.RemovePackAnimal(willi);
            Assert.AreEqual(3, saharaExpress.Count, " Sollten nur mehr 3 Tiere sein");
            Assert.IsNull(willi.MyCaravan, "Momentan keine Karawane für Willi");
            secondExpress.AddPackAnimal(willi);
            Assert.AreEqual(2, secondExpress.Count, "Secondexpress sollte jetzt 2 Tiere haben");
            // Brutalumstieg eines Tiers
            secondExpress.AddPackAnimal(moritz);
            Assert.AreEqual(secondExpress, moritz.MyCaravan, "Moritz gehört jetzt zu secondExpress");
            Assert.AreEqual(3, secondExpress.Count, " Sollten 3 Tiere sein");
            Assert.AreEqual(2, saharaExpress.Count, " Sollten nur mehr 2 Tiere sein");
            Assert.AreEqual(3, secondExpress["Moritz"]!.Load, "Moritz Ladung gehört jetzt zu SecondExpress");
            // weiterer Brutalumstieg eines Tiers
            moritz.MyCaravan = saharaExpress;
            Assert.AreEqual(saharaExpress, moritz.MyCaravan, "Moritz gehört jetzt wieder zu Saharaexpress");
            Assert.AreEqual(3, saharaExpress["Moritz"]!.Load, "Moritz Ladung gehört jetzt auch wieder zu Saharaexpress");
            Assert.AreEqual(2, secondExpress.Count, " Sollten 2 Tiere sein");
            Assert.AreEqual(3, saharaExpress.Count, " Sollten 3 Tiere sein");
        }
    }
}