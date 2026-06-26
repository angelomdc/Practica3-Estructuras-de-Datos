// Clase que representa a un estudiante
public class Estudiante
{
    public string Nombre { get; set; }
    public double Calificacion { get; set; }

    public Estudiante(string nombre, double calificacion)
    {
        Nombre = nombre;
        Calificacion = calificacion;
    }
}