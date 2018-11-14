using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;

namespace TpGrupal.Models
{
    public static class BD
    {
        private static string conexion = "Server=.;Database=QEQB06;Trusted_Connection=true;";
        //private static string conexion = "Server=10.128.8.16;Database=QEQB06;User Id=QEQB06;Password=QEQB06;";
        private static SqlConnection Conectar()
        {
            SqlConnection conector = new SqlConnection(conexion);
            conector.Open();
            return conector;
        }
        private static void Desconectar(SqlConnection conector)
        {
            conector.Close();
        }

        public static int LoginUsuario(Usuarios x)
        {
            int Devolver = 0;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_LoginUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            consulta.Parameters.AddWithValue("@pMail", x.Mail);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Devolver = Convert.ToInt32(dataReader["IDUsuario"]);
            }
            Desconectar(conexion);

            return Devolver;
        }
        public static void LogOut()
        {
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "Logout";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.ExecuteNonQuery();
            Desconectar(conexion);
        }

        public static bool VerSiEsAdmin()
        {
            bool Admin = false;
            string ver = "";
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_VerificarAdmin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                ver = dataReader["Tipo"].ToString();
            }
            if (ver == "Admin")
            {
                Admin = true;
            }

            Desconectar(conexion);
            return Admin;
        }

        public static int VerSesion()
        {
            int retorno = 0;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "VerificarSesion";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                retorno = Convert.ToInt32(dataReader["IDUsuario"]);
            }
            Desconectar(conexion);

            return retorno;
        }
        ////////////////////ABM///CATEGORIA///////////////////////////////////////
        public static bool RegistrarCategoria(string tipo)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RegistrarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pTipo", tipo);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool ModificarCategoria(string tipo, int idcateg)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pTipo", tipo);
            consulta.Parameters.AddWithValue("@pIdCategoria", idcateg);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarCategoria(int idcateg)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdCategoria", idcateg);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static Categorias ObtenerCategorias(int IdCat)
        {
            Categorias MiCat = new Categorias();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IdCat);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                MiCat.IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]);
                MiCat.Tipo = (dataReader["Tipo"].ToString());
            }
            Desconectar(conexion);
            return MiCat;
        }
        public static List<Categorias> ListarCategoria()
        {
            List<Categorias> Cat = new List<Categorias>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]);
                string Tipo = (dataReader["Tipo"].ToString());
                Categorias C = new Categorias(IdCategoria, Tipo);
                Cat.Add(C);
            }
            Desconectar(conexion);
            return Cat;
        }
        ////////////////////ABM///USUARIOS///////////////////////////////////////

        public static bool RegistarUsuario(Usuarios x)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RegistrarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            consulta.Parameters.AddWithValue("@pMail", x.Mail);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }

        public static bool ModificarUsuario(Usuarios x)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdusuario", x.IdUsuario);
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            consulta.Parameters.AddWithValue("@pMail", x.Mail);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarUsuario(int idusuario)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdusuario", idusuario);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static Usuarios ObtenerUsuario(int IdUser)
        {
            Usuarios MiUser = new Usuarios();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IdUser);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                MiUser.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                MiUser.Mail = (dataReader["Mail"].ToString());
                MiUser.Nombre = (dataReader["Nombre"].ToString());
                MiUser.Contraseña = (dataReader["Contraseña"].ToString());
                MiUser.Tipo = (dataReader["Tipo"].ToString());
                MiUser.Bitcoins = Convert.ToInt32(dataReader["Bitcoins"]);
            }
            Desconectar(conexion);
            return MiUser;
        }
        public static List<Usuarios> ListarUsurios()
        {
            List<Usuarios> User = new List<Usuarios>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                string Mail = (dataReader["Mail"].ToString());
                string Nombre = (dataReader["Nombre"].ToString());
                string Contraseña = (dataReader["Contraseña"].ToString());
                string Tipo = (dataReader["Tipo"].ToString());
                int Bitcoins = Convert.ToInt32(dataReader["Bitcoins"]);
                Usuarios U = new Usuarios(IdUsuario, Mail, Nombre, Contraseña, Tipo, Bitcoins);
                User.Add(U);
            }
            Desconectar(conexion);
            return User;
        }

        public static string VerUsuarioMail(string Mail)
        {
            string retorno = "";
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_VerUsuarioMail";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pMail", Mail);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                retorno = dataReader["Mail"].ToString();
            }
            Desconectar(conexion);
            return retorno;
        }
        ////////////////////ABM///PREGUNTAS//////////////////////////////////////
        /*
        public static bool RegistrarPregunta(string Descripcion)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pDescripcion", Descripcion);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool ModificarPregunta(int idatri, string Descripcion)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdAtributo", idatri);
            consulta.Parameters.AddWithValue("@pDescripcion", Descripcion);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarPregunta(int idatri)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdAtributo", idatri);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static Preguntas ObtenerPregunta(int IdPreg)
        {
            Preguntas Preg = new Preguntas();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IdPreg);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                Preg.Id = Convert.ToInt32(dataReader["IdPersonaje"]);
                Preg.Nombre = (dataReader["Nombre"].ToString());


            }

            Desconectar(conexion);
            return Preg;
        }
        public static List<Preguntas> ListarPregunta()
        {
            List<Personajes> PJ = new List<Personajes>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdPersonaje = Convert.ToInt32(dataReader["IdPersonaje"]);
                string Nombre = (dataReader["Nombre"].ToString());
                int Categoria = Convert.ToInt32(dataReader["Categoria"]);
                string Imagen = (dataReader["Imagen"].ToString());
                Personajes M = new Personajes(IdPersonaje, Nombre, Categoria, Imagen);
                PJ.Add(M);
            }
            Desconectar(conexion);
            return PJ;
        }
        */
        ////////////////////ABM///PERSONAJES///////////////////////////////////////
        public static bool RegistrarPersonaje(Personajes Registrar)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RegistrarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pImagen", Registrar.Imagen);
            consulta.Parameters.AddWithValue("@pNombre", Registrar.Nombre);
            consulta.Parameters.AddWithValue("@pCategoria", Registrar.Categoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }

        public static bool ModificarPersonaje(Personajes x)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificaPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pImagen", x.Imagen);
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pCategoria", x.Categoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarPersonaje(int idatri)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdAtributo", idatri);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static Personajes ObtenerPersonaje(int IdPersonaje)
        {
            Personajes MiPersonaje = new Personajes();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IdPersonaje);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                MiPersonaje.Id = Convert.ToInt32(dataReader["IdPersonaje"]);
                MiPersonaje.Nombre = (dataReader["Nombre"].ToString());
                MiPersonaje.Imagen = (dataReader["Imagen"].ToString());
                MiPersonaje.Categoria = Convert.ToInt32(dataReader["Categoria"]);

            }

            Desconectar(conexion);
            return MiPersonaje;
        }
        public static List<Personajes> ListarPersonajes()
        {
            List<Personajes> PJ = new List<Personajes>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdPersonaje = Convert.ToInt32(dataReader["IdPersonaje"]);
                string Nombre = (dataReader["Nombre"].ToString());
                int Categoria = Convert.ToInt32(dataReader["Categoria"]);
                string Imagen = (dataReader["Imagen"].ToString());
                Personajes M = new Personajes(IdPersonaje, Nombre, Categoria, Imagen);
                PJ.Add(M);
            }
            Desconectar(conexion);
            return PJ;
        }
    }
    //////////////////////////////////////////////////////////////

}
