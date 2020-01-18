using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DB_VAGAS
{
    class Vagas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string TipoCargo { get; set; }
        public string Empresa { get; set; }
        public string Local { get; set; }
        public string Salario { get; set; }
        public string Acao { get; set; }

        public Vagas() { }

        public Vagas(int id, string nome, string email, string cpf, string senha, string cargo, string tipocargo, string empresa, string local, string salario, int acao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
            Senha = senha;
            Cargo = cargo;
            TipoCargo = tipocargo;
            Empresa = empresa;
            Local = local;
            Salario = salario;
        }

        public Vagas(string nome, string email, string cpf, string senha, string cargo, string tipocargo, string empresa, string local, string salario, int acao)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Senha = senha;
            Cargo = cargo;
            TipoCargo = tipocargo;
            Empresa = empresa;
            Local = local;
            Salario = salario;
        }

        public int inserir()
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Inserir_Alterar";
            comm.Parameters.Add("@id", SqlDbType.Int).Value = 0;
            comm.Parameters.Add("@nome", SqlDbType.VarChar).Value = Nome;
            comm.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            comm.Parameters.Add("@cpf", SqlDbType.VarChar).Value = CPF;
            comm.Parameters.Add("@senha", SqlDbType.VarChar).Value = Senha;
            comm.Parameters.Add("@acao", SqlDbType.VarChar).Value = 1;
            comm.ExecuteNonQuery();
            Id = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();

            SqlCommand conn = new SqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "sp_Inserir_Atualizar";
            comm.Parameters.Add("@cargo", SqlDbType.VarChar).Value = Cargo;
            comm.Parameters.Add("@tipocargo", SqlDbType.VarChar).Value = TipoCargo;
            comm.Parameters.Add("@empresa", SqlDbType.VarChar).Value = Empresa;
            comm.Parameters.Add("@empresalocal", SqlDbType.VarChar).Value = Local;
            comm.Parameters.Add("@salario", SqlDbType.VarChar).Value = Salario;
            comm.Parameters.Add("@acao", SqlDbType.VarChar).Value = 1;
            comm.Parameters.Add("@id", SqlDbType.Int).Value = 0;
            comm.ExecuteNonQuery();
            Id = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();

            return Id;
        }

    }
}
