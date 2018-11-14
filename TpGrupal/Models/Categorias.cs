using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpGrupal.Models
{
    public class Categorias
    {
        private int _IdCategoria;
        private string _Tipo;

        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }

        public Categorias(int IdCategoria, string Tipo)
        {
            this.IdCategoria = IdCategoria;
            this.Tipo = Tipo;

        }
        public Categorias()
        {
        }
    }
}