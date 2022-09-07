create table employee_payroll1(
Id int primary key identity,
name varchar(50),
phone varchar(15),
address varchar(100),
department varchar(20),
gender varchar(1),
basic_pay money,
deduction money,
taxable_pay money,
tax money,
netpay money,
startDate date
);

select * from employee_payroll1

insert into employee_payroll1 values
('Bili',12000456455,'pune','HR','F',22000,1500,200,300,25000,'2022-06-27'),
('Terisa',120065646455,'pune','HR','F',23000,1800,300,400,26000,'2022-06-28'),
('Charlie',96580456455,'pune','HR','M',21000,1400,150,250,24000,'2022-06-24')


select * from employee_payroll1
