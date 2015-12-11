using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public class MainViewModel : ViewModelBase
    {
        public AutoCompleteTextBoxViewModel AutoCompleteTextBoxViewModel { get; set; }

        public MainViewModel()
        {
            AutoCompleteTextBoxViewModel = new AutoCompleteTextBoxViewModel(null);
        }

        //private string _searchedText;
        //public string SearchedText
        //{
        //    get
        //    {
        //        return _searchedText;
        //    }
        //    set
        //    {
        //        if (_searchedText != value)
        //        {
        //            _searchedText = value;
        //            SendPropertyChanged(() => SearchedText);
        //        }
        //    }
        //}

        //private string _selectedItem;
        //public string SelectedItem
        //{
        //    get
        //    {
        //        return _selectedItem;
        //    }
        //    set
        //    {
        //        if (_selectedItem != value)
        //        {
        //            _selectedItem = value;
        //            SendPropertyChanged(() => SelectedItem);
        //        }
        //    }
        //}


    }
}
