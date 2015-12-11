using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public class AutoCompleteTextBoxViewModel<T> : ViewModelBase where T : class
    {
        private readonly Func<string, Task<IEnumerable<T>>> _itemGetter;
        private T _itemToBeSet;

        
        public AutoCompleteTextBoxViewModel(T itemToBeSet, Func<string, Task<IEnumerable<T>>> itemGetter)
        {
            _itemToBeSet = itemToBeSet;
            _itemGetter = itemGetter;
        }

        private T _selectedItem;
        public T SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    SendPropertyChanged(() => SelectedItem);
                }
            }
        }

        private ObservableCollection<T> _availableItems;
        public ObservableCollection<T> AvailableItems
        {
            get
            {
                return _availableItems;
            }
            set
            {
                if (_availableItems != value)
                {
                    _availableItems = value;
                    SendPropertyChanged(() => AvailableItems);
                }
            }
        }

        private string _searchedText;

        public string SearchedText
        {
            get
            {
                return _searchedText;
            }
            set
            {
                if (_searchedText != value)
                {
                    _searchedText = value;
                    SendPropertyChanged(()=>SearchedText);
                    GetCandidates(SearchedText);
                }
            }
        }

        private void GetCandidates(string searchedText)
        {
            throw new NotImplementedException();
        }
    }
}
