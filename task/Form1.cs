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

            // Shuffle array.
            _game.ShuffleArray();

            // Displaying the playing field on the buttons.
            _game.SetCurrentArrIntoButtonsText(Controls);

            // Game start time.
            _game.GameStartTime = DateTime.Now;

        }

        // Menu item "Exit".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Do you really want to leave ?.
            _game.ReallyWantToLeave();
        }

        // Timer tick. 
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Maybe timer not needed.

        }

        // Get ControlCollection controlCollection.
        //public TYPE Type { get; set; }

        // Click on the playing field.
        private void gameField_buttons_Click(object sender, EventArgs e)
        {
            // One step in the game.
            _game.OneStepInTheGame((Button)sender, Controls);
        }
    }

    // The class that implements the logic of the game.
    internal class Game
    {
        // The number of buttons in their places as a percentage.
        public string ButtonsInTheirPlaces { get; set; }

        // Counting the number of buttons in their places as a percentage.
        void CountingButtonsInTheirPlaces()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (
                        _arr[0, 0] == 1 || _arr[0, 1] == 2 || _arr[0, 2] == 3 || _arr[0, 3] == 4 ||
                        _arr[1, 0] == 5 || _arr[1, 1] == 6 || _arr[1, 2] == 7 || _arr[1, 3] == 8 ||
                        _arr[2, 0] == 9 || _arr[2, 1] == 10 || _arr[2, 2] == 11 || _arr[2, 3] == 12 ||
                        _arr[3, 0] == 13 || _arr[3, 1] == 14 || _arr[3, 2] == 15 || _arr[3, 3] == 0
                    )
                        count++;
                    //    0  1  2  3
                    // 0  1  2  3  4
                    // 1  5  6  7  8
                    // 2  9  10 11 12
                    // 3  13 14 15 0
                }
            }

            ButtonsInTheirPlaces = (count * 6.5) + " % in their places.";
        }

        // Get ControlCollection controlCollection;
        //public Control.ControlCollection ControlCollection { get; set; }

        // Time spent playing.
        public DateTime GameStartTime { get; set; }

        // Button name with an empty square.
        public string EmptySquareNameButton { get; set; }

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
                            if (_arr[i, j] == 0)
                                ((Button)control).Text = "";
                            else
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

        // Do you really want to leave ?.
        public void ReallyWantToLeave()
        {
            var result = MessageBox.Show("Do you really want to leave ?", "Game \"Fifteen\".", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }

        // Check if there is an empty square nearby.
        //Point IsAnEmptySquareNearby(Point userMove)
        //{

        //}

        // One step in the game.
        public void OneStepInTheGame(Button button, Control.ControlCollection controlCollection)
        {
            // Get empty square coordinates.
            Point zeroPosition = GetEmptySquareCoordinates();
            // Get user move coordinates.
            Point userMove = ConvertButtonToCoordinates(button);

            // Let the battle begin!

            // if my move is - 1,1
            // square to check is:
            //        0,1
            // 1,0  >>1,1<<  1,2 
            //        2,1

            // Check the top square.
            if (userMove.X - 1 >= 0 && _arr[userMove.X - 1, userMove.Y] == 0)
            {
                // If an empty square is found here, change the user's move with an empty square.
                (_arr[zeroPosition.X, zeroPosition.Y], _arr[userMove.X, userMove.Y]) =
                    (_arr[userMove.X, userMove.Y], _arr[zeroPosition.X, zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
                // Displaying the playing field on the buttons.
                SetCurrentArrIntoButtonsText(controlCollection);
            }
            // Check the bottom square.
            else if (userMove.X + 1 <= 3 && _arr[userMove.X + 1, userMove.Y] == 0)
            {
                // If an empty square is found here, change the user's move with an empty square.
                (_arr[zeroPosition.X, zeroPosition.Y], _arr[userMove.X, userMove.Y]) =
                    (_arr[userMove.X, userMove.Y], _arr[zeroPosition.X, zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
                // Displaying the playing field on the buttons.
                SetCurrentArrIntoButtonsText(controlCollection);
            }
            // Check left square.
            else if (userMove.Y - 1 >= 0 && _arr[userMove.X, userMove.Y - 1] == 0)
            {
                // If an empty square is found here, change the user's move with an empty square.
                (_arr[zeroPosition.X, zeroPosition.Y], _arr[userMove.X, userMove.Y]) =
                    (_arr[userMove.X, userMove.Y], _arr[zeroPosition.X, zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
                // Displaying the playing field on the buttons.
                SetCurrentArrIntoButtonsText(controlCollection);
            }
            else if (userMove.Y + 1 <= 3 && _arr[userMove.X, userMove.Y + 1] == 0)
            {
                // If an empty square is found here, change the user's move with an empty square.
                (_arr[zeroPosition.X, zeroPosition.Y], _arr[userMove.X, userMove.Y]) =
                    (_arr[userMove.X, userMove.Y], _arr[zeroPosition.X, zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
                // Displaying the playing field on the buttons.
                SetCurrentArrIntoButtonsText(controlCollection);
            }
            // Just else ...
            else
                return;
        }

        // Converts the pressed button on the playfield to the corresponding array coordinates.
        public Point ConvertButtonToCoordinates(Button button)
        {
            var coordinates = new Point();
            if (button.Name == "gameField_button1")
            {
                coordinates.X = 0;
                coordinates.Y = 0;
            }
            else if (button.Name == "gameField_button2")
            {
                coordinates.X = 0;
                coordinates.Y = 1;
            }
            else if (button.Name == "gameField_button3")
            {
                coordinates.X = 0;
                coordinates.Y = 2;
            }
            else if (button.Name == "gameField_button4")
            {
                coordinates.X = 0;
                coordinates.Y = 3;
            }
            else if (button.Name == "gameField_button5")
            {
                coordinates.X = 1;
                coordinates.Y = 0;
            }
            else if (button.Name == "gameField_button6")
            {
                coordinates.X = 1;
                coordinates.Y = 1;
            }
            else if (button.Name == "gameField_button7")
            {
                coordinates.X = 1;
                coordinates.Y = 2;
            }
            else if (button.Name == "gameField_button8")
            {
                coordinates.X = 1;
                coordinates.Y = 3;
            }
            else if (button.Name == "gameField_button9")
            {
                coordinates.X = 2;
                coordinates.Y = 0;
            }
            else if (button.Name == "gameField_button10")
            {
                coordinates.X = 2;
                coordinates.Y = 1;
            }
            else if (button.Name == "gameField_button11")
            {
                coordinates.X = 2;
                coordinates.Y = 2;
            }
            else if (button.Name == "gameField_button12")
            {
                coordinates.X = 2;
                coordinates.Y = 3;
            }
            else if (button.Name == "gameField_button13")
            {
                coordinates.X = 3;
                coordinates.Y = 0;
            }
            else if (button.Name == "gameField_button14")
            {
                coordinates.X = 3;
                coordinates.Y = 1;
            }
            else if (button.Name == "gameField_button15")
            {
                coordinates.X = 3;
                coordinates.Y = 2;
            }
            else if (button.Name == "gameField_button16")
            {
                coordinates.X = 3;
                coordinates.Y = 3;
            }
            return coordinates;
        }
        //    0  1  2  3
        // 0  1  2  3  4
        // 1  5  6  7  8
        // 2  9  10 11 12
        // 3  13 14 15 0
    }
}