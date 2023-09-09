
public abstract class Persona
{
    private string nombre, sexo, tipo;
    private int edad;

    public Persona()
    {
        nombre = "";
        sexo = "";
        tipo = "";
        edad = 0;
    }

    public Persona(string nombre, string sexo, string tipo, int edad)
    {
        this.nombre = nombre;
        this.sexo = sexo;
        this.tipo = tipo;
        this.edad = edad;
    }

    public int getEdad()
    {
        return edad;
    }

    public void setEdad(int edad)
    {
        this.edad = edad;
    }

    public string getNombre()
    {
        return nombre;
    }

    public void setNombre(string nombre)
    {
        this.nombre= nombre;
    }

    public string getSexo()
    {
        return sexo;
    }

    public void setSexo(string sexo)
    {
        this.sexo = sexo;
    }

    public string getTipo()
    {
        return tipo;
    }

    public void setTipo(string tipo)
    {
        this.tipo = tipo;
    }
    public override string ToString() {
        return "El "+getTipo()+" de sexo "+getSexo()+" se llama "+getNombre()+" y tiene "+getEdad()+" años.";
    }

    public abstract string descripcion();
}
