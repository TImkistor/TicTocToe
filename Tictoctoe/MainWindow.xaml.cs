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

            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            mPlayer1Turn ^= true;
            CheckForWinner();
        }
        private void CheckForWinner()
        { // 1
          if (mResults [0] != TimType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            // 2
            if (mResults[3] != TimType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            // 3
            if (mResults[6] != TimType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }


            // 4
            if (mResults[0] != TimType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            // 5
            if (mResults[1] != TimType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            // 6
            if (mResults[2] != TimType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }


            // 7
            if (mResults[0] != TimType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            // 8
            if (mResults[2] != TimType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }


            
            if (!mResults.Any(f => f == TimType.Free))
            {
                mGameEnded = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
    #endregion
}
