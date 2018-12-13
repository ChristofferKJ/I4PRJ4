using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Services;
using NUnit.Framework;
using NSubstitute;
using App1.ViewModel;

namespace App1.Unit.Test
{
    [TestFixture]
    class UserViewModelTest
    {
        private UserViewModel _uut;
        [SetUp]
        public void setup()
        {
            UserServices us = Substitute.For<UserServices>();
            //Test noget venneste venne ven
        }
        [Test]
        public void TestIfConstructorCallsService()
        {

        }
    }
}
