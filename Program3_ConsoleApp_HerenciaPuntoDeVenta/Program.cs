using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Ticket ticket = new Ticket("MUSIC-WORLD", "VAEL941215TT3", DateTime.Now);
            inventario.GenerarInventario();
            while (true)
            {
                if(inventario==null)
                { 
                    inventario = new Inventario();
                    ticket = new Ticket("MUSIC-WORLD", "VAEL941215TT3", DateTime.Now);
                    inventario.GenerarInventario();
                }
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------------Presiona: X PARA CERRAR");
                Console.WriteLine("ARTICULOS DE LA TIENDA-------------------------------------------Presiona: T para comprar Tiempo Aire");
                inventario.imprimirInventario();
                Console.WriteLine("REALIZAR COMPRA-------------------------------------------------------Presiona: C para realiza Compra");
                Console.WriteLine("=====================================================================================================");
                ticket.MostrarVentaActual();
                Console.WriteLine("ID del articulo a comprar:");
                string compraX = Console.ReadLine();
                if (compraX == Char.ToString('X'))
                {
                    Environment.Exit(0);
                }
                else if (compraX == Char.ToString('C'))
                {
                    ticket.RealizarCompra();
                    inventario = null;
                    ticket = null;
                }
                else if (compraX == Char.ToString('T'))
                {
                    Console.WriteLine("Número de Celular: "); 
                    string compraAire = Console.ReadLine();
                    Console.WriteLine("Monto:");
                    string cantidAire = Console.ReadLine();
                    Console.WriteLine("Compañia:");
                    string compañia = Console.ReadLine();
                    bool cantidYES = Int32.TryParse(cantidAire, out int salidaCantida);
                    if (cantidYES)
                    {
                        ticket.Sumar(new CompraTiempoAire(compraAire, salidaCantida, compañia));

                    }
                    else
                    {
                        Console.WriteLine("===================================>Datos de Compra Erroneos");
                        Console.ReadKey();
                    }  
                }
                else
                {
                    Console.WriteLine("Cantidad:");
                    string cantidX = Console.ReadLine();
                    bool compraYES = Int32.TryParse(compraX, out int idSalidaCompra);
                    bool cantidYES = Int32.TryParse(cantidX, out int salidaCantidad);
                    if (compraYES && cantidYES)
                    {
                        //SI LA CANTIDAD DE COMPRA ES MAYOR A  1 EVALUAR EL DESCUENTO
                        List<Articulo> ListaInventario = inventario.GetInventario();
                        List<Articulo> Vistanueva = ListaInventario.Where(x => x.id == idSalidaCompra).ToList<Articulo>();
                        foreach (Articulo al in Vistanueva)
                        {
                            ticket.Sumar(new Compra(al.id, al.nombre, al.precio, salidaCantidad));
                        }
                    }
                    else
                    {
                        Console.WriteLine("===================================>Datos de Compra Erroneos");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            }
        }
        
        public class Ticket
        {
            private string nombreEMPRESA;
            private string RFC;
            private DateTime fechaActual;
            private decimal total;
            private List<string> items;

            public Ticket(string nombreEMPRES, string RF, DateTime fechaActua) 
            {
                this.nombreEMPRESA = nombreEMPRES; 
                this.fechaActual = fechaActua;
                this.RFC = RF;
                items = new List<string>();
            }

            public void Sumar(CompraBase compraNueva)
            {
                this.total = total + compraNueva.Total();
                if (compraNueva.cantidad == 1)
                {
                    this.items.Add(compraNueva.Imprimir());
                }
                else if (compraNueva.cantidad > 1)
                {
                    this.total = total - compraNueva.Descuento();
                    //CompraDescuento cd = new CompraDescuento(compraNueva.id, compraNueva.nombre, compraNueva.precio, compraNueva.cantidad);
                    this.items.Add(new CompraDescuento(compraNueva.id, compraNueva.nombre, compraNueva.precio, compraNueva.cantidad).Imprimir());
                }
            }
            
            public void MostrarVentaActual()
            {
                Console.WriteLine("TICKET TIENDITA---------------");
                ImprimirDatosDeLaEmpresa();
                Console.WriteLine("------------------------------");
                Console.WriteLine("CANTIDAD-------NOMBRE-------P/UNITARIO--------PRECIO");
                foreach (string item in this.items)
                {
                    Console.WriteLine(item);
                }
            }
            
            public void ImprimirDatosDeLaEmpresa()
            {
                Console.WriteLine($"Empresa: {this.nombreEMPRESA}");
                Console.WriteLine($"RFC:     {this.RFC}");
                Console.WriteLine($"Fecha:   {this.fechaActual}");
            }
            internal void RealizarCompra()
            {
                Console.WriteLine($"Total a pagar = ${this.total}");
                Console.ReadLine();
            }
        }
    }
}
