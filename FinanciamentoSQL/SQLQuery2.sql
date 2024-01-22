
insert into (ClienteNome, ClienteCPF, ClienteRG) values ('@ClienteNome', '@ClienteCPF', '@ClienteRG') 
Update Cliente set ClienteNome = '@ClienteNome' where ClienteId = '@ClienteId'
