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
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();                                                                            //hide the cursor

            this.FormBorderStyle = FormBorderStyle.None;                                              // remove any border
            this.TopMost = true;                                                                      //bring the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;                                                //make it fullscreen

            racket.Top = playground.Bottom - (playground.Bottom / 10);                                    //Set the position of racket
        }



    }
}
