using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Task1
{
    public partial class MainWindow : Window
    {
        private readonly LinearList<string> _list = new LinearList<string>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void UpdateUI()
        {
            CurrentItemText.Text = $"Текущий элемент: {_list.CurrentItem ?? "нет"}";
            CountText.Text = $"Количество элементов: {_list.Count}";
            IsEmptyText.Text = $"Список пуст: {_list.IsEmpty}";
        }

        private void OnAddClick(object? sender, RoutedEventArgs e)
        {
            var item = InputTextBox.Text?.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                _list.Add(item);
                InputTextBox.Text = "";
                StatusText.Text = $"Добавлен элемент: {item}";
                UpdateUI();
            }
        }

        private void OnRemoveClick(object? sender, RoutedEventArgs e)
        {
            if (_list.RemoveCurrent())
            {
                StatusText.Text = "Текущий элемент удален";
            }
            else
            {
                StatusText.Text = "Не удалось удалить элемент (список пуст)";
            }
            UpdateUI();
        }

        private void OnNextClick(object? sender, RoutedEventArgs e)
        {
            if (_list.MoveNext())
            {
                StatusText.Text = "Перешли к следующему элементу";
            }
            else
            {
                StatusText.Text = "Не удалось перейти к следующему элементу";
            }
            UpdateUI();
        }

        private void OnStartClick(object? sender, RoutedEventArgs e)
        {
            _list.MoveToStart();
            StatusText.Text = "Перешли в начало списка";
            UpdateUI();
        }
    }
}