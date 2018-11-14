using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpGrupal.Models
{
    public class Personajes
    {
        private int _Id;
        private string _Nombre;
        private int _Categoria;
        private string _Imagen;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Categoria { get => _Categoria; set => _Categoria = value; }
        public string Imagen { get => _Imagen; set => _Imagen = value; }

        public Personajes(int IdNombre, string Nombre, int Categoria, string Imagen)
        {
            this.Id = IdNombre;
            this.Nombre = Nombre;
            this.Categoria = Categoria;
            this.Imagen = Imagen;
        }

        public Personajes()
        {
        }
    }
}