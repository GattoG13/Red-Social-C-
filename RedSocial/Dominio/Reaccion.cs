using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reaccion
    {
        public string EstadoReaccion { get; set; }
        public Miembro Autor { get; set; }

        //Constructor
        public Reaccion(Miembro autor, string estadoReaccion)
        {
            Autor = autor;
            EstadoReaccion = estadoReaccion;
            Validar();
        }

        //Validaciones
        public void Validar()
        {
            ValidarAutor();
            ValidarEstadoReaccion();
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

        /// <summary>
        /// Valida que el string no sea vacio y que el EstadoReaccion sea "LIKE" o "DISLIKE".
        /// </summary>
        public void ValidarEstadoReaccion()
        {
            if (!LibreriaMetodos.StringValido(EstadoReaccion) || !((EstadoReaccion.Equals("LIKE") || EstadoReaccion.Equals("DISLIKE"))))
            {
                throw new Exception("El campo no puede ser vacio y debe contener LIKE o DISLIKE");
            }
        }

        /// <summary>
        /// Convierte el objeto obj a una Reaccion(unR).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Autor de la Reaccion con el Autor del objeto(unR)</returns>
        public override bool Equals(object? obj)
        {
            Reaccion? unR = obj as Reaccion;
            return unR != null && Autor == unR.Autor;
        }
    }
}
