   M S B A M L   `   `   `  ����B  >Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Toolbox.pagesToolbox.pages  5          Toolbox.pages.CheatSheets   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Toolbox.pages     5      .��5	      �� ._�5
      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Cheat Sheets��6   $��24(�6(   $
��Bold"�66   $��10q�6H   � 5      $��0��6   $��2��6      5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� -   5         ��Name$ 
EditButton��5      $��2��6-   $��0��6:   $
��Edit��6J   $��10q�6Y   6e   �� 5      -   5        $ 
ViewButton��5      $��2��6-   $��1��6:   $
��View��6J   $��10q�6Y   6e   5      �� 5      -   5         ��Name$ CheatSheetsNav��5   ?   $��1��6   $��0��6#   $��10q�63    �� DisplayMemberPath$
 Name��6�   ��6X   �� *MarkdownFiles+ �� SelectedItem 6~   �� *SelectedFile+6�   �� 5      $��1��6   $��1��6&   $��10q�66   ._�5      (  "System.Windows.Controls.WebBrowser  -   5          Name$ 
webBrowser��5      5       �� 5!      -   5         ��Name$ editTextBox��5!   T    �� AcceptsReturn$
 True��6   $��1��6+   $��1��68   $��10q�6H   $y�	Collapsed=�6i   � 5#   
   $��2��6   $��0��6     5$      �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5(      �� -   5        $	��New��5(      $��40��6C   $��	10,5,10,5q�6O   �� 5)      -   5        $��1��5)      $��Delete��6%   $��40��6Q   $��	10,5,10,5q�6]   5*      �� 5+   
   -   5        $��2��5+      $��1��6   $
��Save��6.   $��40��6V   $��	10,5,10,5q�6b   5,      5-      5.      