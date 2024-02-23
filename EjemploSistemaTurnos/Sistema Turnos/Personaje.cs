using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos
{
    internal class Personaje
    {
        public static int BASE_ACTION_VALUE = 10000;

        public Personaje(double velocidad, string nombre) {
            this.velocidad = velocidad;
            this.nombre = nombre;
        }

        private double velocidad;
        private double valorDeAccion;
        private string nombre;

        public double GetVelocidad() { return velocidad; }
        public double GetValorDeAccion() {  return valorDeAccion; }
        public string GetNombre() {  return nombre; }
        //public void SetValorDeAccion(double valorDeAccion) { this.valorDeAccion = valorDeAccion; }
        //public void SetVelocidad(double velocidad) { this.velocidad = velocidad; }

        public void RefreshValorAccion()
        {
            valorDeAccion = BASE_ACTION_VALUE / velocidad;
        }


    }
}
