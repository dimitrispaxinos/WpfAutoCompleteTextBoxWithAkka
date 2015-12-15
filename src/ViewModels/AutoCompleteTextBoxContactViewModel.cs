using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class AutoCompleteTextBoxContactViewModel : AutoCompleteTextBoxViewModelBase<Contact>
    {
        public async override Task<IEnumerable<Contact>> GetItems(string text)
        {
            await Task.Delay(1500);
            return Contact.GetContacts().Where(x => x.LastName.ToLower().Contains(text.ToLower()));
        }
    }
}
