using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.Models;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Clients.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IAsyncDocumentSession _asyncSession;

        public ClientsController(IAsyncDocumentSession session)
        {
            _asyncSession = session;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _asyncSession.Query<Client>().ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            await _asyncSession.StoreAsync(client);
            await _asyncSession.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View(await _asyncSession.LoadAsync<Client>(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _asyncSession.StoreAsync(client);
            await _asyncSession.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}