using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using StaffManager.Models;
using StaffManager.Commands;
using Microsoft.EntityFrameworkCore;
using StaffManager.Data;
using System.Windows;

namespace StaffManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Person> Persons { get; set; }
        public ICommand AddPersonCommand { get; set; }
        public ICommand RemovePersonCommand { get; private set; }
        public ICommand EditPersonCommand { get; set; }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();

            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson);
            EditPersonCommand = new RelayCommand(EditPerson);

            LoadPersons();

        }

        private void AddPerson(object parameter)
        {
            if (parameter is string name && !string.IsNullOrWhiteSpace(name))
            {
                Persons.Add(new Person { Name = name });

                using (var context = new AppDbContext())
                {
                    var person = new Person { Name = name };
                    context.People.Add(person);
                    context.SaveChanges();
                }
            }
        }

        private void RemovePerson(object parameter)
        {
            if (parameter is Person person)
            {
                Persons.Remove(person);
                using (var context = new AppDbContext())
                {
                    var personToRemove = context.People.Find(person.Id);
                    if (personToRemove != null)
                    {
                        context.People.Remove(personToRemove);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void EditPerson(object parameter)
        {
            if (parameter is Person person)
            {
                var window = new Views.EditView(person);
                MessageBox.Show($"persons name is {person.Name}");
                window.ShowDialog();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private async void LoadPersons()
        {
            using (var context = new AppDbContext())
            {
                var persons = await context.People.ToListAsync();
                foreach (var person in persons)
                {
                    Persons.Add(person);
                }
            }
        }
    }
}
