using System.Windows;
using System.Windows.Controls;

namespace PasswordBoxBinding
{
    public static class PasswordBoxBindingHelper
    {
        public static string GetPasswordContent(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordContentProperty);
        }

        public static void SetPasswordContent(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordContentProperty, value);
        }

        public static readonly DependencyProperty PasswordContentProperty =
            DependencyProperty.RegisterAttached("PasswordContent", typeof(string), typeof(PasswordBoxBindingHelper),
            new PropertyMetadata(string.Empty, OnPasswordContentPropertyChanged));

        private static void OnPasswordContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;
            box.PasswordChanged -= OnPasswordChanged;
            var password = (string)e.NewValue;
            if (box != null && box.Password != password)
                box.Password = password;
            box.PasswordChanged += OnPasswordChanged;
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = sender as PasswordBox;
            SetPasswordContent(box, box.Password);
        }
    }
}
