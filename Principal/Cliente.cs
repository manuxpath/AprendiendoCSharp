

public class Cliente : Persona
{
    private string dni;

    public Cliente()
    {
        dni = "";
    }

    public void setDni(string dni)
    {
        this.dni = dni;
    }

    public string getDni() {
        return dni;
    }

    override
        public string descripcion()
    { return "El cliente es un usuario de la empresa que compra su contenido."; }
}