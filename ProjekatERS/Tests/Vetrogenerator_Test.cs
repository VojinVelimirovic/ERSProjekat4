using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjekatERS.Tests
{
    [TestFixture]
    class Vetrogenerator_Test
    {
        public Generators.Vetrogenerator vetrogenerator;

        [SetUp]
        public void Setup()
        {
            vetrogenerator = new Generators.Vetrogenerator("Test");
        }

        [Test]
        public void Snaga_PromenaSnage_JeUGranicama_Test()
        {
            vetrogenerator.PromenaSnage();
            Assert.That(vetrogenerator.Snaga, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void Teardown()
        {
            vetrogenerator = null;
        }
    }
}
