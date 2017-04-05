using ConsoleClient.EvalServiceReference;
using EvalServiceLibrary;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cf = new ChannelFactory<IEvalServiceChannel>("NetNamedPipeBinding_IEvalService");
            //var channel = cf.CreateChannel();

            Console.WriteLine("Retrieving endpoints via MEX...");
            var endpoints = MetadataResolver.Resolve(typeof(EvalServiceLibrary.IEvalService), 
                new EndpointAddress("http://localhost:8080/evals/mex"));


            foreach (var se in endpoints)
            {
                EvalServiceClient channel = new EvalServiceClient(se.Binding, se.Address);

                //var eval = new Eval()
                //{
                //    Submitter = "Elad Mizrahi",
                //    Timesent = DateTime.Now,
                //    Comments = "I'm liking this..."
                //};



                var eval = new Eval("Elad Mizrahi", "I'm liking this...");

                try
                {
                    channel.SumbitEval(eval);
                    channel.SumbitEval(eval);

                    channel.GetEvalsCompleted += Channel_GetEvalsCompleted;
                    channel.GetEvalsAsync();

                    Console.WriteLine("Waiting...");
                    //foreach (var e in evals) 
                    //{
                    //    Console.WriteLine($"Submitter: {e.Submitter} \nTime sent: {e.Timesent} \nComments: {e.Comments}");
                    //}

                    channel.Close();
                }
                catch (FaultException fe)
                {
                    Console.WriteLine("FaultException handler: {0}", fe.GetType());
                    channel.Abort();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("CommunicationException handler: {0}", ce.GetType());
                    channel.Abort();
                }
                catch (TimeoutException te)
                {
                    Console.WriteLine("TimeoutException handler: {0}", te.GetType());
                    channel.Abort();
                }
            }
            
        }

        private static void Channel_GetEvalsCompleted(object sender, GetEvalsCompletedEventArgs e)
        {
            Console.WriteLine("Number of evals: {0}", e.Result.Count);
        }
    }
}
