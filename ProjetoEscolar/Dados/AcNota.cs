using MySql.Data.MySqlClient;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Dados
{
    public class AcNota
    {
        Conexao con = new Conexao();
        public void inserirNota(Nota cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbNotas (codProf, codAluno, codDisciplina, nota) values (@codProf, @codAluno, @codDisciplina, @nota)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@Nota", MySqlDbType.VarChar).Value = cm.nota;
            cmd.Parameters.Add("@codProf", MySqlDbType.VarChar).Value = cm.codProf;
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;
            cmd.Parameters.Add("@codDisciplina", MySqlDbType.VarChar).Value = cm.codDisciplina;


            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        MySqlDataReader dr;
    }
}