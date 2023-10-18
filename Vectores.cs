using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculadoraVectores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //------------------METODOS AUXILIARES-------------------------------
        private double gradosToRadianes(double grados)
        {
            //metodo para convertir angulo a radianes
            return grados * Math.PI/180;
        }
        private double radianesToGrados(double radianes)
        {
            return radianes * 180/Math.PI;
        }
        private double getApertura(double anguloA, double anguloB)
        {
            //metodo para calcular el angulo entre dos angulos
            double apertura = Math.Abs(anguloB - anguloA);
            return apertura;
        }

        private double ajustarApertura(double apertura)
        {
            //metodo para ajustar la apertura y que no sea mayor a 180 grados
            double aperturaAjustada = apertura;
            if (apertura > 180)
            {
                aperturaAjustada = 360 - apertura;
            }
            return aperturaAjustada;
        }
        private double getAnguloProductoEscalar(double[] a, double[] b)
        {
            //obtener magnitudes para los vectores
            double A = getMagnitud(a[0], a[1], a[2]);
            double B = getMagnitud(b[0], b[1], b[2]);
            double i = (a[0] * b[0]);
            double j = (a[1] * b[1]);
            double k = (a[2] * b[2]);

            double despeje = (i + j + k) / (A * B);

            //aplicar coseno inverso para obtener el angulo del vector
            //(se obtiene a partir del despeje de  AB*cos(Φ) = suma de las componentes del vector resultante)
            double angulo = Math.Acos(despeje);

            angulo = radianesToGrados(angulo); //convertir radianes a angulos
            
            return angulo;
        }

        private double getMagnitud(double x, double y, double z)
        {
            //metodo para aplicar teorema de piagoras para obetener la resultante de un vector
            double magnitud = Math.Sqrt(x*x + y*y + z*z);
            return magnitud;
        }

        private double[] getProductoPunto(double[] vectorA, double[] vectorB)
        {
            //metodo para calcular el producto escalar de dos vectores
            double[] productoPunto = {(vectorA[0] * vectorB[0]), (vectorA[1] * vectorB[1]), (vectorA[2] * vectorB[2])};
            return productoPunto;
        }
        private int determinarSigno(double apertura)
        {
            //metodo para determinar el signo del producto escalar

            int signo = 1;
            if (apertura > 90)
            {
                //si la apertura es mayor a 90 grados el signo del producto es negativo
                signo = -1;
                return signo;
            }

            //si no se cumple el producto escalar es positivo
            else
            {
                return signo;
            }
        }

        private double[] getProductoCruz(double[] A, double[] B)
        {
            //determinantes para calcular las componentes de un producto vectorial

            //  i = AyBz - AzBy
            double i = (A[1] * B[2] - A[2] * B[1]);

            //  j = AzBx - AxBz
            double j = (A[2] * B[0] - A[0] * B[2]);
            
            //   k = AxBy - AyBx
            double k = (A[0] * B[1] - A[1] * B[0]);

            double[] componentes = { i, j, k };
            return componentes;
        }


        //---------------------pestaña 1 SUMAR VECTORES-------------------------
            
            //funcion para sumar vectores
                    private void bttnSumarVectores_Click_1(object sender, EventArgs e)
        {
            //capturar el texto de los textbox e igualarlo a las componente
            double Ax = double.Parse(txtAx.Text);
            double Ay = double.Parse(txtAy.Text);
            double Az = double.Parse(txtAz.Text);

            double Bx = double.Parse(txtBx.Text);
            double By = double.Parse(txtBy.Text);
            double Bz = double.Parse(txtBz.Text);
            //-----------------------------------------------------------------

            //declarar vectores y en el vector C sumas componentes de A y B
            double[] vectorA = { Ax, Ay, Az };
            double[] vectorB = { Bx, By, Bz };
            double[] vectorC = { (Ax + Bx), (Ay + By), (Az + Bz) };

            double magnitud = getMagnitud(vectorC[0], vectorC[1], vectorC[2]); //calcular magnitud pasando las componentes como parametro

            //mostrar resultados
            MessageBox.Show($"El resultado de sumar el vector A y B es: (x: {vectorC[0]},  y: {vectorC[1]},  z:{vectorC[2]})  " +
                $"\nSu magnitud es: {Math.Round(magnitud, 2)}");

        }

        private void bttnBorrar_Click(object sender, EventArgs e)
        {
            //al dar click en borrar todos los textbox seran 0
            txtAx.Text = "0";
            txtAy.Text = "0";
            txtAz.Text = "0";
            txtBx.Text = "0";
            txtBy.Text = "0";
            txtBz.Text = "0";
        }


        //--------------------pestaña 2 CALCULAR COMPONENTES-------------------------

        //funcion para calcular componentes de un vector
        private void bttnCalcular_Click_1(object sender, EventArgs e)
        {
            //declarar variables igual a el dato obtenido en los textbox correspondientes
            double magnitud = double.Parse(txtMagnitud.Text);
            double angulo = double.Parse(txtAngulo.Text);

            angulo = gradosToRadianes(angulo); //convertir angulo a radianes para que el calculo sea exacto


            //calcular componentes usando seno y coseno del angulo por la magnitud del vector 
            double x = magnitud * Math.Cos(angulo);
            double y = magnitud * Math.Sin(angulo);

            //mostrar resultados obtenidos
            MessageBox.Show($"Las componentes del vector ingresado son: (x:{Math.Round(x, 2)},  y:{Math.Round(y, 2)})");
        }

        private void bttmBorrarP2_Click_1(object sender, EventArgs e)
        {
            //borrar los textbox y dejarlos en cero 
            txtAngulo.Text = "0";
            txtMagnitud.Text = "0";
            txtA.Text = "0";
            txtB.Text = "0";
            txtAnguloA.Text = "0";
            txtAnguloB.Text = "0";
        }

        //--------------------pestaña 3 PRODUCTO ESCALAR--------------------------

        //funcion para calcular producto escalar con angulo y magnitudes
        private void bttnProductoEscalar_Click(object sender, EventArgs e)
        {
            //capturar texto y guardarlos en las variables
            double A = double.Parse(txtA.Text);
            double B = double.Parse(txtB.Text);
            double anguloA = double.Parse(txtAnguloA.Text);
            double anguloB = double.Parse(txtAnguloB.Text);

            double apertura = getApertura(anguloA, anguloB); //calcular el angulo de apertura entre los dos angulos

            //aplicar metodo parajustar el angulo de apertura entre los vectores
            apertura = ajustarApertura(apertura);

            //aplicar metodo para determinar el signo del producto escalar
            double signo = determinarSigno(apertura);

            double producto_escalar = A * B * Math.Cos(apertura) * signo;
            MessageBox.Show($"RESULTADOS:\n " +
                $"\nEl producto escalar es: {Math.Round(producto_escalar,2)}" +
                $"\nΦ: {apertura}°");
        }

        private void bttnClearP3_Click(object sender, EventArgs e)
        {
            txtA.Text = "0";
            txtB.Text = "0";
            txtAnguloA.Text = "0";
            txtAnguloB.Text = "0";
        }
        
            //funcion para calcular producto escalar usando componentes
        private void calcularProductoEscalarComp_Click(object sender, EventArgs e)
        {
            //declarar dos listas que seran igual a las componentes de cada vector
            double[] vectorA = { double.Parse(txtAxPe.Text), double.Parse(txtAyPe.Text), double.Parse(txtAzPe.Text) };
            double[] vectorB = { double.Parse(txtBxPe.Text), double.Parse(txtByPe.Text), double.Parse(txtBzPe.Text) };


            //obtener componentes para el vector resultante aplicando el metodo dedicado
            double[] resultante = getProductoPunto(vectorA, vectorB);
            double magnitud = getMagnitud(resultante[0], resultante[1], resultante[2]);
            //aplicar metodo para encontrar el angulo entre los do vectores y su magnitud
            double angulo = getAnguloProductoEscalar(vectorA, vectorB);

            //motrar resultados en una ventana emergente
            MessageBox.Show($"RESULTADOS:\n " +
                $"\nComponentes: (x:{Math.Round(resultante[0],2)}, y: {Math.Round(resultante[1],2)},  z:{Math.Round(resultante[2],2)})" +
                $"\nMagnitud: {Math.Round(magnitud,2)} \nAngulo: {Math.Round(angulo, 2)}°");


        }
        private void clearComps_Click(object sender, EventArgs e)
        {
            txtAxPe.Text = "0";
            txtAyPe.Text = "0";
            txtAzPe.Text = "0";

            txtBxPe.Text = "0";
            txtByPe.Text = "0";
            txtBzPe.Text = "0";
        }
        
        
        
        //--------------pestaña 4 PRODCUTO VECTORIAL----------------------
        
            //funcion para calcular producto vectorial con angulo y magnitudes
        private void bttnProductoVectorial_Click(object sender, EventArgs e)
        {
            double A = double.Parse(txtMagA.Text);
            double B = double.Parse(txtMagB.Text);

            //convertir angulo A y B a radianes para obtener un calculo exacto
            double anguloA = gradosToRadianes(double.Parse(txtAngleA.Text)); 
            double anguloB = gradosToRadianes(double.Parse(txtAngleB.Text));

            //obtener agulo fi (angulo de diferencia entre los dos vectores)
            double apertura = getApertura(anguloA, anguloB);

            //calcular producto vectorial 
            double producto_vectorial = A * B * Math.Sin(apertura);
            showProductoVectorial.Text = Math.Round(producto_vectorial,2).ToString();
        }
        private void bttnClearPv_Click(object sender, EventArgs e)
        {
            txtAngleA.Text = "0";
            txtAngleB.Text = "0";
            txtMagA.Text = "0";
            txtMagB.Text = "0";
            showProductoVectorial.Text = "0";
            
        }

            //metodo para calcuar producto vectorial a partir de sus componentes 
        private void bttnCalcularPV_Click(object sender, EventArgs e)
        {
            //declarar listas para vector A y B
            double[] A = {double.Parse(txtAxPv.Text), double.Parse(txtAyPv.Text), double.Parse(txtAzPv.Text) };
            double[] B = { double.Parse(txtBxPv.Text), double.Parse(txtByPv.Text), double.Parse(txtBzPv.Text) };


            //aplicar metodo para obtener el producto cruz a partir de determinantes
            double[] AxB = getProductoCruz(A,B);
            
            //obtener magnitud
            double magnitud = getMagnitud(AxB[0], AxB[1], AxB[2]);

            //mostrar resultados
            MessageBox.Show($"RESULTADOS:\n " +
                $"\nMagnitud: {Math.Round(magnitud,2)}" +
                $"\nComponentes: (x: {Math.Round(AxB[0],2)},  y: {Math.Round(AxB[1], 2)},  z: {Math.Round(AxB[2],2)})");

        }
        private void bttnClearCompsPv_Click(object sender, EventArgs e)
        {
            txtAxPv.Text = "0";
            txtAyPv.Text = "0";
            txtAzPv.Text = "0";
            txtBxPv.Text = "0";
            txtByPv.Text = "0";
            txtBzPv.Text = "0";
        }
        
        
        
        //---------------PRESTAÑA 5 CALCULAR VECTOR UNITARIO---------------
        private void bttnCalcularVu_Click(object sender, EventArgs e)
        {
            //capturar datos ingresados
            double x = double.Parse(txtxVu.Text);
            double y= double.Parse(txtyVu.Text);
            double z = double.Parse(txtzVu.Text);

            //aplicar metod para calcular magnitud
            double magnitud = getMagnitud(x, y, z);

            //mostrar resultados
            showVectorUnitaio.Text = $"x: {Math.Round(x/magnitud,2)}, y:{Math.Round(y/magnitud,2)}, z: {Math.Round(z/magnitud,2)}";
            showMagnitud.Text = $"{Math.Round(magnitud,2)}";
        }
        private void clearComponentes_Click(object sender, EventArgs e)
        {
            txtxVu.Text = "0";
            txtyVu.Text = "0";
            txtzVu.Text = "0";
            showVectorUnitaio.Text = "0";
            showMagnitud.Text = "0";
        }
    }
}
