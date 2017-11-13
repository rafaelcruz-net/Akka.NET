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
    public class UserActor : ReceiveActor
    {
        public UserActor()
        {
            IActorRef repositoryActor = Context.ActorOf(Props.Create(() => new RepositoryActor()));

            var github = new GitHubClient(new ProductHeaderValue("AkkaSample"), new InMemoryCredentialStore(new Credentials("rafaelcruz-net", "brq#130301")));

            Receive<String>(x =>
            {
                Console.WriteLine($"Buscando o usuário {x}");
                var user = github.User.Get(x).Result;
                Console.WriteLine($"Nome: {user.Name} \nLogin: {user.Login}");

                var repos = github.Repository.GetAllForUser(x).Result;

                foreach (var item in repos)
                {
                    repositoryActor.Tell(item.Name);
                }

            });
            


        }

    }
}
