using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpGrupal.Models;
using System.IO;

namespace TpGrupal.Controllers
{
    public class ABMsController : Controller
    {
        // GET: ABMs
        ////////////////////ABM///PERSONAJE///////////////////////////////////////
        public ActionResult Personajes()
        {
            return View();
        }
        public ActionResult EdicionPersonaje(Personajes C, string Accion, int ID = 0)
        {
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                bool x = true;
                ViewBag.Accion = Accion;
                List<Personajes> listaPersonajes = new List<Personajes>();
                listaPersonajes = BD.ListarPersonajes();
                ViewBag.Personajes = listaPersonajes;


                if (Accion == "Modificar")
                {

                    bool B = BD.ModificarPersonaje(C);
                    return View("Personajes", "ABMs", C);
                }
                if (Accion == "Ver")
                {
                    C = BD.ObtenerPersonaje(ID);
                    ViewBag.Imagen = C.Imagen;
                    return View("Personajes", "ABMs", C);
                }
                if (Accion == "Eliminar")
                {
                    List<Personajes> lista = BD.ListarPersonajes();
                    foreach (Personajes miPersonaje in lista)
                    {
                        if (miPersonaje.Id == ID)
                        {
                            ViewBag.BajaCategoria = "No se puede eliminar la categoría seleccionada porque uno o más personajes pertenecen a ella";
                            x = false;
                            List<Personajes> Personaje = new List<Personajes>();
                            Personaje = BD.ListarPersonajes();
                            ViewBag.Lista = Personaje;
                        }
                    }
                    if (x == true)
                    {
                        BD.EliminarCategoria(ID);
                        List<Personajes> Personaje = new List<Personajes>();
                        Personaje = BD.ListarPersonajes();
                        ViewBag.Lista = Personaje;
                    }
                    return View("Personajes","ABMs");
                }
                if (Accion == "Insertar")
                {
                    return View("Personajes","ABMs");
                }

                return View("Personajes", "ABMs");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CosasAPersonaje(string Imagen, Personajes x, string Accion, int Id = 0)
        {
            x.Categoria = Id;
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                if (Accion == "Insertar")
                {
                    BD.RegistrarPersonaje(x);
                }
                if (Accion == "Modificar")
                {
                    x.Imagen = Imagen;
                    if (Imagen != x.Imagen)
                        BD.ModificarPersonaje(x);
                }
                List<Personajes> MiPersonaje = new List<Personajes>();
                MiPersonaje = BD.ListarPersonajes();

                ViewBag.Lista = MiPersonaje;
                return View("Personajes");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ////////////////////ABM///CATEGORIA///////////////////////////////////////

        public ActionResult Categoria()
        {
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                List<Categorias> Categoria = new List<Categorias>();
                Categoria = BD.ListarCategoria();
                ViewBag.Lista = Categoria;
                return View("Categorias");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult EdicionCategoria(string Accion, int ID = 0)
        {
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                bool x = true;
                ViewBag.Accion = Accion;
                if (Accion == "Modificar")
                {
                    Categorias C = BD.ObtenerCategorias(ID);
                    ViewBag.Id = ID;
                    return View("FormTrabajador", C);
                }
                if (Accion == "Ver")
                {
                    Categorias C = BD.ObtenerCategorias(ID);
                    return View("Categoria","ABMs", C);
                }
                if (Accion == "Eliminar")
                {
                    List<Categorias> lista = BD.ListarCategoria();
                    foreach (Categorias miCat in lista)
                    {
                        if (miCat.IdCategoria == ID)
                        {
                            ViewBag.BajaCategoria = "No se puede eliminar la categoría seleccionada porque uno o más personajes pertenecen a ella";
                            x = false;
                            List<Categorias> Categoria = new List<Categorias>();
                            Categoria = BD.ListarCategoria();
                            ViewBag.Lista = Categoria;
                        }
                    }
                    if (x == true)
                    {
                        BD.EliminarCategoria(ID);
                        List<Categorias> Categoria = new List<Categorias>();
                        Categoria = BD.ListarCategoria();
                        ViewBag.Lista = Categoria;
                    }
                    return View("Categorias");
                }
                if (Accion == "Insertar")
                {
                    return View("Categoria", "ABMs");
                }

                return View("Categoria", "ABMs");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CosasATrabajador(Categorias x, string Accion, int Id = 0)
        {
            x.IdCategoria = Id;
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                if (Accion == "Insertar")
                {
                    BD.RegistrarCategoria(x.Tipo);
                }
                if (Accion == "Modificar")
                {
                    BD.ModificarCategoria(x.Tipo, x.IdCategoria);
                }
                List<Categorias> MiCat = new List<Categorias>();
                MiCat = BD.ListarCategoria();

                ViewBag.Lista = MiCat;
                return View("Categorias");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ////////////////////ABM///USUARIOS///////////////////////////////////////

        public ActionResult Usuarios()
        {

            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                List<Usuarios> User = new List<Usuarios>();
                User = BD.ListarUsurios();
                ViewBag.Lista = User;
                return View("Usuarios");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult EdicionUsuario(string Accion, int ID = 0)
        {
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                bool x = true;
                ViewBag.Accion = Accion;
                if (Accion == "Modificar")
                {
                    Usuarios C = BD.ObtenerUsuario(ID);
                    ViewBag.Id = ID;
                    return View("Usuarios", "ABMs", C);
                }
                if (Accion == "Ver")
                {
                    Usuarios C = BD.ObtenerUsuario(ID);
                    return View("Usuarios", "ABMs", C);
                }
                if (Accion == "Eliminar")
                {
                    List<Usuarios> lista = BD.ListarUsurios();
                    foreach (Usuarios miUser in lista)
                    {
                        if (miUser.IdUsuario == ID)
                        {
                            ViewBag.BajaCategoria = "No se puede eliminar la categoría seleccionada porque uno o más personajes pertenecen a ella";
                            x = false;
                            List<Usuarios> Usuario = new List<Usuarios>();
                            Usuario = BD.ListarUsurios();
                            ViewBag.Lista = Usuario;
                        }
                    }
                    if (x == true)
                    {
                        BD.EliminarUsuario(ID);
                        List<Usuarios> Usuario = new List<Usuarios>();
                        Usuario = BD.ListarUsurios();
                        ViewBag.Lista = Usuario;
                    }
                    return View("Usuarios");
                }
                if (Accion == "Insertar")
                {
                    return View("Usuarios", "ABMs");
                }

                return View("Usuarios", "ABMs");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CosasATrabajador(Usuarios x, string Accion, int Id = 0)
        {
            x.IdUsuario = Id;
            if (Convert.ToBoolean(Session["Admin"]) == true)
            {
                if (Accion == "Insertar")
                {
                    BD.RegistarUsuario(x);
                }
                if (Accion == "Modificar")
                {
                    BD.ModificarUsuario(x);
                }
                List<Usuarios> MiUs = new List<Usuarios>();
                MiUs = BD.ListarUsurios();

                ViewBag.Lista = MiUs;
                return View("Usuarios");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
    ////////////////////ABM///PREGUNTAS///////////////////////////////////////
    /*
} public ActionResult Preguntas()
    {
        return View();
    }
    */
}