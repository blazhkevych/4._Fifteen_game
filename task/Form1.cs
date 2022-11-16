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

    // ������ �� ����� ����������� ������ ����.
    private readonly Game _game;

    // ���������� �����.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ����������� ����� ���� "����� ����".
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // ����������� ����� ���� "�����".
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    // ����� ����������� ������ ����.
    internal class Game
    {
        // ������ ��� �������� �������� ������.
        int[,] arr =
        {
            {0, 1, 2, 3},
            {4, 5, 6, 7},
            {8, 9, 10, 11},
            {12, 13, 14, 15}
        };

        // ����� ������������ �������. ���� "��������".
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