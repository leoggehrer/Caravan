using Caravan.Logic;

namespace Caravan.UnitTest
{
    [TestClass]
    public class PackAnimalUnitTest
    {
        [TestMethod()]
        public void T01_CamelConstructorTest()
        {
            Camel willi = new Camel("willi", 10);
            Assert.AreEqual(10, willi.Pace, "Geschw. 10 nicht korrekt");
            Camel franzi = new Camel("Franzi", -5);
            Assert.AreEqual(0, franzi.Pace, "Geschw. -5 nicht korrekt");
            Camel susi = new Camel("Susi", 80);
            Assert.AreEqual(20, susi.Pace, "Geschw. 80 nicht korrekt");
        }
    }
}
