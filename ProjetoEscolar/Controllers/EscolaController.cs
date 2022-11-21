using MySql.Data.MySqlClient;
using ProjetoEscolar.Dados;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoEscolar.Controllers
{
    public class EscolaController : Controller
    {
        // GET: Escola
        public void CarregaAlunos()
        {
            List<SelectListItem> alunos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdEscola;User=root;pwd=12@Teste"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select codAluno, nomeAluno from tbAluno;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    alunos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();


            }

            ViewBag.alunos = new SelectList(alunos, "Value", "Text");
        }

        public void CarregaDisciplina()
        {
            List<SelectListItem> disciplina = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdEscola;User=root;pwd=12@Teste"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select codDisciplina, Disciplina from tbDisciplina;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    disciplina.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();


            }

            ViewBag.disciplina = new SelectList(disciplina, "Value", "Text");
        }

        public void CarregaProfessor()
        {
            List<SelectListItem> professores = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdEscola;User=root;pwd=12@Teste"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProfessor;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    professores.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();


            }

            ViewBag.professores = new SelectList(professores, "Value", "Text");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Escolar()
        {
            return View();
        }
        public ActionResult CadAluno()
        {
            return View();
        }
        Aluno modAluno = new Aluno();
        AcAluno acAlu = new AcAluno();
        [HttpPost]
        public ActionResult CadAluno(FormCollection frm)
        {
            modAluno.nomeAluno = frm["txtNmAluno"];
            modAluno.telAluno = frm["txtTelefone"];
            acAlu.inserirAluno(modAluno);
            ViewBag.Mensagem = "Cadastro Efetuado Com Sucesso";
            return View();
        }

        public ActionResult CadProfessor()
        {
            return View();
        }
        Professor modProf = new Professor();
        AcProfessor acProf = new AcProfessor();
        [HttpPost]
        public ActionResult CadProfessor(FormCollection frm)
        {
            modProf.nomeProf = frm["txtNmProfessor"];
            acProf.inserirProfessor(modProf);
            ViewBag.Mensagem = "Cadastro Efetuado Com Sucesso";
            return View();
        }

        public ActionResult CadNota()
        {
            CarregaAlunos();
            CarregaProfessor();
            CarregaDisciplina();
            return View();
        }

        Nota modNota = new Nota();
        AcNota nota = new AcNota();
        [HttpPost]
        public ActionResult CadNota(Nota modNota)
        {
            CarregaAlunos();
            CarregaProfessor();
            CarregaDisciplina();
            modNota.codProf = Request["professores"];
            modNota.codAluno = Request["alunos"];
            modNota.codDisciplina = Request["disciplina"];

            nota.inserirNota(modNota);
            ViewBag.Mensagem = "Cadastro efetuado com sucesso!";
            return View();
        }



        public ActionResult AtNomeAluno()
        {
            CarregaAlunos();
            return View();
        }
       
        [HttpPost]
        public ActionResult AtNomeAluno(FormCollection frm)
        {
            CarregaAlunos();

            modAluno.codAluno = Request["alunos"];
            modAluno.nomeAluno = Request["txtNomeAluno"];

            acAlu.AtualizarNomeAluno(modAluno);
            ViewBag.atualizar = "Nome Atualizados Com Sucesso!";

            return View();
        }
        public ActionResult AtNomeProf()
        {
            CarregaProfessor();
            return View();
        }

        [HttpPost]
        public ActionResult AtNomeProf(FormCollection frm)
        {
            CarregaProfessor();

            modProf.codProf = Request["professores"];
            modProf.nomeProf = Request["txtNomeProf"];

            acProf.AtualizarNomeProfessor(modProf);
            ViewBag.atualizar = "Nome Atualizados Com Sucesso!";

            return View();
        }

        public ActionResult AtTelAluno()
        {
            CarregaAlunos();
            return View();
        }

        [HttpPost]
        public ActionResult AtTelAluno(FormCollection frm)
        {
            CarregaAlunos();

            modAluno.codAluno = Request["alunos"];
            modAluno.telAluno = Request["txtTelAluno"];

            acAlu.AtualizarTelAluno(modAluno);
            ViewBag.atualizar = "Telefone Atualizado Com Sucesso!";

            return View();
        }

        public ActionResult ConsultaAluno()

        {

            AcAluno acAlu  = new AcAluno();

            GridView dgv = new GridView(); // Instância para a tabela 

            dgv.DataSource = acAlu.consultaAlu(); //Atribuir ao grid o resultado da consulta 

            dgv.DataBind(); //Confirmação do Grid 

            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 

            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 

            dgv.RenderControl(htw); //Comando para construção do Grid na tela 

            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela 

            return View();

        }

        public ActionResult ConsultaProf()

        {

            AcProfessor acProf = new AcProfessor();

            GridView dgv = new GridView(); // Instância para a tabela 

            dgv.DataSource = acProf.consultaProf(); //Atribuir ao grid o resultado da consulta 

            dgv.DataBind(); //Confirmação do Grid 

            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 

            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 

            dgv.RenderControl(htw); //Comando para construção do Grid na tela 

            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela 

            return View();

        }
    }
}