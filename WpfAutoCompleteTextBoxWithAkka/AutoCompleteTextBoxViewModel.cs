using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
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
            list.Add("Item1");
            list.Add("Item2");
            list.Add("Item3");
            list.Add("Item4");
            list.Add("Item5");
            await Task.Delay(2000);
            return list;
        }
        
    }
}
