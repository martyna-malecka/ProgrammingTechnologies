using System.Windows;

namespace VideoRental.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public RelayCommand ToRentalsCommand { get; set; }
        public RelayCommand ToClientsCommand { get; set; }
        public RelayCommand ToVideosCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public MainViewModel()
        {
            ToRentalsCommand = new RelayCommand(ToRentals);
            ToClientsCommand = new RelayCommand(ToClients);
            ToVideosCommand = new RelayCommand(ToVideos);
            ExitCommand = new RelayCommand(Exit);
        }

        void ToRentals(object parameter)
        {
            var win = new RentalsWindow();
            win.Show();
        }

        void ToClients(object parameter)
        {
            var win = new ClientsWindow();
            win.Show();
        }

        void ToVideos(object parameter)
        {
            var win = new VideosWindow();
            win.Show();
        }

        void Exit(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
