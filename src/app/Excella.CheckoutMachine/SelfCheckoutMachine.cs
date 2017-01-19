namespace Excella.CheckoutMachine
{
    public class SelfCheckoutMachine
    {
        private int _total;

        public int GetTotal()
        {
            return _total;
        }

        public void Scan(int SKU)
        {
            if (SKU == Constants.SkuNumbers.CHIPS)
            {
                _total = 200;
            }
            if (SKU == 456)
            {
                _total = 100;
            }
            if (SKU == 789)
            {
                _total = 1000;
            }
            if (SKU == 111)
            {
                _total = 500;
            }
        }
    }
}
