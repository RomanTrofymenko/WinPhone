using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PivotView.ViewModels
{
    public class PivotPageViewModel : INotifyPropertyChanged
    {
        private FeedViewModel _feedViewModel;

        public FeedViewModel FeedViewModel
        {
            get
            {
                return _feedViewModel;
            }
            set
            {
                _feedViewModel = value; 
                OnPropertyChanged();
            }
        }

        private ProfileViewModel _profileViewModel;

        public ProfileViewModel ProfileViewModel
        {
            get
            {
                return _profileViewModel;
            }
            set
            {
                _profileViewModel = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
