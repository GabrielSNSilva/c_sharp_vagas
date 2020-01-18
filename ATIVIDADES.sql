create database DB_VAGAS
go

use DB_VAGAS
go


--TABELA USUARIO
create table Usuario(
id		int primary key identity (100,1),
nome	varchar(40),
email	varchar(40),
cpf		char(14),
senha	varchar(20)
)

create procedure sp_Inserir_Alterar
@id			int output,
@nome		varchar(40),
@email		varchar(40),
@cpf		char(14),
@senha		varchar(20),
@acao		int
as
	begin
		if(@acao = 1)
	   begin
	    insert into Usuario(nome, email, cpf, senha)
        values(@nome, @email, @cpf, @senha)
	   end
	   else if(@acao = 2)
	    begin
		 update Usuario set		nome			= @nome,
								email			= @email,
								cpf				= @cpf,
								senha			= @senha
								     
								where   id = @id
		end
	end


--TABELA VAGAS (PROJETO)
create table Vagas(
id				int foreign key references Usuario(id),
cargo			varchar(20),
tipocargo		varchar(20),
empresa			varchar(20),
empresalocal	varchar(20),
salario			varchar(10)
)

create procedure sp_Inserir_Atualizar
@cargo			varchar(20),
@tipocargo		varchar(20),
@empresa		varchar(20),
@empresalocal	varchar(20),
@salario		varchar(10),
@acao			int,
@id				int output
as
	begin
		if(@acao = 1)
	   begin
	    insert into Vagas(cargo, tipocargo, empresa, empresalocal, salario)
        values(@cargo, @tipocargo, @empresa, @empresalocal, @salario)
	   end
	   else if(@acao = 2)
	    begin
		 update Vagas set		cargo				= @cargo,
								tipocargo			= @tipocargo,
								empresa				= @empresa,
								empresalocal		= @empresalocal,
								salario				= @salario
								     
								where   id = @id
		end
	end