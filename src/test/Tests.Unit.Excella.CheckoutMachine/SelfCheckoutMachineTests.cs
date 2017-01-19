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

        [Test]
        public void GetTotal_WhenOnlyBonusCardScanned_Returns0()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(999); // I've chosen 999 as the bonus card SKU

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Scan_WithChips_ExpectTotalOf200()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(123); 

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void Scan_WithSalsa_ExpectTotalOf100()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(456);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(100));
        }
    }
}
