namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public AutoCompleteTextBoxViewModel AutoCompleteTextBoxViewModel { get; set; }

        public AutoCompleteTextBoxContactViewModel AutoCompleteTextBoxContactViewModel { get; set; }


        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                SendPropertyChanged(() => SelectedContact);
            }
        }

        public MainViewModel()
        {
            AutoCompleteTextBoxContactViewModel = new AutoCompleteTextBoxContactViewModel();
        }
    }
}
