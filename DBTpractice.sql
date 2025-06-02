use data
--Display module names for “PG-DAC” course.
select * from modules
select * from course
select * from course_modules
select m.name from modules m join course_modules cm 
on m.ID = cm.moduleID
join course c 
on cm.courseID = c.ID 
where c.name = 'PG-DAC';


--Display namefirst, namelast, and batch name for all students.
SELECT * from student;
select * from batch_students
select * from course_batches
select s.namefirst , s.namelast , cb.[name] 
from student s join batch_students bs
on s.ID = bs.studentID
join course_batches cb
on  bs.batchID = cb.ID

--Display (namefirst, namelast, phone number, and emailid) whose student ID is 13.
select * from student_phone;
select DISTINCT s.namefirst, s.namelast, sp.number , s.emailid 
from student s join student_phone sp
on s.ID = sp.studentID
where s.id = 13

--Display (namefirst and count the total number of phones a student is having) for all student.
select s.namefirst , count(sp.number) 
from student s join student_phone sp 
on s.ID = sp.studentID 
group by s.namefirst


--Get student’s (namefirst, namelast, DOB, address, name, college, university, marks, and year).
select * from student;
select * from student_address;
select * from student_qualifications
select s.namefirst , s.namelast , s.dob , 
sa.[address] , 
sq.[name] , sq.college , sq.university , sq.marks , sq.[year]
from student s join student_address sa
on s.ID = sa.studentID
join student_qualifications sq
on s.ID = sq.studentID

--Get (namefirst, namelast, emailID, phone number, and address) whose faculty name is ‘ketan’.
select * from faculty
select * from faculty_qualifications
select * from faculty_address
select * from faculty_phone

select f.namefirst, f.namelast, f.emailid , fp.number, fa.[address]
from faculty f inner join faculty_phone fp
on f.ID = fp.facultyID 
inner join faculty_address fa
on f.ID = fa.facultyID
where f.namefirst = 'ketan'

--Get(course name and batch name)for all courses.

--Display all student and with their address from student and student_address tables.
select s.namefirst, sa.[address] from 
student s join student_address sa
on s.ID = sa.studentID

--Display (namefirst, namelast, emailID, and student_qualification details) from student and student_qualification relations.
select s.namefirst, sq.* from 
student s join student_qualifications sq
on s.id = sq.studentID

--Display (namefirst, namelast, emailID, college, and university) who have studied in 'Yale University'. (Use student, and student_qualification relation)
select s.namefirst , sq.college , sq.university from
student s join student_qualifications sq
on s.ID = sq.studentID
where sq.university = 'Yale University'

--•	Display how many modules are taught in each course.
select * from modules
select * from course_modules
select * from course

select c.[name] , COUNT(m.[name]) from 
modules m join course_modules cm
on m.ID = cm.moduleID
join course c 
on cm.courseID = c.ID
group by c.[name]