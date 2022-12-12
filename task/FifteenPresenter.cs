namespace task;

public class FifteenPresenter
{
    private readonly IModel _model;
    private readonly IFifteenView _view;

    // The principle of inversion of dependencies.
    // The constructor takes the interface of the model and the view.
    public FifteenPresenter(IModel model, IFifteenView view)
    {
        _model = model;
        _view = view;
        UserMove = new Point(-1, -1);
        // Presenter subscribes to notifications about View events.
        // Event of pressing the "New Game" button.
        _view.NewGameButtonClickEvent += ShuffleArray;
        _view.NewGameButtonClickEvent += SetCurrentArrIntoButtonsText;
        _view.NewGameButtonClickEvent += CountingButtonsInTheirPlacesasPercentage;
        _view.NewGameButtonClickEvent += SetGameStartTime;

        // Event of pressing a button on the game field.
        _view.UserMoveButtonPressedClickEvent += GetUserMove; // get button
        _view.GameFieldButtonClickEvent += OneStepInTheGame; // get form
    }

    // User move coordinates.
    private Point UserMove { get; set; }

    // Converts the pressed button on the playfield to the corresponding array coordinates.
    private Point ConvertButtonToCoordinates(Button button)
    {
        Point coordinates = new();
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

    private Point GetEmptySquareCoordinates()
    {
        // Find the coordinates of the empty button.
        Point p = new();

        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
            if (_model[i, j] == 0)
            {
                p.X = i;
                p.Y = j;
            }

        return p;
    }

    // Get user move coordinates.
    private void GetUserMove(object sender, EventArgs e)
    {
        var button = (Button)sender;
        UserMove = ConvertButtonToCoordinates(button);
    }

    // One step in the game.
    private void OneStepInTheGame(object sender, EventArgs e)
    {
        // Get empty square coordinates.
        var zeroPosition = GetEmptySquareCoordinates();

        // Check the top square.
        if (UserMove.X - 1 >= 0 && _model[UserMove.X - 1, UserMove.Y] == 0)
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.X, zeroPosition.Y], _model[UserMove.X, UserMove.Y]) =
                (_model[UserMove.X, UserMove.Y],
                    _model[zeroPosition.X,
                        zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            SetCurrentArrIntoButtonsText(sender, e);
        }
        // Check the bottom square.
        else if (UserMove.X + 1 <= 3 && _model[UserMove.X + 1, UserMove.Y] == 0)
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.X, zeroPosition.Y], _model[UserMove.X, UserMove.Y]) =
                (_model[UserMove.X, UserMove.Y],
                    _model[zeroPosition.X,
                        zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            SetCurrentArrIntoButtonsText(sender, e);
        }
        // Check left square.
        else if (UserMove.Y - 1 >= 0 && _model[UserMove.X, UserMove.Y - 1] == 0)
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.X, zeroPosition.Y], _model[UserMove.X, UserMove.Y]) =
                (_model[UserMove.X, UserMove.Y],
                    _model[zeroPosition.X,
                        zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            SetCurrentArrIntoButtonsText(sender, e);
        }
        else if (UserMove.Y + 1 <= 3 && _model[UserMove.X, UserMove.Y + 1] == 0)
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.X, zeroPosition.Y], _model[UserMove.X, UserMove.Y]) =
                (_model[UserMove.X, UserMove.Y],
                    _model[zeroPosition.X,
                        zeroPosition.Y]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            SetCurrentArrIntoButtonsText(sender, e);
        }

        CountingButtonsInTheirPlacesasPercentage(sender, e);
    }

    // Game start time.
    private void SetGameStartTime(object sender, EventArgs e)
    {
        _model.GameStartTime = DateTime.Now;
    }

    // Shuffle array.
    private void ShuffleArray(object sender, EventArgs e)
    {
        Random r = new();

        var n = 3;
        while (n > 0)
        {
            for (var i = 0; i < 4; i++)
            for (var j = 0; j < 4; j++)
            {
                var row = r.Next(0, 4);
                var col = r.Next(0, 4);
                (_model[i, j], _model[row, col]) = (_model[row, col], _model[i, j]);
            }

            n--;
        }
    }

    // Displaying the playing field on the buttons.
    private void SetCurrentArrIntoButtonsText(object sender, EventArgs e)
    {
        var k = 1;
        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
            foreach (Control control in ((Form)sender).Controls)
                if (control is Button button && button.Name == "gameField_button" + k)
                {
                    button.Text = _model[i, j] == 0 ? "" : _model[i, j].ToString();
                    k++;
                }
    }

    // Counting the number of buttons in their places as a percentage.
    private void CountingButtonsInTheirPlacesasPercentage(object sender, EventArgs e)
    {
        var count = 0;
        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
        {
            if (i == 0 && j == 0 && _model[0, 0] == 1) count++;

            if (i == 0 && j == 1 && _model[0, 1] == 2) count++;

            if (i == 0 && j == 2 && _model[0, 2] == 3) count++;

            if (i == 0 && j == 3 && _model[0, 3] == 4) count++;

            if (i == 1 && j == 0 && _model[1, 0] == 5) count++;

            if (i == 1 && j == 1 && _model[1, 1] == 6) count++;

            if (i == 1 && j == 2 && _model[1, 2] == 7) count++;

            if (i == 1 && j == 3 && _model[1, 3] == 8) count++;

            if (i == 2 && j == 0 && _model[2, 0] == 9) count++;

            if (i == 2 && j == 1 && _model[2, 1] == 10) count++;

            if (i == 2 && j == 2 && _model[2, 2] == 11) count++;

            if (i == 2 && j == 3 && _model[2, 3] == 12) count++;

            if (i == 3 && j == 0 && _model[3, 0] == 13) count++;

            if (i == 3 && j == 1 && _model[3, 1] == 14) count++;

            if (i == 3 && j == 2 && _model[3, 2] == 15) count++;

            if (i == 3 && j == 3 && _model[3, 3] == 0) count++;
        }

        foreach (Control control in ((Form)sender).Controls)
            if (control is ProgressBar bar && bar.Name == "progressBar1")
                bar.Value = (int)(count * 6.5);

        if (count == 16)
        {
            _model.GameStopTime = DateTime.Now;
            var timeSpan = _model.GameStopTime - _model.GameStartTime;
            _view.WinMessage(timeSpan);
        }
    }
}