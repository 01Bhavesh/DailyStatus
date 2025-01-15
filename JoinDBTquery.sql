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