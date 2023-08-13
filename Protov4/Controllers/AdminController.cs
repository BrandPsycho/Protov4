using Microsoft.AspNetCore.Mvc;
using Protov4.DTO;

namespace Protov4.DAO
{
    public class AdminController:Controller
    {
        private readonly MikuTechFactory db;

        public AdminController(IConfiguration configuration)
        {
            db = new MikutechDAO(configuration);
        }
        public ActionResult Producto(string tipo)
        {
            var productos = ListarProductos(tipo);
            return View(productos);
        }
        public ActionResult ProductoSeleccion(string _id)
        {
            var productos = ObjetoSeleccion(_id);
            return View(productos);
        }
        [HttpGet]
        public List<ProductoDTO> ObjetoSeleccion(string _id)
        {
            List<ProductoDTO> productos;
            productos = db.GetSeleccion(_id);
            var ProductoDTO = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre_Producto = p.Nombre_Producto,
                Precio = p.Precio,
                Marca = p.Marca,
                Existencia = p.Existencia,
                Tipo = p.Tipo,
                Especificaciones = new EspecificacionesDTO
                {
                    Fabricante = p.Especificaciones.Fabricante,
                    Modelo = p.Especificaciones.Modelo,
                    Velocidad = p.Especificaciones.Velocidad,
                    Zócalo = p.Especificaciones.Zócalo,
                    TamañoVRAM = p.Especificaciones.TamañoVRAM,
                    Interfaz = p.Especificaciones.Interfaz,
                    Tamañomemoria = p.Especificaciones.Tamañomemoria,
                    TecnologíaRAM = p.Especificaciones.TecnologíaRAM,
                    Almacenamiento = p.Especificaciones.Almacenamiento,
                    Descripción = p.Especificaciones.Descripción
                }

            }).ToList();

            return ProductoDTO;
        }
        [HttpGet]
        public List<ProductoDTO> ListarProductos(string tipo)
        {
            List<ProductoDTO> productos;
            productos = db.GetAllProductos(tipo);
            var ProductoDTO = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre_Producto = p.Nombre_Producto,
                Precio = p.Precio,
                Imagen = p.Imagen,
                Marca = p.Marca,
                Existencia = p.Existencia,
                Tipo = p.Tipo
            }).ToList();

            return ProductoDTO;
        }
        //private readonly DBMongo _context;

        //public AdminController(DBMongo context) { 

        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View();
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
