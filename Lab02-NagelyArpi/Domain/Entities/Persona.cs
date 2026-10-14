namespace Lab02_NagelyArpi.Models;

public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Dni { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Persona(int id, string nombre, string dni, string email, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Dni = dni;
        Email = email;
        Telefono = telefono;
    }
}