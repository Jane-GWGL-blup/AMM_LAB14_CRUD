using System;
using System.Collections.Generic;
using System.Text;

namespace Database2022.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nota { get; set; }
        public bool EstaAprobado { get; set; }
       
    }
}
