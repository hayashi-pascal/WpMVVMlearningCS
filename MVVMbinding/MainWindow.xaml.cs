using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MVVMbinding
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            this.DataContext = vm;
        }

        // MVVMパターンのうち、UIに配置したコントロールのプロパティをバインディングした例.
        // UIで配置したコントロールのプロパティはViewModelクラスのプロパティに置き換えられる.
        // UIでの操作は引き続きイベントハンドラで処理する

        /// <summary>
        /// ButtonChAクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChA_Click(object sender, RoutedEventArgs e)
        {
            vm.Status = "A";
        }

        /// <summary>
        /// ButtonChBクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChB_Click(object sender, RoutedEventArgs e)
        {
            vm.Status = "B";
        }
    }

    /// <summary>
    /// MainWindowのViewModel. INotifyPropertyChangedインターフェースを継承
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // ラベルのメンバーとプロパティ
        private string _status = "Start";
        public string Status
        {
            get { return this._status; }
            set
            {
                if (value != this._status)
                {
                    this._status = value;
                    this.RaisePropertyChanged(nameof(Status));
                    return;
                }
            }
        }

        // InotifyPropertyChangedメンバー
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }

}
