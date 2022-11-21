using MySql.Data.MySqlClient;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Dados
{
    public class AcAluno
    {
        Conexao con = new Conexao();
        public void inserirAluno(Aluno cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAluno (nomeAluno, telAluno) values (@nomeAluno,@telefone)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@nomeAluno", MySqlDbType.VarChar).Value = cm.nomeAluno;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cm.telAluno;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        MySqlDataReader dr;
        public void AtualizarNomeAluno(Aluno cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAluno set nomeAluno=@nomeAluno where codAluno=@codAluno", con.MyConectarBD());

            cmd.Parameters.Add("@nomeAluno", MySqlDbType.VarChar).Value = cm.nomeAluno;
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void AtualizarTelAluno(Aluno cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAluno set telAluno=@telefone where codAluno=@codAluno", con.MyConectarBD());

            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cm.telAluno;
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable consultaAlu()

        {

            MySqlCommand cmd = new MySqlCommand("select * from tbAluno", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable Aluno = new DataTable();

            da.Fill(Aluno);

            con.MyDesConectarBD();

            return Aluno;

        }
    }
}