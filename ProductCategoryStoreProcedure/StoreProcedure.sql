use ProductCategories;
--Get product by id
create procedure GetProductById
@id int
as 
	begin
	select * from products where ProductId = 1;
end
--get all category
create procedure GetAllCategory
as
	begin
	select * from Categories;
end

--Add category
create procedure CreateCategory
@CategoryName varchar(25)
as
	begin
	insert into Categories(CategoryName) values(@CategoryName);
end

