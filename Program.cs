using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("        MENÚ PRINCIPAL");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Lista de Estudiantes");
            Console.WriteLine("2. Cola de Atención al Cliente FIFO");
            Console.WriteLine("3. Pila de Tareas Pendientes LIFO");
            Console.WriteLine("4. Salir del sistema");
            Console.Write("Seleccione una opción: ");

            bool opcionValida = int.TryParse(Console.ReadLine(), out opcion);

            if (!opcionValida)
            {
                Console.WriteLine("Debe ingresar un número válido.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ModuloEstudiantes.MenuEstudiantes();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("===== COLA DE ATENCIÓN AL CLIENTE FIFO =====");
                    Console.WriteLine("Este módulo será desarrollado por otro integrante.");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("===== PILA DE TAREAS PENDIENTES LIFO =====");
                    Console.WriteLine("Este módulo será desarrollado por otro integrante.");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 4);
    }
}
