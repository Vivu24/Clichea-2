namespace Sistema_Turnos
{
    //Este programa es para demostrar y probar el sistema de velocidades y turnos.
    internal class Program
    {
        static private void Show(BarraTurnos barraTurnos)
        {
            Console.WriteLine("Este es el estado actual de los turnos");
            List<Personaje> list = barraTurnos.GetPersonajeList();
            foreach (Personaje p in list)
            {
                Console.WriteLine(p.nombre + " velocidad: " + p.velocidad + " acción: " + p.accion);
            }
        }

        static void Main(string[] args)
        {
            //Inicializa la barra de turnos

            Console.WriteLine("Hello, World!");
            BarraTurnos barra = new BarraTurnos();
            barra.AddPersonaje(new Personaje(20, 0, "Elric"));
            Show(barra);
        }

    }
}
