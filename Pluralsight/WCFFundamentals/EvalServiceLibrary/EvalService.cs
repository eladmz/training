using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    [DataContract]
    public class Eval
    {
        public Eval()
        {

        }

        public Eval(string submitter, string comments)
        {
            this.Submitter = submitter;
            this.Comments = comments;
            this.Timesent = DateTime.Now;
        }

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
        [OperationContract]
        void SumbitEval(Eval eval);
        [OperationContract]
        List<Eval> GetEvals();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evals = new List<Eval>();

        public void SumbitEval(Eval eval)
        {
            if (eval.Submitter.Equals("Throw")) throw new FaultException("Error within SubmitEval");
            evals.Add(eval);
        }

        public List<Eval> GetEvals()
        {
            System.Threading.Thread.Sleep(500);
            return evals;
        }
    }
}
