using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class AutoCompleteTextBoxContactViewModel : AutoCompleteTextBoxViewModelBase<Contact>
    {
        public AutoCompleteTextBoxContactViewModel(Contact itemToBeSet)
            : base(itemToBeSet)
        {
        }

        public async override Task<IEnumerable<Contact>> GetItems(string text)
        {
            return Contact.GetContacts().Where(x => x.LastName.StartsWith(text, true, CultureInfo.InvariantCulture));
        }
    }
}
