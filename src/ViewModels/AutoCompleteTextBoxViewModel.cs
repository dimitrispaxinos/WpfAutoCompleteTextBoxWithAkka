using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akka.Actor;

using WpfAutoCompleteTextBoxWithAkka.Actors;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public class AutoCompleteTextBoxViewModel<T> : ViewModelBase
    {
        private readonly IActorRef _getCandidatesCoordinatorActor;
        private readonly Func<T> _getSelectedItem;  
        private readonly Func<string, Task<IEnumerable<T>>> _getItems;

        /// <summary>
        /// Creating the AutoCompleteTextBoxViewModel 
        /// </summary>
        /// <param name="getSelectedItem">Func to return the item to be set oecn you select an item from the list</param>
        /// <param name="getItems">Func fetching the availalbe items based on the supplied query text</param>
        public AutoCompleteTextBoxViewModel(Func<T> getSelectedItem, Func<string, Task<IEnumerable<T>>> getItems)
        {
            _getSelectedItem = getSelectedItem;
            _getItems = getItems;
            _getCandidatesCoordinatorActor =
                ActorData.ActorSystem.ActorOf(
                    Props.Create(() => new GetCandidatesCoordinatorActor<T>(this, _getItems))
                        .WithDispatcher("akka.actor.synchronized-dispatcher"), ActorData.ActorPaths.GetCandidatesCoordinatorActor.Name);
        }

        #region  Properties

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

        private int _callsInProgress;
        public int CallsInProgress
        {
            get
            {
                return _callsInProgress;
            }
            set
            {
                _callsInProgress = value;
                SendPropertyChanged(() => CallsInProgress);
                SendPropertyChanged(() => IsLoading);
            }
        }

        public bool IsLoading
        {
            get
            {
                return CallsInProgress > 0;
            }
        }

        private string _queryText;
        public string QueryText
        {
            get
            {
                return _queryText;
            }
            set
            {
                if (_queryText != value)
                {
                    _queryText = value;
                    SendPropertyChanged(() => QueryText);
                    GetCandidates(QueryText);
                }
            }
        }

        #endregion

        // Method being invoked every time the Query Text changes
        private void GetCandidates(string searchedText)
        {
            // if there is already a selected item, then we do not have to search again
            if (_getSelectedItem() != null)
                return;

            if (!string.IsNullOrEmpty(searchedText))
            {
                _getCandidatesCoordinatorActor.Tell(new GetCandidatesCoordinatorActor<T>.InitializeSearch(searchedText));
                CallsInProgress++;
            }
            else
                AvailableItems = null;
        }
    }
}
