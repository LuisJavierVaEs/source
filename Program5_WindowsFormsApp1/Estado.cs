using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstado
{
    class Estado
    {
        private int _id;
        private string _nombreEstado;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nombreEstado
        {
            get { return _nombreEstado; }
            set { _nombreEstado = value; }
        }

        public Estado()
        {}

        public Estado(int id, string nombreEstado)
        {
            this._id = id;
            this._nombreEstado = nombreEstado;
        }
    }
}
