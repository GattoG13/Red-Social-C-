using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario : Publicacion
    {
        public int IdPost { get; set; }

        //Constructor
        public Comentario(int idPost, string titulo, string contenido, Miembro autor, DateTime fechaPublicacion) : base(titulo, contenido, autor, fechaPublicacion)
        {
            IdPost = idPost;
            ValidarComentario();
        }

        //Validaciones
        public void ValidarComentario()
        {
            base.Validar();
            ValidIdPost();
        }

        /// <summary>
        /// Valida que el Id del Post sea mayor a 0
        /// </summary>
        public void ValidIdPost()
        {
            if (!(IdPost > 0)) 
            {
                throw new Exception("La id es incorrecta");
            }
        }

        /// <returns>Devuelve un string "*Es un comentario*"</returns>
        public override string Tipo()
        {
            return " * Es un comentario *";
        }
        /// <summary>
        /// Convierte el objeto obj a un Comentario(unC).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Id del Comentario con el Id del objeto (unC)</returns>
        public override bool Equals(object? obj)
        {
            Comentario? unC = obj as Comentario;
            return unC != null && Id == unC.Id;
        }
    }
}
