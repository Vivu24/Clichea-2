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
        //Por ahora va a ser equivalente al valor del mas pequeño de la lista

        private static int VALOR_ACCION_BASE = 100;

        private List<Personaje> personajeList;

        public BarraTurnos() {
            personajeList = new List<Personaje>();
        }

        public void AddPersonaje(Personaje personaje)
        {
            personajeList.Add(personaje);
        }

        public int SetupBar()
        {
            foreach (Personaje p in personajeList)
            {
                p.accion = p.velocidad * VALOR_ACCION_BASE;
            }
            return 0;
        }

        /**
         * Efectua el turno y con ello actualiza el valor de los distintos personajes en la lista
         */
        public void Turn()
        {

        }
        
        public List<Personaje> GetPersonajeList()
        {
            return personajeList;
        }
    }
}
