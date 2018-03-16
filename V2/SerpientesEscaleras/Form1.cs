using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerpientesEscaleras.Graphic;

namespace SerpientesEscaleras
{
    public partial class Form1 : Form
    {

        GDice dado;

        public Form1()
        {
            InitializeComponent();
            Inicializar();
            dado = new GDice(this);
        }

        delegate void ActualizarTexto(string nombre);

        public void updateDice(string text)
        {
            if(this.InvokeRequired)
            {
                ActualizarTexto aT = new ActualizarTexto(updateDice);
                this.Invoke(aT, text);
            }
            else
            {
                dice.Text = text;
            }
        }

        private void Inicializar()
        {
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                button2.Text = "2";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                button2.Text = "1";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void Button1_DragEnter(object sender, DragEventArgs e)
        {

            button1.BackColor = Color.Red;
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gray;
        }

        private void Button2_DragEnter(object sender, DragEventArgs e)
        {
            button2.BackColor = Color.Gray;
        }

        private void Button3_DragDrop(object sender, DragEventArgs e)
        {
            button3.BackColor = Color.Gray;
        }

        private void Panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            dado.RollDice();
        }
    }
}
