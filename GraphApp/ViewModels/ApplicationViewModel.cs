using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphApp.ViewModels
{
    public class ApplicationViewModel : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;
        private ICommand _displayHourlyView;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        public ApplicationViewModel()
        {
            // Add available pages
            PageViewModels.Add(new HomeViewModel());
         //   PageViewModels.Add(new ProductsViewModel());
          //  PageViewModels.Add(new DrawingViewModel());
            PageViewModels.Add(new HourlyView());


            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new MVVM.RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    NotifyPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        public ICommand DisplayHourlyView
        {
            get
            {
                if (_displayHourlyView == null)
                {
                    _displayHourlyView = new MVVM.RelayCommand(
                        param => displayView(),
                        param => (true)
                    );
                }

                return _displayHourlyView;
            }
        }

        public void displayView()
        {
            CurrentPageViewModel = PageViewModels[1];
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}
