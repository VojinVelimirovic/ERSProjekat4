using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class HidroElektrana_Test
    {
        //jednostavni testovi metoda
        public PowerPlant.Hidroelektrana hidroElektrana;

        [SetUp]
        public void Setup()
        {
            hidroElektrana = new PowerPlant.Hidroelektrana();
        }

        [TestCase(-1)]
        [TestCase(101)]
        public void HidroElektrana_PromenaProizvodnje_JeUGranicama_Test(int losProcenat)
        {
            hidroElektrana.PromenaProizvodnje(losProcenat);
            Assert.That(hidroElektrana.Proizvodnja, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void Teardown()
        {
            hidroElektrana = null;
        }
    }
}
