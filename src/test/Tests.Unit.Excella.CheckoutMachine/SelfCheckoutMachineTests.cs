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

        [TestCase(Constants.SkuNumbers.CHIPS, 200)]
        [TestCase(Constants.SkuNumbers.SALSA, 100)]
        [TestCase(Constants.SkuNumbers.WINE, 1000)]
        [TestCase(Constants.SkuNumbers.CIGARETTES, 500)]
        public void Scan_WithSingleItem_ExpectTotalToBePriceOfThatItem(int singleItemSku, int expectedTotal)
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(singleItemSku);
            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [TestCase(Constants.SkuNumbers.CHIPS, 400)]
        [TestCase(Constants.SkuNumbers.SALSA, 200)]
        [TestCase(Constants.SkuNumbers.WINE, 2000)]
        [TestCase(Constants.SkuNumbers.CIGARETTES, 1000)]
        public void Scan_WithTwoOfAnItem_ExpectTotalToBeTwiceTheItemPrice(int sku, int expectedTotal)
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(sku);
            sut.Scan(sku);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(expectedTotal));
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

        [Test]
        public void Scan_WithBonusCard_WhenScanningSalsa_ExpectTotalOf50()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Scan_WithBonusCard_WhenScanningMultipleSalsas_ExpectThemAllToBeHalfOff()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void Scan_WithBonusCard_WhenScanning3Chips_ExpectOnlyToBeChargedForTwo()
        {
            var sut = new SelfCheckoutMachine();

            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(400));
        }
    }
}
