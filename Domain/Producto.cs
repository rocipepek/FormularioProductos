﻿
namespace Domain
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string desc, string precio, string stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = desc;
            this.Precio = precio;
            this.Stock = stock;
        }
    }

}
