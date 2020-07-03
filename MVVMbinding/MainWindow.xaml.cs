using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        // MVVMパターンにより、UIに配置したコントロールのプロパティと
        // コントロールのコマンドのバインディングを行った.
        // この部分にあった、ボタンクリックのイベントハンドラーを取り去ったため、
        // Viewのコードビハインドは「表示するだけ」になった。
    }

    /// <summary>
    /// MainWindowのViewModel. INotifyPropertyChangedインターフェースを継承
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // コマンドの実装：ICommandプロパティを宣言し、Xamlにバインドする
        public ICommand ChangeA { get; set; }
        public ICommand ChangeB { get; set; }

        // ViewModelのコンストラクタ
        public MainViewModel()
        {
            // コマンドのインスタンス生成
            ChangeA = new CommandA(this);
            ChangeB = new CommandB(this);
        }

        // ラベルのメンバーとプロパティ
        private string _status = "Start";
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        // InotifyPropertyChangedメンバー
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    /// <summary>
    /// ButtonAの状態・動作定義
    /// </summary>
    public class CommandA : ICommand
    {
        // メンバーとコンストラクターでCommandとViewModelを関連付ける
        readonly MainViewModel vm;
        public CommandA(MainViewModel viewModel)
        {
            this.vm = viewModel;
        }

        // Commandの実行可能状態変化を検知するイベントハンドラー
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }

        // Commandが実行可能か判定する
        public bool CanExecute(object parameter)
        {
            if (vm.Status != null)
                return true;
            else
                return false;
        }

        // Command動作本体
        public void Execute(object parameter)
        {
            vm.Status = "A";
        }
    }

    /// <summary>
    /// ButtonBの状態・動作定義
    /// </summary>
    public class CommandB : ICommand
    {
        // メンバーとコンストラクターでCommandとViewModelを関連付ける
        private readonly MainViewModel vm;
        public CommandB(MainViewModel viewModel)
        {
            this.vm = viewModel;
        }

        // Commandの実行可能状態変化を検知するイベントハンドラー
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }

        // Commandが実行可能か判定する
        public bool CanExecute(object parameter)
        {
            if (vm.Status != null)
                return true;
            else
                return false;
        }

        // Command動作本体
        public void Execute(object parameter)
        {
            vm.Status = "B";
        }
    }
}
