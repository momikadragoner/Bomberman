using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bomberman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test(7);
        }

        // DELETE LATER
        private void Test(int size)
        {
            Model.Maze maze = new(size);
            TextBlock.Text = MazeToString(maze);
        }
        // DELETE LATER
        private string MazeToString(Model.Maze maze)
        {
            string mazeAsString = "";
            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    mazeAsString += ($"{maze[i, j]} ");
                }
                mazeAsString += "\n";
            }
            return mazeAsString;
        }
    }
}