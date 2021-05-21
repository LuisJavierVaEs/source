using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp3_Herencia
{
    public interface CompraBase
    {
        int id
        {
            get;
            set;
        }
        string nombre
        {
            get;
            set;
        }
        decimal precio
        {
            get;
            set;
        }
        int cantidad
        {
            get;
            set;
        }
        decimal total
        {
            get;
            set;
        }

        decimal SubTotalCompra(decimal precio, int cantidad);
        decimal Descuento();
        String Imprimir();
        decimal Total();
    }
}
