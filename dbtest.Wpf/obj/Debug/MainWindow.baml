   M S B A M L   `   `   `  ����l  hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    Sistema de Votação   dbtest.Wpf.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��525��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � WindowStyle$
 None=�6p   ��5      �� 5   
    �� ImageSource$% Resources/Images/background.png��6   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��400 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�65   $��2��6N   $��	0,10,20,0q�6^   $	��Top=�6q   $��20��6�   .+�5      �� -   5        $��16��5       � ToolTip$ Fechar��6%   $��16��66   ��5      �� 5      $! /Resources/Images/close.png��6%   6Q   ��5!      �� 5"      	 �� 
TargetType"	 ��6*   .R�5#      � 
 �Name$
 RootGrid��6#   '  !System.Windows.VisualStateManager   VisualStateGroups 5$   "   %  System.Windows.VisualStateGroup  5%   &   CommonStates��   States. 5&   *      System.Windows.VisualState  
Normal��66     5'   *   	MouseOver��   
Storyboard. 5(   .   �� .��5)   2   W�  g� Duration$ 0D�6B   	 W� To$ .6X�6O    �� TargetProperty$ Opacity�6W    �� 
TargetName$ 
CloseImage��6{   5*   /   5+   +     5,   *   Pressed��. 5-   .   �� .��5.   2   W� $ 0D�6B   $ .3X�6O   $ Opacity�6W   $ 
CloseImage��6{   5/   /   50   +     51   *   Disabled��66   52   '     53   &   FocusStates��. 54   *     Focused��66     55   *   	Unfocused��66     56   *   PointerFocused��66   57   '   .+�59   "   (� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6*   $��3q�6l   .��5:   &   � ���	#00FFFFFF.+�5;   *   �� $��
CloseImage��60   $!��/Resources/Images/close.png��6B    J� Opacity$	 0.8Q�6g   5<   '   5=   #   5>      5?      5A      5B      �� 5D      -   5        $��UserInformationPanel��5D      $��Right=�65   $ 
Horizontal=�6Q   $��2��6j   $��
0,20,350,0q�6z   $��Center=�6�   $��20��6�   .+�5E      �� -   5        $��txtName��5E      ���	#FFEBEBEB&   System.Windows.Media.TextOptions   TextRenderingMode$ Aliased=�6B   $��2��6j   $
��Left=�6z   $��0,0,50,0q�6�   $��Nome do usuário��6�   5F      5G      � 5I   
   -   5        $��
GridPanel1��5I      $��1��6!   $y�Hidden=�6.   .+�5J      �� $
��Auto=�6   $��	10,10,0,0q�6>   $	��345��6Q   $	��Top=�6^   .��5K      �� -   5        $��PanelRadioButton��5K      5L      �� 5M      $��45��6   $��Bottom=�6%   .+�5N      �� -   5        $��btnVote��5N      $��	350,5,0,0q�6(   $y�Visible=�6;   $��35��6P   $	��100��6\   $��Votar��6h   ���	#FFEBEBEB��5O      �� 5P      "	 ��6*   .R�5Q      � $
 RootGrid��6#    5R   "     5S   &   CommonStates��. 5T   *     
Normal��66     5U   *   	MouseOver��66     5V   *   Pressed��66     5W   *   Disabled��66   5X   '     5Y   &   FocusStates��. 5Z   *     Focused��66     5[   *   	Unfocused��66     5\   *   PointerFocused��66   5]   '   .+�5_   "   (� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6*   $��3q�6l   .��5`   &   � $��gridBtnVote��6+   $	��190��6>   $��50��6J   .+�5a   *   �� $��BorderBtnVote��61    �� CornerRadius$ 3��6F   ���	#FF0179B1$��1,1,1,1q�6n   ._�5b   .   �� $��Votar��68   $��28(�6E    �� TextAlignment$ Center=�6S   $��Center=�6j   5c   +   5d   '   5e   #   5f      5g      5i      �� 5k      -   5        $��btnVoted��5k      $��350,-35,0,0q�6)   $y�Hidden=�6>   $��35��6R   $	��150��6^   ���	#FFEBEBEB��5l      �� 5m      "	 ��6*   .R�5n      � $
 RootGrid��6#    5o   "     5p   &   CommonStates��. 5q   *     
Normal��66     5r   *   	MouseOver��66     5s   *   Pressed��66     5t   *   Disabled��66   5u   '     5v   &   FocusStates��. 5w   *     Focused��66     5x   *   	Unfocused��66     5y   *   PointerFocused��66   5z   '   .+�5|   "   (� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6*   $��3q�6l   .��5}   &   � $��gridBtnVote��6+   $	��280��6>   $��60��6J   .+�5~   *   �� $ 3��61   ���	#FF6C6C6C$��1,1,1,1q�6Y   ._�5   .   �� $��Visualizar votos��68   $��28(�6P   $ Center=�6^   $��Center=�6u   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      � 5�   
   -	   5        $��
GridPanel2��5�      $��1��6!   .+�5�      �� $��Right=�6   $ 
Horizontal=�65   $��	0,20,20,0q�6N   $��Center=�6a   $	��300��6|   $	��480��6�   .+�5�      �� ���	#FFEBEBEB$ Aliased=�63   $��18(�6[   $
��Left=�6i   $��
150,0,50,0q�6�   $��Votação Encerrada��6�   5�      � 5�      $��0,30,0,0q�6   .+�5�      >   8System.Windows.Controls.DataVisualization.Charting.Chart  -
   5        $��mcChart��5�   =   
 �� Top$ 80��6    �� Left$ 10��6,   $	��400��6L   $	��250��6X   
����İ�   Series 5�      B   <System.Windows.Controls.DataVisualization.Charting.PieSeries  -   5        $��
VotesChart��5�   6   ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Votos��6(   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 6H   ��  �� Path$	 Key�   DependentValueBinding 6u   �� $ Value�5�      5�      5�      5�      5�      5�      