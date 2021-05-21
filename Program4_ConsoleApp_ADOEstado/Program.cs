using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstado
{
    class Program
    {
        static void Main(string[] args)
        {
            string lectura;
            int opcion;
            ConeccionADO_Estado ADO = new ConeccionADO_Estado();
            while (true)
            {
                Console.WriteLine("\n-------------------------------MENU--------------------------------\n"+
                                  "1.- Consultar todos\n" +    
                                  "2.- Consultar todos por Lista\n" +  
                                  "3.- Consultar uno por ID\n" +
                                  "4.- Agregar\n" +
                                  "5.- Actualizar\n" +
                                  "6.- Eliminar\n" +
                                  "F.- Terminar\n");
                Console.WriteLine("\nOpcion: ");
                lectura = Console.ReadLine();
                if (lectura == Char.ToString('F') || lectura == Char.ToString('f'))                
                    Environment.Exit(0);
                else
                {
                    bool flag = Int32.TryParse(lectura, out opcion);
                    if (flag)
                    {
                        if (opcion < 8 && opcion > 0)
                        {
                            if (opcion == 1) 
                            {
                                DataTable dt = new DataTable();
                                dt=ADO.Consultar();
                                string idS = "", nombreS = "";
                                for (int i=0; i<dt.Rows.Count; i++)
                                {
                                    idS = dt.Rows[i]["id"].ToString();
                                    nombreS = dt.Rows[i]["Nombre"].ToString();
                                    Console.WriteLine($"{idS}> {nombreS}");
                                }
                                /*
                                foreach (DataRow row in dt.Rows)
                                {
                                    foreach (var item in row.ItemArray)
                                {
                                Console.WriteLine(item);*/
                            }
                            else if (opcion == 2)
                            {
                                List<Estado> ListaEstados= ADO.ConsultarLst();
                                foreach (Estado edo in ListaEstados)
                                {
                                    Console.WriteLine($"{edo.id}: {edo.nombreEstado}");
                                }
                            }
                            else if(opcion ==3)
                            {
                                Console.WriteLine("\nInserte el 'id' del estado a buscar: "); 
                                string idBuscado = Console.ReadLine();
                                if (Int32.TryParse(idBuscado, out int id))
                                {
                                    Estado edo = ADO.Consultar(id);
                                    if (edo.nombreEstado != null)
                                    {
                                        Console.WriteLine($"{edo.id}: {edo.nombreEstado}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Id sin datos");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("idBuscado no es un valor numerico aceptble");
                                }
                            }
                            else if (opcion == 4)
                            {
                                Console.WriteLine("\nInserte el 'Nombre' del estado nuevo: ");
                                string nombre = Console.ReadLine();
                                if (nombre != null && nombre!="")
                                {
                                    int x = ADO.AgregarEstado(nombre);
                                    if(x>0)
                                    {
                                        Console.WriteLine($"Agregado Existosamente");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ocurrio un error durante la insercion");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No se puede insertar un valor vacio");
                                }
                            }
                            else if (opcion == 5)
                            { 
                                Console.WriteLine("\nInserte la 'id' del estado a editar");
                                string idBuscado = Console.ReadLine();
                                if (Int32.TryParse(idBuscado, out int id))
                                {
                                    DataTable dt = new DataTable();
                                    bool flagid = false;
                                    dt = ADO.Consultar();
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        string idS = dt.Rows[i]["id"].ToString();
                                        if(idS==idBuscado)
                                        {
                                            flagid = true;
                                        }
                                    }
                                    if (flagid)
                                    {
                                        Console.WriteLine("\nInserte el nuevo 'Nombre' para editar");
                                        string nvoNombre = Console.ReadLine();
                                        if (nvoNombre != null && nvoNombre != "")
                                        {
                                            ADO.Actualizar(id, nvoNombre);
                                            Console.WriteLine("Actualizado");
                                        }
                                        else
                                        {
                                            Console.WriteLine("El 'Nombre' esta vacio");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El id indicado no existe");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("idBuscado no es un entero");
                                }
                            }
                            else if (opcion == 6) 
                            {
                                Console.WriteLine("\nInserte la 'id' del estado a editar");
                                string idBuscado = Console.ReadLine();
                                DataTable dt = new DataTable();
                                bool flagid = false;
                                dt = ADO.Consultar();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    string idS = dt.Rows[i]["id"].ToString();
                                    if (idS == idBuscado)
                                    {
                                        flagid = true;
                                    }
                                }
                                if (flagid)
                                {
                                    if (Int32.TryParse(idBuscado, out int id))
                                    {
                                        ADO.Eliminar(id);
                                        Console.WriteLine("Eliminado");
                                    }
                                    else
                                    {
                                        Console.WriteLine("El id insertado no es un entero");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El id indicado no existe");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opción Incorrecta del menú");   
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opción Incorrecta del menú");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción Incorrecta del menú");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
