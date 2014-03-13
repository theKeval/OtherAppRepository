using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private VideosViewModel _videosViewModel;
       private AboutIndiasGotTalentViewModel _aboutIndiasGotTalentViewModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModels()
        {
            _selectedItem = VideosViewModel;
        }
 
        public VideosViewModel VideosViewModel
        {
            get { return _videosViewModel ?? (_videosViewModel = new VideosViewModel()); }
        }
 
        public AboutIndiasGotTalentViewModel AboutIndiasGotTalentViewModel
        {
            get { return _aboutIndiasGotTalentViewModel ?? (_aboutIndiasGotTalentViewModel = new AboutIndiasGotTalentViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            VideosViewModel.ViewType = viewType;
            AboutIndiasGotTalentViewModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == VideosViewModel)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsLockScreenVisible
        {
            get { return SelectedItem == null || SelectedItem == VideosViewModel; }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == VideosViewModel; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsLockScreenVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                VideosViewModel.LoadItems(isNetworkAvailable),
                AboutIndiasGotTalentViewModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("LockScreenImage.jpg");
                });
            }
        }
    }
}
