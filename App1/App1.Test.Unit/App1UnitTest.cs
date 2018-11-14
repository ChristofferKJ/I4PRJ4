using System;
using NUnit.Framework;

namespace App1.Test.Unit
{

    [TestFixture]
    public class App1UnitTest
    {
        [Test]
        public void TestTest()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }
    }
}
