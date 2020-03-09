using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;


namespace Login.Controllers
{
    public class AdmController : Controller
    {
        Funcionario1Entities db = new Funcionario1Entities();
        // GET: Adm
        public ActionResult Cadastrar()
        {

            //A classe list cria uma lista de itens de acordo com o parametro
            //passado, pode ser uma lista de objetos ou uma generica como no 
            // exemplo abaixo. Essas listas serão carregadas pelo drodownlist na view
            List<String> listaCargo = new List<string>();
            listaCargo.Add("Administrador");
            listaCargo.Add("Funcionário");
            listaCargo.Add("Estágiário");
            //passando a lista para a view atraves da viewbag
            ViewBag.status = listaCargo;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Cadastrar (usuario user)
        {
            try
            {
                user.status = "A";
                db.usuarios.Add(user);
                db.SaveChanges();
                return RedirectToAction("Listar", "Principal");
            }

            catch
            {
                return RedirectToAction("Listar", "Principal");
            }
         
        }

        public ActionResult Alterar(int ? id)
        {
            if (id==null)
            {
                return RedirectToAction("Listar", "Principal");
            }

            else
            {
                //a classe list cria uma lista de itens de acordo com o parametro
                //passado, pode ser uma lista de objetos ou uma generica como no 
                //exemplo abaixo. Essas listas serão carregadas pelo dropdownlist na view
                List<String> listaCargo = new List<string>();
                listaCargo.Add("Administrador");
                listaCargo.Add("Funcionário");
                listaCargo.Add("Estágiário");
                //passando a lista para a view atraves da viewbag
                ViewBag.status = listaCargo;
                //criando uma list para o status do funcionario
                List<String> listaStatus = new List<string>();
                listaStatus.Add("Ativo");
                listaStatus.Add("Inativo");   
                ViewBag.status = listaStatus;
               
                usuario user =  db.usuarios.Find(id);
                return View (user);
            }


         

           }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alterar([Bind(Include = "idFuncionario, nome, email.login, senha, cargo, status")]usuario user)
        {
            /*
             * O [Bind (Include =atributos)] irá popular somente os atributos adicionados no Includ,
             * caso o POST envie algo alem do listado, esse será desconsiderado.
             * O if abaixo irá verificar a seleção do DropDown e 
             * irá atribuir ao campo status o char correspondente.*/

            if (user.status.Equals("Ativo"))

            {
                user.status = "A";
            }

            else

            {
                user.status = "I";
            }

            //o codigo abaixo irá informar ao entity que a operação será de Update 
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //SaveChanges()fará o entity executar o comando de update(comando acima) no SQL.
            db.SaveChanges();
            return RedirectToAction("Listar", "Principal");

        }

        public ActionResult Delete (int? id)
        {
            usuario user = db.usuarios.Find(id);
            return View(user);
        }

        //POST: usuarios/Delete/
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirma (int? id)
        {
            usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Listar", "Principal");
        }

        public ActionResult Administrar()
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View(db.usuarios.ToList());
        }

        public ActionResult Sair()
        {
            Session["cargo"] =null;
            Session["login"] = null;
            Session["nomeUsuarioLogado"] = null;
            return RedirectToAction("Index" ,"Principal");
        }
    }
}