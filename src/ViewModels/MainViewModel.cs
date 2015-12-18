using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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
            AutoCompleteTextBoxContactViewModel = new AutoCompleteTextBoxViewModel<Contact>(() => SelectedContact, GetItems);
        }

        // Mehtod to be passed at the creation of the AutoCompleteTextBoxContactViewModel for data retrieval
        public async Task<IEnumerable<Contact>> GetItems(string text)
        {
            await Task.Delay(500);
            return Contact.GetContacts().Where(x => x.LastName.ToLower().Contains(text.ToLower()));
        }
    }
}
