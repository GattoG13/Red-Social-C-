using Dominio;

namespace ConsoleApp1
{
    internal class Program
    {
        private static Sistema _sistema = new Sistema();

        static void Main(string[] args)
        {
            int opcion;
            Precargar();
            do
            {
                Console.Clear();
                Console.WriteLine
                    (
                    "Ingrese opcion\n\n" +
                    "-------------------------------------\n" +
                    "1-Alta Miembro\n" +
                    "2-Mostrar publicaciones de miembro\n" +
                    "3-Mostrar Publicaciones que tienen comentarios de miembro\n" +
                    "4-Mostrar Posts dentro de 2 fechas\n" +
                    "5-Mostrar miembros con mas publicaciones\n" +
                    "0-Salir de la consola\n"
                    );
                opcion = PedirNumero();
                switch (opcion)
                {
                    case 1:
                        AltaMiembro();
                        break;
                    case 2:
                        ListarPublicaciones();
                        break;
                    case 3:
                        ListarPostXComentarios();
                        break;
                    case 4:
                        ListarPostXFechas();
                        break;
                    case 5:
                        ListarMiembrosConMasInteracciones();
                        break;
                }

            } while (opcion != 0);
        }

        //Precarga de datos
        static private void Precargar()
        {
            try
            {
                _sistema.Precargar();
                Console.WriteLine("Se han precargado los datos correctamente\n" + "Presione una tecla para ingresar al menu");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            Console.Clear();

        }

        /// <summary>
        /// Crea un numero igual a 0 y un bool salir a false
        /// Hace en un do while hasta que el bool sea true,en un try cambia el bool a true y castea el numero a que ingresa el usuario
        /// En caso contrario se mantiene el bool en false y se informa al usuario que solo puede ingresar numeros
        /// </summary>
        /// <returns>Devuelve el numero</returns>
        private static int PedirNumero()
        {
            int numero = 0;
            bool salir = false;
            do
            {
                try
                {
                    salir = true;
                    numero = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    salir = false;
                    Console.WriteLine("Solo debe ingresar numeros");
                }
            } while (!salir);
            return numero;
        }

        //Punto nro 1
        static private void AltaMiembro()
        {
            try
            {
                SolicitarDatos();
                Console.WriteLine("\nSe ha dado de alta al miembro correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Solicita los datos al usuario y valida que cada campo no este vacio y que el mail y las fechas sean validas.
        /// </summary>
        /// <return>Da alta al miembro validado</return>>
        private static void SolicitarDatos()
        {
            //Creamos las variables con su tipo necesario
            string email;
            string nombre;
            string apellido;
            string contrasena;
            string fechaIngresada;
            DateTime fechaDeNacimiento;
            //Pedimos los datos al usuario, verificamos y guardamos en las variables
            Console.WriteLine("\nIngrese un email");
            email = Console.ReadLine();
            LibreriaMetodos.ValidarEmail(email);
            Console.WriteLine("\nIngrese un contrasena");
            contrasena = Console.ReadLine();
            LibreriaMetodos.ValidarCampoVacio(contrasena);
            Console.WriteLine("\nIngrese un nombre");
            nombre = Console.ReadLine();
            LibreriaMetodos.ValidarCampoVacio(nombre);
            Console.WriteLine("\nIngrese un apellido");
            apellido = Console.ReadLine();
            LibreriaMetodos.ValidarCampoVacio(apellido);
            Console.WriteLine("\nIngrese una fecha de nacimiento");
            fechaIngresada = Console.ReadLine();
            fechaDeNacimiento = LibreriaMetodos.ValidarDateTime(fechaIngresada);
            //Creamos el nuevo Miembro y se da de alta si cumplio con todas las validaciones correspondientes
            Miembro altaMiembro = new Miembro(email, contrasena, nombre, apellido, fechaDeNacimiento, false);
            _sistema.AltaAMiembro(altaMiembro);
        }

        //Punto nro 2
        static private void ListarPublicaciones()
        {
            try
            {
                ListarPublicacionesPorEmail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Recorre la lista de publicaciones del miembro recibido y todas las publicaciones (Post y Comentario)
        /// </summary>
        private static void ListarPublicacionesPorEmail()
        {
            string email;
            Console.WriteLine("\nIngrese el email del cual desea recibir las publicaciones");
            email = Console.ReadLine();
            List<Usuario> listaUsuarios = _sistema.Usuarios;
            if (listaUsuarios.Count < 0)
            {
                throw new Exception("\nNo existen usuarios.");
            }
            else
            {
                if (!LibreriaMetodos.StringValido(email) || !LibreriaMetodos.EmailValido(email))
                {
                    throw new Exception("\nEl mail ingresado no es valido.");
                }
                else
                {
                    Usuario usuario = _sistema.ObtenerUsuarioPorMail(email);
                    if (usuario is Miembro)
                    {
                        Miembro miembro = (Miembro)usuario;
                        Console.WriteLine("\nLas publicaciones del miembro son:");
                        List<Publicacion> listaPublicacion = miembro.ListaPublicaciones();
                        if (listaPublicacion.Count > 0)
                        {
                            foreach (Publicacion publicacion in listaPublicacion)
                            {
                                Console.WriteLine(publicacion);
                            }
                        }
                        else
                        {
                            throw new Exception("\nEl miembro no tiene publicaciones");
                        }
                    }
                    else
                    {
                        throw new Exception("\nEl usuario que ingreso no es valido");
                    }
                }
            }
        }

        //Punto nro 3
        private static void ListarPostXComentarios()
        {
            try
            {
                ListarPostPorComentario();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Recorre la lista de usuarios para encontrar al Miembro.
        ///  Recorre la lista de publicaciones del miembro recibido e ingresa a todas las publicaciones que sean Comentario.
        ///  Vuelve a recorrer la lista de Usuarios y compara la id de todos los post de cada Miembro con el idPost de cada Comentario del Miembro buscado.  
        /// </summary>
        private static void ListarPostPorComentario()
        {
            string email;
            Console.WriteLine("\nIngrese el email del cual desea recibir las publicaciones");
            email = Console.ReadLine();
            Usuario usuario = _sistema.ObtenerUsuarioPorMail(email);
            List<Usuario> listaUsuarios = _sistema.Usuarios;
            if (usuario != null && LibreriaMetodos.StringValido(email) && LibreriaMetodos.EmailValido(email))
            {
                if (usuario is Miembro)
                {
                    Miembro miembro = (Miembro)usuario;
                    List<Publicacion> listaPublicacion = miembro.ListaPublicaciones();
                    if (listaPublicacion.Count < 1)
                    {
                        throw new Exception("\nEl miembro no tiene ninguna publicación.");
                    }
                    else
                    {
                        Console.WriteLine("\nLas publicaciones que comentó el Miembro son: ");
                        foreach (Publicacion publicacion in listaPublicacion)
                        {
                            if (publicacion.Autor == miembro)
                            {
                                if (publicacion is Comentario)
                                {
                                    Comentario comentario = (Comentario)publicacion;
                                    foreach (Usuario usuario1 in listaUsuarios)
                                    {
                                        if (usuario1 is Miembro)
                                        {
                                            Miembro miembro2 = (Miembro)usuario1;
                                            List<Publicacion> listaPublicacion2 = miembro2.ListaPublicaciones();
                                            foreach (Publicacion publi2 in listaPublicacion2)
                                            {
                                                if (publi2 is Post)
                                                {
                                                    Post post = (Post)publi2;
                                                    if (post.Id == comentario.IdPost)
                                                    {
                                                        Console.WriteLine(post);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    throw new Exception("\nDebe ingresar un Miembro.");
                }
            }
            else
            {
                throw new Exception("\nEl usuario que ingreso no es valido.");
            }
            Console.ReadKey();
        }

        //punto nro 4
        private static void ListarPostXFechas()
        {
            try
            {
                ListarPostsPorFechas();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Solicita dos fechas al usuario y valida que sean fechas.
        /// Trae la lista de usuarios y crea una nueva lista de posts
        /// Se crea un boolean de chequeo en false.
        /// Recorre la lista de usuarios y chequea que el usuario sea un miembro y lo castea a miembro
        /// Recorre la lista de posts de ese usuario y chequea que sea un post y lo castea a post
        /// Lo añade a lista creada anteriormente si esos post estan contenidos dentro de las dos fechas solicitadas y cambia el valor del boolean a true.
        /// Chequea que el boolean sea true y en caso de serlo crea un mensaje al usuario y lista los post de manera descendente.
        /// </summary>
        /// <return>La lista de los post dentro de las fechas solicitadas de manera descendente</return>>
        public static void ListarPostsPorFechas()
        {
            string fecha1Ingresada;
            string fecha2Ingresada;
            Console.WriteLine("\nIngrese una primera fecha");
            fecha1Ingresada = Console.ReadLine();
            DateTime fecha1 = LibreriaMetodos.ValidarDateTime(fecha1Ingresada);
            Console.WriteLine("\nIngrese una segunda fecha (mayor que la anterior)");
            fecha2Ingresada = Console.ReadLine();
            DateTime fecha2 = LibreriaMetodos.ValidarDateTime(fecha2Ingresada);
            List<Usuario> listaUsuarios = _sistema.Usuarios;
            List<Post> listaPost = new List<Post>();
            bool existen = false;
            if (fecha1 < fecha2)
            {
                foreach (Usuario usuario in listaUsuarios)
                {
                    if (usuario is Miembro)
                    {
                        Miembro usuarioMiembro = (Miembro)usuario;
                        List<Publicacion> listaPublicacion = usuarioMiembro.ListaPublicaciones();
                        foreach (Publicacion publicacion in listaPublicacion)
                        {
                            if (publicacion is Post)
                            {
                                Post post = (Post)publicacion;
                                if (post.FechaPublicacion >= fecha1 && post.FechaPublicacion <= fecha2)
                                {
                                    existen = true;
                                    listaPost.Add(post);
                                }
                            }
                        }
                    }
                }
                if (existen)
                {
                    Console.WriteLine($"\nLos posts entre las fechas {fecha1} y {fecha2} son:\n" + "----------------------------------------------------------------\n");
                    //Crea una lista de forma descendente de los post recibidos
                    List<Post> postOrdenados = listaPost.OrderByDescending(post => post.FechaPublicacion).ToList();
                    foreach (Post post in postOrdenados)
                    {
                        Console.WriteLine(post);
                    }
                }
                if (!existen)
                {
                    throw new Exception($"\nNo existen publicaciones entre {fecha1Ingresada} y {fecha2Ingresada}");
                }
                Console.ReadKey();
            }
            else
            {
                throw new Exception($"\nLa primera fecha ({fecha2Ingresada}) debe ser mayor a la primera fecha ingresada ({fecha1Ingresada})");
            }
        }

        //punto nro 5
        private static void ListarMiembrosConMasInteracciones()
        {
            try
            {
                ListarMiembrosConMasPublicaciones();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Trae la lista de miembros de sistema
        /// Valida que la lista tenga contenido
        /// Crea un mensaje al usuario dependiendo de si la lista tiene un miembro o varios "El/Los miembro/s con mas publicaciones es/son:"
        /// Recorre la lista de miembros y escribe el/los miembros
        /// </summary>
        /// <return>Da alta al miembro validado</return>>
        public static void ListarMiembrosConMasPublicaciones()
        {
            List<Miembro> listaMiembros = _sistema.MiembrosConMasPublicaciones();
            if (listaMiembros.Count >= 1)
            {
                if (listaMiembros.Count > 1)
                {
                    Console.WriteLine("\nLos miembros con mas publicaciones son:\n");
                }
                else
                {
                    Console.WriteLine("\nEL miembros con mas publicaciones es:\n");
                }
                foreach (Miembro miembro in listaMiembros)
                {
                    Console.WriteLine(miembro);
                }
                Console.ReadKey();
            }
            else
            {
                throw new Exception("\nLa lista se encuentra vacia");
            }
        }
    }
}