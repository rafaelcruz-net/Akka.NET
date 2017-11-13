using Akka.Actor;
using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaSample.Actors
{
    public class RepositoryActor : ReceiveActor
    {
        public RepositoryActor()
        {
            Receive<String>(x =>
            {
                Console.WriteLine($"Nome dos Repositorio {x}");
            });
        }

    }
}
