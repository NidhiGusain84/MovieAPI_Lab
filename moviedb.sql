create database moviedb;
use moviedb;
create table movie(
id int not null auto_increment,
name varchar(100),
category varchar(100),
primary key (id)
);
insert into movie (id, name, category)
values (1, 'National Treasure', 'Action');
insert into movie (id, name, category)
values (2, 'Leaving Las Vegas', 'Drama');
insert into movie (id, name, category)
values (3, 'High and low', 'Thriller');
insert into movie (id, name, category)
values (4, 'Pearl Harbor', 'Action');
insert into movie (id, name, category)
values (5, 'Throne of Blood', 'Drama');
select * from movie;
select * from movie where category = 'drama';
select * from movie;

select category from movie;

select * from movie where name like 'High and low';

select * from movie where name like '%as%';

