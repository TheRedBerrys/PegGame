using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PegGame
{
    /// <summary>
    /// The main form in which the game runs.
    /// </summary>
    public partial class PegGame : Form
    {
        /// <summary>
        /// The image for the pegs in the "ON" position.
        /// </summary>
        Image onImage;
        /// <summary>
        /// The image for the pegs in the "OFF" position.
        /// </summary>
        Image offImage;
        /// <summary>
        /// The object that handles the logic for the game.
        /// </summary>
        PegGameLogic logic;
        /// <summary>
        /// Handles whether to show the messages at the start of a new game.
        /// </summary>
        bool ShowGameMessage;

        /// <summary>
        /// Creates the form and sets the logic for the game.
        /// </summary>
        public PegGame()
        {
            InitializeComponent();

            onImage = Image.FromFile("../../ON.PNG");
            offImage = Image.FromFile("../../OFF.PNG");

            logic = new PegGameLogic();

            ResetGraphics();

            ShowGameMessage = true;
        }

        /// <summary>
        /// Resets all of the graphics in the form.
        /// </summary>
        private void ResetGraphics()
        {
            ResetTarget();
            ResetCurrent();
            ResetLabels();
        }

        /// <summary>
        /// Resets the graphics for the target pegs.
        /// </summary>
        private void ResetTarget()
        {
            ResetPictureBox(picTarget1, logic.Target[1]);
            ResetPictureBox(picTarget2, logic.Target[2]);
            ResetPictureBox(picTarget3, logic.Target[3]);
            ResetPictureBox(picTarget4, logic.Target[4]);
            ResetPictureBox(picTarget5, logic.Target[5]);
            ResetPictureBox(picTarget6, logic.Target[6]);
            ResetPictureBox(picTarget7, logic.Target[7]);
            ResetPictureBox(picTarget8, logic.Target[8]);
        }

        /// <summary>
        /// Resets the graphics for the current pegs.
        /// </summary>
        private void ResetCurrent()
        {
            ResetPictureBox(picCurrent1, logic.Current[1]);
            ResetPictureBox(picCurrent2, logic.Current[2]);
            ResetPictureBox(picCurrent3, logic.Current[3]);
            ResetPictureBox(picCurrent4, logic.Current[4]);
            ResetPictureBox(picCurrent5, logic.Current[5]);
            ResetPictureBox(picCurrent6, logic.Current[6]);
            ResetPictureBox(picCurrent7, logic.Current[7]);
            ResetPictureBox(picCurrent8, logic.Current[8]);
        }

        /// <summary>
        /// Resets the text of the labelMoves and labelHint labels.
        /// </summary>
        private void ResetLabels()
        {
            labelMoves.Text = string.Format("Moves: {0}", logic.Moves);
            labelHint.Text = logic.Hint;
        }

        /// <summary>
        /// Resets a peg PictureBox.
        /// </summary>
        /// <param name="target">The PictureBox control for the peg to change.</param>
        /// <param name="value">True if the peg is "ON"; false if the peg is "OFF".</param>
        private void ResetPictureBox(PictureBox target, bool value)
        {
            if (value)
                target.Image = onImage;
            else
                target.Image = offImage;
        }

        /// <summary>
        /// Attempts to switch a peg between "ON" and "OFF", according to the rules of the game.
        /// </summary>
        /// <param name="index"></param>
        private void MakeMove(int index)
        {
            //The logic for whether a switch can be changed is handled in the PegGameLogic class.
            logic.Switch(index);

            ResetGraphics();

            //If this move solves the board, set up a new game.
            if (logic.IsSolved())
            {
                logic.ResetTargetAndCurrent();

                ResetGraphics();

                if (ShowGameMessage)
                {
                    MessageBox.Show("You Won!", "Congratulations!");
                    MessageBox.Show("Each new game has a randomly selected rule set. The rules might be completely different now!", "The Rules");
                    ShowGameMessage = false;
                }
            }
        }

        /// <summary>
        /// Attempts to make a move, based on the user clicking a peg PictureBox.
        /// </summary>
        /// <param name="sender">The PictureBox the user clicked on.</param>
        /// <param name="e">The event arguments of the PictureBox click.</param>
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox control = (PictureBox)sender;
            int id = Convert.ToInt32(control.Name.Substring(control.Name.Length - 1));

            MakeMove(id);
        }

        /// <summary>
        /// Attempts to make a move based on a keyboard button press by the user.
        /// </summary>
        /// <param name="sender">The form control that makes the call.</param>
        /// <param name="e">The event created by the user pressing a keyboard button.</param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int id = Convert.ToInt32(e.KeyChar);

            //If the button pressed is a number key between 1 and 8, make the move.
            if (id >= 49 && id <= 56)
            {
                id -= 48;
                MakeMove(id);
            }
        }

        /// <summary>
        /// Shows message boxes when the game form is first shown.
        /// </summary>
        /// <param name="sender">The form.</param>
        /// <param name="e">The event caused by the form being shown.</param>
        private void PegGame_Shown(object sender, EventArgs e)
        {
            if (ShowGameMessage)
            {
                MessageBox.Show("The goal of the game is to match the \"Current\" pegs to the \"Target\" pegs.", "Welcome to the Peg Game!");
                MessageBox.Show("To switch a peg, click on it or use the keyboard (use the number key for the number shown under the peg).", "The Rules");
                MessageBox.Show("You can only switch your pegs based on the current rules. It's up to you to figure out the rules.", "The Rules");
            }
        }

        /// <summary>
        /// Sets the hint to show or not to show, based on the "Hint?" check box.
        /// </summary>
        /// <param name="sender">The "Hint?" check box.</param>
        /// <param name="e">The event caused by the user clicking on the "Hint?" check box.</param>
        private void checkShowHint_CheckedChanged(object sender, EventArgs e)
        {
            labelHint.Visible = checkShowHint.Checked;
        }
    }
}
