using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plano_Círculo_Solos
{
    public partial class Form1 : Form
    {
        int Ang = 45, Diameter = 450, maxresx = 1280, maxresy = (720 - 40), minresx = 0, minresy = 0;
        string ScrollAngle, textSin, textCos, textTan, textCot, textSec, textCsc;
        double sin = 0, cos = 0, tan = 0, cot = 0, sec = 0, csc = 0;
        float Sin, Cos, Tan, Cot, Sec, Csc, ysin, xcos, xtan, ycot, xsec, ycsc;
        
        public Form1()
        {
            InitializeComponent();
            TodoFunc();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Para resolución de 1280 x 720
            // La barra del título quita 40 pix por eso a la resolución max en y (maxresy) le quite 40
            // 80 es la separación de los limites lateral izquierdo e inferior
            // Si cambio el diametro que quiera se modifican los valores de cada función graficada con respecto al radio
            
            // Contenido Nuevo
            // Mejora al ARCO actualizado al ángulo
            // Establecer los cambios necesarios para graficar 0° y 90°
            // Pasar los dibujos al panel
            // Mejoras en el código

            int Rad = Diameter / 2, xcartint = (minresx + 60), ycartint = (maxresy - 85);
            float xcartfloat = xcartint, ycartfloat = ycartint;

            Graphics g = panel1.CreateGraphics();

            //Graficar cosas básicas
            Pen LCartesian = new Pen(Color.DarkGray, 2);
            Pen LCircle = new Pen(Color.DarkGray, 2);
            Pen LArc = new Pen(Color.Goldenrod, 2);
            Pen LRadius = new Pen(Color.Black, 2);

            // Mitades y limites de la resolución total en la que quiero trabajar
            // Eje X
            g.DrawLine(LCartesian, minresy, ycartint, maxresx, ycartint);
            // Eje Y
            g.DrawLine(LCartesian, xcartint, minresy, xcartint, maxresy);
            // Uso de Rectangle para trabajar más fácil, creación de la circunferencia
            Rectangle rec = new Rectangle((xcartint - Rad), (ycartint - Rad), Diameter, Diameter);
            g.DrawEllipse(LCircle, rec);
            g.DrawArc(LArc, rec, 0, -(Ang));
            

            if (Ang > 0 && Ang < 90)
            {
                TodoFunc();

                ysin = ycartfloat - Sin;
                xcos = xcartfloat + Cos;
                xtan = xcartfloat + Sec;
                ycot = ycartfloat - Csc;
                xsec = xcartfloat + Sec;
                ycsc = ycartfloat - Csc;

                label4.Text = textSin;
                label6.Text = textCos;
                label8.Text = textTan;
                label10.Text = textCot;
                label12.Text = textSec;
                label14.Text = textCsc;

                // Comienzan las Funciones Graficadas

                Pen LSeno = new Pen(Color.Red, 2);
                Pen LCoseno = new Pen(Color.Blue, 2);
                Pen LTangente = new Pen(Color.Brown, 2);
                Pen LCotangente = new Pen(Color.GreenYellow, 2);
                Pen LSecante = new Pen(Color.Teal, 2);
                Pen LCosecante = new Pen(Color.Magenta, 2);

                // El Radio
                g.DrawLine(LRadius, xcartfloat, ycartfloat, xcos, ysin);

                // Seno y Coseno
                g.DrawLine(LSeno, xcartfloat, ycartfloat, xcartfloat, ysin);
                g.DrawLine(LCoseno, xcartfloat, ycartfloat, xcos, ycartfloat);

                // Tangente y Cotangente
                g.DrawLine(LTangente, xcos, ysin, xtan, ycartfloat);
                g.DrawLine(LCotangente, xcos, ysin, xcartfloat, ycot);

                // Secante y Cosecante
                g.DrawLine(LSecante, xcartfloat, ycartfloat, xsec, ycartfloat);
                g.DrawLine(LCosecante, xcartfloat, ycartfloat, xcartfloat, ycsc);

                // Dibujos duplicados de Seno y Coseno
                g.DrawLine(LSeno, xcos, ycartfloat, xcos, ysin);
                g.DrawLine(LCoseno, xcartfloat, ysin, xcos, ysin);
            }
            else
            {
                if (Ang == 0)
                {
                    TodoFunc();

                    ysin = ycartfloat - Sin; // Seno a 0 grados es igual a 0
                    xcos = xcartfloat + Cos; // Coseno a 0 grados es igual a 1
                    xtan = xcartfloat + Sec; // Tangente a 0 grados es igual a 0
                    ycot = -ycartfloat; // Cotangente a 0 grados es infinita - positiva, no existe
                    xsec = xcartfloat + Sec; // Secante a 0 grados es igual a 1
                    ycsc = -ycartfloat; // Cosecante a 0 grados es inginita - positiva, al igual que la Cotangente

                    label4.Text = textSin;
                    label6.Text = textCos;
                    label8.Text = textTan;
                    label10.Text = textCot;
                    label12.Text = textSec;
                    label14.Text = textCsc;

                    // Comienzan las Funciones Graficadas

                    Pen LSeno = new Pen(Color.Red, 2);
                    Pen LCoseno = new Pen(Color.Blue, 2);
                    Pen LTangente = new Pen(Color.Brown, 2);
                    Pen LCotangente = new Pen(Color.GreenYellow, 2);
                    Pen LSecante = new Pen(Color.Teal, 2);
                    Pen LCosecante = new Pen(Color.Magenta, 2);

                    // El Radio
                    g.DrawLine(LRadius, xcartfloat, ycartfloat, xcos, ysin);

                    // Seno a 0 grados es igual a 0
                    // Coseno a 0 grados es igual a 1
                    // Tangente a 0 grados es igual a 0
                    // Cotangente a 0 grados es infinita - positiva, no existe
                    // Secante a 0 grados es igual a 1
                    // Cosecante a 0 grados es inginita - positiva, al igual que la Cotangente

                    // Seno y Coseno
                    g.DrawLine(LSeno, xcartfloat, ycartfloat, xcartfloat, ysin);
                    g.DrawLine(LCoseno, xcartfloat, ycartfloat, xcos, ycartfloat);

                    // Tangente y Cotangente
                    g.DrawLine(LTangente, xcos, ysin, xtan, ycartfloat);
                    g.DrawLine(LCotangente, xcos, ycartfloat, xcos, ycot);

                    // Secante y Cosecante
                    g.DrawLine(LSecante, xcartfloat, ycartfloat, xsec, ycartfloat);
                    g.DrawLine(LCosecante, xcartfloat, ycartfloat, xcartfloat, ycsc);

                    // Dibujos duplicados de Seno y Coseno
                    g.DrawLine(LSeno, xcos, ycartfloat, xcos, ysin);
                    g.DrawLine(LCoseno, xcartfloat, ysin, xcos, ysin);
                }
                else
                {
                    TodoFunc();

                    ysin = ycartfloat - Sin; // Seno a 90 grados es igual a 1
                    xcos = xcartfloat + Cos; // Coseno a 90 grados es igual a 0
                    xtan = xcartfloat + 1000; // Tangente a 90 grados es infinita - positiva, no existe
                    ycot = ycartfloat - Csc; // Cotangente a 90 grados es 0
                    xsec = xcartfloat + 1000; // Secante a 90 grados es infinita - positiva, al igual que la Tangente
                    ycsc = ycartfloat - Csc; // Cosecante a 90 grados es 1

                    label4.Text = textSin;
                    label6.Text = Convert.ToString(0);
                    label8.Text = Convert.ToString(Math.Pow(0, -1)); 
                    label10.Text = Convert.ToString(0);
                    label12.Text = Convert.ToString(Math.Pow(0, -1));
                    label14.Text = Convert.ToString(1);

                    // Comienzan las Funciones Graficadas

                    Pen LSeno = new Pen(Color.Red, 2);
                    Pen LCoseno = new Pen(Color.Blue, 2);
                    Pen LTangente = new Pen(Color.Brown, 2);
                    Pen LCotangente = new Pen(Color.GreenYellow, 2);
                    Pen LSecante = new Pen(Color.Teal, 2);
                    Pen LCosecante = new Pen(Color.Magenta, 2);

                    // El Radio
                    g.DrawLine(LRadius, xcartfloat, ycartfloat, xcos, ysin);

                    // Seno a 90 grados es igual a 1
                    // Coseno a 90 grados es igual a 0
                    // Tangente a 90 grados es infinita - positiva, no existe
                    // Cotangente a 90 grados es 0
                    // Secante a 90 grados es infinita - positiva, al igual que la Tangente
                    // Cosecante a 90 grados es 1

                    // Seno y Coseno
                    g.DrawLine(LSeno, xcartfloat, ycartfloat, xcartfloat, ysin);
                    g.DrawLine(LCoseno, xcartfloat, ycartfloat, xcos, ycartfloat);

                    // Tangente y Cotangente
                    g.DrawLine(LTangente, xcartfloat, ysin, xtan, ysin);
                    g.DrawLine(LCotangente, xcos, ysin, xcartfloat, ycot);

                    // Secante y Cosecante
                    g.DrawLine(LSecante, xcartfloat, ycartfloat, xsec, ycartfloat);
                    g.DrawLine(LCosecante, xcartfloat, ycartfloat, xcartfloat, ycsc);

                    // Dibujos duplicados de Seno y Coseno
                    g.DrawLine(LSeno, xcos, ycartfloat, xcos, ysin);
                    g.DrawLine(LCoseno, xcartfloat, ysin, xcos, ysin);
                }
            }
        }

        private void trackBarforAngle_Scroll(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            g.Clear(Color.WhiteSmoke);
            label1.Text = trackBarforAngle.Value.ToString();
            ScrollAngle = trackBarforAngle.Value.ToString();
            Ang = Int32.Parse(ScrollAngle);
            PaintEventArgs p;
            p = new PaintEventArgs(g, this.Bounds);
            panel1_Paint(trackBarforAngle, p);
        }

        private void trackBarRad_Scroll(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            g.Clear(Color.WhiteSmoke);
            ScrollAngle = trackBarRad.Value.ToString();
            Diameter = Int32.Parse(ScrollAngle);
            PaintEventArgs p;
            p = new PaintEventArgs(g, this.Bounds);
            panel1_Paint(trackBarforAngle, p);
        }
        
        private void TodoFunc()
        {
            int Rad = Diameter / 2;

            sin = Math.Sin(Ang * 2.0 * Math.PI / 360.0);
            cos = Math.Cos(Ang * 2.0 * Math.PI / 360.0);
            tan = Math.Tan(Ang * 2.0 * Math.PI / 360.0);
            cot = (Math.Pow(tan, -1));
            sec = (Math.Pow(cos, -1));
            csc = (Math.Pow(sin, -1));

            Sin = Convert.ToSingle(sin);
            Cos = Convert.ToSingle(cos);
            Tan = Convert.ToSingle(tan);
            Cot = Convert.ToSingle(cot);
            Sec = Convert.ToSingle(sec);
            Csc = Convert.ToSingle(csc);

            textSin = Convert.ToString(Sin);
            textCos = Convert.ToString(Cos);
            textTan = Convert.ToString(Tan);
            textCot = Convert.ToString(Cot);
            textSec = Convert.ToString(Sec);
            textCsc = Convert.ToString(Csc);

            Sin = Sin * Rad;
            Cos = Cos * Rad;
            Tan = Tan * Rad;
            Cot = Cot * Rad;
            Sec = Sec * Rad;
            Csc = Csc * Rad;
        }
    }

}