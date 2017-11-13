using Akka.Actor;
using AkkaSample.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("main");

            var userActor = system.ActorOf(Props.Create(() => new UserActor()));

            userActor.Tell("rafaelcruz-net");

            Console.Read();
            
        }
    }
}
