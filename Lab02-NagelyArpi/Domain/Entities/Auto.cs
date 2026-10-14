namespace Lab02_NagelyArpi.Models
{
    public class Auto<T>
    {
        public string Placa { get; set; }
        public string SedeTransito { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public T Propietario { get; set; }

        public Auto(string placa, string sedeTransito, string marca, string modelo, int anio, T propietario)
        {
            Placa = placa;
            SedeTransito = sedeTransito;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Propietario = propietario;
        }
    }
}

