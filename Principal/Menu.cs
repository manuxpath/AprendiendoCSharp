using System;
using System.Data.SqlClient;

public class Menu
{
    Cliente cliente = new Cliente();
    Tecnico tecnico = new Tecnico();
    Ventas ventas = new Ventas();

    public void menu()
    {
        bool flag = true;

        while (flag)
        {
            Menu m = new Menu();
            Console.WriteLine("MENU DE OPCIONES\n1.Cliente\n2.Técnico\n3.Ventas\n4.Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                    m.opciones(opcion);
                    break;
                case 4:
                    Console.WriteLine("Hasta la próxima...");
                    flag = false;
                    break;
                default:
                    Console.WriteLine("La opción elegida no es correcta.");
                    break;
            }
        }
    }

    private void opciones(int opcion)
    {
        bool flag = true;

        int opcionUltima = -1;

        switch (opcion)
        {
            case 1:
                Console.WriteLine("USTED HA ELEGIDO CLIENTE");
                while (flag)
                {
                    Console.WriteLine("1.INGRESAR\n2.¿QUÉ ES?\n3.SALIR");
                    opcionUltima = Convert.ToInt32(Console.ReadLine());

                    switch (opcionUltima)
                    {
                        case 1:
                            try
                            {
                                using (SqlConnection cn = new SqlConnection("Server=127.0.0.1;User=root;Password=12345;Database=examen"))
                                {
                                    DBConexion.AbrirConexion(DBConexion.ObtenerConexion());

                                    do
                                    {
                                        Console.WriteLine("Introduzca el DNI del cliente:");
                                        cliente.setDni(Console.ReadLine());
                                        if (cliente.getDni().Length != 9)
                                            Console.WriteLine("El DNI debe ser de 9 caracteres.");
                                    } while (cliente.getDni().Length != 9);

                                    SqlCommand comandoCliente = new SqlCommand("INSERT INTO CLIENTES(DNI) VALUES (@DNI)", DBConexion.ObtenerConexion());
                                    comandoCliente.Parameters.AddWithValue("@DNI", cliente.getDni());
                                    comandoCliente.ExecuteNonQuery();

                                    do
                                    {
                                        Console.WriteLine("Introduzca el nombre del cliente:");
                                        cliente.setNombre(Console.ReadLine());
                                        if (cliente.getNombre().Length < 1)
                                            Console.WriteLine("El nombre no es válido.");
                                    } while (cliente.getNombre().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca el sexo del cliente:");
                                        cliente.setSexo(Console.ReadLine());
                                        if (cliente.getSexo().Length < 1)
                                            Console.WriteLine("El sexo no es válido.");
                                    } while (cliente.getSexo().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca la edad del cliente:");
                                        cliente.setEdad(Convert.ToInt32(Console.ReadLine()));
                                        if (cliente.getEdad() > 100 || cliente.getEdad() < 1)
                                            Console.WriteLine("La edad no es válida.");
                                    } while (cliente.getEdad() > 100 || cliente.getEdad() < 1);

                                    cliente.setTipo("Cliente");
                                    SqlCommand comandoEmpleado = new SqlCommand("INSERT INTO PERSONAS(NOMBRE,SEXO,EDAD,TIPO,ID_CLIENTE) VALUES (@NOMBRE,@SEXO,@EDAD,@TIPO,@ID_CLIENTE)", DBConexion.ObtenerConexion());
                                    comandoEmpleado.Parameters.AddWithValue("@NOMBRE", cliente.getNombre());
                                    comandoEmpleado.Parameters.AddWithValue("@SEXO", cliente.getSexo());
                                    comandoEmpleado.Parameters.AddWithValue("@EDAD", cliente.getEdad());
                                    comandoEmpleado.Parameters.AddWithValue("@TIPO", cliente.getTipo());
                                    comandoEmpleado.Parameters.AddWithValue("@ID_CLIENTE", cliente.getDni());
                                    comandoEmpleado.ExecuteNonQuery();
                                    DBConexion.CerrarConexion(DBConexion.ObtenerConexion());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 2:
                            Console.WriteLine(cliente.descripcion());
                            break;
                        case 3:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("No has elegido una opción correcta.");
                            break;
                    }
                }
                break;
            case 2:
                Console.WriteLine("USTED HA ELEGIDO TÉCNICO");
                while (flag)
                {
                    Console.WriteLine("1.INGRESAR\n2.¿QUÉ ES?\n3.SALIR");
                    opcionUltima = Convert.ToInt32(Console.ReadLine());

                    switch (opcionUltima)
                    {
                        case 1:
                            try
                            {
                                using (SqlConnection cn = new SqlConnection("Server=127.0.0.1;User=root;Password=12345;Database=examen"))
                                {
                                    DBConexion.AbrirConexion(DBConexion.ObtenerConexion());

                                    do
                                    {
                                        Console.WriteLine("Introduzca el DNI del técnico:");
                                        tecnico.setDni(Console.ReadLine());
                                        if (tecnico.getDni().Length != 9)
                                            Console.WriteLine("El DNI debe ser de 9 caracteres.");
                                    } while (tecnico.getDni().Length != 9);

                                    Console.WriteLine("Introduzca el salario del técnico:");
                                    tecnico.setSalario(Convert.ToDecimal(Console.ReadLine()));
                                    if (tecnico.getSalario() < 10000 || tecnico.getSalario() > 80000)
                                        Console.WriteLine("El salario debe ser anual.");

                                    SqlCommand comandoEmpleado = new SqlCommand("INSERT INTO TECNICOS(DNI,SALARIO) VALUES (@DNI,@SALARIO)", DBConexion.ObtenerConexion());
                                    comandoEmpleado.Parameters.AddWithValue("@DNI", tecnico.getDni());
                                    comandoEmpleado.Parameters.AddWithValue("@SALARIO", tecnico.calcularSalario());
                                    comandoEmpleado.ExecuteNonQuery();

                                    do
                                    {
                                        Console.WriteLine("Introduzca el nombre del técnico:");
                                        tecnico.setNombre(Console.ReadLine());
                                        if (tecnico.getNombre().Length < 1)
                                            Console.WriteLine("El nombre no es válido.");
                                    } while (tecnico.getNombre().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca el sexo del técnico:");
                                        tecnico.setSexo(Console.ReadLine());
                                        if (tecnico.getSexo().Length < 1)
                                            Console.WriteLine("El sexo no es válido.");
                                    } while (tecnico.getSexo().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca la edad del técnico:");
                                        tecnico.setEdad(Convert.ToInt32(Console.ReadLine()));
                                        if (tecnico.getEdad() > 70 || tecnico.getEdad() < 1)
                                            Console.WriteLine("La edad no es válida.");
                                    } while (tecnico.getEdad() > 70 || tecnico.getEdad() < 1);

                                    tecnico.setTipo("Tecnico");

                                    SqlCommand comando = new SqlCommand("INSERT INTO PERSONAS(NOMBRE,SEXO,EDAD,TIPO,ID_TECNICO) VALUES (@NOMBRE,@SEXO,@EDAD,@TIPO,@ID_TECNICO)", DBConexion.ObtenerConexion());
                                    comando.Parameters.AddWithValue("@NOMBRE", tecnico.getNombre());
                                    comando.Parameters.AddWithValue("@SEXO", tecnico.getSexo());
                                    comando.Parameters.AddWithValue("@EDAD", tecnico.getEdad());
                                    comando.Parameters.AddWithValue("@TIPO", tecnico.getTipo());
                                    comando.Parameters.AddWithValue("@ID_TECNICO", tecnico.getDni());
                                    comando.ExecuteNonQuery();
                                    DBConexion.CerrarConexion(DBConexion.ObtenerConexion());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 2:
                            Console.WriteLine(tecnico.descripcion());
                            break;
                        case 3:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("No has elegido una opción correcta.");
                            break;
                    }
                }
                break;
            case 3:
                Console.WriteLine("USTED HA ELEGIDO VENTAS");
                while (flag)
                {
                    Console.WriteLine("1.INGRESAR\n2.¿QUÉ ES?\n3.SALIR");
                    opcionUltima = Convert.ToInt32(Console.ReadLine());

                    switch (opcionUltima)
                    {
                        case 1:
                            try
                            {
                                using (SqlConnection cn = new SqlConnection("Server=127.0.0.1;User=root;Password=12345;Database=examen"))
                                {
                                    DBConexion.AbrirConexion(DBConexion.ObtenerConexion());

                                    do
                                    {
                                        Console.WriteLine("Introduzca el DNI de ventas:");
                                        ventas.setDni(Console.ReadLine());
                                        if (ventas.getDni().Length != 9)
                                            Console.WriteLine("El DNI debe ser de 9 caracteres.");
                                    } while (ventas.getDni().Length != 9);

                                    Console.WriteLine("Introduzca el salario de ventas:");
                                    ventas.setSalario(Convert.ToDecimal(Console.ReadLine()));
                                    if (ventas.getSalario() < 10000 || ventas.getSalario() > 80000)
                                        Console.WriteLine("El salario debe ser anual.");

                                    SqlCommand comandoEmpleado = new SqlCommand("INSERT INTO VENTAS(DNI,SALARIO) VALUES (@DNI,@SALARIO)", DBConexion.ObtenerConexion());
                                    comandoEmpleado.Parameters.AddWithValue("@DNI", ventas.getDni());
                                    comandoEmpleado.Parameters.AddWithValue("@SALARIO", ventas.calcularSalario());
                                    comandoEmpleado.ExecuteNonQuery();

                                    do
                                    {
                                        Console.WriteLine("Introduzca el nombre de ventas:");
                                        ventas.setNombre(Console.ReadLine());
                                        if (ventas.getNombre().Length < 1)
                                            Console.WriteLine("El nombre no es válido.");
                                    } while (ventas.getNombre().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca el sexo de ventas:");
                                        ventas.setSexo(Console.ReadLine());
                                        if (ventas.getSexo().Length < 1)
                                            Console.WriteLine("El sexo no es válido.");
                                    } while (ventas.getSexo().Length < 1);

                                    do
                                    {
                                        Console.WriteLine("Introduzca la edad de ventas:");
                                        ventas.setEdad(Convert.ToInt32(Console.ReadLine()));
                                        if (ventas.getEdad() > 70 || ventas.getEdad() < 1)
                                            Console.WriteLine("La edad no es válida.");
                                    } while (ventas.getEdad() > 70 || ventas.getEdad() < 1);

                                    ventas.setTipo("Ventas");

                                    SqlCommand comando = new SqlCommand("INSERT INTO PERSONAS(NOMBRE,SEXO,EDAD,TIPO,ID_VENTAS) VALUES (@NOMBRE,@SEXO,@EDAD,@TIPO,@ID_VENTAS)", DBConexion.ObtenerConexion());
                                    comando.Parameters.AddWithValue("@NOMBRE", ventas.getNombre());
                                    comando.Parameters.AddWithValue("@SEXO", ventas.getSexo());
                                    comando.Parameters.AddWithValue("@EDAD", ventas.getEdad());
                                    comando.Parameters.AddWithValue("@TIPO", ventas.getTipo());
                                    comando.Parameters.AddWithValue("@ID_VENTAS", ventas.getDni());
                                    comando.ExecuteNonQuery();
                                    DBConexion.CerrarConexion(DBConexion.ObtenerConexion());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        case 2:
                            Console.WriteLine(ventas.descripcion());
                            break;
                        case 3:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("No has elegido una opción correcta.");
                            break;
                    }
                }
                break;
        }
    }
}
