using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarImagem
{
    internal class hsv
    {
        private double _h;
        private double _s;
        private double _v;

        public double h
        {
            get { return _h; }
            set { _h = value; }
        }

        public double s
        {
            get { return _s; }
            set { _s = value; }
        }

        public double v
        {
            get { return _v; }
            set { _v = value; }
        }

    }
}
