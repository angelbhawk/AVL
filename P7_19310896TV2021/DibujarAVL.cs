using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace P7_19310896TV2021
{
    class DibujarAVL
    {
        public AVL Raiz;
        public AVL aux;

        //Constructor
        public DibujarAVL() 
        {
            aux = new AVL();
        }
        public DibujarAVL(AVL RaizNueva)
        {
            Raiz = RaizNueva;
        }

        //Agregar un nievo valor al arbol
        public void insertar(int dato)
        {
            if (Raiz == null)
                Raiz = new AVL(dato, null, null, null);
            else
                Raiz = Raiz.Insertar(dato, Raiz);

        }
        //Eliminar un valor del arbol
        public void Eliminar(int dato)
        {
            if (Raiz == null)
                Raiz = new AVL(dato, null, null, null);
            else
                Raiz.Elimnar(dato, ref Raiz);
        }

        private const int Radio = 30;
        private const int DistanciaH = 40;
        private const int Distanciav = 10;
        private int CoordenadaX;
        private int CoordenadaY;

        public void PosicionNodoRecorrido(ref int xmin, ref int ymin)
        {
            CoordenadaY = (int)(ymin + Radio / 2);
            CoordenadaX = (int)(xmin + Radio / 2);

        }

        public void color(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, AVL Raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    color(grafo, fuente, Brushes.Red, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(500);
                    Raiz.Colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    color(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);

                }

            }
            else if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.Colorear(grafo, fuente, Brushes.Yellow, Brushes.Red, Pens.Black);
                    Thread.Sleep(500);
                    Raiz.Colorear(grafo, fuente, Brushes.White, Brushes.Black, Pens.Black);
                    color(grafo, fuente, Brushes.Red, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    color(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);
                }
            }
            else if (post == true)
            {
                if (Raiz != null)
                {
                    color(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    color(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);
                    Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(500);
                    Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                }
            }
        }

        public void colorearB(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, AVL Raiz, int busqueda)
        {
            Brush entorno = Brushes.Red;
            if (Raiz != null)
            {
                Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                if (busqueda < Raiz.valor)
                {
                    Thread.Sleep(500);
                    Raiz.Colorear(grafo, fuente, entorno, Brushes.Red, Lapiz);
                    colorearB(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, busqueda);
                }
                else
                {
                    if (busqueda > Raiz.valor)
                    {
                        Thread.Sleep(500);
                        Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                        colorearB(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, busqueda);
                    }
                    else
                    {
                        Raiz.Colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                        Thread.Sleep(500);
                    }
                }
            }
        }


        //Dibujar el arbol
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, int dato, Brush encuentro)
        {
            int x = 100;
            int y = 75;
            if (Raiz == null) return;

            //Posicion de todos los nodos.

            Raiz.PocisionNodo(ref x, y);

            //Dibuyja los enlaces entre los nodos
            Raiz.DubujarRamas(grafo, Lapiz);

            //Dibujar todos los nodos
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, dato, encuentro);
        }

        public int x1 = 100;
        public int y2 = 75;
        public void restablecer_valores()
        {
            x1 = 100;
            y2 = 75;
        }
        public void buscar(int x)
        {
            if (Raiz == null)
                MessageBox.Show("Arbol AVL vacio", "Error", MessageBoxButtons.OK);
            else
                Raiz.buscar(x, Raiz);
        }
    }
}
