using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Akka.Actor;
using Akka.Pattern;

namespace WpfAutoCompleteTextBoxWithAkka
{
    public static class ActorData
    {
        public static ActorSystem ActorSystem { get; set; }

        public static class ActorPaths
        {
            public static readonly ActorMetaData GetCandidatesCoordinatorActor = new ActorMetaData("getCandidatesCoordinator", "akka://ActorSystem/user/getCandidatesCoordinator");
        }

        /// <summary>
        /// Meta-data class
        /// </summary>
        public class ActorMetaData
        {
            public ActorMetaData(string name, string path)
            {
                Name = name;
                Path = path;
            }

            public string Name { get; private set; }

            public string Path { get; private set; }
        }

    }
}
