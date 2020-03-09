using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Quitanda.Controllers
{
    public class AdmController : Controller
    {
        SaboresFitnessEntities db = new SaboresFitnessEntities();

        // GET: Adm
        public ActionResult CadastrarProdutos()
        {
            //A classe list cria uma lista de itens de acordo com o parametro
            //passado, pode ser uma lista de objetos ou uma generica como no 
            // exemplo abaixo. Essas listas serão carregadas pelo drodownlist na view
            List<String> listaCategoria = new List<string>();
            listaCategoria.Add("Carne");
            listaCategoria.Add("Frango");
            listaCategoria.Add("Peixe");
            //passando a lista para a view atraves da viewbag
            ViewBag.categoria = listaCategoria;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CadastrarProdutos(Produto user)
        {
            try
            {
                user.Status_Produto = "A";
                db.Produto.Add(user);
                db.SaveChanges();
                return RedirectToAction("ListarProd", "Adm");
            }

            catch
            {
                return RedirectToAction("ListarProd", "Adm");
            }


        }

        public ActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListarProdutos", "Home");
            }

            else
            {
                //a classe list cria uma lista de itens de acordo com o parametro
                //passado, pode ser uma lista de objetos ou uma generica como no 
                //exemplo abaixo. Essas listas serão carregadas pelo dropdownlist na view
                List<String> listaCategoria = new List<string>();
                listaCategoria.Add("Carne");
                listaCategoria.Add("Frango");
                listaCategoria.Add("Peixe");
                //passando a lista para a view atraves da viewbag
                ViewBag.categoria = listaCategoria;

                //criando uma list para o Status do produto
                List<String> listaStatus_Produto = new List<string>();
                listaStatus_Produto.Add("Ativo");
                listaStatus_Produto.Add("Inativo");
                ViewBag.Status_Produto = listaStatus_Produto;

                Produto user = db.Produto.Find(id);
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alterar([Bind(Include = "Id_Produto, Nome_Produto, Valor_Produto, Tamanho_Marmita, Descrição_Produto, Categoria, Status_Produto")]Produto user)
        {
            /*
             * O [Bind (Include =atributos)] irá popular somente os atributos adicionados no Includ,
             * caso o POST envie algo alem do listado, esse será desconsiderado.
             * O if abaixo irá verificar a seleção do DropDown e 
             * irá atribuir ao campo status o char correspondente.*/


            if (user.Status_Produto.Equals("Ativo"))
            {
                user.Status_Produto = "A";
            }
            else
            {
                user.Status_Produto = "I";
            }

            //o codigo abaixo irá informar ao entity que a operação será de Update 
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //SaveChanges()fará o entity executar o comando de update(comando acima) no SQL.
            db.SaveChanges();
            return RedirectToAction("ListarProdutos", "Home");

        }
         public ActionResult Delete (int? id)
        {
            Produto user = db.Produto.Find(id);
            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Produto Produto = db.Produto.Find(id);
            db.Produto.Remove(Produto);
            db.SaveChanges();
            return RedirectToAction("Delete", "Adm");
        }

        public ActionResult CadastrarFun()
        {
            //A classe list cria uma lista de itens de acordo com o parametro
            //passado, pode ser uma lista de objetos ou uma generica como no 
            // exemplo abaixo. Essas listas serão carregadas pelo drodownlist na view
            List<String> listaCargo = new List<string>();
            listaCargo.Add("Administrador");
            listaCargo.Add("Funcionário");
            listaCargo.Add("Estagiário");
            //passando a lista para a view atraves da viewbag
            ViewBag.Cargo = listaCargo;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CadastrarFun(Usuario user)
        {
            try
            {
                user.Status = "A";
                db.Usuario.Add(user);
                db.SaveChanges();
                return RedirectToAction("ListarFun", "Adm");
            }

            catch
            {
                return RedirectToAction("ListarFun", "Adm");
            }


        }

        public ActionResult AlterarFun(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListarFun", "Home");
            }

            else
            {
                //a classe list cria uma lista de itens de acordo com o parametro
                //passado, pode ser uma lista de objetos ou uma generica como no 
                //exemplo abaixo. Essas listas serão carregadas pelo dropdownlist na view
                List<String> listaCargo = new List<string>();
                listaCargo.Add("Administrador");
                listaCargo.Add("Funcionário");
                listaCargo.Add("Estagiário");
                //passando a lista para a view atraves da viewbag
                ViewBag.Cargo = listaCargo;

                //criando uma list para o Status do produto
                List<String> listaStatus = new List<string>();
                listaStatus.Add("Ativo");
                listaStatus.Add("Inativo");
                ViewBag.Status = listaStatus;

                Usuario user = db.Usuario.Find(id);
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AlterarFun([Bind(Include = "Id_Funcionario, Nome, Email, Login, Senha, Cargo, Status")]Usuario user)
        {
            /*
             * O [Bind (Include =atributos)] irá popular somente os atributos adicionados no Includ,
             * caso o POST envie algo alem do listado, esse será desconsiderado.
             * O if abaixo irá verificar a seleção do DropDown e 
             * irá atribuir ao campo status o char correspondente.*/


            if (user.Status.Equals("Ativo"))
            {
                user.Status = "A";
            }
            else
            {
                user.Status = "I";
            }

            //o codigo abaixo irá informar ao entity que a operação será de Update 
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //SaveChanges()fará o entity executar o comando de update(comando acima) no SQL.
            db.SaveChanges();
            return RedirectToAction("ListarFun", "Home");

        }


        public ActionResult DeleteFunc(int? id)
        {
            Usuario user = db.Usuario.Find(id);
            return View(user);
        }


        [HttpPost, ActionName("DeleteFunc")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteFunc(int id)
        {
            Usuario Usuario = db.Usuario.Find(id);
            db.Usuario.Remove(Usuario);
            db.SaveChanges();
            return RedirectToAction("DeleteFunc", "Adm");
        }


        public ActionResult Administrar()
        {
            return View();
        }

        public ActionResult ListarFun()
        {
            return View(db.Usuario.ToList());
        }

        public ActionResult ListarProd()
        {
            return View(db.Produto.ToList());

        }


        public ActionResult Sair()
        {
            Session["Cargo"] = null;
            Session["Login"] = null;
            Session["nomeUsuarioLogado"] = null;
            return RedirectToAction("Index", "Home");
        }

    }


}

