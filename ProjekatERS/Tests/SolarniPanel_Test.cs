using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ProjekatERS.Tests
{
    [TestFixture]
    class SolarniPanel_Test
    {
        public Generators.SolarniPanel solarniPanel;

        [SetUp]
        public void Setup()
        {
            solarniPanel = new Generators.SolarniPanel("Test");
        }

        [Test]
        public void Snaga_PromenaSnage_JeUGranicama_Test()
        {
            solarniPanel.PromenaSnage();
            Assert.That(solarniPanel.Snaga, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void Teardown()
        {
            solarniPanel = null;
        }
    }
}
