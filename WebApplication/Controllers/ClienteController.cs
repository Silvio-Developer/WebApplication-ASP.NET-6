using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        // Referência ao Persistencia.dll
        private Persistencia.Controllers.ClienteController clienteController = new Persistencia.Controllers.ClienteController();
        // GET: ClienteController
        public ActionResult Index()
        {
            return View(clienteController.GetAll());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            Cliente cliente = clienteController.GetAll().Where(c => c.Id == id).First();
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                clienteController.Insert(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente cliente = clienteController.GetAll().Where(c => c.Id == id).First();
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = clienteController.GetAll().Where(c => c.Id == id).First();
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
