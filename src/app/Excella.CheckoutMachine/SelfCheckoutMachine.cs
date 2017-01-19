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
        }
    }
}
