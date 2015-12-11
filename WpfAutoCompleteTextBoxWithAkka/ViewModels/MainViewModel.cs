namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public AutoCompleteTextBoxViewModel AutoCompleteTextBoxViewModel { get; set; }

        public MainViewModel()
        {
            AutoCompleteTextBoxViewModel = new AutoCompleteTextBoxViewModel(null);
        }
    }
}
