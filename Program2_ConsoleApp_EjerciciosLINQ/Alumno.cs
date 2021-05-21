using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Alumno
    {
        private int _id;
        private string _nombre;
        private string _correo;
        private string _CURP;
        private DateTime _fechaNacimiento;
        private int _edad;
        private int _calificacion;
        private int _idEstado;
        private int _idEstatus;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public string CURP
        {
            get { return _CURP; }
            set
            {
                _CURP = value;
                _fechaNacimiento = setFechaNacimientoDelRFC();
                _edad = getEdad();
            }
        }
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
        }

        public int edad
        {
            get { return _edad; }
        }

        public int idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public int idEstatus
        {
            get { return _idEstatus; }
            set { _idEstatus = value; }
        }

        public int calificacion
        {
            get { return _calificacion; }
            set { _calificacion= value; }
        }

        private DateTime setFechaNacimientoDelRFC()
        {
            string añostringformat = "", añostring = this._CURP.Substring(4, 6);
            for (int i = 5; i >= 0; i -= 1)
            {
                i--;
                añostringformat = añostringformat + añostring.Substring((i), 2);
                if (i > 0)
                    añostringformat = añostringformat + '/';
            }
            DateTime fechanam = Convert.ToDateTime(añostringformat);
            return fechanam;
        }

        public int getEdad()
        {
            DateTime hoy = DateTime.Today;
            int añoActual = hoy.Year;
            _edad = añoActual - this.fechaNacimiento.Year;
            return añoActual - this.fechaNacimiento.Year;
        }

        public List<string> getAtributos()
        {
            List<string> atributos = new List<string>();
            atributos.Add(Convert.ToString(this._id));
            atributos.Add(this._nombre);
            atributos.Add(this._CURP);
            atributos.Add(Convert.ToString(this._fechaNacimiento));
            atributos.Add(Convert.ToString(this._edad));
            atributos.Add(Convert.ToString(this._idEstado));
            atributos.Add(Convert.ToString(this._idEstatus));
            return atributos;
        }

        internal void imprimirAtributos()
        {
            Console.WriteLine($"id={this.id} CURP={this._CURP} Estatus={this._idEstatus} Estado={this.idEstado} Edad={this.edad} años ; Nombre: {this._nombre}");
        }
    }




}
