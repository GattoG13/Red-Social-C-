using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion
    {
        public int Id { get; set; }
        private static int _utlId;
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Miembro Autor { get; set; }
        private List<Reaccion> _reacciones = new List<Reaccion>();
        public List<Reaccion> Reacciones { get { return _reacciones; } }

        /// <summary>
        /// Valida que el objeto reaccion no sea nulo y que no exista en la lista _reacciones
        /// Agrega el objeto reaccion a la lista _reacciones.
        /// </summary>
        /// <returns></returns>
        public void AgregarReaccion(Reaccion reaccion)
        {
            if (reaccion == null)
            {
                throw new Exception("Reaccion no válido");
            }
            if (_reacciones.Contains(reaccion))
            {
                throw new Exception("La reaccion ya existe");
            }
            _reacciones.Add(reaccion);
        }

        //Constructor
        public Publicacion(string titulo, string contenido, Miembro autor, DateTime fechaPublicacion)
        {
            Id = ++_utlId;
            Titulo = titulo;
            Contenido = contenido;
            FechaPublicacion = fechaPublicacion;
            Autor = autor;
        }

        //Validaciones
        public void Validar()
        {
            ValidarTitulo();
            ValidarContenido();
            ValidarAutor();
        }

        /// <summary>
        /// Valida que el string Titulo sea mayor a 3 caracteres y que no sea vacio o nulo con un boolean.
        /// </summary>
        public void ValidarTitulo()
        {
            if (Titulo.Length < 3 || !LibreriaMetodos.StringValido(Titulo))
            {
                throw new Exception("El titulo debe ser mayor a tres caracteres");
            }
        }

        /// <summary>
        /// Valida que el string Contenido no sea vacio o nulo con un boolean
        /// </summary>
        public void ValidarContenido()
        {
            if (!LibreriaMetodos.StringValido(Contenido))
            {
                throw new Exception("El contenido no puede ser vacio");
            }
        }

        /// <summary>
        /// Valida que el objeto no sea nulo.
        /// </summary>
        public void ValidarAutor()
        {
            if (!LibreriaMetodos.ObjetoValido(Autor))
            {
                throw new Exception("El Autor es incorrecto");
            }
        }

        //Sobreescribe lo que se muestra en consola.
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Id : {Id} \n";
            respuesta += $"Titulo : {Titulo} \n";
            respuesta += $"Contenido : {LibreriaMetodos.AcortarString(Contenido)} \n";
            respuesta += $"Autor : {Autor.Email} \n";
            respuesta += $"Fecha Publicación : {FechaPublicacion} \n";
            respuesta += $"Tipo de publicacion : {Tipo()} \n";
            return respuesta;
        }

        public abstract string Tipo();

        /// <summary>
        /// Convierte el objeto obj a una Publicacion(unP).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Id de la Publicacion con el Id del objeto(unP)</returns>
        public override bool Equals(object? obj)
        {
            Publicacion? unP = obj as Publicacion;
            return unP != null && Id == unP.Id;
        }
    }
}
