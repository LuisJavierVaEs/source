using System;
using System.Collections.Generic;

namespace ConsoleApp3_Herencia
{
    class Inventario
    {
        List<Articulo> Articulos;
        public Inventario() { }

        internal void GenerarInventario()
        { 
            Articulos = new List<Articulo>{ new Articulo { id=1, nombre="Acoustic Guitar", precio=1000 },
                                            new Articulo { id=2, nombre="ElectoAcustic Guitar", precio=2000 },
                                            new Articulo { id=3, nombre="Electric Guitar", precio=2500 },
                                            new Articulo { id=4, nombre="Keyboard", precio=5000  },
                                            new Articulo { id=5, nombre="Bass" , precio=2500 },
                                            new Articulo { id=6, nombre="Drums" , precio=1000 } };
            }

        internal void imprimirInventario()
        {
            foreach(Articulo ar in Articulos)
            {
                Console.WriteLine($"ID_Articulo={ar.id}; Precio=${ar.precio}; {ar.nombre}");
            }
        }

        public List<Articulo> GetInventario()
        {
            return this.Articulos;
        }
    }
}