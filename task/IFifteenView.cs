using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public interface IFifteenView
    {
        // Event of pressing the "New Game" button.
        event EventHandler<EventArgs> NewGameButtonClickEvent;

        // Event of pressing a button on the game field.
        event EventHandler<EventArgs>? GameFieldButtonClickEvent;

        // Event of user move.
        public event EventHandler<EventArgs>? UserMoveButtonPressedClickEvent;

        // Displaying a message about the victory.
        void WinMessage(TimeSpan timeSpan);

        // Display a message "Do you want to play again?".
        public void AskPlayMore();

        // Do you really want to leave ?.
        void ReallyWantToLeave();
    }
}
