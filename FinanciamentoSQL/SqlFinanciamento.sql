create table FinanciamentoCliente
(
	FinanciamentoId integer primary key identity (1,1) ,
	ClienteId integer
)

alter table  Financiamento ADD FinanciamentoJuros decimal (10,2)

alter table Financiamento ADD FinanciamentoId int identity (1,1) primary key

SET IDENTITY_INSERT Financiamento ON
SET IDENTITY_INSERT Financiamento OFF