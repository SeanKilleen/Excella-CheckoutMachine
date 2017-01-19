using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Unit.Excella.CheckoutMachine
{
    public class CheckoutMachineTests
    {
        [Test]
        public void GetTotal_WithNoItemsScanned_Returns0()
        {
            var sut = new CheckoutMachine();

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
