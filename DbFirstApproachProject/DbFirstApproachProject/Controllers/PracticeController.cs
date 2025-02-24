using Azure;
using DbFirstApproachProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbFirstApproachProject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PracticeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PracticeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetData()
        {

            //Display all student and with their address from student and student_address tables
            //(select s.namefirst , sa.address from student s inner join student_address sa on s.id = sa.studentID;) 
            //var data = (from s in _dataContext.Students 
            //            join sa in _dataContext.StudentAddresses
            //            on s.Id equals sa.StudentId
            //            select new { Name = s.Namefirst , Addresses = sa.Address});


            //Display(namefirst, namelast, emailID, and student_qualification details) from student and student_qualification relations
            //select s.namefirst , s.namelast, s.emailid , sq.name,sq.college,sq.university,
            //sq.marks,sq.year from student s inner join student_qualifications sq
            //on s.ID = sq.studentID;
            //var data = (from s in _dataContext.Students
            //            join sq in _dataContext.StudentQualifications
            //            on s.Id equals sq.StudentId
            //            select new
            //            {
            //                s.Namefirst,
            //                s.Namelast,
            //                s.EmailId,
            //                sq.Name,
            //                sq.College,
            //                sq.University,
            //                sq.Marks,
            //                sq.Year
            //            });


            //Display(namefirst, namelast, emailID, college, and university) who have studied in 
            //    'Yale University'. (Use student, and student_qualification relation)
            //var data = (from s in _dataContext.Students
            //            join sq in _dataContext.StudentQualifications
            //            on s.Id equals sq.StudentId
            //            where sq.University == "Yale University"
            //            select new { 
            //                s.Namefirst,
            //                s.Namelast,
            //                s.EmailId,
            //                sq.College,
            //                sq.University
            //            });


            //Display all student details his phone details and his qualification details. 
            //(Use student, student_phone and student_qualification relation)
            //select s.namefirst , sp.number , sq.[name] , sq.college , sq.university
            //from student s inner join student_phone sp
            //on s.ID = sp.studentID inner join student_qualifications sq
            //on s.ID = sq.studentID;
            //var data = (from s in _dataContext.Students join
            //            sp in _dataContext.StudentPhones 
            //            on s.Id equals sp.StudentId
            //            join sq in _dataContext.StudentQualifications 
            //            on s.Id equals sq.StudentId
            //            select new { 
            //                s.Namefirst,
            //                sp.Number,
            //                sq.Name,
            //                sq.College,sq.University
            //            });


            //Display(studentID, namefirst, namelast, name, college, university, and marks)
            //whose name is ‘BE’.(Use student, and student_qualification relation)
            //select sq.studentid , s.namefirst , s.namelast , sq.college ,sq.university, sq.marks
            //from student s inner join student_qualifications sq
            //on s.id = sq.studentID
            //where sq.name = 'be';
            //var data = (from s in _dataContext.Students
            //            join sq in _dataContext.StudentQualifications
            //            on s.Id equals sq.StudentId
            //            where sq.Name == "Be"
            //            select new { 
            //            s.Namefirst,
            //            s.Namelast,
            //            sq.College,
            //            sq.University,
            //            sq.Marks
            //            });

            //Display the module name and the duration of the module for the batch “Batch1”.
            //select * from modules
            //select *from course_modules
            //select *from course
            //select *from course_batches
            //
            //select m.[name], m.duration
            //from modules m join course_modules cm
            //on m.id = cm.moduleid
            //join course_batches cb
            //on cm.courseID = cb.courseID
            //where cb.name = 'Batch1';
            //var data = (from m in _dataContext.Modules
            //            join cm in _dataContext.CourseModules
            //            on m.Id equals cm.ModuleId
            //            join cb in _dataContext.CourseBatches
            //            on cm.CourseId equals cb.CourseId
            //            where cb.Name == "Batch1"
            //            select new
            //            { 
            //                m.Name,
            //                m.Duration
            //            });


            //Display student information along with his batch details who have joined in “Batch1”.
            //select s.namefirst , s.namelast , s.dob 
            //from student s join batch_students bs 
            //on s.ID = bs.studentID 
            //inner join course_batches cb
            //on cb.ID = bs.batchID
            //where cb.[name] = 'Batch1';--Display student information along with his batch details who have joined in “Batch1”.
            //select s.namefirst , s.namelast , s.dob 
            //from student s join batch_students bs 
            //on s.ID = bs.studentID 
            //inner join course_batches cb
            //on cb.ID = bs.batchID
            //where cb.[name] = 'Batch1';
            //var data = (from s in _dataContext.Students 
            //            join bs in _dataContext.BatchStudents
            //            on s.Id equals bs.StudentId 
            //            join cb in _dataContext.CourseBatches
            //            on bs.BatchId equals cb.Id
            //            where cb.Name == "Batch1"
            //            select new { 
            //                s.Namefirst,
            //                s.Namelast,
            //                s.Dob
            //            });


            //Display module names for “PG - DAC” course.
            //select * from modules
            //select *from course
            //select *from course_modules

            //select m.name from modules m join course_modules cm
            //on m.ID = cm.moduleID
            //join course c
            //on cm.courseID = c.ID
            //where c.name = 'PG-DAC';
            //var data = (from m in _dataContext.Modules
            //            join cm in _dataContext.CourseModules
            //            on m.Id equals cm.ModuleId
            //            join c in  _dataContext.Courses
            //            on cm.CourseId equals c.Id
            //            where c.Name == "PG-DAC"
            //            select new { 
            //            m.Name
            //            });

            //Display namefirst, namelast, and batch name for all students.
            //SELECT * from student;
            //select * from batch_students
            //select *from course_batches
            //select s.namefirst, s.namelast, cb.[name]
            //from student s join batch_students bs
            //on s.ID = bs.studentID
            //join course_batches cb
            //on bs.batchID = cb.ID
            //var data = (from s in _dataContext.Students
            //            join bs in _dataContext.BatchStudents
            //            on s.Id equals bs.StudentId
            //            join cb in _dataContext.CourseBatches
            //            on bs.BatchId equals cb.Id
            //            select new { 
            //            s.Namefirst,
            //            s.Namelast,
            //            cb.Name
            //            });

            //Display(namefirst, namelast, phone number, and emailid) whose student ID is 13.
            //select * from student_phone;
            //select DISTINCT s.namefirst, s.namelast, sp.number , s.emailid
            //from student s join student_phone sp
            //on s.ID = sp.studentID
            //where s.id = 13

            //var data = (from s in _dataContext.Students
            //            join sp in _dataContext.StudentPhones
            //            on s.Id equals sp.StudentId
            //            where s.Id == 13
            //            select new { 
            //            s.Namefirst,
            //            s.Namelast,
            //            sp.Number
            //}).Distinct();

            //Display(namefirst and count the total number of phones a student is having) for all student.
            //select s.namefirst, count(sp.number)
            //from student s join student_phone sp
            //on s.ID = sp.studentID
            //group by s.namefirst
            //var data = (from s in _dataContext.Students
            //            join sp in _dataContext.StudentPhones
            //            on s.Id equals sp.StudentId
            //            group s by s.Namefirst into sep
            //            select new { 
            //                name = sep.Key,
            //            count = sep.Count()});


            //Get student’s(namefirst, namelast, DOB, address, name, college, university, marks, and year).
            //select s.namefirst , s.namelast , s.dob , 
            //sa.[address] , 
            //sq.[name] , sq.college , sq.university , sq.marks , sq.[year]
            //from student s join student_address sa
            //on s.ID = sa.studentID
            //join student_qualifications sq
            //on s.ID = sq.studentID
            //var data = (from s in _dataContext.Students
            //            join sa in _dataContext.StudentAddresses
            //            on s.Id equals sa.StudentId
            //            join sq in _dataContext.StudentQualifications
            //            on s.Id equals sq.StudentId
            //            select new { 
            //                s.Namefirst,
            //                s.Namelast,
            //                s.Dob,
            //                sa.Address,
            //                sq.Name,
            //                sq.College,
            //                sq.University,
            //                sq.Marks,
            //                sq.Year
            //            });


            //Get(namefirst, namelast, emailID, phone number, and address) whose faculty name is ‘ketan’.
            //select f.namefirst, f.namelast, f.emailid , fp.number, fa.[address]
            //from faculty f inner
            //join faculty_phone fp
            //on f.ID = fp.facultyID
            //inner
            //join faculty_address fa
            //on f.ID = fa.facultyID
            //where f.namefirst = 'ketan'

            //var data = (from f in _dataContext.Faculties
            //            join fp in _dataContext.FacultyPhones
            //            on f.Id equals fp.FacultyId
            //            join fa in _dataContext.FacultyAddresses
            //            on f.Id equals fa.FacultyId
            //            where f.Namefirst == "ketan"
            //            select new { 
            //            f.Namefirst,
            //            f.Namelast,
            //            f.EmailId,
            //            fp.Number,
            //            fa.Address
            //            });


            //Get(course name and batch name)for all courses.
            //SELECT
            //s.ID, 
            //s.[name], 
            //STRING_AGG(cb.[name], ', ') AS Batches
            //FROM course s
            //INNER JOIN course_batches cb
            //ON s.ID = cb.courseID
            //GROUP BY s.ID, s.[name];

            //var data = (from c in _dataContext.Courses
            // join cb in _dataContext.CourseBatches
            // on c.Id equals cb.CourseId
            // group cb by new { c.Id, CourseName = c.Name } into grouped
            //select new
            //{
            //    grouped.Key.Id,
            //    grouped.Key.CourseName,
            //    Batches = string.Join(", ", grouped.Select(cb => cb.Name))
            //});


            //Get all student details who have taken admission in ‘PG-DAC’ course
            //select distinct s.id, s.namefirst, c.[name]
            //from student s inner
            //join batch_students bs
            //on s.ID = bs.studentID inner
            //join course_batches cb
            //on bs.batchID = cb.ID inner
            //join course c
            //on cb.courseID = c.ID
            //where c.name = 'PG-DAC'
            //order by s.ID
            //var data = (from );
            //var data = (from s in _dataContext.Students
            //            join bs in _dataContext.BatchStudents
            //            on s.Id equals bs.StudentId
            //            join cb in _dataContext.CourseBatches
            //            on bs.BatchId equals cb.Id
            //            join c in _dataContext.Courses
            //            on cb.CourseId equals c.Id
            //            where c.Name == "PG-DAC"
            //            select new { 
            //            Id = s.Id,
            //            Name = s.Namefirst,
            //            CourseName = c.Name});


            //Get all course name and module names which are taught in ‘PG-DAC’ course
            //select m.* from course c
            //join course_modules cm
            //on c.ID = cm.courseID
            //join modules m
            //on cm.moduleID = m.ID
            //where c.name = 'PG-DAC'

            //var data = (from c in _dataContext.Courses
            //            join cm in _dataContext.CourseModules
            //            on c.Id equals cm.CourseId
            //            join m in _dataContext.Modules
            //            on cm.ModuleId equals m.Id
            //            where c.Name == "PG-DAC"
            //            select new { 
            //            m.Id,
            //            m.Name});

            //Display how many modules are taught in each course.
            //select c.[name], count(m.[name])
            //from course c join course_modules cm
            //on c.ID = cm.courseID
            //join modules m
            //on cm.moduleID = m.ID
            //group by c.[name]

            //var data = (from c in _dataContext.Courses
            //            join cm in _dataContext.CourseModules
            //            on c.Id equals cm.CourseId
            //            join m in _dataContext.Modules
            //            on cm.ModuleId equals m.Id
            //            group c by c.Name into grouped
            //            select new { 
            //            Name = grouped.Key,                        
            //            Count = grouped.Count(),
            //            });


            //Display the student detail who are ‘BE’ graduate
            //select s.namefirst , sq.university 
            //from student s join student_qualifications sq
            //on s.ID = sq.studentID
            //where sq.[name] = 'BE'

            var data = (from s in _dataContext.Students
                        join sq in _dataContext.StudentQualifications
                        on s.Id equals sq.StudentId
                        where sq.Name == "BE"
                        select new { 
                        Name = s.Namefirst,
                        sq.University});

            return Ok(data);

        }
    }
}
