   M S B A M L   `   `   `  ����B  >Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Toolbox.pagesToolbox.pages  5          Toolbox.pages.Checksum   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Toolbox.pages     5      .��5
      �� ._�5   
   � $��20q�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��
File Path:��6   $��Center=�6.   �� 5      -   5         ��Name$ txtFilePath��5      $��5,0,0,0q�6/   $��Center=�6@   $	��200��6[   �� 5      -   5         ��Name$ 	btnBrowse��5      $��Browse��6,   6=   5      �� 5      $��1��6   $ 
Horizontal=�6&   $��0,10,0,0q�6?   .+�5      �� $��	Checksum:��6   $��Center=�6-   �� 5      -   5        $ txtChecksumResult��5   *   $��1��6   $��5,0,0,0q�6E    �� 
IsReadOnly$
 True��6V   $��Center=�6h   $	��200��6�   $��Stretch=�6�   5      �� 5      $��2��6   $ 
Horizontal=�6&   $��0,10,0,0q�6?   .+�5      �� $��Status:��6   $��Center=�6+   �� 5       -   5         ��Name$ 	txtStatus��5       $��5,0,0,0q�6/   $��Center=�6@   5!      �� 5#      $��3��6   $ 
Horizontal=�6&   .+�5$      �� -   5        $ btnCalculateChecksum��5$      $��Calculate Checksum��67   $��	0,20,10,0q�6T   $��Center=�6�   �� 5%      -   5        $ btnStoreChecksum��5%      $��Store Checksum��63   $��	0,20,10,0q�6L   $��Center=�6~   �� 5&      -   5        $ btnCheckFile��5&      $��
Check File��6/   $��0,20,0,0q�6D   $��Center=�6q   5'      5(      5)      5*      