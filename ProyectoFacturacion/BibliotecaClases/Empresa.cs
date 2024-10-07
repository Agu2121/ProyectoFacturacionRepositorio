namespace BibliotecaClases
{
    public class Empresa
    {
        // Atributos
        private string _nombre;
        private string _cuit;
        private string _domicilio;
        private string _localidad;
        private string _provincia;
        private string _condicionIva;

        // Propiedades
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }

        public string Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }

        public string CondicionIva
        {
            get { return _condicionIva; }
            set { _condicionIva = value; }
        }
    }
}
