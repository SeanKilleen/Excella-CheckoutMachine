using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excella.CheckoutMachine
{
    public interface IInventoryControlSystem
    {
        void LogScannedItem(int sku);
    }
}
