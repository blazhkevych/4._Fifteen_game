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

    // Ссылка на класс реализующий логику игры.
    private readonly Game _game;

    // Конструтор формы.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Контекстный пункт меню "Новая игра".
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Контекстный пункт меню "Выход".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    // Класс реализующий логику игры.
    internal class Game
    {
        // Массив для хранения значений кнопок.
        int[,] arr =
        {
            {0, 1, 2, 3},
            {4, 5, 6, 7},
            {8, 9, 10, 11},
            {12, 13, 14, 15}
        };

        // Метод перемешивает матрицу. Игра "Пятнашки".
        void ShakeArr()
        {
            Random r = new Random();
            int min = 0;
            int max = 3;
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
                        int temp = arr[i][j];
                        arr[i][j] = arr[row][col];
                        arr[row][col] = temp;
                    }
                }
                n--;
            }
        }
    }
}