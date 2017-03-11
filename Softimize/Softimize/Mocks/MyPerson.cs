using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softimize
{
    /// <summary>
    /// Mock person object for testing.
    /// </summary>
    public class MyPerson : Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private int height;
        private DateTime dateOfBirth;

        public MyPerson(int id, string firstName, string lastName, int height, DateTime dateOfBirth)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
        }

        public int GetId()
        {
            return id;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetHeight()
        {
            return height;
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public override string ToString()
        {
            return String.Format("{0} : {1} {2}", id, firstName, lastName);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            MyPerson comparePerson = obj as MyPerson;
            if (comparePerson != null && this.id == comparePerson.id && this.firstName == comparePerson.firstName && 
                this.lastName == comparePerson.lastName && this.height == comparePerson.height &&
                this.dateOfBirth == comparePerson.dateOfBirth)
            {
                return true;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() ^ firstName.GetHashCode() ^ lastName.GetHashCode() ^ height.GetHashCode() ^ dateOfBirth.GetHashCode();
        }
    }
}
