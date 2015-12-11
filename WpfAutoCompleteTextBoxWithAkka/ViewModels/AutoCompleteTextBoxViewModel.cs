using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class AutoCompleteTextBoxViewModel : AutoCompleteTextBoxViewModelBase<string>
    {
        public AutoCompleteTextBoxViewModel(string itemToBeSet)
            : base(itemToBeSet)
        {
        }

        public override async Task<IEnumerable<string>> GetItems(string text)
        {
            var list = new List<string>();
            list.Add("Sebastian");
            list.Add("Manu");
            list.Add("Dimitris");
            list.Add("Ingo");
            list.Add("Vladimir");
            list.Add("Arpad");
            list.Add("Jacob");
            //await Task.Delay(1000);
            return list.Where(x=>x.ToLower().Contains(text));
        }
        
    }
}
