using NUnit.Framework;
using Excella.CheckoutMachine;
using Moq;

namespace Tests.Unit.Excella.CheckoutMachine
{
    public class SelfCheckoutMachineTests
    {
        private SelfCheckoutMachine sut;
        private Mock<IInventoryControlSystem> mockInventoryControl;

        [SetUp]
        public void Setup()
        {
            mockInventoryControl = new Mock<IInventoryControlSystem>();
            sut = new SelfCheckoutMachine(mockInventoryControl.Object);
        }

        [Test]
        public void GetTotal_WithNoItemsScanned_Returns0()
        {
            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetTotal_WhenOnlyBonusCardScanned_Returns0()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD); 

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase(Constants.SkuNumbers.CHIPS, 200)]
        [TestCase(Constants.SkuNumbers.SALSA, 100)]
        [TestCase(Constants.SkuNumbers.WINE, 1000)]
        [TestCase(Constants.SkuNumbers.CIGARETTES, 550)]
        public void Scan_WithSingleItem_ExpectTotalToBePriceOfThatItem(int singleItemSku, int expectedTotal)
        {
            sut.Scan(singleItemSku);
            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [TestCase(Constants.SkuNumbers.CHIPS, 400)]
        [TestCase(Constants.SkuNumbers.SALSA, 200)]
        [TestCase(Constants.SkuNumbers.WINE, 2000)]
        [TestCase(Constants.SkuNumbers.CIGARETTES, 1100)]
        public void Scan_WithTwoOfAnItem_ExpectTotalToBeTwiceTheItemPrice(int sku, int expectedTotal)
        {
            sut.Scan(sku);
            sut.Scan(sku);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void Scan_WithOneOfEachItem_ExpectTotalOf1850()
        {
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.WINE);
            sut.Scan(Constants.SkuNumbers.CIGARETTES);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1850));
        }

        [Test]
        public void Scan_WithBonusCard_WhenScanningSalsa_ExpectTotalOf50()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Scan_WithBonusCard_WhenScanningMultipleSalsas_ExpectThemAllToBeHalfOff()
        {
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
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(400));
        }
        [Test]
        public void Scan_WithBonusCard_WhenScanning4Chips_OnlyDiscountsForOneGroup()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(600));
        }

        [Test]
        public void Scan_WithBonusCard_WhenScanning6Chips_DiscountsTwice()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(800));
        }
        [Test]
        public void Scan_WithBonusCard_WhenScanning7Chips_DiscountsTwiceOnly()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void Scan_WithBonusCard_AndBothKindsOfBonusDeals_ReturnsExpectedTotal()
        {
            sut.Scan(Constants.SkuNumbers.BONUS_CARD);

            // 7 Chips = 2 deals (800) + 1 = 1000
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);
            sut.Scan(Constants.SkuNumbers.CHIPS);

            // 3 Salsas = 3 deals (3*50) = 150
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.SALSA);
            sut.Scan(Constants.SkuNumbers.SALSA);

            var result = sut.GetTotal();

            Assert.That(result, Is.EqualTo(1150));
        }

        [Test]
        public void Scan_Cigarettes_WithTobaccoSurcharge_ExpectTotalToBe550()
        {
            sut.Scan(Constants.SkuNumbers.CIGARETTES);

            var total = sut.GetTotal();

            Assert.That(total, Is.EqualTo(550));
        }

        [TestCase(Constants.SkuNumbers.CHIPS)]
        [TestCase(Constants.SkuNumbers.SALSA)]
        [TestCase(Constants.SkuNumbers.WINE)]
        [TestCase(Constants.SkuNumbers.CIGARETTES)]
        public void Scan_AnyProduct_LogsItToInventoryControl(int skuToTest)
        {
            var mockInventoryControl = new Mock<IInventoryControlSystem>();
            var sut = new SelfCheckoutMachine(mockInventoryControl.Object);

            sut.Scan(skuToTest);

            mockInventoryControl.Verify(x=>x.LogScannedItem(skuToTest), Times.Once);
        }
    }
}
