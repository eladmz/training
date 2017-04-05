using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibraryREST
{
    [ServiceContract]
    public interface ICourseService
    {
        [OperationContract]
        List<string> GetCourseList();
    }

    public class CourseService : ICourseService
    {
        public List<string> GetCourseList()
        {
            var courses = new List<string>();
            courses.Add("WCF Fundamentals");
            courses.Add("WF Fundamentals");
            courses.Add("WPF Fundamentals");
            courses.Add("Silverlight Fundamentals");

            return courses;
        }
    }
}
