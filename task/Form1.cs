namespace task;

/// <summary>
///     Ќаписать игру Ђѕ€тнашкиї, учитыва€ следующие требовани€:
///     Х предусмотреть автоматическую перестановку Ђп€тнашекї в начале
///     новой игры;
///     Х выводить врем€, за которое пользователь окончил игру (собрал
///     Ђп€тнашкиї);
///     Х предусмотреть индикатор процесса, который будет отображать
///     процесс собирани€ Ђп€тнашекї, т.е. отображать, какое количество
///     кнопок в процентном отношении находитс€ на своих местах;
///     Х предусмотреть возможность начать новую игру.
/// </summary>

public partial class Form1 : Form, IFifteenView
{
    #region IFifteenView Implementation

    #region EVENTS:
    // Event of pressing the "New Game" button.
    public event EventHandler<EventArgs>? NewGameButtonClickEvent;

    // Event of pressing a button on the game field.
    public event EventHandler<EventArgs>? GameFieldButtonClickEvent;

    // Event of user move.
    public event EventHandler<EventArgs>? UserMoveButtonPressedClickEvent;
    #endregion

    #region MESSAGES:
    // Output a message about victory.
    public void WinMessage(TimeSpan timeSpan) // todo: по идее, не должно быть никаких принимаемых параметров.
    {
        MessageBox.Show("Congratulations! You have done the impossible! You won !" +
                        $"\nTo win you spent {timeSpan:hh\\:mm\\:ss}",
            "Game \"Fifteen\".", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        AskPlayMore();
    }

    // Display a message "Do you want to play again?".
    public void AskPlayMore()
    {
        DialogResult result = MessageBox.Show("Do you want to play again ?", "Game \"Fifteen\".", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.No)
        {
            Application.Exit();
        }
        else if (result == DialogResult.Yes)
        {
            Application.Restart();
        }
    }

    // Do you really want to leave ?.
    public void ReallyWantToLeave()
    {
        DialogResult result = MessageBox.Show("Do you really want to leave ?", "Game \"Fifteen\".", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }
        else
        {
            return;
        }
    }
    #endregion
    #endregion

    // Form constructor.
    public Form1()
    {
        InitializeComponent();

        // Turn off the playing field before starting the game.
        TurnOffThePlayingFields();
    }

    // Turn off the playing field before starting the game.
    private void TurnOffThePlayingFields()
    {
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
    }

    // Turn on the playing field before starting the game.
    private void TurnOnThePlayingFields()
    {
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
    }

    // Menu item "New game".
    private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Turn on the playing field before starting the game.
        TurnOnThePlayingFields();

        // New game event start. 
        NewGameButtonClickEvent?.Invoke(this, EventArgs.Empty);
    }

    // Menu item "Exit".
    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Do you really want to leave ?.
        ReallyWantToLeave();
    }

    // Click on the playing field.
    private void gameField_buttons_Click(object sender, EventArgs e)
    {
        // One step in the game.

        UserMoveButtonPressedClickEvent?.Invoke(sender, EventArgs.Empty);
        GameFieldButtonClickEvent?.Invoke(this, EventArgs.Empty);
    }
}