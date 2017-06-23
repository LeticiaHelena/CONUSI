using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Prj_TCC_0._1.Models
{
    public class Categoria
    {
        public Categoria() 
        {
            Descricao = " ";
        }

        public Categoria(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        
        public int    Id        { get; set; }
        [Display(Name = "Categoria")]
        //[Required]
        public string Descricao { get; set; }
    }
}