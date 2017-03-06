using System.IO;
using System.Collections;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {
        string Name { get; set; }
        event NameChangedDelegate NameChanged;

        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
    }
}