using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_VAGAS
{
    public static class Banco
    {
        public static SqlConnection Abrir()
        {
            string strConexao = @"Data Source=127.0.0.1;Initial Catalog=DB_VAGAS;User ID=sa;pwd=senac@itq"; //inserir as string de conexão
            SqlConnection cn = new SqlConnection(strConexao);
            cn.Open();//abrir conexão
            return cn;
        }
    }
}
