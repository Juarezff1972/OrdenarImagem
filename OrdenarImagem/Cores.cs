using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarImagem
{
    internal class Cores
    {
        public double corLong;
        public int cinza2;
        public double cinza;

        rgb RGB;
        hsv HSV;

        public Cores()
        {
            RGB = new rgb();
            RGB.R = 0;
            RGB.B = 0;
            RGB.G = 0;
            HSV = new hsv();
        }

        public void rgb2hsv()
        {
            hsv out1 = new hsv();
            rgb in1 = new rgb();
            byte min, max, delta;

            in1.R = RGB.R;
            in1.G = RGB.G;
            in1.B = RGB.B;

            min = in1.R < in1.G ? in1.R : in1.G;
            min = min < in1.B ? min : in1.B;

            max = in1.R > in1.G ? in1.R : in1.G;
            max = max > in1.B ? max : in1.B;

            out1.v = max;
            delta = (byte)(max - min);

            if (delta < 0.00001)
            {
                out1.s = 0;
                out1.h = 0; // undefined, maybe nan?
                HSV.h = out1.h;
                HSV.s = out1.s;
                HSV.v = out1.v;
                return;
            }
            if (max > 0.0)
            { // NOTE: if Max is == 0, this divide would cause a crash
                out1.s = (delta / max);                  // s
            }
            else
            {
                // if max is 0, then r = g = b = 0              
                // s = 0, h is undefined
                out1.s = 0.0;
                out1.h = double.NaN;                            // its now undefined
                HSV.h = out1.h;
                HSV.s = out1.s;
                HSV.v = out1.v;
                return;
            }
            if (in1.R >= max)                           // > is bogus, just keeps compilor happy
                out1.h = (in1.G - in1.B) / delta;        // between yellow & magenta

            else
        if (in1.G >= max)
                out1.h = 2.0 + (in1.B - in1.R) / delta;  // between cyan & yellow

            else
                out1.h = 4.0 + (in1.R - in1.G) / delta;  // between magenta & cyan

            out1.h *= 60.0;                              // degrees

            if (out1.h < 0.0)
                out1.h += 360.0;

            HSV.h = out1.h;
            HSV.s = out1.s;
            HSV.v = out1.v;
        }

        public void hsv2rgb()
        {
            double hh, p, q, t, ff;
            long i;

            rgb out1 = new rgb(); ;
            hsv in1 = new hsv();

            in1.h = HSV.h;
            in1.s = HSV.s;
            in1.v = HSV.v;

            if (in1.s <= 0.0)
            {       // < is bogus, just shuts up warnings
                out1.R = (byte)in1.v;
                out1.G = (byte)in1.v;
                out1.B = (byte)in1.v;
                RGB.R = out1.R;
                RGB.G = out1.G;
                RGB.B = out1.B;
                return;
            }
            hh = in1.h;
            if (hh >= 360.0) hh = 0.0;
            hh /= 60.0;
            i = (long)hh;
            ff = hh - i;
            p = in1.v * (1.0 - in1.s);
            q = in1.v * (1.0 - (in1.s * ff));
            t = in1.v * (1.0 - (in1.s * (1.0 - ff)));

            switch (i)
            {
                case 0:
                    out1.R = (byte)in1.v;
                    out1.G = (byte)t;
                    out1.B = (byte)p;
                    break;
                case 1:
                    out1.R = (byte)q;
                    out1.G = (byte)in1.v;
                    out1.B = (byte)p;
                    break;
                case 2:
                    out1.R = (byte)p;
                    out1.G = (byte)in1.v;
                    out1.B = (byte)t;
                    break;
                case 3:
                    out1.R = (byte)p;
                    out1.G = (byte)q;
                    out1.B = (byte)in1.v;
                    break;
                case 4:
                    out1.R = (byte)t;
                    out1.G = (byte)p;
                    out1.B = (byte)in1.v;
                    break;
                case 5:
                default:
                    out1.R = (byte)in1.v;
                    out1.G = (byte)p;
                    out1.B = (byte)q;
                    break;
            }
            RGB.R = out1.R;
            RGB.G = out1.G;
            RGB.B = out1.B;
        }

        public void setCor(Color cor)
        {
            double nRPct;
            double nGPct;
            double nBPct;
            double linR;
            double linG;
            double linB;
            double lY;
            double l;
            double gama;
            rgb color = new rgb();
            //hsv colorhsv;
            int r;
            int g;
            int b;

            corLong = cor.B + cor.G * 256 + cor.R * 256 * 256;

            //color = 
            RGB.R = cor.R;// cor % 256;
            RGB.G = cor.G;// (cor / 256) % 256;
            RGB.B = cor.B;// cor / 256 / 256;


            r = RGB.R;
            g = RGB.G;
            b = RGB.B;

            //=0,299*I1+0,587*J1+0,114*K1
            nRPct = r;// (0.299 * r);
            nGPct = g;// (0.587 * g);
            nBPct = b;// (0.114 * b);
            cinza2 = (int)roundf((nRPct + nGPct + nBPct) / 3);

            nRPct = r / 255.0;
            nGPct = g / 255.0;
            nBPct = b / 255.0;


            rgb2hsv();


            if (nRPct <= 0.04045)
            {
                linR = nRPct / 12.92;
            }
            else
            {
                linR = Math.Pow(((nRPct + 0.055) / 1.055), 2.4);
            }
            if (nGPct <= 0.04045)
            {
                linG = nGPct / 12.92;
            }
            else
            {
                linG = Math.Pow(((nGPct + 0.055) / 1.055), 2.4);
            }
            if (nBPct <= 0.04045)
            {
                linB = nBPct / 12.92;
            }
            else
            {
                linB = Math.Pow(((nBPct + 0.055) / 1.055), 2.4);
            }

            gama = 1.0; // '2.2

            //lY = 0.2126 * linR + 0.7152 * linG + 0.0722 * linB;
            lY = 0.3 * linR + 0.59 * linG + 0.11 * linB;
            l = lY * 1048576 * Math.Pow(lY, (1 / gama));  //'116 * lY ^ (1 / 3) //' - 16

            cinza = l;
        }

        private int roundf(double v)
        {
            return (int)Math.Round(v);
        }
    }
}

