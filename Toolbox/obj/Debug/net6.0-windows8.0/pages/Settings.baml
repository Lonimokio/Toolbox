   M S B A M L   `   `   `  ����B  >Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Toolbox.pagesToolbox.pages  5          Toolbox.pages.Settings   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Toolbox.pages     5      .��5	      �� ._�5
      � $��20q�6     � 	Resources  5   
    �� 
TargetType �� Property �� Value��%�   '��       '�� r     �� 5      " ��6   .�5      ��  � ��$ 16(�6-   �� 5       � ��$ 0,0,10,0q�6+   5      �� 5      " ��6   .�5      ��  � ��$ 0,0,0,10q�6+   5      5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5!   
   �� $��0��6   $��0��6    $��Default Open Page:��6-   �� 5"      -   5         ��Name$ DefaultPageSetting��5"   4   $��1��6   $��0��6'   ��5#      �� *DefaultPageSettingData+ �� SelectedIndex 5$      �� *SelectedDefaultPageIndex+ �� Mode$ TwoWay=���5%      �� 5&      .R�5'      �� ��6$   �� ��65   �� *ComboboxText+5(      5*      � 5,   
   $��1��6   $��2��6    5-      �� 5.      $��* �6#   �� 5/      $��* �6#    52      �� 53      $
��Auto �6    �� 54      $
��Auto �6    .+�57      �� $��0��6   $��0��6!   $��Enable settings Popups:��62   �� 58      -   5        	 ��Name$	 SettingsPopup��58   '   $��1��6   
 d� 	IsChecked$

 TrueY�6>   �� 5:      $��1��6   $��0��6!   $��Enable Cheatsheet Popups:��62   �� 5;      -   5        $	 CheatSheetsPopup��5;   4   $��1��6   $��1��6$   $

 TrueY�6N   5<      �� 5?   
   $��0��6   $��2��6    $��Theme:��6-   �� 5@      -   5        $ ThemeSetting��5@   4   $��1��6   $��2��6'   ��5A      �� *ThemeSettingData+ 5B      �� *SelectedThemeIndex+$ TwoWay=���5C      �� 5D      .R�5E      �� ��6$   �� ��65   �� *ComboboxText+5F      5H      �� 5K   
   $��0��6   $��3��6    $��	Language:��6-   �� 5L      -   5        $ LanguageSetting��5L   4   $��1��6   $��3��6'   ��5M      �� *LanguageSettingData+��5N      �� 5O      .R�5P      �� ��6$   �� ��65   �� *ComboboxText+5Q      5S      �� 5T   
   -   5        $��0��5T      $��4��6!   $��2��6.   $
��Save��6B   $��0,128,0,-168q�6f   5U      5V      5W      