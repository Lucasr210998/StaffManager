using StaffManager.Models;
using StaffManager.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using StaffManager.Commands;

namespace StaffManager.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Person _person;

        public EditViewModel(Person person)
        {
            _person = person;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SaveCommand { get; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Name))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        return "Name is required.";

                    if (Name.Length < 2)
                        return "Name must be at least 2 characters.";

                    if (Name.Length > 50)
                        return "Name cannot exceed 50 characters.";
                }

                return null;
            }
        }

        private bool CanSave(object parameter)
        {
            return string.IsNullOrWhiteSpace(this[nameof(Name)]);
        }

        private void Save(object parameter)
        {
            if (!CanSave(null))
                return;

            using var db = new AppDbContext();
            db.People.Update(_person);
            db.SaveChanges();

            if (parameter is Window window)
                window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}