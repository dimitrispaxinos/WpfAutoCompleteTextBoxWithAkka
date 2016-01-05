using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsByLastName(string lastName);
    }
}
