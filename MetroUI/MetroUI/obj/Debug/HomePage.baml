   M S B A M L   `   `   `  ����B  >MetroUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MetroUIMetroUI  5      H DMahapps.Metro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          MetroUI.HomePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:MetroUI     5      R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5        N� Title$  HomePage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $
��160* �6   �� 5      $	��120 �6   .+�5   
   �  5      �� 5      $��* �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $��70 �6#   �� 5      $	��200 �6#   �� 5      $	��180 �6#   �� 5      $	��180 �6#   �� 5      $
��156* �6#   .+�5      �� $��1��6   $��Server Activity��6(   $��Center=�6?   $��0,22,0,1q�6Z   $��24(�6l   
�������$��Microsoft YaHei)�6�   �� 5       $��1��6   $��1��6(   $��May 11th - 16th��65   $	��Top=�6L   ���	#FFC7C7C7$��11(�6{   $��3��6�   �� 5!      $��2��6   $��	5 22 15 5q�6%   $��1q�68   $��27��6L    �� CornerRadius$ 14��6X   ���	#FFACACAC._�5"      �� $��7 0 7 2q�6   $��0q�6-    �� SelectedIndex$ 0��6W   ��6A   Z� .@�5#      �� $��Type:Requests��6#   5$      5%      �� 5'      $��3��6   $��	15 22 5 5q�6%   $��1q�68   $��27��6L   $ 14��6X   ���	#FFACACAC._�5(      �� $��7 0 7 2q�6   $��0q�6,   $ 0��6V   ��6@   Z� .@�5)      �� $��Status:Active��6#   5*      5+      5.        OxyPlot.Wpf.Plot  50   
   $��1��6   ���	#00FFFFFF   	TextColor$ 	#FFB2A2A2��68      PlotAreaBorderColor$ 	#FFB8B8B8��6N   $��20q�6n      LegendPlacement$ Inside=�51          LegendMargin$ 0Q�69   	   Axes	 52        OxyPlot.Wpf.LinearAxis  53        OxyPlot.Wpf.Axis
   Position$

 Left=�6!     OxyPlot.Wpf.DateTimeAxis  54      $
 Bottom=�6#      IntervalType$ Seconds=�66      AxislineStyle$ Solid=�6M      ExtraGridlineColor$ 	#FFF12A2A��6c      MajorGridlineColor$ 	#40FB1818��6�      Series 5<        OxyPlot.Wpf.LineSeries  5=      !  OxyPlot.Wpf.DataPointSeries   
DataFieldX$
 Date��5>   !      
DataFieldY$ Value��63     OxyPlot.Wpf.Series   Title$ 速度��6F      StrokeThickness$ 1Q�5?   !      Color$ 	#FF3DFF1F��66      
MarkerType$ Diamond=�5@   !      TrackerFormatString$5 /时间: {2:yyyy-MM-dd HH:mm:ss}
速度: {4}km/h��66   ��5=   !   �� *%#SingleVehicleMonitorModel.SpeedData+5A      5C      � 5E   
   $��2��6    5F      �� 5G      $��70 �6#   �� 5H      $
��302* �6#   �� 5I      $
��391* �6#   .+�5L      � $��1��6    5M      �� 5N      $	��12* �6$   �� 5O      $	��12* �6$   �� 5P      $	��12* �6$   �� 5Q      $	��12* �6$   �� 5R      $	��30* �6$    5T      �� 5U      $��80 �6'   �� 5V      $
��150* �6'   �� 5W      $	��57* �6'   .+�5Z      �� $��0��6   $��0��6,   $��Total Users��69   $��Center=�6L   
�������6g   �� 5[      $��0��6   $��1��6,   $��Requests��69   $��Center=�6I   
�������6d   �� 5\      $��0��6   $��2��6,   $��Timeouts��69   $��Center=�6I   
�������6d   �� 5]      $��0��6   $��3��6,   $��Latches��69   $��Center=�6H   
�������6c   � 5_      $��0q�6   $��1��62   $��0��6B   $��5��6O    � Value$ 50Q�6Z   ���	#3FFFFFFF���	#FFF30E0E6|   � 5`      $��0q�6   $��1��62   $��1��6B   $��5��6O   $ 30Q�6Z   ���	#3FFFFFFF���	#FF2EFF006|   � 5a      $��0q�6   $��1��62   $��2��6B   $��5��6O   $ 70Q�6Z   ���	#3FFFFFFF���	#FF0B59FF6|   � 5b      $��0q�6   $��1��62   $��3��6B   $��5��6O   $ 80Q�6Z   ���	#3FFFFFFF���	#FFFF2DCF6|   �� 5e      $��2��6   $��0��6,   $��15 0 0 0q�69   $
��1304��6L   $��Center=�6X   
�������6s   �� 5f      $��2��6   $��1��6,   $��15 0 0 0q�69   $
��2399��6L   $��Center=�6X   
�������6s   �� 5g      $��2��6   $��2��6,   $��15 0 0 0q�69   $	��895��6L   $��Center=�6W   
�������6r   �� 5h      $��2��6   $��3��6,   $��15 0 0 0q�69   $
��2492��6L   $��Center=�6X   
�������6s   5i      5m      5n      5o      