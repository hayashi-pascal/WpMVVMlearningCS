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

namespace MVVMlearning
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // MVVMパターンを使わないコーディング. Windows Form Applicationのコーディングスタイルとほとんど変わらない.
        // UIで配置したコントロールのプロパティをこの部分で直接操作する（LabelStatus）
        // UIでの操作をイベントハンドラで処理する
        
        /// <summary>
        /// ButtonChAクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChA_Click(object sender, RoutedEventArgs e)
        {
            LabelStatus.Content = "A";
        }

        /// <summary>
        /// ButtonChBクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChB_Click(object sender, RoutedEventArgs e)
        {
            LabelStatus.Content = "B";
        }
    }
}
