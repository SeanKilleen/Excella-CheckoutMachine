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

            sut.Scan(Constants.SkuNumbers.CHIPS); 

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void Scan_WithSalsa_ExpectTotalOf100()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void Scan_WithWine_ExpectTotalOf1000()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.WINE);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void Scan_WithCigarettes_ExpectTotalOf500()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.CIGARETTES);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(500));
        }


        [Test]
        public void Scan_WithTwoBagsOfChips_ExpectTotalOf400()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(400));
        }

        [Test]
        public void Scan_WithTwoSalsas_ExpectTotalOf200()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(200));
        }
        [Test]
        public void Scan_WithTwoWines_ExpectTotalOf2000()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.WINE);
            sut.Scan(Constants.SkuNumbers.WINE);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(2000));
        }
        [Test]
        public void Scan_WithTwoCigarettes_ExpectTotalOf1000()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.CIGARETTES);
            sut.Scan(Constants.SkuNumbers.CIGARETTES);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1000));
        }
        [Test]
        public void Scan_WithOneOfEachItem_ExpectTotalOf1800()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.WINE);
            sut.Scan(Constants.SkuNumbers.CIGARETTES);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1800));
        }
    }
}
