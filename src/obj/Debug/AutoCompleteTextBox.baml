   M S B A M L   `   `   `  ����Y  UWpfAutoCompleteTextBoxWithAkka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:WpfAutoCompleteTextBoxWithAkka.LoadingControl-WpfAutoCompleteTextBoxWithAkka.LoadingControl  5      O,clr-namespace:WpfAutoCompleteTextBoxWithAkkaWpfAutoCompleteTextBoxWithAkka  5      8    2WpfAutoCompleteTextBoxWithAkka.AutoCompleteTextBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      VloadingControl;clr-namespace:WpfAutoCompleteTextBoxWithAkka.LoadingControl     5      WwpfAutoCompleteTextBoxWithAkka,clr-namespace:WpfAutoCompleteTextBoxWithAkka     5      -   5        $
��Ctrl��5      .��5      � -   5        $��MainGrid��5      
�������.+�5	   
   � $��20��6     � ColumnDefinitions  5
      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��PART_TextBox��5   ;   $��0��6   $��0q�6&   
������ $��Center=�5   /   
������ ��5   P   ��  �� ElementName$
 Ctrl�� �� Path$ QueryString� �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 5      �� $
 Ctrl��$ ToolTip�(� 5      $��1��6   $��20��6&   $��3,3,3,3q�61   y�5      �� $
 Ctrl��$ 	IsLoading�   BoolToVisibilityConverter �� 	Converter# [  .��5      D   >WpfAutoCompleteTextBoxWithAkka.LoadingControl.LoadingAnimation  5      5      � 5   
   -   5         �Name$ 
PART_Popup��5      $
��Left=�6$   $��Center=�6?    � AllowsTransparency .  � 	StaysOpen .  $	��120��5   I   	 J� Opacity$		 0.7Q�6V   ��6   �� $ MainGrid��$ ActualWidth���5      `� 5      
 `� Mode$
 OneWay=�6     BooleanAndConverter `� 	Converter# [ 6-   .1�5      �� $ Ctrl ��6   $ ItemsSource�62     NullToFalseConverter# [ 6E   �� 5      $
 Ctrl��6   $ SelectedItem�61     NullToTrueConverter# [ 6E   �� 5      $ PART_TextBox��6   $ 	IsFocused�69   5      .��5       �� -   5         ��Name$ PART_ListBox��5       $��Stretch=�6,   
�������$		 0.9Q�6e   $��15(�5!      $��SemiBold"�6$   $ �� IsSynchronizedWithCurrentItem$ FalseY�5"      ��5#      �� $
 Ctrl��$ ItemsSource� �� DisplayMemberPath 5$      �� $
 Ctrl��$ DisplayMemberPath� �� SelectedValuePath 5%      �� $
 Ctrl��$ SelectedValuePath�5&      5'      5(      5)      