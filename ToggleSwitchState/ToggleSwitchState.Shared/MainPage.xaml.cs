using System.ComponentModel;
using System.Threading.Tasks;

namespace ToggleSwitchState
{
    public class VM : INotifyPropertyChanged
    {
      internal  bool _isEnabled;
        public bool IsEnabled => _isEnabled;
        bool _isOn;
        public bool IsOn { get => _isOn;  set { _isOn = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    public sealed partial class MainPage
    {
        public MainPage()
        {
            VM = new VM() ;
            this.InitializeComponent();
            Loaded += async (s, e) =>
            {
                VM.IsOn = true;
                VM.Notify("IsOn");
                VM._isEnabled = false;
                VM.Notify("IsEnabled");
                VM.IsOn = false;
                VM.Notify("IsOn");
                VM._isEnabled = true;
                VM.Notify("IsEnabled");
                VM._isEnabled = true;
                VM.Notify("IsEnabled");
            };
        }

        public VM VM { get; set; }
    }
}
