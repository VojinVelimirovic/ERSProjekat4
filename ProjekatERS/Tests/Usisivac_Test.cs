using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class Usisivac_Test
    {
        private Consumer.Usisivac usisivac;

        [SetUp]
        public void Setup()
        {
            usisivac = new Consumer.Usisivac();
        }
        [Test]
        public void Usisivac_Ukljuci_jeIskljuceno_Test()
        {

            bool rezultat = usisivac.Ukljuci();
            Assert.That(rezultat, Is.True);
        }
        [Test]
        public void Usisivac_Ukljuci_jeUkljuceno_Test()
        {

            usisivac.Ukljuci();
            bool rezultat = usisivac.Ukljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Usisivac_Iskljuci_jeIskljuceno_Test()
        {

            bool rezultat = usisivac.Iskljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Usisivac_Iskljuci_jeUkljuceno_Test()
        {

            usisivac.Ukljuci();
            bool rezultat = usisivac.Iskljuci();
            Assert.That(rezultat, Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            usisivac = null;
        }
    }
}
