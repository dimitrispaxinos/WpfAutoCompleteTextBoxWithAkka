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
        
    }
}
