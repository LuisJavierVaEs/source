using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Herencia
{
    class CompraTiempoAire:CompraBase
    {
        public int id         { get; set; }
        public string nombre  { get; set; }
        public decimal precio { get; set; }
        public int cantidad   { get; set; }
        public decimal total  { get; set; }
        private string compañia  { get; set; }

        public CompraTiempoAire(string numeroCelular, decimal TiempoA, string nombreCompañia)
        {
            if (this.id == 0)
                this.id = 1;
            this.nombre = $"Tiempo Aire ({numeroCelular})";
            this.cantidad = 1;
            this.precio = TiempoA;
            this.compañia = nombreCompañia;
            this.total = precio * cantidad + 2;
        }

        decimal CompraBase.SubTotalCompra(decimal precio, int cantidad)
        {
            decimal total;
            total = precio * cantidad;
            return total;
        }

        string CompraBase.Imprimir()
        {
            return $"{this.cantidad} : {this.nombre} : {this.precio} : {this.total} COMPAÑIA:{this.compañia}";
        }

        decimal CompraBase.Total()
        {
            return this.total;
        }

        public decimal Descuento()
        {
            return 0;
        }
    }
}
