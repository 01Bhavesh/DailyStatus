--⦁	Display all student who have taken admission in more than 2 batches.
select * from student;
select * from course_batches;
select * from batch_students;
select * from modules;

select s.* from student s 
where s.ID in 
(select studentId from batch_students
group by studentid 
having count(studentid)>2 );

--Display the student detail who have joined the same batch of the student ‘saleel’.
select * from student 
where id in 
(select studentid from batch_students 
where batchid in
(select batchid from batch_students
where studentid in 
(select id from student 
where namefirst = 'saleel'))); 

--Display all courses where least number of students have taken the admission.
select * from course;
select studentid from batch_students;


--Display student details who have not taken the admission.
select s.* from student s 
where id not in
(select studentID from batch_students);

--Get all courses where no modules are defined in course_modules table.
select * from course;
select * from modules;
select * from course_modules;

select * from course 
where id not in 
(select distinct courseid from course_modules);

--Display course_batches details where student has taken the admission.
select * from batch_students;
select * from course_batches;

select * from course_batches 
where id in 
(select batchid from batch_students);

--Display all students whose marks of ‘BE’ is more than ‘ULKA’ marks in ‘BE’.
select * from student;
select * from student_qualifications;
select * from student 
where id in 
(select studentID 
from student_qualifications 
where marks > 
(select marks 
from student_qualifications 
where studentID = 
(select id from student where namefirst = 'ulka')
and name = 'be') and name = 'be');

create database xyz;