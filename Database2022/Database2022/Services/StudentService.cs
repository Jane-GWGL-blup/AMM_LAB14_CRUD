using Database2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database2022.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService() => _context = App.GetContext();

        public List<Student> Get()
        {
            return _context.Students.ToList();
        }
        public bool Create(Student item)
        {
            try
            {
                //EntityFrameworkCore
                _context.Students.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Student GetById(Student student)
        {
            return _context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public void Delete(Student student)
        {

            var Student = GetById(student);
            _context.Students.Remove(Student);
            _context.SaveChanges();         
           
        }



    }
}
