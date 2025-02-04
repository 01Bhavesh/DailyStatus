using DbFirstApproachProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

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
            var data = (from s in _dataContext.Students 
                        join bs in _dataContext.BatchStudents
                        on s.Id equals bs.StudentId 
                        join cb in _dataContext.CourseBatches
                        on bs.BatchId equals cb.Id
                        where cb.Name == "Batch1"
                        select new { 
                            s.Namefirst,
                            s.Namelast,
                            s.Dob
                        });


            return Ok(data);
        }
    }
}
