﻿using Microsoft.AspNetCore.Mvc;

namespace Protov4.DAO
{
    public class AdminController:Controller
    {
        private readonly MikuTechFactory db;

        public AdminController(IConfiguration configuration)
        {
            db = new MikutechDAO(configuration);
        }
        //private readonly DBMongo _context;

        //public AdminController(DBMongo context) { 

        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return db.Compras != null ?
                        View(await _context.Compras.ToListAsync()) :
                        Problem("Entity set 'ScrapDbContext.Compras'  is null.");
        }

        public IActionResult Create()
        {
            return View();
        }
        /*Metodo GET para dirigirse a la ventana de eliminar un producto*/
        public IActionResult Delete()
        {
            return View();
        }
        /*Metodo GET para dirigirse a la ventana de ver mas a detalle el producto*/
        public IActionResult Details()
        {
            return View();
        }
        /*Metodo GET para dirigirse a la ventana de editar un producto*/
        public IActionResult Edit()
        {
            return View();
        }

    }
}
