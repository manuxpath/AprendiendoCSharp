using System;
using System.Data;
using System.Data.SqlClient;

public class DBConexion
{
    private static string cadenaConexion = "Server=127.0.0.1;User=root;Password=12345;Database=examen";

    public static SqlConnection ObtenerConexion()
    {
        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener la conexión: " + ex.Message);
            return null;
        }
    }

    public static bool AbrirConexion(SqlConnection conexion)
    {
        try
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            return false;
        }
    }

    public static bool CerrarConexion(SqlConnection conexion)
    {
        try
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            return false;
        }
    }
}
