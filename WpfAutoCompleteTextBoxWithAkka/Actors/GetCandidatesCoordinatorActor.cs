using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Akka.Actor;

namespace WpfAutoCompleteTextBoxWithAkka.Actors
{
    public class GetCandidatesCoordinatorActor<T> : ReceiveActor
    {
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

        private readonly Func<string, Task<IEnumerable<T>>> _itemGetter;

        private IActorRef _worker;
        //private T SelectedItem;
        private ObservableCollection<T> AvailableItems;


        public GetCandidatesCoordinatorActor(ObservableCollection<T> availableItems, Func<string, Task<IEnumerable<T>>> itemGetter)
        {
            _itemGetter = itemGetter;
            _worker = Context.ActorOf(Props.Create(() => new GetCandidatesWorkerActor<T>(_itemGetter)));
            //SelectedItem = selectedItem;
            AvailableItems = availableItems;

            Receive<CandidatesResults<T>>(res => UpdateItems(res));
            Receive<InitializeSearch>(res => Search(res.TextToMatch));
        }

        private void UpdateItems(CandidatesResults<T> res)
        {
            if (res.Results != null)
                AvailableItems = new ObservableCollection<T>(res.Results);
        }

        public void Search(string searchText)
        {
            _worker.Tell(new GetCandidatesWorkerActor<T>.GetCandidates(searchText));
        }
    }
}
