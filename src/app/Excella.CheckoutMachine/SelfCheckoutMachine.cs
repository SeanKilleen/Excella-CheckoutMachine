using System;

namespace Excella.CheckoutMachine
{
    public class SelfCheckoutMachine
    {
        private int _total;

        private bool _bonusCardScanned = false;
        private int salsaCount = 0;
        private int chipCount = 0;
        private int tobaccoCount = 0;
        public int GetTotal()
        {
            int discount = 0;
            _total = _total + (50 * tobaccoCount);
            if (_bonusCardScanned)
            {
                discount = discount + (salsaCount*50);

                var threeChipGroups = chipCount/3.0;
                var chipDeals = Convert.ToInt32(Math.Floor(threeChipGroups));
                discount = discount + (200*chipDeals);
            }
            return _total - discount;
        }

        public void Scan(int SKU)
        {
            if (SKU == Constants.SkuNumbers.BONUS_CARD)
            {
                _bonusCardScanned = true;
            }
            if (SKU == Constants.SkuNumbers.CHIPS)
            {
                chipCount++;
                _total += 200;
            }
            if (SKU == Constants.SkuNumbers.SALSA)
            {
                salsaCount++;
                _total += 100;
            }
            if (SKU == Constants.SkuNumbers.WINE)
            {
                _total += 1000;
            }
            if (SKU == Constants.SkuNumbers.CIGARETTES)
            {
                tobaccoCount++;
                _total += 500;
            }
        }
    }
}
