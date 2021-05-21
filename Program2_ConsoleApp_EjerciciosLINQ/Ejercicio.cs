using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Ejercicio
    {
        public List<Estado> ListaEstados;
        public List<Alumno> ListaAlumnos;
        public List<Estatus> ListaEstatus;
        public Ejercicio(List<Estado> estados, List<Alumno> grupo, List<Estatus> GrupoEstatus)
        {
            this.ListaEstados = estados;
            this.ListaAlumnos = grupo;
            this.ListaEstatus = GrupoEstatus;
            
            ejercicio1();
            ejercicio2();
            ejercicio3();
            ejercicio4();
            ejercicio5();
            ejercicio6();
            ejercicio7();
            ejercicio8();
            ejercicio9();
        }

        private void ejercicio9()
        {
            Console.WriteLine($"9. Mostar en la consola los siguientes datos, de aquellos alumnos cuyo estatus sea mayor a 2, ordenado por nombre del estatus\n" +
                              $"A).idAlumnos," +
                              $"B).nombreAlumno," +
                              $"C).nombre del Estado al que pertenece" +
                              $"D).nombre del Estatus en que se encuentran");
            var consulta2000 = from Alumno in ListaAlumnos
                               join Estatus in ListaEstatus on Alumno.idEstatus equals Estatus.id
                               join Estados in ListaEstados on Alumno.idEstado equals Estados.id
                               where Alumno.idEstatus < 2
                               orderby Estatus.definicion
                               select new { Estatus = Estatus.definicion, idAlu = Alumno.id, Nombre = Alumno.nombre, Estado = Estados.nombreEstado };
            foreach (var x in consulta2000)
            {
                Console.WriteLine($" Estatus:{x.Estatus} - {x.idAlu} - {x.Nombre} - Estado:{x.Estado}");
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio8()
        {
            Console.WriteLine($"8.- Mostrar en la consola los siguientes datos, de aquellos alumnos que tengan estatus 2 ordenado por el nombre de estatus\n" +
                              $"A).idAlumnos,\n" +
                              $"B).nombreAlumno,\n" +
                              $"C).nombre del Estado al que pertenece\n");
            var consulta1000 = from Alumno in ListaAlumnos
                               join Estatus in ListaEstatus on Alumno.idEstatus equals Estatus.id
                               join Estados in ListaEstados on Alumno.idEstado equals Estados.id
                               where Alumno.idEstatus == 2
                               orderby Estatus.definicion
                               select new { Nombre = Alumno.nombre, Estatus = Estatus.definicion, Estado = Estados.nombreEstado };
            foreach (var x in consulta1000)
            {
                Console.WriteLine($"{x.Nombre} - Estatus:{x.Estatus}  - Estado:{x.Estado}");
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio7()
        {
            Console.WriteLine($"7.- Mostrar en la consola los siguientes datos, de aquellos alumnos que estén en estatus 2\n" +
                              $"A).idAlumnos,\n" +
                              $"B).nombreAlumno,\n" +
                              $"C).nombre del Estado al que pertenece\n");
            var consulta1000 = from Alumno in ListaAlumnos
                               join Estatus in ListaEstatus on Alumno.idEstatus equals Estatus.id
                               join Estados in ListaEstados on Alumno.idEstado equals Estados.id
                               where Alumno.idEstatus == 2
                               orderby Alumno.nombre
                               select new { Nombre = Alumno.nombre, Estatus = Estatus.id, Estado = Estados.nombreEstado };
            foreach (var x in consulta1000)
            {
                Console.WriteLine($"{x.Nombre} - Estatus:{x.Estatus}  - Estado:{x.Estado}");
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio6()
        {
            Console.WriteLine("6.- En caso de que ningún alumno tenga 10, sumarles 1 punto de calificación, y en caso de que todos estén entre 6 y 7 sumarles dos puntos.");
            var consulta1 = ListaAlumnos.Where(x => x.calificacion > 0).OrderBy(x => x.calificacion).ToList();
            var consulta2 = ListaAlumnos.Where(x => x.calificacion != 10).OrderBy(x => x.calificacion).ToList();
            var consulta3 = ListaAlumnos.Where(x => x.calificacion == 6 || x.calificacion == 7).OrderBy(x => x.calificacion).ToList();
            Console.WriteLine("\nCALIFICAIONES NORMALES");
            foreach (var x in consulta1)
            {
                Console.WriteLine($"Calificaciones: {x.calificacion} {x.nombre}");
            }
            Console.ReadKey();
            Console.WriteLine("\nCALIFICAIONES SIN DIEZ + 1");
            foreach (var x in consulta2)
            {
                Console.WriteLine($"Calificaciones: {x.calificacion + 1} {x.nombre}");
            }
            Console.ReadKey();
            Console.WriteLine("\nCALIFICAIONES SIETE & OCHO + 2");
            foreach (var x in consulta3)
            {
                Console.WriteLine($"Calificaciones: {x.calificacion + 2} {x.nombre}");
            }

            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio5()
        {
            Console.WriteLine("5.- Obtener la calificación promedio de los alumnos\n");
            var variable = ListaAlumnos.FindAll(x => x.calificacion > 0);
            List<int> calificaciones = new List<int>();
            foreach (var x in variable)
            {
                calificaciones.Add(x.calificacion);
            }
            double average = calificaciones.Average(num => Convert.ToInt64(num));
            Console.WriteLine($"Promedio = {average}");
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio4()
        {
            Console.WriteLine("4.- Obtener una lista de los alumnos que tienen calificación aprobatoria, considerando ésta como 6 o mayor, ordenado por calificación del mayor al menor\n");
            var variable = ListaAlumnos.Where(x => x.calificacion > 6).OrderBy(x => x.calificacion).ToList();
            foreach (var x in variable)
            {
                Console.WriteLine($"Calificacion:{x.calificacion}, {x.nombre} ");
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio3()
        {
            Console.WriteLine("3.- De la lista de alumnos obtener los alumnos que son IdEstado 1 y 2 y además de que estén en el estatus 2 o 4");
            Console.WriteLine("INFORMACION = Modificamos el id a 6 por Chiapas y a 32 por CDMX [Por motivos prácticos]\n");
            var variable = ListaAlumnos.Where(x => x.idEstado == 6 || x.idEstado == 32 &&
                                                   x.idEstatus == 2 || x.idEstatus == 4
                                             ).OrderBy(x => x.nombre).ToList();
            foreach (var x in variable)
            {
                Console.WriteLine($" {x.idEstado}  {x.nombre} {x.idEstatus}");
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio2()
        {
            Console.WriteLine("2. De la lista de alumnos obtener a los alumnos cuyo idEstado 3 y 5, Ordenado por nombre");
            Console.WriteLine("INFORMACION = Modificamos el id a 6 por Chiapas y a 29 por Veracruz [Por motivos prácticos]\n");
            var variable = ListaAlumnos.Where(x => x.idEstado == 29 || x.idEstado == 6).OrderBy(x => x.nombre).ToList();
            foreach (var x in variable)
            {
                Console.WriteLine($" {x.idEstado}  {x.nombre} ");

                //Console.WriteLine(Convert.ToString(x.idEstado), x.nombre);
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }

        private void ejercicio1()
        {
            Console.WriteLine("1. De la lista de estados, obtener el estado que tiene el id = 5\n");
            var variable = ListaEstados.Where(x => x.id == 5).ToList();
            foreach (var x in variable)
            {
                Console.WriteLine(x.nombreEstado);
            }
            Console.WriteLine("\nContinuar?...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
