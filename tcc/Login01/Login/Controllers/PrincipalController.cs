using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class PrincipalController : Controller
    {
        Funcionario1Entities db = new Funcionario1Entities();
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        //GET: Listar 

        public ActionResult Listar()
        {
            return View(db.usuarios.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(usuario u)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Funcionario1Entities()) //ome do entity localizado no usuario.context
                {

                    /*o comando abaixo ira realizar um select, caso exista um usuario compativel com o login e sneha a estrutura de decisao irá verificar o cargo 
                     e redireciona lo para a pagian corresponde*/

                    var v = db.usuarios.Where(a => a.login.Equals(u.login) && a.senha.Equals(u.senha)).FirstOrDefault();

                    if (v != null)
                    {

                        if (v.cargo.Equals("Administrador"))
                        {
                            Session["nomeUsuarioLogado"] = v.nome.ToString();
                            Session["login"] = v.login.ToString();
                            //caso seja administrador iremos redirecionar para uma pagina especifica 
                            //a qual ainda iremos criar
                            return RedirectToAction("administrador", "Adm");

                        }

                        if (v.cargo.Equals("Funcionário") || v.cargo.Equals("Estagiário"))
                        {
                            Session["nomeUsuarioLogado"] = v.nome.ToString();
                            return RedirectToAction("Index", "Principal");
                        }


                    }

                }

            }

            return View(u);

        }
    }


 }
