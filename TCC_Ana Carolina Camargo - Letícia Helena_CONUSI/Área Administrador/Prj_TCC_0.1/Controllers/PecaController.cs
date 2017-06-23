using Prj_TCC_0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_TCC_0._1.Controllers
{
    public class PecaController : Controller
    {
        public ActionResult Index(string pesquisa)
        {
            try
            {
                var lst = new PecaDAO().Listar(pesquisa);
                return View("Index", lst);
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao buscar peca. {0}", ex.Message);
                return View(new List<Peca>());
            }
        }

        public ActionResult Cadastro()
        {
            ViewBag.Tipos = new TipoDAO().Listar();

            return View(new Peca());

        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Tipos = new TipoDAO().Listar();

            if (id == null || id == 0)
            {
                return View();
            }

            try
            {
                var obj = new PecaDAO().Buscar((int)id);
                return View(obj);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Não foi possível buscar esse Peca. {0}", ex.Message);
                return View();
            }

        }

        public ActionResult Salvar(Peca peca)
        {
            ViewBag.Tipos = new TipoDAO().Listar();

            if (!ModelState.IsValid)
            {
                return View("Cadastro", peca);
            }

         
            try
            {
                new PecaDAO().Salvar(peca);
                TempData["SuccessMsg"] = "Peça salva com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = string.Format("Não foi possível buscar essa peça. {0}", ex.Message);

            }

            return View("Editar", peca);
        }


        public ActionResult Excluir(int id)
        {
            try
            {
                new PecaDAO().Delete(new Peca { Id = id });
                TempData["SuccessMsg"] = "Peça excluída com sucesso.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao excluir essa peça. {0}", ex.Message);
            }
            return RedirectToAction("Index");
        }

    }
}
