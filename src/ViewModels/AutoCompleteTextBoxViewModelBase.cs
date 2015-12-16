using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akka.Actor;

using WpfAutoCompleteTextBoxWithAkka.Actors;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public abstract class AutoCompleteTextBoxViewModelBase<T> : ViewModelBase
    {
        private readonly IActorRef _getCandidatesCoordinatorActor;
        // Using a func to get the selected item instead of a reference that could be null
        private readonly Func<T> _getSelectedItem;

        protected AutoCompleteTextBoxViewModelBase(Func<T> getSelectedItem)
        {
            _getSelectedItem = getSelectedItem;
            _getCandidatesCoordinatorActor =
                ActorData.ActorSystem.ActorOf(
                    Props.Create(() => new GetCandidatesCoordinatorActor<T>(this, GetItems))
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

        /// <summary>
        /// Implement the data retrieval. Call a service to get the 
        /// data and act apuon them perhaps
        /// </summary>
        /// <param name="text">This is the Query Text</param>
        /// <returns></returns>
        public abstract Task<IEnumerable<T>> GetItems(string text);

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
