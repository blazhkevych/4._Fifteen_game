using System.Drawing;

namespace task
{
    /// <summary>
    /// Ќаписать игру Ђѕ€тнашкиї, учитыва€ следующие требовани€: 
    /// Х предусмотреть автоматическую перестановку Ђп€тнашекї в начале 
    /// новой игры; 
    /// Х выводить врем€, за которое пользователь окончил игру (собрал 
    /// Ђп€тнашкиї); 
    /// Х предусмотреть индикатор процесса, который будет отображать 
    /// процесс собирани€ Ђп€тнашекї, т.е. отображать, какое количество 
    /// кнопок в процентном отношении находитс€ на своих местах;
    /// Х предусмотреть возможность начать новую игру.
    /// </summary>


    // Form constructor.
    public partial class Form1 : Form
    {
        // Link to the class that implements the game logic.
        private readonly Game _game;
        public Form1()
        {
            InitializeComponent();

            // Turn off the playing field before starting the game.
            // Will be enabled only after clicking the "Start game" button.
            gameField_button1.Enabled = false;
            gameField_button2.Enabled = false;
            gameField_button3.Enabled = false;
            gameField_button4.Enabled = false;
            gameField_button5.Enabled = false;
            gameField_button6.Enabled = false;
            gameField_button7.Enabled = false;
            gameField_button8.Enabled = false;
            gameField_button9.Enabled = false;
            gameField_button10.Enabled = false;
            gameField_button11.Enabled = false;
            gameField_button12.Enabled = false;
            gameField_button13.Enabled = false;
            gameField_button14.Enabled = false;
            gameField_button15.Enabled = false;
            gameField_button16.Enabled = false;

            _game = new Game();
        }

        // Menu item "New game".
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Turn on the playing field.
            gameField_button1.Enabled = true;
            gameField_button2.Enabled = true;
            gameField_button3.Enabled = true;
            gameField_button4.Enabled = true;
            gameField_button5.Enabled = true;
            gameField_button6.Enabled = true;
            gameField_button7.Enabled = true;
            gameField_button8.Enabled = true;
            gameField_button9.Enabled = true;
            gameField_button10.Enabled = true;
            gameField_button11.Enabled = true;
            gameField_button12.Enabled = true;
            gameField_button13.Enabled = true;
            gameField_button14.Enabled = true;
            gameField_button15.Enabled = true;
            gameField_button16.Enabled = true;

            // Displaying the playing field on the buttons.
            _game.SetCurrentArrIntoButtonsText(Controls);
            // Shuffle array.
            _game.ShuffleArray();

            // пересмотреть сортировку и писать дальше.

        }

        // Menu item "Exit".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Timer tick. 
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Output in the title of the time spent on the passage of the game.

        }

        // Click on the playing field.
        private void gameField_button1_Click(object sender, EventArgs e)
        {

        }
    }

    // The class that implements the logic of the game.
    internal class Game
    {
        // Array for storing button values.
        int[,] _arr =
        {
            {1, 2, 3, 4},
            { 5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 0}
        };

        // Shuffle array.
        public void ShuffleArray()
        {
            Random r = new Random();

            int row = 0, col = 0;
            int n = 3;
            while (n > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        row = r.Next(0, 4);
                        col = r.Next(0, 4);
                        int temp = _arr[i, j];
                        _arr[i, j] = _arr[row, col];
                        _arr[row, col] = temp;
                    }
                }
                n--;
            }
        }

        // Displaying the playing field on the buttons.
        public void SetCurrentArrIntoButtonsText(Control.ControlCollection controlCollection)
        {
            int k = 1;
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    foreach (Control control in controlCollection)
                    {
                        if (control is Button && ((Button)control).Name == "gameField_button" + k)
                        {
                            ((Button)control).Text = _arr[i, j].ToString();
                            k++;
                        }
                    }
                }
            }
        }

        // Returns the coordinates of the empty square.
        public Point GetEmptySquareCoordinates()
        {
            // Find the coordinates of the empty button.
            Point p = new Point();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_arr[i, j] == 0)
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
            }

            return p;
        }





    }
}