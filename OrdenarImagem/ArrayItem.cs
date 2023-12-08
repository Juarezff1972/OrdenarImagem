using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarImagem
{
    internal class ArrayItem : IComparable
    {
        private int v;
        private int indice;
        private bool mudou;
        private Color c;

        public ArrayItem()
        {
            mudou = true;
        }

        //public event EscritaEventHandler? Escreveu;
        //public event MudarEventHandler Mudar;

        public Color Cor
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
            }
        }

        public int Indice
        {
            get
            {
                return indice;
            }
            set
            {
                indice = value;
            }
        }

        public int Valor
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
                //Dispara(new EventArgs());

                Mudou = true;
            }
        }
        /*public void Dispara(EventArgs e)
        {
            Escreveu?.Invoke(this, e);
        }*/

        /*public void DisparaMudar(VetorEventArgs e)
        {
            Mudar?.Invoke(this, e);
        }*/

        public bool Mudou
        {
            get
            {
                return mudou;
            }
            set
            {
                mudou = value;
                if (mudou)
                {
                    //Debug.WriteLine("Mudou - Indice: " + Indice.ToString());
                    /*VetorEventArgs e = new()
                    {
                        indice = Indice,
                        valor = Valor,
                        cor= Cor
                    };

                    DisparaMudar(e);*/
                }
            }
        }

        public int CompareTo(Object? v1)
        {
            int ret;
            ArrayItem? a = (ArrayItem?)v1;
            ret = 0;

            if (a != null)
            {
                if (a.Valor == v)
                {
                    ret = 0;
                }

                if (a.Valor < v)
                {
                    ret = 1;
                }

                if (a.Valor > v)
                {
                    ret = -1;
                }
            }

            return ret;
        }

        /*public virtual void OnEscreveu(EventArgs e)
        {
            Escreveu?.Invoke(this, e);
        }*/

        public override string ToString()
        {
            return v.ToString();
        }
    }
}
