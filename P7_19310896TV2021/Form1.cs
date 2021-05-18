using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P7_19310896TV2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;

        DibujarAVL arbolAVL = new DibujarAVL(null);
        DibujarAVL arbolAVL_Letra = new DibujarAVL(null);
        Graphics g;

        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;

            arbolAVL.DibujarArbol(g, this.Font, Brushes.White, Brushes.Black, Pens.White, datb, Brushes.Black);
            datb = 0;

            if(pintaR == 1)
            {
                arbolAVL.color(g, this.Font, Brushes.White, Brushes.Yellow, Pens.Blue, arbolAVL.Raiz, post.Checked, Ino.Checked, pre.Checked);
            }
            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolAVL.Raiz, int.Parse(valor.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    arbolAVL.insertar(dato);
                    valor.Clear();
                    valor.Focus();
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    cont++;
                    Refresh();
                    Refresh();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                    errores.SetError(valor, "Debe ser numerico");
                }
            }
        }
        int pintaR = 0;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    datb = int.Parse(valor.Text);
                    arbolAVL.buscar(datb);
                    pintaR = 2;
                    Refresh();
                    valor.Clear();
                }
                catch (Exception)
                {
                    errores.SetError(valor, "Debe ser numerico");
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");

            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    valor.Clear();
                    arbolAVL.Eliminar(dato);
                    if(arbolAVL.Raiz != null)
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    Refresh();
                    Refresh();
                    cont2++;

                }
                catch (Exception ms)
                {

                    errores.SetError(valor, "Debe ser numerico");
                }
            }
            Refresh(); Refresh(); Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
