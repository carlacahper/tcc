
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quitanda.Models;

namespace Quitanda.Controllers
{
    public class HomeController : Controller
    {
        SaboresFitnessEntities db = new SaboresFitnessEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //GET:ListarProdutos
        public ActionResult ListarProdutos()
        {
            return View(db.Produto.ToList());
        }

        //GET: ListarFun
        public ActionResult ListarFun()
        {
            return View(db.Usuario.ToList());
        }



        public ActionResult CardapioCarne()
        {
            return View();
        }

        public ActionResult CardapioFrango()
        {
            return View();
        }

        public ActionResult CardapioPeixe()
        {
            return View();
        }


        public ActionResult QuemSomos()
        {
            return View();
        }

        
        public ActionResult Cadastro()
        {
            return RedirectToAction("Cadastro","Cliente");
        }

        public ActionResult Polpetone()
        {
            return View();
        }

        public ActionResult Escondidinho()
        {
            return View();
        }
        public ActionResult PatinhoComPure()
        {
            return View();
        }
        public ActionResult FrangoComMandioquinha()
        {
            return View();
        }
        public ActionResult FrangoDesfiado()
        {
            return View();
        }
        public ActionResult Panqueca()
        {
            return View();
        }
        public ActionResult TilapiaGrelhada()
        {
            return View();
        }
        public ActionResult FileSalmao()
        {
            return View();
        }
        public ActionResult SalmaoComChia()
        {
            return View();
        }

        public ActionResult DeixeSuaMensagem()
        {
            return View();
        }

        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid)
            {
                using (var db = new SaboresFitnessEntities()) //ome do entity localizado no usuario.context
                {

                    /*o comando abaixo ira realizar um select, caso exista um usuario compativel com o login e sneha a estrutura de decisao irá verificar o cargo 
                     e redireciona lo para a pagian corresponde*/

                    var v = db.Usuario.Where(a => a.Login.Equals(u.Login) && a.Senha.Equals(u.Senha)).FirstOrDefault();

                    if (v != null)
                    {

                        if (v.Cargo.Equals("Administrador"))
                        {
                            Session["nomeUsuarioLogado"] = v.Nome.ToString();
                            Session["Login"] = v.Login.ToString();
                            Session["Cargo"] = v.Cargo.ToString();
                            return RedirectToAction("Administrar", "Adm");

                        }

                        if (v.Cargo.Equals("Funcionário") || v.Cargo.Equals("Estagiário"))
                        {
                            Session["nomeUsuarioLogado"] = v.Nome.ToString();
                            return RedirectToAction("Index", "Home");
                        }


                    }

                }

            }

            return View(u);

        }
    }


}
