using Database2022.Models;
using Database2022.Services;
using Database2022.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{

        public class ViewModelStudent : BaseViewModel
        {
            #region Services
            private readonly StudentService dataServiceStudents;
            #endregion

            #region Attributes
            private string nombre;
            private string apellidoPaterno;
            private DateTime fechaNacimiento;
            private int nota;
            private string estaAprobado;
            private Student student;
            #endregion

            #region Properties
            public Student Student
            {
                get { return this.student; }
                set { SetValue(ref this.student, value); }
            }
            public string Nombre
            {
                get { return this.nombre; }
                set { SetValue(ref this.nombre, value); }
            }
            public string ApellidoPaterno
        {
                get { return this.apellidoPaterno; }
                set { SetValue(ref this.apellidoPaterno, value); }
            }
            public DateTime FechaNacimiento
            {
                get { return this.fechaNacimiento; }
                set { SetValue(ref this.fechaNacimiento, value); }
            }
            public int Nota
            {
                get { return this.nota; }
                set { SetValue(ref this.nota, value); }
            }

            public string EstaAprobado
            {
                get { return this.estaAprobado; }
                set { SetValue(ref this.estaAprobado, value); }
            }

            #endregion

            #region Commands
            public ICommand CreateCommand
            {
                get
                {
                    return new Command<Student>(execute: async (student) =>
                    {
                        if (this.Student.StudentId > 0)
                        {

                            var newStudent = new Student()
                            {
                                StudentId = this.Student.StudentId,
                                Nombre = this.Nombre,
                                ApellidoPaterno = this.ApellidoPaterno,
                                FechaNacimiento = this.FechaNacimiento,
                                Nota = this.Nota,
                                EstaAprobado = this.EstaAprobado
                            };

                            await this.dataServiceStudents.Update(newStudent);

                        }
                        else
                        {
                            var newStudent = new Student()
                            {
                                Nombre = this.Nombre,
                                ApellidoPaterno = this.ApellidoPaterno,
                                FechaNacimiento = this.FechaNacimiento,
                                Nota = this.Nota,
                                EstaAprobado = this.EstaAprobado
                            };

                            this.dataServiceStudents.Create(newStudent);
                            await Application.Current.MainPage.Navigation.PopAsync();
                        }


                        await Application.Current.MainPage.Navigation.PushAsync(new StudentsView());
                        ViewModelStudents viewModelStudents = new ViewModelStudents();
                        viewModelStudents.LoadStudents();
                    });
                }
            }
            #endregion Commands

            #region Constructor
            public ViewModelStudent(Student student)
            {
                this.dataServiceStudents = new StudentService();
                if (student != null)
                {
                    this.Student = student;
                    this.Nombre = student.Nombre;
                    this.ApellidoPaterno = student.ApellidoPaterno;
                    this.FechaNacimiento = student.FechaNacimiento;
                    this.Nota = student.Nota;
                    this.EstaAprobado = student.EstaAprobado;

                }
                else
                {
                    this.Nombre = "";
                    this.ApellidoPaterno = "";
                    this.FechaNacimiento = DateTime.Today;
                    this.Nota = 0;
                    this.EstaAprobado = "Si";
                }
            }
            #endregion Constructor

        }
    
}
