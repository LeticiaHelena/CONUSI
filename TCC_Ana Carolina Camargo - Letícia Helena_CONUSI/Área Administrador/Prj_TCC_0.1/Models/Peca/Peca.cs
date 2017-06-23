using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_TCC_0._1.Models
{
    public class Peca 
    {
        public Peca () 
        {
            Tipo = new Tipo();
        }
        public Peca(int id, string codconusi, Tipo tipo) 
        {
            Id = id;
            CodConusi = codconusi;
            Tipo = tipo;
        }

        [Key]
        public int    Id{ get; set; }
        [Display(Name = "Código Conusi")]
        [Required]
        public string CodConusi { get; set; }

        public Tipo Tipo { get; set; }
    }
}