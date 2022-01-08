using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tictoctoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        private TimType[] mResults;
        private bool mPlayer1Turn;
        private bool mGameEnded;

        #endregion
        #region Constructor

        /// <summary>
        /// Default  constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NeWGame();
        }

        private void NeWGame()
        {
           mResults = new TimType[9];

            for (var i = 0; i<mResults.Length; i++)
                mResults[i] = new TimType();

            mPlayer1Turn = true;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = String.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NeWGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row*3);

            if (mResults[index] != TimType.Free)
                return;

            mResults[index] = mPlayer1Turn ? TimType.Cross : TimType.Nought;

            button.Content = mPlayer1Turn ? "X" : "0";
        }
    }
    #endregion
}
