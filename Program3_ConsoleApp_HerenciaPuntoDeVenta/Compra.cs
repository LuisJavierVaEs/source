using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Herencia
{
    class Compra:CompraBase
    {

        public Compra(int idArticulo, string nombreArticulo, decimal precio, int cantidad)
        {
            this.id = idArticulo;
            this.nombre = nombreArticulo;
            this.precio = precio;
            this.cantidad = cantidad;
            this.total = precio * cantidad;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set ; }

        decimal CompraBase.SubTotalCompra(decimal precio, int cantidad)
        {
            decimal total;
            total = precio*cantidad;
            return total;
        }

        string CompraBase.Imprimir()
        {
            return $"{this.cantidad} : {this.nombre} : {this.precio} : {this.total}";
        }

        decimal CompraBase.Total()
        {
            return this.total;
        }
        
        public decimal Descuento()
        {
            decimal descuento = 0;
            if (this.cantidad == 2)
            {
                descuento = cantidad*precio*(decimal)Convert.ToDouble(0.2);
            }
            else if (this.cantidad > 2)
            {
                descuento = cantidad * precio *(decimal)Convert.ToDouble(0.3);
            }
            return descuento;
        }
    }
}
