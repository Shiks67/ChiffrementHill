using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChiffrementHill
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Encrypt encrypt = new Encrypt();
        Decrypt decrypt = new Decrypt();

        int[] cryptMatrix = new int[4];

        /// <summary>
        /// Encrypt the message with its 2*2 matrice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encrypt_btn_Click(object sender, RoutedEventArgs e)
        {
            cryptMatrix[0] = Convert.ToInt32(m1.Text);
            cryptMatrix[1] = Convert.ToInt32(m2.Text);
            cryptMatrix[2] = Convert.ToInt32(m3.Text);
            cryptMatrix[3] = Convert.ToInt32(m4.Text);
            result.Text = encrypt.EncryptMessage(message.Text.ToLower().ToCharArray(), cryptMatrix);
        }

        /// <summary>
        /// Decrypt the message with its 2*2 matrice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decrypt_btn_Click(object sender, RoutedEventArgs e)
        {
            cryptMatrix[0] = Convert.ToInt32(m1.Text);
            cryptMatrix[1] = Convert.ToInt32(m2.Text);
            cryptMatrix[2] = Convert.ToInt32(m3.Text);
            cryptMatrix[3] = Convert.ToInt32(m4.Text);
            result.Text = decrypt.DecryptMessage(message.Text.ToLower().ToCharArray(), cryptMatrix);
        }
    }
}
