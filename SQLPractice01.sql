--Get(course name and batch name)for all courses.

select * from course 
select * from course_batches

SELECT 
    s.ID, 
    s.[name], 
    STRING_AGG(cb.[name], ', ') AS Batches
FROM course s 
INNER JOIN course_batches cb 
ON s.ID = cb.courseID
GROUP BY s.ID, s.[name];

--Get all student details who have taken admission in ‘PG-DAC’ course
select * from student
select * from course
select * from course_batches
select * from batch_students

select distinct s.id, s.namefirst, c.[name] 
from student s inner join batch_students bs
on s.ID = bs.studentID inner join course_batches cb
on bs.batchID = cb.ID inner join course c
on cb.courseID = c.ID
where c.name = 'PG-DAC'
order by s.ID

--Get all course details which had started on ‘2016-02-01’.
select * from course_batches where starton = '2016-02-01';
select * from student

--Get all course name and module names which are taught in ‘PG-DAC’ course
select * from modules
select * from course
select * from course_modules

select m.* from course c 
join course_modules cm 
on c.ID = cm.courseID 
join modules m 
on cm.moduleID = m.ID
where c.name = 'PG-DAC'



--SELECT CONCAT(
  --  SUBSTRING_INDEX(emailid, ' ', 1), 
    --'XYZ.', 
    --SUBSTRING_INDEX(emailid, ' ', -1)) 
--FROM student;

--SELECT 
  --  CONCAT(PARSENAME(REPLACE(fullName, ' ', '.'), 3), ' XYZ ', 
	--	   PARSENAME(REPLACE(fullName, ' ', '.'), 1)) AS MaskedName
--FROM (SELECT 'Bhvesh Yash Gharat' AS fullName) AS t;


--Display how many modules are taught in each course.
select c.[name], count(m.[name]) 
from course c join course_modules cm 
on c.ID = cm.courseID
join modules m 
on cm.moduleID = m.ID
group by c.[name]

--Display the student detail who are ‘BE’ graduate
select * from student
select * from student_qualifications

select s.namefirst , sq.university 
from student s join student_qualifications sq
on s.ID = sq.studentID
where sq.[name] = 'BE'

with firstCTE (FirstName, LastName)
as 
	(select namefirst, namelast from student)
	select * from firstCTE;

--Display all distinct course detail, where module for every course is designed. 
select distinct c.* from course c 
join course_modules cm
on c.ID = cm.courseID

