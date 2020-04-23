using Domain;
using Negocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormularioProductos
{
    public partial class frmProductos : Form
    {
        public int IDProducto;
        public frmProductos()
        {
            InitializeComponent();
            ObtenerRegistro();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = ObtenerProducto();
            ProductManager.GuardarProducto(producto);
            ObtenerRegistro();
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto producto = ObtenerProducto();
            ProductManager.EliminarProducto(producto.Id);
            ObtenerRegistro();
            LimpiarCampos();
        }

        private void dgwRegistro_Click(object sender, EventArgs e)
        {
            RellenarCampos();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductManager.validarCaracter(e);
        }


        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductManager.validarNumero(e);
        }

        

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductManager.validarNumero(e);
        }


        private void ObtenerRegistro()
        {
            List<Producto> lista = ProductManager.ObtenerProducto();
            dgwRegistro.DataSource = lista;
        }

        private Producto ObtenerProducto()
        {
            Producto producto = new Producto();

            producto.Id = IDProducto;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = txtPrecio.Text;
            producto.Stock = txtStock.Text;

            return producto;
        }

        private void RellenarCampos()
        {
            btnAgregar.Text = "Modificar";
            IDProducto = Convert.ToInt32(dgwRegistro.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(dgwRegistro.CurrentRow.Cells[1].Value);
            txtDescripcion.Text = Convert.ToString(dgwRegistro.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dgwRegistro.CurrentRow.Cells[3].Value);
            txtStock.Text = Convert.ToString(dgwRegistro.CurrentRow.Cells[4].Value);

        }

        private void LimpiarCampos()
        {
            btnAgregar.Text = "Agregar";
            IDProducto = 0;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

        }

        
    }

    
}
