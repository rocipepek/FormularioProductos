﻿using Datos;
using Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Negocios
{
    public class ProductManager
    {
        public static void GuardarProducto(Producto producto)
        {
            
            if((producto.Id).Equals(0))
            {
                if (!CamposVacios(producto)) //Si no esta vacio, almacenar el producto
                {
                    DataProduct.GuardarNuevo(producto);
                    MessageBox.Show("El producto: "+ producto.Nombre + " ha sido agregado con exito", "Producto Agregado con Exito");
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos!", "Atención");
                }
                
            }
            else
            {
                DataProduct.Modificar(producto);
                MessageBox.Show("El producto ha sido modificado con exito", "Producto Modificado con Exito");
            }
        }

        public static void EliminarProducto(Producto producto)
        {
            if (producto.Id.Equals(0))
            {
                //No se selecciono ningun producto
                MessageBox.Show("Seleccione un producto", "Atención");
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataProduct.Eliminar(producto);
                }
            }
        }

        public static void validarCaracter(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public static void validarNumero(KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar == (char)Keys.Decimal))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        public static List<Producto> ObtenerProducto()
        {
            List<Producto> lista = DataProduct.Obtener();
            return lista;
        }

        private static bool CamposVacios(Producto producto) //TODO: mejorar metodo
        {
            bool isEmpty = true;

            if(!(string.IsNullOrEmpty(producto.Nombre) && string.IsNullOrEmpty(producto.Descripcion) &&
                string.IsNullOrEmpty(producto.Precio) && string.IsNullOrEmpty(producto.Stock))) //No estan vacios
            {
                isEmpty = false;
                return isEmpty;
            }
            return isEmpty;
        }
    }
}
