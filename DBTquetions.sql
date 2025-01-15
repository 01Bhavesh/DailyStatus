select count(*) as count from student;

select count(*) as count from student where datename(year, dob) = 1986;

select count(*) as count from student where namefirst like 'b%';

select COUNT(*) as count from student where DATENAME(month,dob)='july';

select studentId, count(*) from student_phone group by studentid having count(number) > 2;

select distinct university from student_qualifications;

select university , count('BE') from student_qualifications group by university ;

select * from student_qualifications;

select count(*) from student_qualifications where name = 'be'; 

select count(distinct studentid) from student_qualifications where name != 'be';

select max(marks) from student_qualifications where name = 'be';

select min(marks) from student_qualifications where name = 'be';

select count(*) from course_batches where starton = '2016-02-01';

select count(*) from student_qualifications where marks > 60 and name = 'be';

select count(*) from student_qualifications where marks > 60 and name = 'be' and university='Harvard university';