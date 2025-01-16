select * from student;
select * from student_address;

--use on instead of where cluse 
--ON should be used to define the join condition and WHERE should be used to filter the data.
select s.* , sa.address from student s inner join student_address sa on s.ID = sa.studentID;

select s.namefirst, s.namelast, s.emailid, sq.* from student s inner join student_qualifications sq on s.ID = sq.studentID;

select s.namefirst , s.namelast , s.emailid , sq.college, sq.university from student s inner join 
student_qualifications sq on s.ID = sq.studentID and sq.university = 'Yale University'; 

select s.*, sp.* , sq.* from student s join student_phone sp on s.Id = sp.studentID join student_qualifications sq on 
s.id = sq.studentID;

select sq.studentid,s.namefirst,s.namelast,sq.name,sq.college,sq.university,sq.marks from
student s join student_qualifications sq on s.id = sq.studentid;

select * from student;
select * from student_phone;
select * from modules;
select * from course_batches;
select * from course_modules;
select * from batch_students;
select * from course;

select m.name , m.duration, cb.name from modules m inner join course_modules cm on m.ID = cm.moduleID join
course_batches cb on cm.courseID = cb.ID and cb.name = 'batch1';

--inner join
select s.* ,cb.* from student s inner join batch_students bs on s.ID = bs.studentID join
course_batches cb on bs.batchID = cb.ID and cb.name = 'batch1';
-- subquery
select * from student join (select studentid from course_batches , batch_students where 
course_batches.id = batch_students.batchid and name='Batch1') t on student.id = t.studentid;

select m.name , c.name from modules m inner join course_modules cm on m.ID = cm.moduleID join 
course c on c.ID = cm.courseID and c.name = 'PG-DAC';

select course.name,modules.name from modules inner join course ON course.name = 'PG-DAC';

SELECT s.ID, s.namefirst , s.namelast , cb.name from student s inner join batch_students bs on s.ID
= bs.studentID join course_batches cb on cb.ID = bs.batchID;

select distinct s.namefirst, s.namelast, s.emailid, sp.number from student s inner join student_phone sp
on s.ID = sp.studentID and s.id = 13;

select s.namefirst , count(sp.number) from student s join student_phone sp on s.ID = 
sp.studentID group by s.namefirst;

--Get student’s (namefirst, namelast, DOB, address, name, college, university, marks, and year).
select s.namefirst, s.namelast,s.dob,sa.address,sq.name,sq.college,sq.university,sq.marks,sq.year
from student s join student_address sa on s.ID = sa.studentID join student_qualifications sq on s.ID = sq.studentID;

--Get (namefirst, namelast, emailID, phone number, and address) whose faculty name is ‘ketan’.
select * from faculty;
select * from faculty_qualifications;
select * from faculty_address;
select * from faculty_phone;

select f.namefirst, f.namelast,f.emailid,fp.number,fa.address from faculty f inner join faculty_phone 
fp on f.ID = fp.facultyID join faculty_address fa on f.ID = fa.facultyID where namefirst = 'ketan';

--	Get(course name and batch name)for all courses.
select * from course;
select * from course_batches;
select * from batch_students;

--⦁	Get all student details who have taken admission in ‘PG-DAC’ course.
select * from student;
select * from course;
select * from batch_students;
select * from course_batches;
select * from course_modules;


--⦁	Get all course name and module names which are taught in ‘PG-DAC’ course.
select * from modules;
select * from course_modules;
 
select c.name , m.name from modules m inner join course_modules cm on m.ID = cm.moduleID
join course c on c.ID = cm.courseID where c.name = 'PG-DAC';

--⦁	Display how many modules are taught in each course.
select * from modules;
select * from course;
select * from course_modules;

select c.name , count(m.name) from course c inner join course_modules cm on c.ID = cm.courseID join
modules m on cm.moduleID = m.ID group by c.name;

--⦁	Display studentID who have more than 2 phone numbers.

select sp.studentId , COUNT(sp.number) as count from student_phone sp group by sp.studentid having count(number)>2;





