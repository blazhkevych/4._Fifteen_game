using System.Drawing;

namespace task
{
    /// <summary>
    /// �������� ���� ���������, �������� ��������� ����������: 
    /// � ������������� �������������� ������������ ��������� � ������ 
    /// ����� ����; 
    /// � �������� �����, �� ������� ������������ ������� ���� (������ 
    /// ���������); 
    /// � ������������� ��������� ��������, ������� ����� ���������� 
    /// ������� ��������� ���������, �.�. ����������, ����� ���������� 
    /// ������ � ���������� ��������� ��������� �� ����� ������;
    /// � ������������� ����������� ������ ����� ����.
    /// </summary>


    // ���������� �����.
    public partial class Form1 : Form
    {
        // ������ �� ����� ����������� ������ ����.
        private readonly Game _game;
        public Form1()
        {
            InitializeComponent();

            // ����� ����� ��������� ���� � ��������.
            // ����� �������� ������ ����� ������� ������ "������ ����".
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

        // ����������� ����� ���� "����� ����".
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �������� ������� ����.
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

            // ��������� ������ �� ������� ���� ���������� ������� �� 0 �� 100 � ���������� �� � ����� ������.
            _game.SetAllButtonsText(Controls);
            // ������������ ������.
            _game.ShakeArr();

        }

        // ����������� ����� ���� "�����".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ��� �������. 
        private void timer1_Tick(object sender, EventArgs e)
        {
            // ����� � ��������� ������������ ������� �� �����������

        }

        // ���� �� �������� ����.
        private void gameField_button1_Click(object sender, EventArgs e)
        {

        }
    }

    // ����� ����������� ������ ����.
    internal class Game
    {
        // ������ ��� �������� �������� ������.
        int[,] _arr =
        {
            {0, 1, 2, 3},
            {4, 5, 6, 7},
            {8, 9, 10, 11},
            {12, 13, 14, 15}
        };

        // ������������ �������. ���� "��������".
        public void ShakeArr()
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

        // ��������� Controll �� �����, � ������ ������ ��������� �������������� �����.
        public void SetAllButtonsText(Control.ControlCollection controlCollection)
        {
            int i = 1;
            for (int j = 0; j < _arr.Length; j++)
            {
                foreach (Control control in controlCollection)
                {
                    if(control is Button && ((Button)control).Name == "gameField_button" + i)
                }
            }


            var i = 15;
            do
            {
                foreach (var obj in control)
                    if (obj is Button && ((Button)obj).Name == "gameField_button" + i)
                        ((Button)obj).Text = i.ToString();
                i++;
            } while (i < 17);
        }

        // ���������� ���������� ������� ��������.
        public Point GetEmptySquareCoordinates()
        {
            // ������� ���������� ������ ������.
            Point p = new Point();
            int emptyButtonRowPos = 0;
            int emptyButtonColPos = 0;
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