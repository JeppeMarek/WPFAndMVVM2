using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {
        // Properties and backingfields
        private PersonRepository personRepo = new PersonRepository();
        private PersonViewModel _selectedPerson;
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; } =
            new ObservableCollection<PersonViewModel>();
        public event PropertyChangedEventHandler PropertyChanged;
        public PersonViewModel SelectedPerson
        {
            get => _selectedPerson;
            set { _selectedPerson = value; OnPropertyChanged("SelectedPerson"); }
        }

        // Event handler
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
       // Constructor for MVM add all persons from personRepo to PersonsVM
        public MainViewModel()
        {
            foreach (Person person in personRepo.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }
        // Method adding a new person to both personRepo and PersonsVm
        public void AddDefaultPerson()
        {
            Person person = personRepo.Add("Specify FirstName","Specify LastName",0,"Specify PhoneNumber");
            PersonViewModel personVm = new PersonViewModel(person);
            PersonsVM.Add(personVm);
            SelectedPerson = personVm;
        }

        public void DeleteSelectedPerson()
        {
            if (SelectedPerson != null)
            {
                SelectedPerson.Delete(personRepo);
                PersonsVM.Remove(SelectedPerson);
            }
            else
            {
                MessageBox.Show("Please select a person first");
            }
        }
    }
}
