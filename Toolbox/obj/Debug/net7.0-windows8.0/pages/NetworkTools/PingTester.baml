   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       Toolbox   Toolbox.pages.PingTester   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      �� ._�5
   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      � $��0��6   $��Center=�6    $
��0,10q�6=     5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6   $��Domain:��6)   $��Center=�68    �� TextAlignment$ Center=�6S   $��16(�6j   �� 5      -   5         ��Name$ 	txtDomain��5   '   $��1��6   $	��200��6:   $��
google.com��6F   $	��5,0q�6X    �� TextAlignment$ Center=�6e   6|   �� 5      -   5         ��Name$ btnPing��5   &   $��2��6   $
��Ping��67   $	��100��6F   $��
55,5,55,-5q�6R   6f   5      �� 5         ColorBox#��[  6   $��100,79,100,0q�67   $��2��6M   ._�5      #   LiveCharts.Wpf.CartesianChart  -   5          Name$ 	pingChart��5   %   $
��auto��6`   $
��auto��6n   &    LiveCharts.Wpf.Charts.Base.Chart   Series 68   �� *PingSeriesCollection+   AxisX 5         LiveCharts.Wpf.Axis     Title$ Time (s)��6#   	   MinValue$	 0Q�64   
   MaxValue$
 30Q�6A      FontSize$ 14Q�6O      
Foreground
 �   �6]      AxisY 5"        $ 	Ping (ms)��6#   $ 14Q�6P   
 �   �   LabelFormatter 65   �� 6^   5$      5%      �� 5(      -   5         ��Name$ 	lbResults��5(      $��2��6)   $	��600��66   $	��100��6B   $
��0,20q�6O   5)      5*      5+      