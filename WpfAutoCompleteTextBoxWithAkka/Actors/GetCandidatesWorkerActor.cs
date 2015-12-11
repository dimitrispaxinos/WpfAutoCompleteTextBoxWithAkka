using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Akka.Actor;

namespace WpfAutoCompleteTextBoxWithAkka.Actors
{
    public class GetCandidatesWorkerActor<T> : ReceiveActor
    {
        public class GetCandidates
        {
            public GetCandidates(string textToMatch)
            {
                TextToMatch = textToMatch;
            }

            public string TextToMatch { get; private set; }
        }

        private readonly Func<string, Task<IEnumerable<T>>> _itemGetter;

        public GetCandidatesWorkerActor(Func<string, Task<IEnumerable<T>>> itemGetter)
        {
            _itemGetter = itemGetter;
            Receive<GetCandidates>(text => GetPossibleCanditates(text));
        }

        private void GetPossibleCanditates(GetCandidates getCandidates)
        {
            var results = _itemGetter(getCandidates.TextToMatch).Result;
            var response = new GetCandidatesCoordinatorActor<T>.CandidatesResults<T>(getCandidates.TextToMatch, results);

            // Send Message to the main Actor
            Context.ActorSelection(ActorData.ActorPaths.GetCandidatesCoordinatorActor.Path).Tell(response);
        }
    }
}
