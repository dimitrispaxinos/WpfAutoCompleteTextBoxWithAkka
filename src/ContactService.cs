using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public class ContactService : IContactService
    {
        private static IEnumerable<Contact> Contacts = GetContacts();

        private static IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact() { FirstName = "Steve", LastName = "Jobs", City = "Cupertino", Email = "jobs@apple.com" });
            contacts.Add(new Contact() { FirstName = "John", LastName = "Doe", City = "New York", Email = "doe@gmail.com" });
            contacts.Add(new Contact() { FirstName = "Muster", LastName = "Mustermann", City = "Boston", Email = "mustermann@gmail.com" });
            contacts.Add(new Contact() { FirstName = "Albert", LastName = "Einstein", City = "Berlin", Email = "albertEinstein@gmail.com" });
            contacts.Add(new Contact() { FirstName = "Bill", LastName = "Gates", City = "Washington", Email = "gates@microsoft.com" });

            return contacts;
        }

        // Faking a sevice call and adding a delay
        public async Task<IEnumerable<Contact>> GetContactsByLastName(string lastName)
        {
            await Task.Delay(1500);
            return Contacts.Where(con => con.LastName.Contains(lastName));
        }
    }
}
