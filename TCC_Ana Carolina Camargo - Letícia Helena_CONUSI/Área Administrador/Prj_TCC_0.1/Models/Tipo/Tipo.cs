using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_TCC_0._1.Models
{
    public class Tipo
    {

        public Tipo()
        {

            Descricao = string.Empty;
            CodPeca = 0;


        }
        public Tipo(int id, string descricao, int codpeca)
        {
            IdTipo = id;
            Descricao = descricao;
            this.CodPeca = codpeca;
        }

        public Tipo(int Id, string descricao)
        {
            this.IdTipo = Id;
            Descricao = descricao;
        }

        [Key]
        public int IdTipo { get; set; }

        [Display(Name = "Tipo")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CodPeca { get; set; }

        public Categoria Categoria { get; set; }


    }
}