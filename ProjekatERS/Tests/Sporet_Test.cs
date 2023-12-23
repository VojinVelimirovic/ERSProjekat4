using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class Sporet_Test
    {
        //jednostavni testovi metoda
        private Consumer.Sporet sporet;

        [SetUp]
        public void Setup()
        {
            sporet = new Consumer.Sporet();
        }
        [Test]
        public void Sporet_Ukljuci_jeIskljuceno_Test()
        {

            bool rezultat = sporet.Ukljuci();
            Assert.That(rezultat, Is.True);
        }
        [Test]
        public void Sporet_Ukljuci_jeUkljuceno_Test()
        {

            sporet.Ukljuci();
            bool rezultat = sporet.Ukljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Sporet_Iskljuci_jeIskljuceno_Test()
        {

            bool rezultat = sporet.Iskljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Sporet_Iskljuci_jeUkljuceno_Test()
        {

            sporet.Ukljuci();
            bool rezultat = sporet.Iskljuci();
            Assert.That(rezultat, Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            sporet = null;
        }
    }
}
