using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Invitacion
    {
        public int Id { get; private set; }
        private int _UltId;
        public Miembro MiembroSolicitante { get; set; }
        public Miembro MiembroSolicitado { get; set; }
        public DateTime FechaDeSolicitud { get; set; }
        public string EstadoSolicitud { get; set; }

        //Constructor
        public Invitacion(Miembro miembroSolicitante, Miembro miembroSolicitado, string estadoSolicitud)
        {
            Id = ++_UltId;
            MiembroSolicitante = miembroSolicitante;
            MiembroSolicitado = miembroSolicitado;
            FechaDeSolicitud = DateTime.Now;
            EstadoSolicitud = estadoSolicitud;
            Validar();
        }

        //Validaciones
        public void Validar()
        {
            ValidarMiembroSolicitante();
            ValidarMiembroSolicitado();
            ValidarEstadoSolicitud();
        }

        /// <summary>
        /// Valida que el objeto MiembroSolicitado no sea nulo
        /// </summary>
        public void ValidarMiembroSolicitante()
        {
            if (!LibreriaMetodos.ObjetoValido(MiembroSolicitante))
            {
                throw new Exception("El miembro es incorrecto");
            }
        }


        /// <summary>
        /// Valida que el objeto MiembroSolicitante no sea nulo
        /// </summary>
        public void ValidarMiembroSolicitado()
        {
            if (!LibreriaMetodos.ObjetoValido(MiembroSolicitante))
            {
                throw new Exception("El miembro es incorrecto");
            }
        }

        /// <summary>
        /// Valida que el string EstadoSolicitud no este vacio o que el string sea "PENDIENTE_APROBACION" o "APROBADA" o "RECHAZADA"
        /// </summary>
        public void ValidarEstadoSolicitud()
        {
            if (!LibreriaMetodos.StringValido(EstadoSolicitud) || !((EstadoSolicitud=="PENDIENTE_APROBACION") || (EstadoSolicitud=="APROBADA") || (EstadoSolicitud=="RECHAZADA")))
            {
                throw new Exception("La invitacion no es valida");
            }
        }

        /// <summary>
        /// Convierte el objeto obj a una Invitacion(unI).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el MiembroSolicitante con el MiembroSolicitante del objeto (unI) 
        /// y al MiembroSolicitado con el MiembroSolicitado del objeto (unI)
        /// o compara el MiembroSolicitante con el MiembroSolicitado del objeto (unI)
        /// y al MiembroSolicitado con el MiembroSolicitante del objeto (unI)
        /// </returns>
        public override bool Equals(object? obj)
        {
            Invitacion? unI = obj as Invitacion;
            return unI != null && ((MiembroSolicitante== unI.MiembroSolicitante) &&
       MiembroSolicitado == unI.MiembroSolicitado) ||
      (MiembroSolicitante == unI.MiembroSolicitado &&
       MiembroSolicitado == unI.MiembroSolicitante);
        }

    }
}
