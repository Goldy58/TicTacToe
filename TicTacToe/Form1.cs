namespace TicTacToe
{
    public partial class frm_TTT : Form
    {
        bool player_turn = true;
        int turn_count = 0;

        public frm_TTT()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe Game\n\nDeveloped by: \nGoldy58", "Tic-Tac-Toe About");
        }

        private void bt_ttt_click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (player_turn)
            {
                bt.Text = "X";
            }
            else
            {
                bt.Text = "O";
            }

            player_turn = !player_turn;
            bt.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            // Horizontal Checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            // Vertical Checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            // Diagonal Checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            if (there_is_a_winner)
            {
                disableButtons();
                string winner = "";
                if (player_turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }
                MessageBox.Show(winner + " Wins!", "Yay!");
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("Draw!", "Bummer!");
                }
            }
        }

        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button bt = (Button)c;
                    bt.Enabled = false;
                }
                catch { }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button bt = (Button)c;
                    bt.Enabled = true;
                    bt.Text = "";
                }
                catch { }
            }
            player_turn = true;
            turn_count = 0;
        }
    }
}
