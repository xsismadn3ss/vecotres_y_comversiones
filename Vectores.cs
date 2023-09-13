using System;
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
            return grados * Math.PI/180;
        }
        private double getApertura(double anguloA, double anguloB)
        {
            double apertura = anguloB - anguloA;
            return apertura;
        }

        private double ajustarApertura(double apertura)
        {
            double aperturaAjustada = apertura;
            if (apertura > 180)
            {
                aperturaAjustada = 360 - apertura;
            }
            return aperturaAjustada;
        }

        private double getMagnitud(double x, double y, double z)
        {
            double magnitud = Math.Sqrt(x*x + y*y + z*z);
            return magnitud;
        }
        private double[] getProductoEscalarComponentes(double[] vectorA, double[] vectorB)
        {
            double[] productoPunto = {(vectorA[0] * vectorB[0]), (vectorA[1] * vectorB[1]), (vectorA[2] * vectorB[2]) };
            return productoPunto;
        }
        private int determinarSigno(double apertura)
        {
            int signo = 1;
            if (apertura > 90)
            {
                signo = -1;
            }
            return signo;
        }
        
        
        //---------------------pestaña 1 SUMAR VECTORES-------------------------
            
            //funcion para sumar vectores
        private void bttnSumarVectores_Click(object sender, EventArgs e)
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
            double[] vectorA = { Ax, Ay, Az};
            double[] vectorB = { Bx, By, Bz };
            double[] vectorC = { (Ax+Bx), (Ay+By) , (Az+Bz)};

            double magnitud = getMagnitud(vectorC[0], vectorC[1], vectorC[2]);

            MessageBox.Show($"El resultado de sumar el vector A y B es: (x: {vectorC[0]},y: {vectorC[1]},z:{vectorC[2]})  \nSu magnitud es: {Math.Round(magnitud,2)}");
           
        }

        private void button1_Click(object sender, EventArgs e)
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
        private void bttnCalcular_Click(object sender, EventArgs e)
        {
            double magnitud = double.Parse(txtMagnitud.Text);
            double angulo = double.Parse(txtAngulo.Text);

            angulo = gradosToRadianes(angulo); //convertir angulo a radianes para que el calculo sea exacto

            double x = magnitud * Math.Cos(angulo);
            double y = magnitud * Math.Sin(angulo);

            MessageBox.Show($"Las componentes del vector ingresado son: (x:{Math.Round(x,2)}, y:{Math.Round(y,2)})");
        }

        private void bttmBorrarP2_Click(object sender, EventArgs e)
        {
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
            double A = double.Parse(txtA.Text);
            double B = double.Parse(txtB.Text);
            double anguloA = double.Parse(txtAnguloA.Text);
            double anguloB = double.Parse(txtAnguloB.Text);

            double apertura = getApertura(anguloA, anguloB);
            double signo = 0;

            //condicional para ajustar el angulo de apertura entre los vectores
            apertura = ajustarApertura(apertura);
            signo = determinarSigno(apertura);
            //condicional para determinar el signo del producto escalar

            double producto_escalar = A * B * Math.Cos(apertura) * signo;
            MessageBox.Show($"El producto escalar es: {Math.Round(producto_escalar,2)}");
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
            double[] vectorA = { double.Parse(txtAxPe.Text), double.Parse(txtAyPe.Text), double.Parse(txtAzPe.Text) };
            double[] vectorB = { double.Parse(txtBxPe.Text), double.Parse(txtByPe.Text), double.Parse(txtBzPe.Text) };

            double[] componentes = getProductoEscalarComponentes(vectorA, vectorB);
            double magnitud = getMagnitud(componentes[0], componentes[1], componentes[2] );

            double angulo = Math.Acos((componentes[0] + componentes[1] + componentes[2])/magnitud);

            MessageBox.Show($"RESULTADOS: \nComponentes del producto escalar: (x:{Math.Round(componentes[0],2)}, y: {Math.Round(componentes[1],2)}, z:{Math.Round(componentes[2],2)})" +
                $"\nMagnitud: {Math.Round(magnitud,2)} \nAngulo: {Math.Round(angulo,2)}");


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

            //obtener agulo fi (angulo de diferencia entre los dos)
            double apertura = getApertura(anguloA, anguloB);


            double producto_vectorial = A * B * Math.Sin(apertura);
            showProductoVectorial.Text = Math.Round(producto_vectorial,2).ToString();
        }
        private void bttnClearPv_Click(object sender, EventArgs e)
        {
            txtAngleA.Text = "0";
            txtAngleB.Text = "0";
            txtMagA.Text = "0";
            txtMagB.Text = "0";
            
        }
        
        
        
        //---------------PRESTAÑA 5 CALCULAR VECTOR UNITARIO---------------
        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

    }
}
