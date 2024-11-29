using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio4
{
    public partial class Form1 : Form
    {

        public delegate double Operation(int a, int b);
        Hashtable operaciones;
        DateTime time;
        int num1, num2;
        bool flag1, flag2;

        public Form1()
        {
            InitializeComponent();

            Operation op;
            operaciones = new Hashtable();
            operaciones.Add("+", (Operation) (( a,  b) => a + b));
            operaciones.Add("-", (Operation)((a, b) => a - b));
            operaciones.Add("*", (Operation)((a, b) => a * b));
            operaciones.Add("/", (Operation)((a, b) => a / b));

            label1.Text = "+";

            time = DateTime.Now;
            timer1.Start();
        }

        public void HacerOperacion(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(RadioButton)) {
                label1.Text = ((RadioButton)sender).Text;
                operaciones[label1.Text].ToString();
            }
        }

        private void Foco_TextBox(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                if (int.TryParse(((TextBox)sender).Text, out int num))
                {
                    ((TextBox)sender).BackColor = Color.White;
                } else
                {
                    ((TextBox)sender).BackColor = Color.Red;
                }
            }
        }

        private void titulo_timer(object sender, EventArgs e)
        {
            TimeSpan tiempoTitulo = DateTime.Now - time; 
            this.Text = $"{tiempoTitulo.Minutes:D2}:{tiempoTitulo.Seconds:D2}";
        }

        private void calcularOperacion(object sender, EventArgs e)
        {
            flag1 = int.TryParse(textBox1.Text, out int num1);
            flag2 = int.TryParse(textBox2.Text, out int num2);
            if (flag1 && flag2)
            {
                label2.Text = "Resultado: "+((Operation)operaciones[label1.Text])(num1, num2);
            } else
            {
                label2.Text = "No se ha podido realizar la operación";
            }
        }
    }
}
