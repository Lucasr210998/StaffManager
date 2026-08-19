# 📘 Staff Manager — WPF MVVM Application

A lightweight WPF desktop application built using **C#**, **.NET**, and the **MVVM pattern**.  
Designed for managing staff records with clean UI separation, proper data binding, and Entity Framework Core persistence.

This project demonstrates:

- MVVM architecture  
- ObservableCollection data binding  
- CRUD operations  
- Validation using `IDataErrorInfo`  
- Dialog-based editing  
- EF Core database integration  

---

## 🚀 Features

### ✔ Add Staff  
Quickly add new staff members through the main window.

### ✔ Edit Staff  
Opens a dedicated edit dialog with:

- Live validation  
- Disabled Save button when invalid  
- Error messages displayed under the input  
- Proper MVVM separation (no code-behind logic)

### ✔ Delete Staff  
Remove staff entries directly from the main list.

### ✔ Real-Time UI Updates  
Changes propagate instantly thanks to:

- `INotifyPropertyChanged`  
- `ObservableCollection<Person>`  
- ViewModel-driven updates  

### ✔ EF Core Integration  
All staff data is stored and updated using Entity Framework Core.

---

## 🧱 Tech Stack

- **C# / .NET**
- **WPF**
- **MVVM**
- **Entity Framework Core**
- **SQLite**
- **Visual Studio**

---

## 📂 Project Structure
StaffManager/
│
├── Models/
│   └── Person.cs
│
├── ViewModels/
│   ├── StaffManagerViewModel.cs
│   └── EditViewModel.cs
│
├── Views/
│   ├── MainWindow.xaml
│   └── EditView.xaml
│
├── Data/
│   └── AppDbContext.cs
│
└── StaffManager.csproj

---

## 🧩 MVVM Highlights

### **ViewModels**
- Handle all logic  
- Expose bindable properties  
- Implement validation  
- Trigger database updates  

### **Views**
- Contain only XAML  
- Bind directly to ViewModels  
- No business logic in code-behind  

### **Models**
- Represent staff entities  
- Implement `INotifyPropertyChanged` for live UI updates  

---

## 🛠 How to Run

1. Clone the repository  
2. Open the solution in Visual Studio  
3. Restore NuGet packages  
4. Run the project  
5. The database will be created automatically on first run  

---

## 📌 Future Improvements

- Search & filtering  
- Sorting  
- Better dialog styling  
- Async database operations  
- Repository pattern  
- Unit tests  

---

## 📄 License

This project is free to use, modify, and learn from.



