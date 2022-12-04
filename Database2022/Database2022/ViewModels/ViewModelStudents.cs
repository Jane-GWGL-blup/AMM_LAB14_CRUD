using Database2022.Models;
using Database2022.Services;
using Database2022.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Database2022.ViewModels
{
	public class ViewModelStudents : BaseViewModel
	{
        #region Services        
        private readonly StudentService dataServiceStudents;
        #endregion Services

        #region Attributes

        private ObservableCollection<Student> students;

        #endregion Attributes

        #region Properties

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set { SetValue(ref this.students, value); }
        }

        #endregion Properties

        #region Command

        public ICommand NewStudentCommand
        {
            get
            {
                return new Command(NewStudent);
            }
        }

        public ICommand LoadStudentsCommand
        {
            get
            {
                return new Command(LoadStudents);
            }
        }
        public ICommand DeleteStudentCommand
        {
            get
            {
                return new Command((x) =>
                {
                    var item = (x as Student);
                    DeleteStudent(item);
                });
            }

        }
        public ICommand UpdateStudentCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Student);
                    await UpdateStudent(item);
                });
            }
        }
        #endregion

        #region Constructor
        public ViewModelStudents()
        {
            this.dataServiceStudents = new StudentService();

            this.LoadStudents();

        }
        #endregion Constructor



        #region Methods

        private void NewStudent()
        {
            Student student = new Student();
            student.StudentId = 0;
            student.Nombre = "";
            student.FechaNacimiento = DateTime.Today;
            student.Nota = 0;
            student.EstaAprobado = "Si";

            Application.Current.MainPage.Navigation.PushAsync(new StudentView(student));

            LoadStudents();

        }

        private async Task UpdateStudent(Student student)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StudentView(student));

        }

        private void DeleteStudent(Student student)
        {

            this.dataServiceStudents.Delete(student);
            LoadStudents();
        }

        public void LoadStudents()
        {
            var studentsDB = this.dataServiceStudents.Get();
            this.Students = new ObservableCollection<Student>(studentsDB);
        }
        #endregion Methods
    }
}
