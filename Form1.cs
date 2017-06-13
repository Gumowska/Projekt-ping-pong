using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_ping_pong

    {
    public partial class Form1 : Form
    {


        public int speed_left = 4;                                                                     //Speed of the ball
        public int speed_top = 4;
        public int points = 0;                                                                          //Scored points



        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();                                                                            //hide the cursor

            this.FormBorderStyle = FormBorderStyle.None;                                              // remove any border
            this.TopMost = true;                                                                      //bring the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;                                                //make it fullscreen

            racket.Top = playground.Bottom - (playground.Bottom / 10);                                    //Set the position of racket

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);                      //Position to center
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;                                                                //Hide



        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2);                                        //set the center of the racket to the position of the cursor

            ball.Left += speed_left;
            ball.Top += speed_top;                      //move the ball

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)    //racket collision
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;                                                              //Change direction
                points += 1;
                points_lbl.Text = points.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));     //Get a random RGB Color set is as playground backcolor 

            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }

            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;                                                       //ball is Out-> Stop the game
                gameover_lbl.Visible = true;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }                                      //Press Escape to Quit
            if (e.KeyCode == Keys.F1)                                                             //Relove Game
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;

                playground.BackColor = Color.White;


            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


