using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Post : Publicacion
    {
        public string Imagen { get; set; }
        public bool Censura { get; set; }

        //Constructor
        public Post(string titulo, string contenido, Miembro autor, string imagen, bool censura, DateTime fechaPublicacion) : base(titulo, contenido, autor, fechaPublicacion)
        {
            Imagen = imagen;
            Censura = censura;
            ValidarPost();
        }

        //Validaciones
        public void ValidarPost()
        {
            base.Validar();
            ValidarImagen();
        }

        /// <summary>
        /// Valida que el string Titulo termine con un ".jpg" o ".com" y que no sea vacio o nulo con un boolean.
        /// </summary>
        public void ValidarImagen()
        {
            if (!LibreriaMetodos.StringValido(Titulo) || (Titulo.EndsWith(".jpg") || Titulo.EndsWith(".png")))
            {
                throw new Exception("La imagen no debe ser vacia y debe terminar con .jpg o .png");
            }
        }


        /// <returns>Devuelve "*Es un post*"</returns>
        public override string Tipo()
        {
            return " * Es un post *";
        }

        /// <summary>
        /// Convierte el objeto obj a un Post(unP).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Id del Post con el Id del objeto(unP)</returns>
        public override bool Equals(object? obj)
        {
            Post? unP = obj as Post;
            return unP != null && Id == unP.Id;
        }
    }
}
