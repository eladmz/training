using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public enum Party
    {
        Independent,
        Federalist,
        DemocratRepublican
    }

    public class Employee : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private bool wasReelected;
        public bool WasReelected
        {
            get { return wasReelected; }
            set
            {
                wasReelected = value;
                OnPropertyChanged();
            }
        }

        private Party affiliation;
        public Party Affiliation
        {
            get { return affiliation; }
            set
            {
                affiliation = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "Washington", Title = "President 1", WasReelected = true, Affiliation = Party.Independent });
            employees.Add(new Employee() { Name = "Adams", Title = "President 2", WasReelected = false, Affiliation = Party.Federalist });
            employees.Add(new Employee() { Name = "Jefferson", Title = "President 3", WasReelected = true, Affiliation = Party.DemocratRepublican });
            employees.Add(new Employee() { Name = "Madison", Title = "President 4", WasReelected = true, Affiliation = Party.DemocratRepublican });
            employees.Add(new Employee() { Name = "Monroe", Title = "President 5", WasReelected = true, Affiliation = Party.DemocratRepublican });

            return employees;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
