
using System.Net;

public class Tecnico : Persona, Calcular
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
        return "El técnico se encarga de solucionar problemas con el cliente y sus elementos comprados.";
    }

        public decimal calcularSalario()
    {
        return salario+(salario*0.21m);
    }
}
