namespace Sistema_Turnos
{
    internal class Program
    {
        static private void Show(BarraTurnos barraTurnos)
        {
            Console.WriteLine("Este es el estado actual de los turnos");

        }

        static void Main(string[] args)
        {
            //Inicializa la barra de turnos


            Console.WriteLine("Hello, World!");
            BarraTurnos barra = new BarraTurnos();
            Show(barra);
        }


    }
}
