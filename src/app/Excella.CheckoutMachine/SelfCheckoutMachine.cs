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
            if (SKU == 123)
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
        }
    }
}
