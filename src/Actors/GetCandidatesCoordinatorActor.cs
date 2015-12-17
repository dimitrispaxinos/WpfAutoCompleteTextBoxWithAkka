using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akka.Actor;

using WpfAutoCompleteTextBoxWithAkka.ViewModels;

namespace WpfAutoCompleteTextBoxWithAkka.Actors
{
    public class GetCandidatesCoordinatorActor<T> : ReceiveActor
    {
        #region Messages

        public class CandidatesResults<T>
        {
            public IEnumerable<T> Results { get; private set; }
            public string TextToMatch { get; private set; }

            public CandidatesResults(string textToMatch, IEnumerable<T> results)
            {
                TextToMatch = textToMatch;
                Results = results;
            }
        }

        public class InitializeSearch
        {
            public InitializeSearch(string textToMatch)
            {
                TextToMatch = textToMatch;
            }

            public string TextToMatch { get; private set; }
        }

        #endregion

        private readonly Func<string, Task<IEnumerable<T>>> _itemGetter;

        private readonly AutoCompleteTextBoxViewModel<T> _viewModel;
        private IActorRef _worker;

        public GetCandidatesCoordinatorActor(AutoCompleteTextBoxViewModel<T> viewModel, Func<string, Task<IEnumerable<T>>> itemGetter)
        {
            _itemGetter = itemGetter;
            _worker = Context.ActorOf(Props.Create(() => new GetCandidatesWorkerActor<T>(_itemGetter)));
            _viewModel = viewModel;

            Receive<CandidatesResults<T>>(res => UpdateItems(res));
            Receive<InitializeSearch>(res => Search(res.TextToMatch));
        }

        private void UpdateItems(CandidatesResults<T> res)
        {
            // Decrease number of calls
            _viewModel.CallsInProgress--;

            // Check if there are any results and that the query text is the same as requested
            if (res.Results != null && _viewModel.QueryText == res.TextToMatch)
                _viewModel.AvailableItems = new ObservableCollection<T>(res.Results);
        }

        public void Search(string searchText)
        {
            _worker.Tell(new GetCandidatesWorkerActor<T>.GetCandidates(searchText));
        }
    }
}
