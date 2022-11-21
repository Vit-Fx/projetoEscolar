using MySql.Data.MySqlClient;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Dados
{
    public class AcProfessor
    {
        Conexao con = new Conexao();
        public void inserirProfessor(Professor cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbProfessor (nomeProf) values (@nomeProf)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@nomeProf", MySqlDbType.VarChar).Value = cm.nomeProf;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        MySqlDataReader dr;
        public void AtualizarNomeProfessor(Professor cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbProfessor set nomeProf=@nomeProf where codProf=@codProf", con.MyConectarBD());

            cmd.Parameters.Add("@codProf", MySqlDbType.VarChar).Value = cm.codProf;
            cmd.Parameters.Add("@nomeProf", MySqlDbType.VarChar).Value = cm.nomeProf;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable consultaProf()

        {

            MySqlCommand cmd = new MySqlCommand("select * from tbProfessor", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable Prof = new DataTable();

            da.Fill(Prof);

            con.MyDesConectarBD();

            return Prof;

        }
    }
}