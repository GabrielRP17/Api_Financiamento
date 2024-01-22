create table Financiamento
(
	FinanciamentoId integer Primary key identity (1,1),
	ClienteId integer ,
	Valor integer ,
	NumeroParcelas integer
)


insert into (FinanciamentoValor, FinanciamentoParcelas) values (@FinanciamentoValor, @FinanciamentoParcelas)
Select FinanciamentoId, ClienteId, FinanciamentoValor, FinanciamentoParcelas from @FinanciamentoId, @ClienteId,@FinanciamentoValor, @FinanciamentoParcelas 
update Financiamento set FinanciamentoValor, FinanciamentoParcela = @FinanciamentoValor, @FinanciamentoParcela where FinanciamentoId = @FinanciamentoId