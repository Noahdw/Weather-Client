using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GraphApp.MVVM;

namespace GraphApp.ViewModels
{
    class DrawingViewModel : ObservableObject, IPageViewModel
    {
        private ICommand _createGraph;
        private ObservableCollection<Graphlines> _graphLineList;
        private int _yOffset;
        private int _xOffset;

        public DrawingViewModel()
        {
            YOffSet = 10;
            XOffSet = 10;
            drawLines();
        }
        public int XOffSet
        {
            get { return _xOffset; }
            set
            {
                _xOffset = value;
                NotifyPropertyChanged("XOffSet");
            }
        }
        public int YOffSet
        {
            get { return _yOffset; }
            set
            {
                _yOffset = value;
                NotifyPropertyChanged("YOffSet");
            }
        }

        public ObservableCollection<Graphlines> GraphLineList
        {
            get { return _graphLineList; }
            set
            {
                _graphLineList = value;
                NotifyPropertyChanged("GraphLineList");
            }
        }

        public ICommand CreateGraph
        {
            get
            {
                if (_createGraph == null)
                {
                    _createGraph = new RelayCommand(
                        param => drawLines(),
                        param => (true)
                    );
                }

                return _createGraph;
            }
        }

        public void drawLines()
        {
            GraphLineList = null;
            GraphLineList = new ObservableCollection<Graphlines>();
            if (YOffSet!=0 && XOffSet !=0)
            {


                for (int x = 0; x <= 250; x += XOffSet)
                {
                    GraphLineList.Add(new Graphlines { From = new Point(x, 0), To = new Point(x, 250), });
                    if (x%2==0)
                    {
                        for (int q = 0; q <= 250; q+=YOffSet*2)
                        {
                            for (int i = x; i < x + XOffSet; i++)
                            {
                                GraphLineList.Add(new Graphlines { From = new Point(i, q), To = new Point(i, q+YOffSet) });
                            }
                        }
                        
                    }
                }
                for (int y = 0; y <= 250; y += YOffSet)
                {
                    GraphLineList.Add(new Graphlines { From = new Point(0, y), To = new Point(250, y) });
                }
            }
        }







        public string Name
        {
            get
            {
                return "Drawing";
            }
        }


    }

    public class Graphlines
    {
        public Point From { get; set; }
        public Point To { get; set; }
    }
}
