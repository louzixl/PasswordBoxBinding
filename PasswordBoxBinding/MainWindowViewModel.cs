using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PasswordBoxBinding
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _password;

        public string Password
        {
            get => _password;
            set 
            { 
                _password = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand ClickedCommand => _clickedCommand ?? (_clickedCommand = new DelegateCommand { ExecuteAction = OnClicked });

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnClicked(object o) => MessageBox.Show($"password: {Password}");

        public event PropertyChangedEventHandler PropertyChanged;

        private DelegateCommand _clickedCommand;
    }
}
