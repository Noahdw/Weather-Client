
using GraphApp.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System.Windows;

namespace GraphApp.ViewModels
{

    public class ProductsViewModel : ObservableObject, IPageViewModel
    {
 
        #region Fields
        private ObservableCollection<GraphInfo> _tableOfValues;
        private string _vertex;
        private double _firstTerm;
        private double _secondTerm;
        private double _thirdTerm;
        private ProductModel _currentProduct;
        private ICommand _getProductCommand;
        private ICommand _displayGraphCommand;
        private ObservableCollection<Line> _lineList;

        #endregion

        #region Properties/Commands

        public ObservableCollection<Line> LineList
        {
            get { return _lineList; }
            set
            {
                _lineList = value;
                NotifyPropertyChanged("LineList");
            }
        }

        public ObservableCollection<GraphInfo> TableOfValues
        {
            get { return _tableOfValues; }
            set
            {
                _tableOfValues = value;
                NotifyPropertyChanged("TableOfValues");
            }
        }

        public string Name
        {
            get { return "Products"; }
        }
        public string Vertex
        {
            get { return _vertex; }
            set
            {
                _vertex = value;
                NotifyPropertyChanged("Vertex");
            }
        }

        public double FirstTerm
        {
            get { return _firstTerm; }
            set
            {
                if (value != _firstTerm)
                {
                    _firstTerm = value;
                    NotifyPropertyChanged("FirstTerm");
                }
            }
        }

        public double SecondTerm
        {
            get { return _secondTerm; }
            set
            {
                if (value != _secondTerm)
                {
                    _secondTerm = value;
                    NotifyPropertyChanged("SecondTerm");
                }
            }
        }

        public double ThirdTerm
        {
            get { return _thirdTerm; }
            set
            {
                if (value != _thirdTerm)
                {
                    _thirdTerm = value;
                    NotifyPropertyChanged("ThirdTerm");
                }
            }
        }

        public ProductModel CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                if (value != _currentProduct)
                {
                    _currentProduct = value;
                    NotifyPropertyChanged("CurrentProduct");
                }
            }
        }

        public ICommand GetProductCommand
        {
            get
            {
                if (_getProductCommand == null)
                {
                    _getProductCommand = new RelayCommand(
                        param => GetProduct(),
                        param => FirstTerm > 0
                    );
                }
                return _getProductCommand;
            }
        }

        public ICommand DisplayGraphCommand
        {
            get
            {
                if (_displayGraphCommand == null)
                {
                    _displayGraphCommand = new RelayCommand(
                        param => calculateValues(),
                        param => (true)
                    );
                }

                return _displayGraphCommand;
            }
        }

        #endregion

        #region Methods

        private void GetProduct()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            ProductModel p = new ProductModel();
            // p.ProductId = FirstTerm;
            p.ProductName = "Test Product";
            p.UnitPrice = 10;
            CurrentProduct = p;
        }

        private void calculateValues()
        {
            TableOfValues = null;
            LineList = null;
            TableOfValues = new ObservableCollection<GraphInfo>();
            LineList = new ObservableCollection<Line>();
            int offSet = 50;

            double vX = (-1 * SecondTerm) / (2 * FirstTerm);
            double vY = (Math.Pow(vX, 2) * FirstTerm) + (vX * SecondTerm) + ThirdTerm;
            Math.Round(vX, 2);
            Math.Round(vY, 2);
            Point pVertex = new Point(vX, vY);
            Vertex = pVertex.ToString();

            //Populates a 20 size list with X values and corresponding ax^2 +bx +c =y values
            for (int x = -11; x <= 10; x++)
            {
                double total,total2;
             
                total = (Math.Pow(x, 2) * FirstTerm) + (x * SecondTerm) + ThirdTerm;
                total2 = (Math.Pow(x+1, 2) * FirstTerm) + ((x+1) * SecondTerm) + ThirdTerm;

                GraphInfo info = new GraphInfo(x, total);
                TableOfValues.Add(info);
                
                LineList.Add(new Line { From = new Point(x+offSet,-1*total+offSet), To = new Point(x+1+offSet,-1*total2+offSet) });
            }

        }

        private void SetUpModel()
        {

        }


        public void drawGraph()
        {
          
        }

        #endregion
    }

    public class GraphInfo
    {
        public GraphInfo(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
    public class Line
    {
        public Point From { get; set; }
        public Point To { get; set; }
    }
}
