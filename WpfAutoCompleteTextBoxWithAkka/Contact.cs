using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact() { FirstName = "Dimitris", LastName = "Paxinos" });
            contacts.Add(new Contact() { FirstName = "Sebastian", LastName = "Braune" });
            contacts.Add(new Contact() { FirstName = "Ingo", LastName = "Strauch" });
            contacts.Add(new Contact() { FirstName = "Manuel", LastName = "Saegebrecht" });
            contacts.Add(new Contact() { FirstName = "Vladimir", LastName = "Tasic" });
        }

    }
}
