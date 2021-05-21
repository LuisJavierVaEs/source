using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Estatus
    {
        private int _id;
        private string _definicion;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string definicion
        {
            get { return _definicion; }
            set { _definicion = value; }
        }
    }
}
