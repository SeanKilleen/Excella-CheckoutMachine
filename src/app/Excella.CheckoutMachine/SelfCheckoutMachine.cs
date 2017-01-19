﻿namespace Excella.CheckoutMachine
{
    public class SelfCheckoutMachine
    {
        private int _total;

        private bool _bonusCardScanned = false;
        private int salsaCount = 0;
        public int GetTotal()
        {
            int discount = 0;
            if (_bonusCardScanned)
            {
                discount = discount + (salsaCount*50);
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
                _total += 500;
            }
        }
    }
}
