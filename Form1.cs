using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Yellow = Color.FromArgb(255, 255, 255, 0);

            Pen Pen = new Pen(Yellow);
            Pen.Width = 15;

            // Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawLine(Pen, 200, 100, 200, 700);
            e.Graphics.DrawLine(Pen, 400, 100, 400, 700);
            e.Graphics.DrawLine(Pen, 10, 300, 600, 300);
            e.Graphics.DrawLine(Pen, 10, 480, 600, 480);
        }
        enum enTurn
        {
            Player1,
            Player2
        }
        enTurn Turn = enTurn.Player1;
        byte Attempts = 0;

        void ResetButton(Button button)
        {
            button.Image = Resources.question_mark_96;
            button.Tag = "?";
            button.BackColor = Color.Transparent;
        }
        void ResetForm()
        {
            labPlayer.Text = "Player1";
            Turn = enTurn.Player1;
            labWhoWinner.Text = "In Progress";
            Attempts = 0;


            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
           
        }

        void ShowGameOver()
        {
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
        bool IsDraw()
        {
            return (Attempts == 9);
        }

       

        bool CheckButtons(Button button1,Button button2,Button button3)
        {
            if (button1.Tag.ToString() != "?" && button1.Tag.ToString() == button2.Tag.ToString() &&
                button2.Tag.ToString() == button3.Tag.ToString())
            {
                if(button1.Tag.ToString()=="X")
                {
                    labWhoWinner.Text = "  Player1";
                }
                else
                {
                    labWhoWinner.Text = "  Player2";
                }
            
                labPlayer.Text = "Game Over";
                button1.BackColor = Color.Green;
                button2.BackColor = Color.Green;
                button3.BackColor = Color.Green;
                ShowGameOver();
                return true;

            }

            if (IsDraw())
            {
                labWhoWinner.Text = "   Draw";
                labPlayer.Text = "Game Over";
                ShowGameOver();
                return true;
            }
            return false;
        }

        void CheckResult()
        {
            if (CheckButtons(button1, button2, button3))
                return;

            if (CheckButtons(button4, button5, button6))
                return;

            if (CheckButtons(button7, button8, button9))
                return;

            if (CheckButtons(button1, button4, button7))
                return;

            if (CheckButtons(button2, button5, button8))
                return;

            if (CheckButtons(button3, button6, button9))
                return;

            if (CheckButtons(button1, button5, button9))
                return;

            if (CheckButtons(button3, button5, button7))
                return;

        }

        void ChangeButton(Button button)
        {
            if (labPlayer.Text == "Game Over")
                return;

            if (button.Tag.ToString()=="?")
            {
                if(Turn==enTurn.Player1)
                {
                    button.Image = Resources.X;
                    button.Tag = "X";
                  
                    Turn = enTurn.Player2;
                    labPlayer.Text = "Player2";
                }
                else
                {
                    button.Image = Resources.O;
                    button.Tag = "O";
                    Turn = enTurn.Player1;
                    labPlayer.Text = "Player1";
                }
                Attempts++;
                CheckResult();
                return;
            }
           
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetForm();
        } 
       
    

        private void btnResetGame_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void button_Click(object sender, EventArgs e)
        {

            ChangeButton((Button)sender);
        }

    }
}
