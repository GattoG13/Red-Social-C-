using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Invitacion> _invitaciones = new List<Invitacion>();
        public List<Usuario> Usuarios { get { return _usuarios; } }
        public List<Invitacion> Invitaciones { get { return _invitaciones; } }

        /// <summary>
        /// Funcion encargada de precargar todos los datos
        /// </summary>
        public void Precargar()
        {
            PrecargarUsuariosYSusAmigos();
            PrecargarPublicacionesAMiembros();
            PrecargarInvitaciones();
        }

        /// <summary>
        /// Funcion encargada de precargar Usuarios y amigos
        /// </summary>
        private void PrecargarUsuariosYSusAmigos()
        {
            Administrador unAdministrador1 = new Administrador("admin1@gmail.com", "contrasena1adm");
            AltaAdministrador(unAdministrador1);
            Miembro unMiembro1 = new Miembro("correo1@gmail.com", "contrasena1", "Nombre1", "Apellido1", new DateTime(1990, 1, 1), false);
            AltaAMiembro(unMiembro1);
            Miembro unMiembro2 = new Miembro("correo2@gmail.com", "contrasena2", "Nombre2", "Apellido2", new DateTime(1990, 2, 2), false);
            AltaAMiembro(unMiembro2);
            Miembro unMiembro3 = new Miembro("correo3@gmail.com", "contrasena3", "Nombre3", "Apellido3", new DateTime(1990, 3, 3), false);
            AltaAMiembro(unMiembro3);
            Miembro unMiembro4 = new Miembro("correo4@gmail.com", "contrasena4", "Nombre4", "Apellido4", new DateTime(1990, 4, 4), false);
            AltaAMiembro(unMiembro4);
            Miembro unMiembro5 = new Miembro("correo5@gmail.com", "contrasena5", "Nombre5", "Apellido5", new DateTime(1990, 5, 5), false);
            AltaAMiembro(unMiembro5);
            Miembro unMiembro6 = new Miembro("correo6@gmail.com", "contrasena6", "Nombre6", "Apellido6", new DateTime(1990, 6, 6), true);
            AltaAMiembro(unMiembro6);
            Miembro unMiembro7 = new Miembro("correo7@gmail.com", "contrasena7", "Nombre7", "Apellido7", new DateTime(1990, 7, 7), false);
            AltaAMiembro(unMiembro7);
            Miembro unMiembro8 = new Miembro("correo8@gmail.com", "contrasena8", "Nombre8", "Apellido8", new DateTime(1990, 8, 8), false);
            AltaAMiembro(unMiembro8);
            Miembro unMiembro9 = new Miembro("correo9@gmail.com", "contrasena9", "Nombre9", "Apellido9", new DateTime(1990, 9, 9), false);
            AltaAMiembro(unMiembro9);
            Miembro unMiembro10 = new Miembro("correo10@gmail.com", "contrasena10", "Nombre10", "Apellido10", new DateTime(1991, 1, 1), false);
            AltaAMiembro(unMiembro10);
            //Amigos unMiembro1 
            Amigo amigo1 = new Amigo(unMiembro3);
            Amigo amigo2 = new Amigo(unMiembro6);
            Amigo amigo3 = new Amigo(unMiembro9);
            Amigo amigo4 = new Amigo(unMiembro10);
            //Amigos unMiembro2
            Amigo amigo5 = new Amigo(unMiembro3);
            Amigo amigo6 = new Amigo(unMiembro6);
            //Agregar amigos a miembros
            AgregarAmigoAMiembro(unMiembro1, amigo1);
            AgregarAmigoAMiembro(unMiembro1, amigo2);
            AgregarAmigoAMiembro(unMiembro1, amigo3);
            AgregarAmigoAMiembro(unMiembro1, amigo4);
            AgregarAmigoAMiembro(unMiembro2, amigo5);
            AgregarAmigoAMiembro(unMiembro2, amigo6);
        }

        /// <summary>
        /// Funcion encargada de precargar las publicaciones y sus reacciones
        /// </summary>
        private void PrecargarPublicacionesAMiembros()
        {
            Miembro? unMiembro1 = ObtenerMiembroPorMail("correo1@gmail.com");
            Miembro? unMiembro2 = ObtenerMiembroPorMail("correo2@gmail.com");
            Miembro? unMiembro3 = ObtenerMiembroPorMail("correo3@gmail.com");
            Miembro? unMiembro4 = ObtenerMiembroPorMail("correo4@gmail.com");
            Miembro? unMiembro5 = ObtenerMiembroPorMail("correo5@gmail.com");
            Miembro? unMiembro6 = ObtenerMiembroPorMail("correo6@gmail.com");
            Miembro? unMiembro7 = ObtenerMiembroPorMail("correo7@gmail.com");
            Miembro? unMiembro8 = ObtenerMiembroPorMail("correo8@gmail.com");
            Miembro? unMiembro9 = ObtenerMiembroPorMail("correo9@gmail.com");
            Miembro? unMiembro10 = ObtenerMiembroPorMail("correo10@gmail.com");
            //Post 1
            Post post1 = new Post("Primer titulo", "Primer contenido", unMiembro1, "imagen1.jpg", true, new DateTime(1951, 07, 30));
            AgregarPostAMiembro(unMiembro1, post1);
            //Reacciones a Post 1
            Reaccion reaccionP1 = new Reaccion(unMiembro1, "LIKE");
            AgregarReaccionAPost(post1, reaccionP1);
            Reaccion reaccionP2 = new Reaccion(unMiembro7, "LIKE");
            AgregarReaccionAPost(post1, reaccionP2);
            Reaccion reaccionP3 = new Reaccion(unMiembro9, "DISLIKE");
            AgregarReaccionAPost(post1, reaccionP3);
            Reaccion reaccionP4 = new Reaccion(unMiembro4, "DISLIKE");
            AgregarReaccionAPost(post1, reaccionP4);
            //Post 2
            Post post2 = new Post("Segundo titulo", "Segundo contenido", unMiembro1, "imagen2.jpg", false, new DateTime(1952, 07, 30));
            AgregarPostAMiembro(unMiembro1, post2);
            //Reacciones a Post 2
            Reaccion reaccionP5 = new Reaccion(unMiembro6, "LIKE");
            AgregarReaccionAPost(post2, reaccionP5);
            Reaccion reaccionP6 = new Reaccion(unMiembro2, "LIKE");
            AgregarReaccionAPost(post2, reaccionP6);
            Reaccion reaccionP7 = new Reaccion(unMiembro8, "DISLIKE");
            AgregarReaccionAPost(post2, reaccionP7);
            Reaccion reaccionP8 = new Reaccion(unMiembro4, "DISLIKE");
            AgregarReaccionAPost(post2, reaccionP8);
            //Post 3
            Post post3 = new Post("Tercer titulo", "Tercer contenido", unMiembro2, "imagen3.png", true, new DateTime(1953, 07, 30));
            AgregarPostAMiembro(unMiembro2, post3);
            //Reacciones a Post 3
            Reaccion reaccionP9 = new Reaccion(unMiembro6, "LIKE");
            AgregarReaccionAPost(post3, reaccionP9);
            Reaccion reaccionP10 = new Reaccion(unMiembro3, "LIKE");
            AgregarReaccionAPost(post3, reaccionP10);
            Reaccion reaccionP11 = new Reaccion(unMiembro9, "DISLIKE");
            AgregarReaccionAPost(post3, reaccionP11);
            Reaccion reaccionP12 = new Reaccion(unMiembro5, "DISLIKE");
            AgregarReaccionAPost(post3, reaccionP12);
            //Post 4
            Post post4 = new Post("Cuarto titulo", "Cuarto contenido", unMiembro3, "imagen4.png", false, new DateTime(1954, 07, 30));
            AgregarPostAMiembro(unMiembro3, post4);
            //Post 5
            Post post5 = new Post("Quinto titulo", "Quinto contenido, lorem ipsum dolor sit amet, consectetur adipiscing elit.", unMiembro4, "imagen5.jpg", true, new DateTime(1955, 07, 30));
            AgregarPostAMiembro(unMiembro4, post5);
            //Comentarios
            Comentario comentario1 = new Comentario(1, "Primer Comentario", "Comentario1 Contenido", unMiembro1, new DateTime(1956, 07, 30));
            AgregarComentarioAMiembro(unMiembro1, comentario1);
            //Reacciones a Comentario 1
            Reaccion reaccionC1 = new Reaccion(unMiembro4, "LIKE");
            AgregarReaccionAComentario(comentario1, reaccionC1);
            Reaccion reaccionC2 = new Reaccion(unMiembro7, "LIKE");
            AgregarReaccionAComentario(comentario1, reaccionC2);
            Reaccion reaccionC3 = new Reaccion(unMiembro8, "DISLIKE");
            AgregarReaccionAComentario(comentario1, reaccionC3);
            Reaccion reaccionC4 = new Reaccion(unMiembro3, "DISLIKE");
            AgregarReaccionAComentario(comentario1, reaccionC4);
            Comentario comentario2 = new Comentario(1, "Segunda Comentario", "Comentario2 Contenido", unMiembro2, new DateTime(1957, 07, 30));
            AgregarComentarioAMiembro(unMiembro2, comentario2);
            //Reacciones a Comentario 2
            Reaccion reaccionC5 = new Reaccion(unMiembro8, "LIKE");
            AgregarReaccionAComentario(comentario2, reaccionC5);
            Reaccion reaccionC6 = new Reaccion(unMiembro7, "LIKE");
            AgregarReaccionAComentario(comentario2, reaccionC6);
            Reaccion reaccionC7 = new Reaccion(unMiembro9, "DISLIKE");
            AgregarReaccionAComentario(comentario2, reaccionC7);
            Reaccion reaccionC8 = new Reaccion(unMiembro10, "DISLIKE");
            AgregarReaccionAComentario(comentario2, reaccionC8);
            Comentario comentario3 = new Comentario(1, "Tercero Comentario", "Comentario3 Contenido", unMiembro3, new DateTime(1958, 07, 30));
            AgregarComentarioAMiembro(unMiembro3, comentario3);
            Comentario comentario4 = new Comentario(2, "Cuarto Comentario", "Comentario4 Contenido", unMiembro4, new DateTime(1959, 07, 30));
            AgregarComentarioAMiembro(unMiembro4, comentario4);
            Comentario comentario5 = new Comentario(2, "Quinto Comentario", "Comentario5 Contenido", unMiembro5, new DateTime(1960, 07, 30));
            AgregarComentarioAMiembro(unMiembro5, comentario5);
            Comentario comentario6 = new Comentario(2, "Sexto Comentario", "Comentario6 Contenido", unMiembro6, new DateTime(1961, 07, 30));
            AgregarComentarioAMiembro(unMiembro6, comentario6);
            Comentario comentario7 = new Comentario(3, "Séptimo Comentario", "Comentario7 Contenido", unMiembro7, new DateTime(1962, 07, 30));
            AgregarComentarioAMiembro(unMiembro7, comentario7);
            Comentario comentario8 = new Comentario(3, "Octavo Comentario", "Comentario8 Contenido", unMiembro8, new DateTime(1963, 07, 30));
            AgregarComentarioAMiembro(unMiembro8, comentario8);
            Comentario comentario9 = new Comentario(3, "Noveno Comentario", "Comentario9 Contenido", unMiembro10, new DateTime(1964, 07, 30));
            AgregarComentarioAMiembro(unMiembro10, comentario9);
            Comentario comentario10 = new Comentario(4, "Décimo Comentario", "Comentario10 Contenido", unMiembro10, new DateTime(1965, 07, 30));
            AgregarComentarioAMiembro(unMiembro10, comentario10);
            Comentario comentario11 = new Comentario(4, "Undécimo Comentario", "Comentario11 Contenido", unMiembro1, new DateTime(1966, 07, 30));
            AgregarComentarioAMiembro(unMiembro1, comentario11);
            Comentario comentario12 = new Comentario(4, "Duodécimo Comentario", "Comentario12 Contenido", unMiembro10, new DateTime(1967, 07, 30));
            AgregarComentarioAMiembro(unMiembro10, comentario12);
            Comentario comentario13 = new Comentario(5, "Decimotercero Comentario", "Comentario13 Contenido", unMiembro10, new DateTime(1968, 07, 30));
            AgregarComentarioAMiembro(unMiembro10, comentario13);
            Comentario comentario14 = new Comentario(5, "Decimocuarto Comentario", "Comentario14 Contenido", unMiembro4, new DateTime(1969, 07, 30));
            AgregarComentarioAMiembro(unMiembro4, comentario14);
            Comentario comentario15 = new Comentario(5, "Decimoquinto Comentario", "Comentario15 Contenido", unMiembro5, new DateTime(1970, 07, 30));
            AgregarComentarioAMiembro(unMiembro5, comentario15);
        }

        /// <summary>
        /// Funcion encargada de precargar las invitaciones entre los miembros
        /// </summary>
        private void PrecargarInvitaciones()
        {
            Miembro? unMiembro1 = ObtenerMiembroPorMail("correo1@gmail.com");
            Miembro? unMiembro2 = ObtenerMiembroPorMail("correo2@gmail.com");
            Miembro? unMiembro3 = ObtenerMiembroPorMail("correo3@gmail.com");
            Miembro? unMiembro4 = ObtenerMiembroPorMail("correo4@gmail.com");
            Miembro? unMiembro5 = ObtenerMiembroPorMail("correo5@gmail.com");
            Miembro? unMiembro6 = ObtenerMiembroPorMail("correo6@gmail.com");
            Miembro? unMiembro7 = ObtenerMiembroPorMail("correo7@gmail.com");
            Miembro? unMiembro8 = ObtenerMiembroPorMail("correo8@gmail.com");
            Miembro? unMiembro9 = ObtenerMiembroPorMail("correo9@gmail.com");
            Miembro? unMiembro10 = ObtenerMiembroPorMail("correo10@gmail.com");
            //Invitaciones Miembro 1
            Invitacion invitacion1 = new Invitacion(unMiembro1, unMiembro2, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion1);
            Invitacion invitacion2 = new Invitacion(unMiembro1, unMiembro3, "APROBADA");
            AltaInvitacion(invitacion2);
            Invitacion invitacion3 = new Invitacion(unMiembro1, unMiembro4, "RECHAZADA");
            AltaInvitacion(invitacion3);
            Invitacion invitacion4 = new Invitacion(unMiembro1, unMiembro5, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion4);
            Invitacion invitacion5 = new Invitacion(unMiembro1, unMiembro6, "APROBADA");
            AltaInvitacion(invitacion5);
            Invitacion invitacion6 = new Invitacion(unMiembro1, unMiembro7, "RECHAZADA");
            AltaInvitacion(invitacion6);
            Invitacion invitacion7 = new Invitacion(unMiembro1, unMiembro8, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion7);
            Invitacion invitacion8 = new Invitacion(unMiembro1, unMiembro9, "APROBADA");
            AltaInvitacion(invitacion8);
            Invitacion invitacion9 = new Invitacion(unMiembro1, unMiembro10, "APROBADA");
            AltaInvitacion(invitacion9);
            //Invitaciones Miembro 2
            Invitacion invitacion11 = new Invitacion(unMiembro2, unMiembro3, "APROBADA");
            AltaInvitacion(invitacion11);
            Invitacion invitacion12 = new Invitacion(unMiembro2, unMiembro4, "RECHAZADA");
            AltaInvitacion(invitacion12);
            Invitacion invitacion13 = new Invitacion(unMiembro2, unMiembro5, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion13);
            Invitacion invitacion14 = new Invitacion(unMiembro2, unMiembro6, "APROBADA");
            AltaInvitacion(invitacion14);
            Invitacion invitacion15 = new Invitacion(unMiembro2, unMiembro7, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion15);
            Invitacion invitacion16 = new Invitacion(unMiembro2, unMiembro8, "RECHAZADA");
            AltaInvitacion(invitacion16);
            Invitacion invitacion17 = new Invitacion(unMiembro2, unMiembro9, "PENDIENTE_APROBACION");
            AltaInvitacion(invitacion17);
        }

        public void AltaAdministrador(Administrador administrador)
        {
            if (administrador == null)
            {
                throw new ArgumentNullException("El administrador recibido no es válido.");
            }
            if (_usuarios.Contains(administrador))
            {
                throw new Exception($"El administrador {administrador.Email} ya existe.");
            }
            administrador.Validar();
            _usuarios.Add(administrador);
        }

        public void AltaAMiembro(Miembro miembro)
        {
            if (miembro == null)
            {
                throw new ArgumentNullException("El miembro recibido no es válido.");
            }
            if (_usuarios.Contains(miembro))
            {
                throw new Exception($"El miembro {miembro.Email} ya existe.");
            }
            miembro.Validar();
            _usuarios.Add(miembro);
        }

        /// <summary>
        /// Chequea que el Miembro o el Post no sean nulos informando al usuario en caso de serlo/s
        /// Agrega el Post al Miembro.
        /// </summary>
        public void AgregarPostAMiembro(Miembro miembro, Post post)
        {
            if (miembro == null || post == null)
            {
                throw new Exception("Post invalido");
            }
            miembro.AgregarPost(post);
        }

        /// <summary>
        /// Chequea que el Miembro o el Comentario no sean nulos informando al usuario en caso de serlo/s
        /// Agrega el Comentario al Miembro.
        /// </summary>
        public void AgregarComentarioAMiembro(Miembro miembro, Comentario comentario)
        {
            if (miembro == null || comentario == null)
            {
                throw new Exception("comentario invalido");
            }
            miembro.AgregarComentario(comentario);
        }

        /// <summary>
        /// Chequea que la Reaccion o el Post no sean nulos informando al usuario en caso de serlo/s
        /// Agrega la Reaccion al Post.
        /// </summary>
        public void AgregarReaccionAPost(Post post, Reaccion reaccion)
        {
            if (post == null || reaccion == null)
            {
                throw new Exception("Persona invalida");
            }
            post.AgregarReaccion(reaccion);
        }

        /// <summary>
        /// Chequea que la Reaccion o el Comentario no sean nulos informando al usuario en caso de serlo/s
        /// Agrega la Reaccion al Comentario.
        /// </summary>
        public void AgregarReaccionAComentario(Comentario comentario, Reaccion reaccion)
        {
            if (comentario == null || reaccion == null)
            {
                throw new Exception("Persona invalida");
            }
            comentario.AgregarReaccion(reaccion);
        }

        /// <summary>
        /// Chequea que el Amigo o el Miembro no sean nulos informando al usuario en caso de serlo/s
        /// Agrega el Amigo al Miembro.
        /// </summary>
        public void AgregarAmigoAMiembro(Miembro miembro, Amigo amigo)
        {
            if (miembro == null || amigo == null)
            {
                throw new Exception("Persona invalida");
            }
            miembro.AgregarAmigo(amigo);
        }

        /// <summary>
        /// Chequea que la Invitacion no sea nula informando al usuario en caso de serlo
        /// Chequea que la Invitacion no exista informando al usuario en caso de serlo
        /// Valida la Invitacion chequeando que los objetos no esten vacios y que los strings sean validos, no estando vacios y chequeando que sean "PENDIENTE_APROBACION", "APROBADA" O "RECHAZADA"
        /// Agrega la Invitacion a la lista _invitaciones
        /// </summary>
        public void AltaInvitacion(Invitacion invitacion)
        {
            if (invitacion == null)
            {
                throw new Exception("El Post no es válido.");
            }
            if (_invitaciones.Contains(invitacion))
            {
                throw new Exception($"El Post con id: {invitacion.Id} ya existe.");
            }
            invitacion.Validar();
            _invitaciones.Add(invitacion);
        }

        /// <summary>
        /// Recorre la lista de usuarios
        /// Chequea que el email del usuario sea el mismo que recibe por parametro.
        /// </summary>
        /// <return>Devuelve al usuario o null</return>>
        public Usuario? ObtenerUsuarioPorMail(string mail)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Email == mail)
                {
                    return usuario;
                }
            }
            return null;
        }

        /// <summary>
        /// Recorre la lista de usuarios
        /// Chequea que el Usuario sea un Miembro y que el email del Miembro sea el mismo que recibe por parametro.
        /// </summary>
        /// <return>Devuelve al miembro o null</return>>
        public Miembro? ObtenerMiembroPorMail(string mail)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Miembro miembro && miembro.Email == mail)
                {
                    return miembro;
                }
            }
            return null;
        }

        /// <summary>
        /// Crea una variable "mayor" igualada a 0.
        /// Crea una nueva lista de Miembros.
        /// Crea una variable "cantidad" igualada a 0.
        /// Recorre la lista usuarios y chequea que los usuarios sean Miembros casteandolos a Miembro (Miembro miembro = (Miembro)usuario;)
        /// Definimos cantidad como la cantidad total de publicaciones de los miembros.
        /// Verifica que cantidad sea mayor a 0, define la variable mayor como cantidad, limpia la lista y agrega al miembro casteado.
        /// Verifica que cantidad sea igual a mayor y agrega al miembro a la lista.
        /// </summary>
        /// <return> Devuelve a el/los miembro/s </return>>
        public List<Miembro> MiembrosConMasPublicaciones()
        {
            int mayor = 0;
            List<Miembro> aux = new List<Miembro>();
            int cantidad = 0;
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Miembro)
                {
                    Miembro miembro = (Miembro)usuario;
                    cantidad = miembro.ListaPublicaciones().Count;
                    if (cantidad > mayor)
                    {
                        mayor = cantidad;
                        aux.Clear();
                        aux.Add(miembro);
                    }
                    else if (cantidad == mayor)
                    {
                        aux.Add(miembro);
                    }
                }
            }
            return aux;
        }

    }
}
