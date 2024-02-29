using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro : Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Bloqueado { get; set; }
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Amigo> _amigos = new List<Amigo>();
        public List<Publicacion> Publicaciones { get { return _publicaciones; } }
        public List<Amigo> Amigos { get { return _amigos; } }

        /// <return>Devuelve la lista de Publicaciones: _publicaciones</return>>
        public List<Publicacion> ListaPublicaciones()
        {
            return _publicaciones;
        }

        /// <return>Devuelve la lista de Amigos: _amigos</return>>
        public List<Amigo> ListaAmigos()
        {
            return _amigos;
        }

        /// <summary>
        /// Chequea que el Post no sea nulo informando al usuario en caso de serlo.
        /// Chequea que el Post no exista comparando su Id en la lista _publicaciones.
        /// Valida el Post chequeando que el string Titulo no sea vacio y sea mayor a 3 caracteres, el contenido no vacio y el autor no sea nulo
        /// Agrega el Post a la lista _publicaciones
        /// </summary>
        public void AgregarPost(Post post)
        {
            if (post == null)
            {
                throw new Exception("El Post no es válido.");
            }
            if (_publicaciones.Contains(post))
            {
                throw new Exception($"El Post con id: {post.Id} ya existe.");
            }
            post.ValidarPost();
            _publicaciones.Add(post);
        }

        /// <summary>
        /// Chequea que el Comentario no sea nulo informando al usuario en caso de serlo.
        /// Chequea que el Comentario no exista comparando su Id  en la lista _publicaciones.
        /// Valida el Comentario chequeando que el Id no sea menor a 0
        /// Agrega el Comentario a la lista _publicaciones
        /// </summary>
        public void AgregarComentario(Comentario comentario)
        {
            if (comentario == null)
            {
                throw new Exception("El comentario no es válido.");
            }
            if (_publicaciones.Contains(comentario))
            {
                throw new Exception($"El comentario {comentario.Id} ya existe.");
            }
            comentario.ValidarComentario();
            _publicaciones.Add(comentario);
        }

        /// <summary>
        /// Chequea que el Amigo no sea nulo informando al usuario en caso de serlo.
        /// Chequea que el Amigo no exista comparando su Email.
        /// Agrega al Amigo a la lista _amigos
        /// </summary>
        public void AgregarAmigo(Amigo amigo)
        {
            if (amigo == null)
            {
                throw new Exception("Amigo no valido");
            }
            if (_amigos.Contains(amigo))
            {
                throw new Exception("El amigo ya existe");
            }
            _amigos.Add(amigo);
        }

        //Constructor Miembro
        public Miembro(string email, string contrasena, string nombre, string apellido, DateTime fechaNacimiento, bool bloqueado) : base(email, contrasena)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Bloqueado = bloqueado;
            ValidarMiembro();
        }

        //Validaciones
        public void ValidarMiembro()
        {
            base.Validar();
            ValidarNombre();
            ValidarApellido();
        }

        /// <summary>
        /// Valida que el string Nombre no este vacio con un boolean
        /// </summary>
        public void ValidarNombre()
        {
            if (!LibreriaMetodos.StringValido(Nombre))
            {
                throw new Exception("El campo no puede ser vacio");
            }
        }

        /// <summary>
        /// Valida que el string Apellido no este vacio con un boolean
        /// </summary>
        public void ValidarApellido()
        {
            if (!LibreriaMetodos.StringValido(Apellido))
            {
                throw new Exception("El campo no puede ser vacio");
            }
        }

        /// <returns>Devuelve "*Es Miembro*"</returns>
        public override string Tipo()
        {
            return " * Es Miembro *";
        }

        /// <summary>
        /// Convierte el objeto obj a un Miembro(unM).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Email del Miembro con el Email del objeto(unM)</returns>
        public override bool Equals(object? obj)
        {
            Miembro? unM = obj as Miembro;
            return unM != null && Email.ToLower() == unM.Email.ToLower();
        }
    }
}
