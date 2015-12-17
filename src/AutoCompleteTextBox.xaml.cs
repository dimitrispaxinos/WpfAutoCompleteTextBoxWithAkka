using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAutoCompleteTextBoxWithAkka
{
    /// <summary>
    /// Interaction logic for AutoCompleteTextBox.xaml
    /// </summary>
    public partial class AutoCompleteTextBox : UserControl
    {
        private bool _ignoreChanges;

        #region Dependency Properties

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(AutoCompleteTextBox));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource",
            typeof(IEnumerable),
            typeof(AutoCompleteTextBox));

        public string QueryString
        {
            get { return (string)GetValue(QueryStringProperty); }
            set { SetValue(QueryStringProperty, value); }
        }

        public static readonly DependencyProperty QueryStringProperty =
            DependencyProperty.Register("QueryString", typeof(string), typeof(AutoCompleteTextBox));

        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(AutoCompleteTextBox));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(AutoCompleteTextBox));

        public string SelectedValuePath
        {
            get { return (string)GetValue(SelectedValuePathProperty); }
            set { SetValue(SelectedValuePathProperty, value); }
        }

        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(AutoCompleteTextBox));

        public object ToolTip
        {
            get { return (object)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }

        public static readonly DependencyProperty ToolTipProperty = DependencyProperty.Register(
            "ToolTip",
            typeof(object),
            typeof(AutoCompleteTextBox));



        #endregion

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            PART_TextBox.LostFocus += PartTextBoxLostFocus;
            PART_TextBox.GotFocus += PartTextBoxGotFocus;
        }

        private void PartTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            PART_Popup.IsOpen = true;
        }

        private void PartTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!PART_Popup.IsMouseOver)
                PART_Popup.IsOpen = false;
        }

        private void PART_TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            //Handle KeyUp
            if (e.Key == Key.Down)
                HandleKeyDown(e);

            //Handle KeyDown
            if (e.Key == Key.Up)
                HandleKeyUp();

            //Handle Enter Key
            if (e.Key == Key.Enter)
                HandleListBoxSelection();
        }

        private void HandleListBoxSelection()
        {
            if (PART_ListBox.SelectedItem != null)
            {
                _ignoreChanges = true;
                SelectedItem = PART_ListBox.SelectedItem;
                QueryString = PART_ListBox.SelectedValue.ToString();

                // set cursor at the end of the text inside the text box
                PART_TextBox.CaretIndex = PART_TextBox.Text.Length; 
                PART_ListBox.SelectedItem = null;
                PART_Popup.IsOpen = false;
            }
        }
        private void HandleKeyUp()
        {
            if (PART_ListBox.Items != null && PART_ListBox.Items.Count > 0)
            {
                if (PART_ListBox.SelectedIndex == -1)
                {
                    PART_ListBox.SelectedItem = PART_ListBox.Items[PART_ListBox.Items.Count - 1];
                }
                else
                {
                    var newIndex = PART_ListBox.SelectedIndex - 1;

                    if (newIndex < 0)
                    {
                        PART_ListBox.SelectedItem = PART_ListBox.Items[PART_ListBox.Items.Count - 1];
                    }
                    else
                    {
                        PART_ListBox.SelectedItem = PART_ListBox.Items[newIndex];
                    }
                }
            }
        }

        private void HandleKeyDown(KeyEventArgs e)
        {
            if (PART_ListBox.Items != null && PART_ListBox.Items.Count > 0)
            {
                if (PART_ListBox.SelectedIndex == -1)
                {
                    PART_ListBox.SelectedItem = PART_ListBox.Items[0];
                }
                else
                {
                    var newIndex = PART_ListBox.SelectedIndex + 1;
                    if (newIndex <= PART_ListBox.Items.Count - 1)
                    {
                        PART_ListBox.SelectedItem = PART_ListBox.Items[newIndex];
                    }
                    else
                    {
                        PART_ListBox.SelectedItem = PART_ListBox.Items[0];
                    }
                }
            }
        }

        // Unset the SelectedItem everytime that the text changes except from the case where we change the value programmatically
        private void PART_TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_ignoreChanges)
            {
                _ignoreChanges = !_ignoreChanges;
                return;
            }
            SelectedItem = null;
            PART_Popup.IsOpen = true;
        }

        private void PART_ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Handle Mouse selection
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                HandleListBoxSelection();
        }
    }
}
