namespace Lab02_NagelyArpi.Models;

public class Empresa
{
    public int Id { get; set; }
    public string RazonSocial { get; set; }
    public string Ruc { get; set; }
    public string EmailCorporativo { get; set; }
    public string Direccion { get; set; }

    public Empresa(int id, string razonSocial, string ruc, string emailCorporativo, string direccion)
    {
        Id = id;
        RazonSocial = razonSocial;
        Ruc = ruc;
        EmailCorporativo = emailCorporativo;
        Direccion = direccion;
    }
}