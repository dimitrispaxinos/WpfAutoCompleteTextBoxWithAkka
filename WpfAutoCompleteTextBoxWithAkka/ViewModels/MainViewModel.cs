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
                //if (_selectedContact != value)
                //{
                _selectedContact = value;
                SendPropertyChanged(() => SelectedContact);
                //}
            }
        }

        public MainViewModel()
        {
            //AutoCompleteTextBoxViewModel = new AutoCompleteTextBoxViewModel(null);
            AutoCompleteTextBoxContactViewModel = new AutoCompleteTextBoxContactViewModel(null);
        }
    }
}
