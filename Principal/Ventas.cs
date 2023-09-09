
public class Ventas : Persona, Calcular
{
    private decimal salario;
    private string dni;

    public decimal getSalario()
    {
        return salario;
    }

    public void setSalario(decimal salario)
    {
        this.salario = salario;
    }

    public void setDni(string dni)
    {
        this.dni = dni;
    }

    public string getDni()
    {
        return dni;
    }

    override
        public string descripcion()
    {
        return "Se encarga de solucionar problemas con el cliente y gestionar las ventas de los mismos.";
    }

    public decimal calcularSalario()
    {
        return salario + (salario * 0.21m);
    }
}