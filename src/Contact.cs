using System.Collections.Generic;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public static IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact() { FirstName = "Steve", LastName = "Jobs", City="Cupertino",  Email = "jobs@apple.com"});
            contacts.Add(new Contact() { FirstName = "John", LastName = "Doe", City ="New York", Email = "doe@gmail.com"});
            contacts.Add(new Contact() { FirstName = "Muster", LastName = "Mustermann", City = "Boston", Email = "mustermann@gmail.com"});
            contacts.Add(new Contact() { FirstName = "Albert", LastName = "Einstein", City = "Berlin", Email = "albertEinstein@gmail.com"});
            contacts.Add(new Contact() { FirstName = "Bill", LastName = "Gates", City = "Washington", Email = "gates@microsoft.com"});
            
            return contacts;
        }

    }
}
