using Database2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database2022.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService() => _context = App.GetContext();

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

        public bool CreateRange(List<Student> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.Students.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Student> Get()
        {
            return _context.Students.ToList();
        }

    }
}
