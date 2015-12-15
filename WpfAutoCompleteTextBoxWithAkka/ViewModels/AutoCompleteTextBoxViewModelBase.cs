using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akka.Actor;

using WpfAutoCompleteTextBoxWithAkka.Actors;

namespace WpfAutoCompleteTextBoxWithAkka.ViewModels
{
    public abstract class AutoCompleteTextBoxViewModelBase<T> : ViewModelBase //where T : class
    {
        private IActorRef _getCandidatesCoordinatorActor;

        protected AutoCompleteTextBoxViewModelBase()
        {
            _getCandidatesCoordinatorActor =
                ActorData.ActorSystem.ActorOf(
                    Props.Create(() => new GetCandidatesCoordinatorActor<T>(this, GetItems))
                        .WithDispatcher("akka.actor.synchronized-dispatcher"), ActorData.ActorPaths.GetCandidatesCoordinatorActor.Name);
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

        private void GetCandidates(string searchedText)
        {
            if (!string.IsNullOrEmpty(searchedText))
            {
                _getCandidatesCoordinatorActor.Tell(new GetCandidatesCoordinatorActor<T>.InitializeSearch(searchedText));
                CallsInProgress++;
            }
            else 
                AvailableItems = null;
        }

        public abstract Task<IEnumerable<T>> GetItems(string text);

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
            get { return CallsInProgress>0}
        }

    }
}
