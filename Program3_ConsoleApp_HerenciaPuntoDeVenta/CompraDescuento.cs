using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Herencia
{
    class CompraDescuento:CompraBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }
        public decimal descuento { get; set; }

        public CompraDescuento(int idArticulo, string nombreArticulo, decimal precio, int cantidad)
        {
            this.id = idArticulo;
            this.nombre = nombreArticulo;
            this.precio = precio;
            this.cantidad = cantidad;
            this.total = precio * cantidad;
            //estos descuentos solo son strings, la cantidad se ve en la clase "Compra"
            if (this.cantidad == 2)
            {
                this.descuento = 20;
            }
            else if (this.cantidad > 2)
            {
                this.descuento = 30;
            }
            else
            {
                this.descuento = (0);
            }
        }


        decimal CompraBase.SubTotalCompra(decimal precio, int cantidad)
        {
            decimal total;
            total = precio * cantidad;
            return total;
        }

        public string Imprimir()
        {
            return $"{this.cantidad} : {this.nombre} : {this.precio} : {this.total} :DESCUENTO APLICADO: = {descuento}% ";
        }

        decimal CompraBase.Total()
        {
            return this.total;
        }

        public decimal Descuento()
        {
            this.descuento = 0;
            if (this.cantidad == 2)
            {
                descuento = cantidad * precio * (decimal)Convert.ToDouble(0.2);
            }
            else if (this.cantidad > 2)
            {
                descuento = cantidad * precio * (decimal)Convert.ToDouble(0.3);
            }
            return descuento;
        }
    }
}
