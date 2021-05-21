using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<Estado>  Estados = new List<Estado> { new Estado { id=1, nombreEstado="Aguascalientes" },
                                                      new Estado { id=2, nombreEstado="Baja California"},
                                                      new Estado { id=3, nombreEstado="Baja California Sur"},
                                                      new Estado { id=4, nombreEstado="Campeche"},
                                                      new Estado { id=5, nombreEstado="Chihuahua"},
                                                      new Estado { id=6, nombreEstado="Chiapas"},
                                                      new Estado { id=7, nombreEstado="Coahuila"},
                                                      new Estado { id=8, nombreEstado="Colima"},
                                                      new Estado { id=9, nombreEstado="Durango"},
                                                      new Estado { id=10, nombreEstado="Guanajuato"},
                                                      new Estado { id=11, nombreEstado="Guerrero"},
                                                      new Estado { id=12, nombreEstado="Hidalgo"},
                                                      new Estado { id=13, nombreEstado="Jalisco"},
                                                      new Estado { id=14, nombreEstado="México"},
                                                      new Estado { id=15, nombreEstado="Michoacán"},
                                                      new Estado { id=17, nombreEstado="Nayarit"},
                                                      new Estado { id=18, nombreEstado="Nuevo León"},
                                                      new Estado { id=19, nombreEstado="Oaxaca"},
                                                      new Estado { id=20, nombreEstado="Puebla"},
                                                      new Estado { id=21, nombreEstado="Querétaro"},
                                                      new Estado { id=22, nombreEstado="Quintana Roo"},
                                                      new Estado { id=23, nombreEstado="San Luis Potosí"},
                                                      new Estado { id=24, nombreEstado="Sinaloa"},
                                                      new Estado { id=25, nombreEstado="Sonora"},
                                                      new Estado { id=26, nombreEstado="Tabasco"},
                                                      new Estado { id=27, nombreEstado="Tamaulipas"},
                                                      new Estado { id=28, nombreEstado="Tlaxcala"},
                                                      new Estado { id=29, nombreEstado="Veracruz"},
                                                      new Estado { id=30, nombreEstado="Yucatán"},
                                                      new Estado { id=31, nombreEstado="Zacatecas"},
                                                      new Estado { id=32, nombreEstado="CDMX,DF"} };

            List<Estatus> GrupoEstatus = new List<Estatus> { new Estatus { id=1, definicion="Prospecto" },
                                                             new Estatus { id=2, definicion="Capacitación"},
                                                             new Estatus { id=3, definicion="Incursión" },
                                                             new Estatus { id=4, definicion="Laborando" } } ;

            List<Alumno>  Grupo = new List<Alumno> {
new Alumno { id=1,  nombre="Jean Carlo Vazquez Estrada",     correo="jeancarlovazquezestrada@hotmail.com",                      CURP="VAEJ890315HCSZSS01", calificacion=09,idEstado=06, idEstatus=4},
new Alumno { id=2,  nombre="Sergio Ivan Vazquez Estrada",    correo="sergioivanvazquezestrada@hotmail.com",                     CURP="VAES970920HCSZSS01", calificacion=10,idEstado=14, idEstatus=3},
new Alumno { id=3,  nombre="Adriana Iveth Vazquez Estrada",  correo="adrianaivethvazquezestrada@hotmail.com",                   CURP="VAEA900905MCSZSS01", calificacion=10,idEstado=14, idEstatus=4},
new Alumno { id=4,  nombre="Angel Treviño Hernandez",        correo="angeltreviñohernandez@gmail.com",                          CURP="TRHA940601HCSZSS01", calificacion=09,idEstado=06, idEstatus=2},
new Alumno { id=5,  nombre="Roberto Jimenez Ramirez",        correo="robertojimenezramirez@gmail.com",                          CURP="JIRR011124HCSZSS01", calificacion=07,idEstado=06, idEstatus=2},
new Alumno { id=6,  nombre="Roberto Marina Diaz",            correo="robertomarinadiaz @gmail.com",                             CURP="ROBE941218HCSZSS01", calificacion=08,idEstado=06, idEstatus=2},
new Alumno { id=7,  nombre="Luis Angel Sandoval López",      correo="luis_angelSVL@hotmail.com",                                CURP="SALL960725HSRNPU03", calificacion=10,idEstado=25, idEstatus=3},
new Alumno { id=8,  nombre="Betsabé Nuñez Santiago",         correo="betsysantiago05@gmail.com",                                CURP="NUSB950303MVZUAE02", calificacion=10,idEstado=29, idEstatus=3},
new Alumno { id=9,  nombre="Irving Arturo Guzman Flores",    correo="irgvingarturoGF@gmail.com",                                CURP="GUFI910419HVZZLR07", calificacion=10,idEstado=29, idEstatus=3},
new Alumno { id=10, nombre="Luis Javier Vazquez Estrada",    correo="sistemas.javier@gmail.com",                                CURP="VAEL941215HCSZSS01", calificacion=10,idEstado=06, idEstatus=3},
new Alumno { id=11, nombre="Alberto Joel Serrato Hernandez", correo="albertojoel@hotmail.com",                                  CURP="SEHJ880101HCSRRW01", calificacion=06,idEstado=06, idEstatus=1},
new Alumno { id=12, nombre="Lizeth Merary Cruz",             correo="lizmercruz@hotmail.com",                                   CURP="MECL920601MCSYTW01", calificacion=10,idEstado=06, idEstatus=4},
new Alumno { id=13, nombre="Jorge Gutierrez Lopez",          correo="jorjais@gmail.com",                                        CURP="GULJ870201HCSJJW04", calificacion=07,idEstado=06, idEstatus=1},
new Alumno { id=14, nombre="Osmar Dallan Perez Estrada",     correo="dallandaoz@gmail.com",                                     CURP="PEEO940505HCSKPW01", calificacion=09,idEstado=06, idEstatus=2},
new Alumno { id=15, nombre="Miguel Ángel Ramirez Rodriguez", correo="mikeAcala@gmail.com",                                      CURP="RARM940506HCSDDW02", calificacion=08,idEstado=06, idEstatus=2},
new Alumno { id=16, nombre="Henry Vazquez Aquino",           correo="henryvaa@gmail.com",                                       CURP="VAAH940308HCSFJW02", calificacion=09,idEstado=06, idEstatus=2},
new Alumno { id=17, nombre="German Fuster Sandoval",         correo="yasheer@gmail.com",                                        CURP="FUSG940621HCSDFW06", calificacion=06,idEstado=06, idEstatus=1},
new Alumno { id=18, nombre="Gerardo Jimenez Marcelin",       correo="JIMG940615@hotmail.com",                                   CURP="JIMG940615HCSFTW01", calificacion=04,idEstado=06, idEstatus=1},
new Alumno { id=19, nombre="Jesus Arturo Rodriguez Ramirez", correo="AcrexMalpaso@gmail.com",                                   CURP="RORA941010HCSFFW01", calificacion=05,idEstado=06, idEstatus=1},
new Alumno { id=20, nombre="Jorge Valdivia Rosas",           correo="jvaldivia@ti-capitalhumano.com",                           CURP="VARJ750101HDFBBBBB", calificacion=09,idEstado=32, idEstatus=4},
new Alumno { id=21, nombre="Oscar Urbina Gabriel",           correo="oscar@ti-capitalhumano.com",                               CURP="URGO850101HAABBBBB", calificacion=10,idEstado=29, idEstatus=4},
new Alumno { id=22, nombre="Luis Vazquez Cuj",               correo="luisvazquez@ti-capitalhumano.com",                         CURP="VACL800101HTCBBBBB", calificacion=10,idEstado=26, idEstatus=4},
new Alumno { id=23, nombre="Jose Morales Narváez",           correo="josemorales@ti-capitalhumano.com",                         CURP="MONJ900101HAABBBBB", calificacion=10,idEstado=32, idEstatus=4}
            };

            //Ejercicios E = new Ejercicios(Estados, Grupo, GrupoEstatus);
            Console.WriteLine("/***********************************************************************");
            Console.WriteLine("EJERCICIOS CON LINQ");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Ejercicio Listas = new Ejercicio(Estados, Grupo, GrupoEstatus);
            Environment.Exit(0);
            Console.WriteLine("/***********************************************************************");
            Console.WriteLine("IMPRIMIENDO TODOS LOS ALUMNOS");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            foreach (Alumno al in Grupo)
            {
                al.imprimirAtributos();
            }
            Console.WriteLine("Continuar?...");
            Console.ReadKey();
            Console.Clear();
            //------------------------------------
            List<Alumno> VistaDelGrupo = Grupo.FindAll(x => x.id <= 0);
            foreach(Alumno al in VistaDelGrupo)
            {
                Console.WriteLine($"Nombre={al.nombre}");
            }

            List<Alumno> Vistanueva = Grupo.Where(x => x.edad == 26).ToList<Alumno>();
            foreach (Alumno al in Vistanueva)
            {
                Console.WriteLine($"Nombre={al.nombre}");
            }
            Console.ReadKey();
        }
    }
}