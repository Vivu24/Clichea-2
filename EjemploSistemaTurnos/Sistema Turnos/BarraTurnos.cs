using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Turnos
{
    internal class BarraTurnos
    {
        //Para el factor de reducción, restamos un factor equivalente a todos los personajes.
        //El que menos tenga es movido al final de la cola y su valor de acción es restablecido.

        //Habría que pensar cual es la forma adecuada de calcular ese factor de reducción.
        //Por ahora va a ser equivalente al valor de acción del mas pequeño de la lista

        private static int VALOR_ACCION_BASE = 100;

        private List<Personaje> personajeList;
        private ComparadorPorAccion comparadorA;

        public BarraTurnos() {
            personajeList = new List<Personaje>();
            comparadorA = new ComparadorPorAccion();
        }

        public void AddPersonaje(Personaje personaje)
        {
            personajeList.Add(personaje);
        }

        public int SetupBar()
        {
            foreach (Personaje p in personajeList)
            {
                AplicarAccionBase(p);
            }
            personajeList.Sort(comparadorA);
            return 0;
        }

        /**
         * Efectua el turno y con ello actualiza el valor de los distintos personajes en la lista
         */
        public void Turn()
        {
            int accionPrim = personajeList[0].accion;
            foreach (Personaje p in personajeList)
            {
                p.accion -= accionPrim; //Se resta a todos los personajes la acción del que acaba de actuar
            }
            AplicarAccionBase(personajeList[0]);
            personajeList.Sort(comparadorA);
        }

        public List<Personaje> GetPersonajeList()
        {
            return personajeList;
        }

        //Formula para aplicar la acción base según su velocidad
        private void AplicarAccionBase(Personaje p)
        {
            p.accion = p.velocidad * VALOR_ACCION_BASE;
        }
    }
    
    class ComparadorPorAccion : IComparer<Personaje>
    {
        public int Compare(Personaje? p1, Personaje? p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException("Los objetos a comparar no pueden ser null");

            return p1.accion.CompareTo(p2.accion);
        }
    }
}
