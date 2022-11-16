namespace task
{
    /// <summary>
    /// Написать игру «Пятнашки», учитывая следующие требования: 
    /// • предусмотреть автоматическую перестановку «пятнашек» в начале 
    /// новой игры; 
    /// • выводить время, за которое пользователь окончил игру (собрал 
    /// «пятнашки»); 
    /// • предусмотреть индикатор процесса, который будет отображать 
    /// процесс собирания «пятнашек», т.е. отображать, какое количество 
    /// кнопок в процентном отношении находится на своих местах;
    /// • предусмотреть возможность начать новую игру.
    /// </summary>


    // Конструтор формы.
    public partial class Form1 : Form
    {
        // Ссылка на класс реализующий логику игры.
        private readonly Game _game;
        public Form1()
        {
            InitializeComponent();

            // Перед игрой отключаем поле с кнопками.
            // Будет включено только после нажатия кнопки "Начать игру".
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

        // Контекстный пункт меню "Новая игра".
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Включаем игровое поле.
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

            // Заполняет кнопки на игровом поле случайными числами от 0 до 100 и выставляет их в текст.
            _game.SetAllButtonsTextFromArr(Controls);

        }

        // Контекстный пункт меню "Выход".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Тик таймера. 
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Вывод в заголовок затраченного времени на прохождение

        }
    }

    // Класс реализующий логику игры.
    internal class Game
    {
        // Массив для хранения значений кнопок.
        int[,] _arr =
        {
            {0, 1, 2, 3},
            {4, 5, 6, 7},
            {8, 9, 10, 11},
            {12, 13, 14, 15}
        };

        // Перемешивает матрицу. Игра "Пятнашки".
        void ShakeArr()
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
                        row = r.Next();
                        col = r.Next();
                        int temp = _arr[i, j];
                        _arr[i, j] = _arr[row, col];
                        _arr[row, col] = temp;
                    }
                }
                n--;
            }
        }

        // Принимает Controll из формы, и каждой кнопке назначает сооветствующее число из массива.
        public void SetAllButtonsTextFromArr(Control.ControlCollection control)
        {
            var i = 15;
            do
            {
                foreach (var obj in control)
                    if (obj is Button && ((Button)obj).Name == "gameField_button" + i)
                        ((Button)obj).Text = i.ToString();
                i--;
            } while (i > 0 );
        }

    }
}