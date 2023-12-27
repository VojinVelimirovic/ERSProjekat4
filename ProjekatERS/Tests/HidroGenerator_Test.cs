using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class HidroGenerator_Test
    {
        //jednostavni testovi metoda
        public Generators.HidroGenerator hidrogenerator;

        [SetUp]
        public void Setup()
        {
            hidrogenerator = new Generators.HidroGenerator("Test");
        }

        [Test]
        public void Snaga_PromenaSnage_JeUGranicama_Test()
        {
            hidrogenerator.PromenaSnage();
            Assert.That(hidrogenerator.Snaga, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void Teardown()
        {
            hidrogenerator = null;
        }
    }
}
