using MVVMFramework;
using MVVMFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UrenRegistratie.BLL.Handlers;
using UrenRegistratie.Shared.Entities;

namespace UrenRegistratieUI.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get { return _employees; }
            set 
            {
                if (value != _employees)
                {
                    _employees = value;
                    OnPropertyChanged("Employees");
                }
            }
        }


        private List<Project> _projects;

        public List<Project> Projects
        {
            get { return _projects; }
            set
            {
                if (value != _projects)
                {
                    _projects = value;
                    OnPropertyChanged("Projects");
                }
            }
        }

        private List<Registration> _registrations;

        public List<Registration> Registrations
        {
            get { return _registrations; }
            set
            {
                _registrations = value;
                OnPropertyChanged("Registrations");
            }
        }

        private Registration _registration;

        public Registration Registration
        {
            get 
            {
                if (_registration == null) _registration = new Registration();
                return _registration; 
            }
            set 
            {
                if (value != _registration)
                {
                    _registration = value;
                    OnPropertyChanged("SelectedProject");
                    OnPropertyChanged("SelectedEmployee");
                }
            }
        }

        public Project SelectedProject
        {
            get
            {
                return Registration.Project;
            }
            set
            {
                if (Registration.Project != value)
                {
                    Registration.Project = value;
                    OnPropertyChanged("SelectedProject");
                }
            }
        }

        public Employee SelectedEmployee
        {
            get
            {
                return Registration.Employee;
            }
            set
            {
                if (Registration.Employee != value)
                {
                    Registration.Employee = value;
                    OnPropertyChanged("SelectedEmployee");
                }
            }
        }
        

        public void Load()
        {

            EmployeeHandler handler = new EmployeeHandler();
            Employees = handler.LstEmployees(new Employee());
            ProjectHandler p = new ProjectHandler();
            Projects = p.LstProjects(new Project());

        }

        public ICommand AddRegistrationCommand 
        {
            get { return new RelayCommand(AddRegistration, param => CanExecute); }
        
        }

        private bool CanExecute
        { get { return true; } }

        private void AddRegistration(object param)
        {
            try
            {
                RegistrationHandler h = new RegistrationHandler();
                h.Add(Registration);
                Registrations = null;
                Registrations = h.ListRegistrations();
                Registration = null;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

    }
}
