using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_Herencia
{
    class Articulo
    {
        private int _id;
        private string _nombre;
        private decimal _precio;

        public int id
        {
            get { return _id; }
            set { this._id = value; }
        }
        public string nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public decimal precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
    }
}
