using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos
{
    internal class Personaje
    {
        public int velocidad; //El atributo de velocidad del personaje. Define dónde empieza en la barra de turnos y donde se coloca al utilizar su acción.
        public int accion; //El valor de acción en el combate. Define su posición en la barra.
        public string nombre; //El nombre del personaje. Sin más.

        public Personaje(int velocidad, int accion, string nombre) {
            this.velocidad = velocidad;
            this.nombre = nombre;
            this.accion = accion;
        }
    }
}
