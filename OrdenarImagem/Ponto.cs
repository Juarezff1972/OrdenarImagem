using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace OrdenarImagem
{
    [Serializable]
    [TypeConverter(typeof(PointConverter))]
    [ComVisible(true)]
    public struct Ponto
    {
        public static readonly Ponto Empty;

        private int x;
        private int y;
        private Color c;

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                if (x == 0)
                {
                    return y == 0;
                }

                return false;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Color C
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

        public Ponto(int x, int y, Color c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public Ponto(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.c = Color.FromArgb(0,0,0,0);
        }

        public Ponto(Size sz)
        {
            x = sz.Width;
            y = sz.Height;
            c = Color.FromArgb(0, 0, 0, 0);
        }

        public Ponto(int dw)
        {
            x = (short)LOWORD(dw);
            y = (short)HIWORD(dw);
            c = new Color();
        }

        public static implicit operator PointF(Ponto p)
        {
            return new PointF(p.X, p.Y);
        }

        public static explicit operator Size(Ponto p)
        {
            return new Size(p.X, p.Y);
        }

        public static Ponto operator +(Ponto pt, Size sz)
        {
            return Add(pt, sz);
        }

        public static Ponto operator -(Ponto pt, Size sz)
        {
            return Subtract(pt, sz);
        }

        public static bool operator ==(Ponto left, Ponto right)
        {
            if (left.X == right.X)
            {
                return left.Y == right.Y;
            }

            return false;
        }

        public static bool operator !=(Ponto left, Ponto right)
        {
            return !(left == right);
        }

        public static Ponto Add(Ponto pt, Size sz)
        {
            return new Ponto(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static Ponto Subtract(Ponto pt, Size sz)
        {
            return new Ponto(pt.X - sz.Width, pt.Y - sz.Height);
        }

        public static Ponto Ceiling(PointF value)
        {
            return new Ponto((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));
        }

        public static Ponto Truncate(PointF value)
        {
            return new Ponto((int)value.X, (int)value.Y);
        }

        public static Ponto Round(PointF value)
        {
            return new Ponto((int)Math.Round(value.X), (int)Math.Round(value.Y));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            Ponto point = (Ponto)obj;
            if (point.X == X)
            {
                return point.Y == Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public void Offset(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Offset(Ponto p)
        {
            Offset(p.X, p.Y);
        }

        public override string ToString()
        {
            return "{X=" + X.ToString(CultureInfo.CurrentCulture) + ",Y=" + Y.ToString(CultureInfo.CurrentCulture) + "}";
        }

        private static int HIWORD(int n)
        {
            return (n >> 16) & 0xFFFF;
        }

        private static int LOWORD(int n)
        {
            return n & 0xFFFF;
        }
    }
}