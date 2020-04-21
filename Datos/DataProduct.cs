using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DataProduct
    {
        public static void GuardarNuevo(Producto producto)
        {
            SqlConnection conexion = BdComun.EstablecerConexion();
            SqlCommand comando = new SqlCommand(string.Format("Insert into productos (Nombre, Descripcion, Precio, Stock) values ('{0}','{1}','{2}', '{3}')",
                producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock), conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Modificar(Producto producto)
        {
            SqlConnection conexion = BdComun.EstablecerConexion();
            SqlCommand comando = new SqlCommand(string.Format("Update productos set Nombre = '{0}', Descripcion = '{1}', " +
                "Precio = '{2}', Stock = '{3}' where IDProducto = {4}",
                producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Id), conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<Producto> Obtener()
        {
            SqlConnection conexion = BdComun.EstablecerConexion();
            List<Producto> lista = new List<Producto>();

            String consulta = "SELECT IDProducto, Nombre, Descripcion, Precio, Stock FROM productos";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Descripcion = reader.GetString(2);
                producto.Precio = reader.GetString(3);
                producto.Stock = reader.GetString(4);

                lista.Add(producto);
            }
            conexion.Close();

            return lista; 
        }

        public static void Eliminar(Producto producto)
        {
            SqlConnection conexion = BdComun.EstablecerConexion();
            String consulta = "DELETE from productos where IDProducto= '" + producto.Id + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            
            comando.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
