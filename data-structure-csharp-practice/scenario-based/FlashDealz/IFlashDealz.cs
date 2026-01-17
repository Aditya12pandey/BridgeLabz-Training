using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FlashDealz
{
    internal interface IFlashDealz
    {
        void AddProduct(string name, double price, double discount);
        void DisplayAllProducts();
        void SortByDiscountDesc();
        void DisplayTopN(int n);

    }
}
