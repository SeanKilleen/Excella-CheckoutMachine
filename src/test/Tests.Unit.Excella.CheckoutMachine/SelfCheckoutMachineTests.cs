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

            sut.Scan(Constants.SkuNumbers.BONUS_CARD); 

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

        [Test]
        public void Scan_WithWine_ExpectTotalOf1000()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(789);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void Scan_WithCigarettes_ExpectTotalOf500()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(111);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(500));
        }
    }
}
