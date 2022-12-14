namespace task;

public class FifteenPresenter
{
    private readonly IModel _model;
    private readonly IFifteenView _view;

    // User move coordinates.
    private (int, int) _userMove;

    // The principle of inversion of dependencies.
    // The constructor takes the interface of the model and the view.
    public FifteenPresenter(IModel model, IFifteenView view)
    {
        _model = model;
        _view = view;
        _userMove = (-1, -1);
        // Presenter subscribes to notifications about View events.
        // Event of pressing the "New Game" button.
        _view.NewGameButtonClickEvent += ShuffleArray;
        _view.NewGameButtonClickEvent += CountingButtonsInTheirPlacesasPercentage;
        _view.NewGameButtonClickEvent += SetGameStartTime;

        // Event of pressing a button on the game field.
        _view.GameFieldButtonClickEvent += OneStepInTheGame;
    }

    // Converts the pressed buttons name on the playfield to the corresponding array coordinates.
    private void ConvertButtonToCoordinates(string buttonName)
    {
        if (buttonName == "gameField_button1")
            _userMove = (0, 0);
        else if (buttonName == "gameField_button2")
            _userMove = (0, 1);
        else if (buttonName == "gameField_button3")
            _userMove = (0, 2);
        else if (buttonName == "gameField_button4")
            _userMove = (0, 3);
        else if (buttonName == "gameField_button5")
            _userMove = (1, 0);
        else if (buttonName == "gameField_button6")
            _userMove = (1, 1);
        else if (buttonName == "gameField_button7")
            _userMove = (1, 2);
        else if (buttonName == "gameField_button8")
            _userMove = (1, 3);
        else if (buttonName == "gameField_button9")
            _userMove = (2, 0);
        else if (buttonName == "gameField_button10")
            _userMove = (2, 1);
        else if (buttonName == "gameField_button11")
            _userMove = (2, 2);
        else if (buttonName == "gameField_button12")
            _userMove = (2, 3);
        else if (buttonName == "gameField_button13")
            _userMove = (3, 0);
        else if (buttonName == "gameField_button14")
            _userMove = (3, 1);
        else if (buttonName == "gameField_button15")
            _userMove = (3, 2);
        else if (buttonName == "gameField_button16") _userMove = (3, 3);
    }

    // Get the coordinates of the empty cell.
    private (int, int) GetEmptySquareCoordinates()
    {
        var p = (-1, -1);
        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
            if (_model[i, j] == "")
            {
                p.Item1 = i;
                p.Item2 = j;
            }

        return p;
    }

    // Update the game field from _model to _view.
    private void UpdateGameField()
    {
        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
            if (_model[i, j] == "")
                _view[i, j] = "";
            else
                _view[i, j] = _model[i, j];
    }

    // One step in the game.
    private void OneStepInTheGame(object sender, EventArgs e)
    {
        // Get user move coordinates.
        ConvertButtonToCoordinates(_view.UserMoveButtonName);
        // Get empty square coordinates.
        var zeroPosition = GetEmptySquareCoordinates();

        // Check the top square.
        if (_userMove.Item1 - 1 >= 0 && _model[_userMove.Item1 - 1, _userMove.Item2] == "")
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.Item1, zeroPosition.Item2], _model[_userMove.Item1, _userMove.Item2]) =
                (_model[_userMove.Item1, _userMove.Item2],
                    _model[zeroPosition.Item1,
                        zeroPosition.Item2]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            UpdateGameField();
        }
        // Check the bottom square.
        else if (_userMove.Item1 + 1 <= 3 && _model[_userMove.Item1 + 1, _userMove.Item2] == "")
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.Item1, zeroPosition.Item2], _model[_userMove.Item1, _userMove.Item2]) =
                (_model[_userMove.Item1, _userMove.Item2],
                    _model[zeroPosition.Item1,
                        zeroPosition.Item2]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            UpdateGameField();
        }
        // Check left square.
        else if (_userMove.Item2 - 1 >= 0 && _model[_userMove.Item1, _userMove.Item2 - 1] == "")
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.Item1, zeroPosition.Item2], _model[_userMove.Item1, _userMove.Item2]) =
                (_model[_userMove.Item1, _userMove.Item2],
                    _model[zeroPosition.Item1,
                        zeroPosition.Item2]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            UpdateGameField();
        }
        else if (_userMove.Item2 + 1 <= 3 && _model[_userMove.Item1, _userMove.Item2 + 1] == "")
        {
            // If an empty square is found here, change the user's move with an empty square.
            (_model[zeroPosition.Item1, zeroPosition.Item2], _model[_userMove.Item1, _userMove.Item2]) =
                (_model[_userMove.Item1, _userMove.Item2],
                    _model[zeroPosition.Item1,
                        zeroPosition.Item2]); // Tuples which enables swapping two variables without a temporary one;
            // Displaying the playing field on the buttons.
            UpdateGameField();
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

        // Update the game field from _model to _view.
        UpdateGameField();
    }

    // Counting the number of buttons in their places as a percentage.
    private void CountingButtonsInTheirPlacesasPercentage(object sender, EventArgs e)
    {
        var count = 0;
        for (var i = 0; i < 4; i++)
        for (var j = 0; j < 4; j++)
        {
            if (i == 0 && j == 0 && _model[0, 0] == "1") count++;

            if (i == 0 && j == 1 && _model[0, 1] == "2") count++;

            if (i == 0 && j == 2 && _model[0, 2] == "3") count++;

            if (i == 0 && j == 3 && _model[0, 3] == "4") count++;

            if (i == 1 && j == 0 && _model[1, 0] == "5") count++;

            if (i == 1 && j == 1 && _model[1, 1] == "6") count++;

            if (i == 1 && j == 2 && _model[1, 2] == "7") count++;

            if (i == 1 && j == 3 && _model[1, 3] == "8") count++;

            if (i == 2 && j == 0 && _model[2, 0] == "9") count++;

            if (i == 2 && j == 1 && _model[2, 1] == "10") count++;

            if (i == 2 && j == 2 && _model[2, 2] == "11") count++;

            if (i == 2 && j == 3 && _model[2, 3] == "12") count++;

            if (i == 3 && j == 0 && _model[3, 0] == "13") count++;

            if (i == 3 && j == 1 && _model[3, 1] == "14") count++;

            if (i == 3 && j == 2 && _model[3, 2] == "15") count++;

            if (i == 3 && j == 3 && _model[3, 3] == "") count++;
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