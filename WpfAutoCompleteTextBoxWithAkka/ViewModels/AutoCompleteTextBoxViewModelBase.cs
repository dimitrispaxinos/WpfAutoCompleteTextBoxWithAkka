using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akka.Actor;

using WpfAutoCompleteTextBoxWithAkka.Actors;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public abstract class AutoCompleteTextBoxViewModelBase<T> : ViewModelBase //where T : class
    {
        private T _itemToBeSet;
        private IActorRef _getCandidatesCoordinatorActor;


        protected AutoCompleteTextBoxViewModelBase(T itemToBeSet)
        {
            _itemToBeSet = itemToBeSet;
            _getCandidatesCoordinatorActor =
                ActorData.ActorSystem.ActorOf(
                    Props.Create(() => new GetCandidatesCoordinatorActor<T>(this, GetItems))
                        .WithDispatcher("akka.actor.synchronized-dispatcher"), ActorData.ActorPaths.GetCandidatesCoordinatorActor.Name);
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
                //if (_selectedItem != value)
                //{
                _selectedItem = value;
                SendPropertyChanged(() => SelectedItem);
                //}
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
                    SendPropertyChanged(() => SearchedText);
                    GetCandidates(SearchedText);
                }
            }
        }

        private void GetCandidates(string searchedText)
        {
            if (!string.IsNullOrEmpty(searchedText)) _getCandidatesCoordinatorActor.Tell(new GetCandidatesCoordinatorActor<T>.InitializeSearch(searchedText));
            else AvailableItems = null;
        }

        public abstract Task<IEnumerable<T>> GetItems(string text);
    }
}
