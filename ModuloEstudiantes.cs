using System;
using System.Collections.Generic;
using System.Linq;

// Módulo encargado de manejar la lista de estudiantes
public static class ModuloEstudiantes
{
    // Lista donde se guardan los estudiantes
    private static List<Estudiante> estudiantes = new List<Estudiante>();

    public static void MenuEstudiantes()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("===== LISTA DE ESTUDIANTES =====");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. Mostrar estudiantes");
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
                    AgregarEstudiante();
                    break;

                case 2:
                    EliminarEstudiante();
                    break;

                case 3:
                    MostrarEstudiantes();
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

    private static void AgregarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("===== AGREGAR ESTUDIANTE =====");

        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            Console.ReadKey();
            return;
        }

        bool existe = estudiantes.Any(e =>
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (existe)
        {
            Console.WriteLine("Ya existe un estudiante con ese nombre.");
            Console.ReadKey();
            return;
        }

        Console.Write("Ingrese la calificación: ");
        bool calificacionValida = double.TryParse(Console.ReadLine(), out double calificacion);

        if (!calificacionValida)
        {
            Console.WriteLine("Debe ingresar una calificación válida.");
            Console.ReadKey();
            return;
        }

        if (calificacion < 0 || calificacion > 100)
        {
            Console.WriteLine("La calificación debe estar entre 0 y 100.");
            Console.ReadKey();
            return;
        }

        estudiantes.Add(new Estudiante(nombre, calificacion));

        Console.WriteLine("Estudiante agregado correctamente.");
        Console.ReadKey();
    }

    private static void EliminarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("===== ELIMINAR ESTUDIANTE =====");

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            Console.ReadKey();
            return;
        }

        Console.Write("Ingrese el nombre del estudiante a eliminar: ");
        string nombre = Console.ReadLine() ?? "";

        Estudiante? estudiante = estudiantes.FirstOrDefault(e =>
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (estudiante == null)
        {
            Console.WriteLine("No se encontró un estudiante con ese nombre.");
        }
        else
        {
            estudiantes.Remove(estudiante);
            Console.WriteLine("Estudiante eliminado correctamente.");
        }

        Console.ReadKey();
    }

    private static void MostrarEstudiantes()
    {
        Console.Clear();
        Console.WriteLine("===== ESTUDIANTES REGISTRADOS =====");

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.Nombre} | Calificación: {estudiante.Calificacion}");
            }
        }

        Console.ReadKey();
    }
}