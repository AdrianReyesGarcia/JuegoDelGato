using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego_del_gato
{

    public partial class Form1 : Form
    {
        string JugadorX;
        string JugadorO;
        bool cambio = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffbtn(false);
        }

        private void OnOffbtn(bool OnOff)
        {
            b1.Enabled = OnOff;
            b2.Enabled = OnOff;
            b3.Enabled = OnOff;
            b4.Enabled = OnOff;
            b5.Enabled = OnOff;
            b6.Enabled = OnOff;
            b7.Enabled = OnOff;
            b8.Enabled = OnOff;
            b9.Enabled = OnOff;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Iiniciar();
        }

        private void Iiniciar()
        {
            if (txtJug1.Text == "" && txtJug2.Text == "")
            {

                MessageBox.Show("Deben escribir su nombre en los recuadros.", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtJug1.Text == "")

                {
                    MessageBox.Show("El Jugador 1 necesita un nombre", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (txtJug2.Text == "")

                {
                    MessageBox.Show("El Jugador 2 necesita un nombre", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (txtJug1.Text != "" && txtJug2.Text != "")
            {
                if (rbtnJ1X.Checked && rbtnJ2O.Checked)
                {
                    JugadorX = txtJug1.Text;
                    JugadorO = txtJug2.Text;
                    rbtnJ1O.Enabled = false;
                    rbtnJ2X.Enabled = false;
                    iniciarjuego();
                }
                if (rbtnJ1O.Checked && rbtnJ2X.Checked)
                {
                    JugadorX = txtJug2.Text;
                    JugadorO = txtJug1.Text;
                    rbtnJ1X.Enabled = false;
                    rbtnJ2O.Enabled = false;
                    iniciarjuego();

                }
                if (rbtnJ1X.Checked && rbtnJ2X.Checked)
                {
                    MessageBox.Show("No puedes seleccionar ese", "Intenta de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnJ1O.Checked && rbtnJ2O.Checked)
                {
                    MessageBox.Show("No puedes seleccionar ese", "Intenta de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnJ1X.Checked == false && rbtnJ1O.Checked == false || rbtnJ2X.Checked == false && rbtnJ2O.Checked == false)
                {
                    MessageBox.Show("Cada jugador debe seleccionar una letra", "Intenta de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void iniciarjuego()
        {

          
            lblJug1.Text = txtJug1.Text;
            lblJug2.Text = txtJug2.Text;
            groupBox1.Text = "MARCADOR";
            txtJug1.Visible = false;
            txtJug2.Visible = false;
            btnLimpiar.Visible = true;
            btnReiniciar.Visible = true;
            btnIniciar.Visible = false;

                MessageBox.Show("Comienza el Juego " + JugadorX, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            OnOffbtn(true);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "x";
            }
            else
            {
                b.Text = "o";
            }
            cambio = !cambio;
            b.Enabled = false;
            partida();
        }

        private void partida()
        {
            if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            {
                validacion(b1);
            }
            else if ((b4.Text == b5.Text) & (b5.Text == b6.Text) && (!b4.Enabled))
            {
                validacion(b4);
            }
            else if ((b7.Text == b8.Text) & (b8.Text == b9.Text) && (!b7.Enabled))
            {
                validacion(b7);
            }


            if ((b1.Text == b4.Text) & (b4.Text == b7.Text) && (!b1.Enabled))
            {
                validacion(b1);
            }
            else if ((b2.Text == b5.Text) & (b5.Text == b8.Text) && (!b2.Enabled))
            {
                validacion(b2);
            }
            else if ((b3.Text == b6.Text) & (b6.Text == b9.Text) && (!b3.Enabled))
            {
                validacion(b3);
            }


            if ((b1.Text == b5.Text) & (b5.Text == b9.Text) && (!b1.Enabled))
            {
                validacion(b1);
            }
            else if ((b3.Text == b5.Text) & (b5.Text == b7.Text) && (!b3.Enabled))
            {
                validacion(b3);
            }

            empate++;
            if (empate == 9)
            {
                MessageBox.Show("Hay un empate ", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnOffbtn(true);
                limpiar();
                empate = 0;
               
            }
        }

        private void limpiar()
        {
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            OnOffbtn(true);
            empate = 0;
        }
        private void validacion(Button b)
        {
            empate = -1;
            if (b.Text == "x")

            {
                MessageBox.Show("Gana " + JugadorX, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "o")

            {
                MessageBox.Show("Gana " + JugadorO, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;

            }
            if (rbtnJ1X.Checked && rbtnJ2O.Checked)
            {
                lblJ1Puntos.Text = ganadasX.ToString();
                lblJ2Puntos.Text = ganadasO.ToString();
            }
            if (rbtnJ1O.Checked && rbtnJ2X.Checked)
            {
                lblJ2Puntos.Text = ganadasX.ToString();
                lblJ1Puntos.Text = ganadasO.ToString();
            }   
            limpiar();
            OnOffbtn(true);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            limpiar();
            OnOffbtn(false);
            btnLimpiar.Visible = false;
            btnReiniciar.Visible = false;

            btnIniciar.Visible = true;
            JugadorX = "";
            JugadorO = "";
            ganadasO = 0;
            ganadasX = 0;
            cambio = true; 

            lblJ1Puntos.Text = 0.ToString();
            lblJ2Puntos.Text = 0.ToString();
            lblJug1.Text = "";
            lblJug2.Text = "";

            txtJug1.Text = "";
            txtJug2.Text = "";
            txtJug1.Visible = true;
            txtJug2.Visible = true;

            rbtnJ1X.Enabled = true;
            rbtnJ2X.Enabled = true;
            rbtnJ1O.Enabled = true;
            rbtnJ2O.Enabled = true;

            rbtnJ1X.Checked = false;
            rbtnJ1O.Checked = false;
            rbtnJ2X.Checked = false;
            rbtnJ2O.Checked = false;

            groupBox1.Text = "INTRODUZCAN SUS NOMBRES:";
        }
    }
}

