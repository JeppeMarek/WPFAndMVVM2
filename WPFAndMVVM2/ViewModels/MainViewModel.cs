using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {
        private PersonRepository personRepo = new PersonRepository();
        private PersonViewModel _selectedPerson;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !
        public List<PersonViewModel> PersonsVM { get; set; }

        public MainViewModel()
        {
            PersonsVM = new List<PersonViewModel>();
            foreach (Person person in personRepo.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }
        public PersonViewModel SelectedPerson
        {
            get => _selectedPerson;
            set { _selectedPerson = value; OnPropertyChanged();} 
        }

    }
}
