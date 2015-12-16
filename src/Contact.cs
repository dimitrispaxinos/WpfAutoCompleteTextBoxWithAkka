using System.Collections.Generic;

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
            contacts.Add(new Contact() { FirstName = "Steve", LastName = "Jobs" });
            contacts.Add(new Contact() { FirstName = "John", LastName = "Doe" });
            contacts.Add(new Contact() { FirstName = "Muster", LastName = "Mustermann" });
            contacts.Add(new Contact() { FirstName = "Albert", LastName = "Einstein" });
            contacts.Add(new Contact() { FirstName = "Bill", LastName = "Gates" });
            
            return contacts;
        }

    }
}