/*
 


void ArrayItem::setCor(Color cor)
{
	float nRPct;
	float nGPct;
	float nBPct;
	float linR;
	float linG;
	float linB;
	float lY;
	float l;
	float gama;
	rgb color;
	//hsv colorhsv;
	int r;
	int g;
	int b;

	corLong = cor.B + cor.G * 256 + cor.R * 256 * 256;

	//color = 
	RGB.R = cor.R;// cor % 256;
	RGB.G = cor.G;// (cor / 256) % 256;
	RGB.B = cor.B;// cor / 256 / 256;


	r = RGB.R;
	g = RGB.G;
	b = RGB.B;

	//=0,299*I1+0,587*J1+0,114*K1
	nRPct = r;// (0.299 * r);
	nGPct = g;// (0.587 * g);
	nBPct = b;// (0.114 * b);
	cinza2 = (int)roundf((nRPct + nGPct + nBPct) / 3);

	nRPct = r / 255.0;
	nGPct = g / 255.0;
	nBPct = b / 255.0;


	rgb2hsv();


	if (nRPct <= 0.04045)
	{
		linR = nRPct / 12.92;
	}
	else
	{
		linR = pow(((nRPct + 0.055) / 1.055), 2.4);
	}
	if (nGPct <= 0.04045)
	{
		linG = nGPct / 12.92;
	}
	else
	{
		linG = pow(((nGPct + 0.055) / 1.055), 2.4);
	}
	if (nBPct <= 0.04045)
	{
		linB = nBPct / 12.92;
	}
	else
	{
		linB = pow(((nBPct + 0.055) / 1.055), 2.4);
	}

	gama = 1.0; // '2.2

	lY = 0.2126 * linR + 0.7152 * linG + 0.0722 * linB;
	l = lY * 65535 * pow(lY, (1 / gama));  //'116 * lY ^ (1 / 3) //' - 16

	cinza = l;
}
 
 */
