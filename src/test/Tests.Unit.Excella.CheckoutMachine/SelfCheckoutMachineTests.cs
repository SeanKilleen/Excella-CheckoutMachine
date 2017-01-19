using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Excella.CheckoutMachine;
namespace Tests.Unit.Excella.CheckoutMachine
{
    public class SelfCheckoutMachineTests
    {
        [Test]
        public void GetTotal_WithNoItemsScanned_Returns0()
        {
            var sut = new SelfCheckoutMachine();

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
