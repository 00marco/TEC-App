using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace TEC_App.Views.AddOpeningView
{
    /// <summary>
    /// Interaction logic for AddOpeningView.xaml
    /// </summary>
    public partial class AddOpeningView : UserControl
    {
        public AddOpeningView()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

    }
}
