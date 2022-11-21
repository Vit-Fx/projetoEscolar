using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Models
{
    public class Nota
    {
        public string codProf { get; set; }
        public string codAluno { get; set; }
        public string codDisciplina { get; set; }
        public string nota { get; set; }
    }
}