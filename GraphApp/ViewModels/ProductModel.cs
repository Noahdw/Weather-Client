using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp
{
    public class ProductModel : ObservableObject
    {
        #region Fields

        private int _productId;
        private string _productName;
        private decimal _unitPrice;

        #endregion // Fields

        #region Properties

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value != _productId)
                {
                    _productId = value;
                    NotifyPropertyChanged("ProductId");
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value != _productName)
                {
                    _productName = value;
                    NotifyPropertyChanged("ProductName");
                }
            }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (value != _unitPrice)
                {
                    _unitPrice = value;
                    NotifyPropertyChanged("UnitPrice");
                }
            }
        }

        #endregion // Properties
    }
}
