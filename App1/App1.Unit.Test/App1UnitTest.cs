using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace App1.Unit.Test
{
    [TestFixture]
    public class App1UnitTest
    {
        [Test]
        public void TestTest()
        {
            Assert.That(2 + 2,Is.EqualTo(4));
        }
    }
}
