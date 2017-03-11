using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softimize
{
    /// <summary>
    /// Person interface - in .NET should be called IPerson and have Properties instead of methods.
    /// </summary>
    public interface Person
    {
        int GetId();
        string GetFirstName();
        string GetLastName();
        DateTime GetDateOfBirth();
        int GetHeight();
    }
}
