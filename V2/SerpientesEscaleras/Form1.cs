using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerpientesEscaleras.Graphic;

namespace SerpientesEscaleras
{
    public partial class Form1 : Form
    {

        GDice dado;
        GMaster master;
        GTablero tablero;
        

        public Form1()
        {
            InitializeComponent();
            Inicializar();
            dado = new GDice(this);
        }

        public void onPlay()
        {
            if(listBox1.Items.Count > 1)
            {
                panel6.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                textBox1.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                listBox1.Enabled = false;
                
            }
            else
            {
                ErrorMessageBoxGenerator("No has añadido suficientes jugadores");
            }
            
        }

        public void onWin()
        {
            
            MessageBox.Show(master.Ganador.Nombre + " ha ganado la partida");
            master.Reset();
            button5.Visible = true;
            button4.Visible = false;
            panel6.Visible = false;
            textBox1.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            listBox1.Enabled = true;
        }

        public void onResize()
        {
            master.Resize();
        }

        public void addPlayer(string Nombre)
        {
            foreach(var jugador in listBox1.Items)
            {
                if (jugador.ToString().StartsWith(Nombre.Substring(0, 1)))
                {
                    ErrorMessageBoxGenerator("Ya existe un jugador con esa inicial");
                    return;
                }
                
            }
            Label label = new Label();
            label.Text = Nombre.Substring(0,1);
            label.BackColor = Color.White;
            label.ForeColor = Color.Orange;
            changeFont(label);
            label.Size = new Size(20, 20);
            label.Location = GTablero.calculatePosition(1, panel5);
            panel5.Controls.Add(label);
            //this.Controls.Add(label);
            GToken token = new GToken(label, Nombre);
            master.addPlayer(token);
            listBox1.Items.Add(Nombre);
        }

        public void deletePlayer()
        {
            string nombre = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(listBox1.SelectedItem);
            GToken t = master.DeletePlayer(nombre);
            panel5.Controls.Remove(t.Label);
        }

        private void changeFont(Label label)
        {
            
            label.Font = new Font(pfc.Families[0], label1.Font.Size);
           
        }

        PrivateFontCollection pfc;

        private void InicializarFuente()
        {
            pfc = new PrivateFontCollection();
            //Create your private font collection object.


            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.Scrabbles.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.Scrabbles;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);
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

        delegate void ActualizarPosicionFichas(Point point);

        public void updateTokenCoord(Point point)
        {
            if (this.InvokeRequired)
            {
                ActualizarPosicionFichas aT = new ActualizarPosicionFichas(updateTokenCoord);
                this.Invoke(aT, point);
            }
            else
            {
                master.Current.Label.Location = point;
            }
        }

        private void Inicializar()
        {
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablero = new GTablero(panel5);
            master = new GMaster(tablero, panel5, this);
            InicializarFuente();
            changeFont(label5);
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
            onResize();
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
            onPlay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                ErrorMessageBoxGenerator("Cada jugador debe tener un nombre, ingresa un nombre en el campo");
            }
            else
            {
                addPlayer(textBox1.Text);
            }
            
        }

        private void ErrorMessageBoxGenerator(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            deletePlayer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            master.siguienteTurno();
            string nombre = master.Current.Nombre;
            label4.Text = nombre;
            label5.Text = nombre.Substring(0, 1);
            if(master.Ganador != null)
            {
                onWin();
            }
        }
    }
}
