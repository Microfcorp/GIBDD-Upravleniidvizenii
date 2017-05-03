using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string name = "Разовая ГИБДД";
        string date = DateTime.Today.ToString("d");
        int sredstv = 0;
        string straf;
        string client;
        Form2 form;
        string lab;
        string nodmcu = "192.168.1.34";

        const string message =
        "Вы привысили лимит штрафов. Отчистить базу данных?";
        const string caption = "Превышен лимит";
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            form = new Form2();
            printDialog1.Document = printDocument1;           
        }

        private void проверкаШтрафофToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
            panel8.Visible = !panel8.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(maskedTextBox1.Text != "")
            {
                if (comboBox1.Text != "") {

                    if (comboBox1.Text == "Превышение скорости") { straf = "1"; }
                    if (comboBox1.Text == "Наезд на стоп линию") { straf = "2"; }
                    if (comboBox1.Text == "ДТП") { straf = "3"; }
                    if (comboBox1.Text == "Неуплата штрафа") { straf = "4"; }
                    if (comboBox1.Text == "Проезд на красные свет") { straf = "5"; }
                    if (comboBox1.Text == "Переезд сплошной") { straf = "6"; }
                    if (comboBox1.Text == "Переезд двойной сплошной") { straf = "7"; }
                    if (comboBox1.Text == "Наезд на пешехода") { straf = "8"; }

                    if (label6.Text == "") { label6.Text = maskedTextBox1.Text; label17.Text = maskedTextBox1.Text; client = "0"; }
                    else if (label7.Text == "") { label7.Text = maskedTextBox1.Text; label18.Text = maskedTextBox1.Text; client = "1"; }
                    else if (label8.Text == "") { label8.Text = maskedTextBox1.Text; label20.Text = maskedTextBox1.Text; client = "2"; }
                    else if (label9.Text == "") { label9.Text = maskedTextBox1.Text; label34.Text = maskedTextBox1.Text; client = "3"; }
                    else if (label10.Text == "") { label10.Text = maskedTextBox1.Text; label19.Text = maskedTextBox1.Text; client = "4"; }
                    else if (label11.Text == "") { label11.Text = maskedTextBox1.Text; label25.Text = maskedTextBox1.Text; client = "5"; }
                    else if (label12.Text == "") { label12.Text = maskedTextBox1.Text; label27.Text = maskedTextBox1.Text; client = "6"; }
                    else if (label13.Text == "") { label13.Text = maskedTextBox1.Text; label32.Text = maskedTextBox1.Text; client = "7"; }
                    else
                    {
                        var result = MessageBox.Show(message, caption,
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            label6.Text = ""; label7.Text = ""; label8.Text = ""; label9.Text = "";
                            label10.Text = ""; label11.Text = ""; label12.Text = ""; label13.Text = "";
                        }
                    }

                    switch (client)
                    {
                        case "0":
                            switch (straf)
                            {
                                case "1":
                                    label28.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label28.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label28.Text = "ДТП";
                                    break;
                                case "4":
                                    label28.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label28.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label28.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label28.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label28.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "1":
                            switch (straf)
                            {
                                case "1":
                                    label23.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label23.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label23.Text = "ДТП";
                                    break;
                                case "4":
                                    label23.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label23.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label23.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label23.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label23.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "2":
                            switch (straf)
                            {
                                case "1":
                                    label24.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label24.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label24.Text = "ДТП";
                                    break;
                                case "4":
                                    label24.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label24.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label24.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label24.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label24.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "3":
                            switch (straf)
                            {
                                case "1":
                                    label29.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label29.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label29.Text = "ДТП";
                                    break;
                                case "4":
                                    label29.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label29.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label29.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label29.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label29.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "4":
                            switch (straf)
                            {
                                case "1":
                                    label21.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label21.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label21.Text = "ДТП";
                                    break;
                                case "4":
                                    label21.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label21.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label21.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label21.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label21.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "5":
                            switch (straf)
                            {
                                case "1":
                                    label26.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label26.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label26.Text = "ДТП";
                                    break;
                                case "4":
                                    label26.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label26.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label26.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label26.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label26.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "6":
                            switch (straf)
                            {
                                case "1":
                                    label22.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label22.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label22.Text = "ДТП";
                                    break;
                                case "4":
                                    label22.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label22.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label22.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label22.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label22.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;
                        case "7":
                            switch (straf)
                            {
                                case "1":
                                    label30.Text = "Превышение скорости";
                                    break;
                                case "2":
                                    label30.Text = "Наезд на стоп линию";
                                    break;
                                case "3":
                                    label30.Text = "ДТП";
                                    break;
                                case "4":
                                    label30.Text = "Неуплата штрафа";
                                    break;
                                case "5":
                                    label30.Text = "Проезд на красные свет";
                                    break;
                                case "6":
                                    label30.Text = "Переезд сплошной";
                                    break;
                                case "7":
                                    label30.Text = "Переезд двойной сплошной";
                                    break;
                                case "8":
                                    label30.Text = "Наезд на пешехода";
                                    break;
                            }
                            break;

                    }

                }
            }

            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label14.Text = name;
            label15.Text = date;
            label16.Text = sredstv.ToString();
            MessageBox.Show("Успешное подключение к " + name, "Подключён к БД",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Question);
        }

        private void отчиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label6.Text = ""; label7.Text = ""; label8.Text = ""; label9.Text = "";
            label10.Text = ""; label11.Text = ""; label12.Text = ""; label13.Text = "";
            label17.Text = ""; label18.Text = ""; label20.Text = ""; label34.Text = "";
            label28.Text = ""; label23.Text = ""; label24.Text = ""; label29.Text = "";
            label19.Text = ""; label25.Text = ""; label27.Text = ""; label32.Text = "";
            label21.Text = ""; label26.Text = ""; label22.Text = ""; label30.Text = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label21_Click(object sender, EventArgs e)
        {
            
        }
       

        private void label31_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void управлениеДвижениемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                form.funct(toolStripTextBox1.Text);
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                nodmcu = toolStripTextBox2.Text;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        public void myfunc()
        {
            label16.Text = sredstv.ToString();
        }

        private void смотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lab = toolStripTextBox3.Text;
            sredstv ++;
            myfunc();
          
        }

        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(new Uri("http://"+nodmcu+"/ondviz"));
            // serialPort1.Open();
            //serialPort1.Write("0");
            //serialPort1.Close();
        }

        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(new Uri("http://" + nodmcu + "/offdviz"));
            //serialPort1.Open();
            //serialPort1.Write("1");
            //serialPort1.Close();
        }

        private void полнаяПанельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Visible = !form.Visible;
            form.funct(nodmcu);
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = toolStripTextBox4.Text;
        }

        private void считатьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
              //serialPort1.Open();             
              //label31.Text = serialPort1.ReadLine(); ;
              //serialPort1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(new Uri("http://" + nodmcu + "/onspec"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(new Uri("http://" + nodmcu + "/offspec"));
        }

        private void запуститьДатчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser5.Navigate(new Uri("http://" + nodmcu + "/dat1"));
            webBrowser3.Navigate(new Uri("http://" + nodmcu + "/dat2"));
            webBrowser4.Navigate(new Uri("http://" + nodmcu + "/dat3"));
        }
    }
}
