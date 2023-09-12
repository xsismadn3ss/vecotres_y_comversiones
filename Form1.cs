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
        private double gradosToRadianes(double grados)
        {
            return grados * Math.PI/180;
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

        private int determinarSigno(double apertura)
        {
            int signo = 1;
            if (apertura > 90)
            {
                signo = -1;
            }
            return signo;
        }
        //---------------------pestaña 1-------------------------
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

            double magnitud = Math.Sqrt(Math.Pow(vectorC[0], 2) + Math.Pow(vectorC[1], 2) + Math.Pow(vectorC[2], 2));

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

        //--------------------pestaña 2-------------------------
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
        }

        //--------------------pestaña 3--------------------------
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void bttnProductoEscalar_Click(object sender, EventArgs e)
        {
            double A = double.Parse(txtA.Text);
            double B = double.Parse(txtB.Text);
            double anguloA = double.Parse(txtAnguloA.Text);
            double anguloB = double.Parse(txtAnguloB.Text);

            double apertura = anguloB - anguloA;
            double signo = 0;

            //condicional para ajustar el angulo de apertura entre los vectores
            apertura = ajustarApertura(apertura);
            signo = determinarSigno(apertura);
            //condicional para determinar el signo del producto escalar

            double producto_escalar = A * B * Math.Cos(apertura) * signo;
            MessageBox.Show($"El producto escalar es: {producto_escalar}");
        }

        private void bttnClearP3_Click(object sender, EventArgs e)
        {
            txtA.Text = "0";
            txtB.Text = "0";
            txtAnguloA.Text = "0";
            txtAnguloB.Text = "0";
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}
