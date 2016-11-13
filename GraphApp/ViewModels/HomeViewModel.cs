using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp.ViewModels
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        private int _productId;

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
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
    }
}
