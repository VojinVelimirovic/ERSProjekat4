using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class Bojler_Test
    {
        public Consumer.Bojler bojler;

        [SetUp]
        public void Setup()
        {
            bojler = new Consumer.Bojler();
        }
        [Test]
        public void Bojler_Ukljuci_jeIskljuceno_Test()
        {
            
            bool rezultat = bojler.Ukljuci();
            Assert.That(rezultat, Is.True);
        }
        [Test]
        public void Bojler_Ukljuci_jeUkljuceno_Test()
        {
            
            bojler.Ukljuci();
            bool rezultat = bojler.Ukljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Bojler_Iskljuci_jeIskljuceno_Test()
        {
            
            bool rezultat = bojler.Iskljuci();
            Assert.That(rezultat, Is.False);
        }
        [Test]
        public void Bojler_Iskljuci_jeUkljuceno_Test()
        {
            
            bojler.Ukljuci();
            bool rezultat = bojler.Iskljuci();
            Assert.That(rezultat, Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            bojler = null;
        }
    }
}
