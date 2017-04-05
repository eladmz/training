using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibraryREST
{
    [DataContract(Namespace = "http://pluralsight.com/evals")]
    public class Eval
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Submitter { get; set; }
        [DataMember]
        public DateTime Timesent { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }

    [ServiceContract]
    public interface IEvalService
    {
        [WebInvoke(Method = "POST", UriTemplate = "evals")]
        [OperationContract]
        void SumbitEval(Eval eval);

        [WebGet(UriTemplate = "eval/{id}")]
        [OperationContract]
        Eval GetEval(string id);

        [WebGet(UriTemplate = "evals", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Eval> GetAllEvals();

        [WebGet(UriTemplate = "evals/{submitter}")]
        [OperationContract]
        List<Eval> GetEvalsBySubmitter(string submitter);

        [WebInvoke(Method = "DELETE", UriTemplate = "eval/{id}")]
        [OperationContract]
        void RemoveEval(string id);

        [ServiceKnownType(typeof(Atom10FeedFormatter))]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        [WebGet(UriTemplate = "evals/feed/{format}")]
        [OperationContract]
        SyndicationFeedFormatter GetFeed(string format);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evals = new List<Eval>();
        int evalCount = 0;

        public void SumbitEval(Eval eval)
        {
            eval.Id = (++evalCount).ToString();
            evals.Add(eval);
        }

        public Eval GetEval(string id)
        {
            return evals.First(e => e.Id.Equals(id));
        }

        public List<Eval> GetAllEvals()
        {
            return GetEvalsBySubmitter(null);
        }

        public List<Eval> GetEvalsBySubmitter(string submitter)
        {
            if (string.IsNullOrWhiteSpace(submitter))
            {
                return evals;
            }
            return evals.FindAll(e => e.Submitter.Equals(submitter));
        }

        public void RemoveEval(string id)
        {
            int index = evals.FindIndex(e => e.Id == id);
            evals.RemoveAt(index);
        }

        public SyndicationFeedFormatter GetFeed(string format)
        {
            List<Eval> evals = this.GetAllEvals();
            SyndicationFeed feed = new SyndicationFeed()
            {
                Title = new TextSyndicationContent("Pluralsight Evaluation Summary"),
                Description = new TextSyndicationContent("Recent student eval summary"),
                Items = from eval in evals
                        select new SyndicationItem()
                        {
                            Title = new TextSyndicationContent(eval.Submitter),
                            Content = new TextSyndicationContent(eval.Comments)
                        }
            };
            if (format == "atom")
                return new Atom10FeedFormatter(feed);
            else
                return new Rss20FeedFormatter(feed);
        }
    }
}
