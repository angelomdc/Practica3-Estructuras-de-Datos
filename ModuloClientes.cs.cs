using System;
using System.Collections.Generic;
using System.Linq;

// Módulo encargado de manejar la cola de clientes
public static class ModuloClientes
{
    // Cola FIFO
    private static Queue<string> clientes = new Queue<string>();

    public static void MenuClientes()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("===== COLA DE ATENCIÓN AL CLIENTE =====");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Atender cliente");
            Console.WriteLine("3. Mostrar clientes en espera");
            Console.WriteLine("4. Volver al menú principal");
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
                    AgregarCliente();
                    break;

                case 2:
                    AtenderCliente();
                    break;

                case 3:
                    MostrarClientes();
                    break;

                case 4:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 4);
    }

    private static void AgregarCliente()
    {
        Console.Clear();
        Console.WriteLine("===== AGREGAR CLIENTE =====");

        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            Console.ReadKey();
            return;
        }

        bool existe = clientes.Any(c =>
            c.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (existe)
        {
            Console.WriteLine("Ese cliente ya está en la cola.");
            Console.ReadKey();
            return;
        }

        clientes.Enqueue(nombre);

        Console.WriteLine("Cliente agregado correctamente.");
        Console.ReadKey();
    }

    private static void AtenderCliente()
    {
        Console.Clear();
        Console.WriteLine("===== ATENDER CLIENTE =====");

        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes en espera.");
        }
        else
        {
            string cliente = clientes.Dequeue();
            Console.WriteLine($"Atendiendo al cliente: {cliente}");
        }

        Console.ReadKey();
    }

    private static void MostrarClientes()
    {
        Console.Clear();
        Console.WriteLine("===== CLIENTES EN ESPERA =====");

        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes en espera.");
        }
        else
        {
            foreach (string cliente in clientes)
            {
                Console.WriteLine(cliente);
            }
        }

        Console.ReadKey();
    }
}