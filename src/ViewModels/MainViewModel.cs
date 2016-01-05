namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IContactService _contactService;
        public AutoCompleteTextBoxViewModel<Contact> AutoCompleteTextBoxContactViewModel { get; set; }

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
            // An IContactService Implementation would normally be injected in the real world using an IOC Container. 
            _contactService = new ContactService();
            
            // Create an AutoCompleteTextViewModel for the Contact
            AutoCompleteTextBoxContactViewModel = new AutoCompleteTextBoxViewModel<Contact>(
                () => SelectedContact,
                _contactService.GetContactsByLastName);
        }
    }
}
