   M S B A M L   `   `   `  ���� |  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting   Sistema de Votação   dbtest.Wpf.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     -     � Title$  
MainWindow��$	��450��$	��525�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�����  �� ImageSource$% Resources/Images/background.png��.���  � RowDefinitions �� $��50 ��� $	��400 �.+�� $��0�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto �.+��� $��Right=� �� Orientation$ 
Horizontal=�$��2��$��	0,10,20,0q�$	��Top=�$��20��.+��� -   $��16�� � ToolTip$ Fechar��$��16������ $! /Resources/Images/close.png������ 	 �� 
TargetType"	 ��.R�� 
 �Name$
 RootGrid��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  CommonStates��   States.    System.Windows.VisualState  
Normal��  	MouseOver��   
Storyboard. �� .��W�  g� Duration$ 0D�	 W� To$ .6X� �� TargetProperty$ Opacity� �� 
TargetName$ 
CloseImage��  Pressed��. �� .��W� $ 0D�$ .3X�$ Opacity�$ 
CloseImage��  Disabled��  FocusStates��.   Focused��  	Unfocused��  PointerFocused��.+�(� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    $��3q�.��� ���	#00FFFFFF.+��� $��
CloseImage��$!��/Resources/Images/close.png�� J� Opacity$	 0.8Q��� -   $��UserInformationPanel��$��Right=�$ 
Horizontal=�$��2��$��
0,20,350,0q�$��Center=�$��20��.+��� -   $��txtName�����	#FFEBEBEB&   System.Windows.Media.TextOptions   TextRenderingMode$ Aliased=�$��2��$
��Left=�$��0,0,50,0q�$��Nome do usuário��� -   $��
GridPanel1��$��1��$y�Hidden=�.+��� $
��Auto=�$��	10,10,0,0q�$	��345��$	��Top=�.���� -   $��PanelRadioButton���� $��45��$��Bottom=�.+��� -   $��btnVote��$��	350,5,0,0q�$y�Visible=�$��35��$	��100��$��Votar�����	#FFEBEBEB���� "	 ��.R�� $
 RootGrid��   CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled��  FocusStates��.   Focused��  	Unfocused��  PointerFocused��.+�(� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    $��3q�.��� $��gridBtnVote��$	��190��$��50��.+��� $��BorderBtnVote�� �� CornerRadius$ 3�����	#FF0179B1$��1,1,1,1q�._��� $��Votar��$��28(� �� TextAlignment$ Center=�$��Center=��� -   $��btnVoted��$��350,-35,0,0q�$y�Hidden=�$��35��$	��150�����	#FFEBEBEB���� "	 ��.R�� $
 RootGrid��   CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled��  FocusStates��.   Focused��  	Unfocused��  PointerFocused��.+�(� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    $��3q�.��� $��gridBtnVote��$	��280��$��60��.+��� $ 3�����	#FF6C6C6C$��1,1,1,1q�._��� $��Visualizar votos��$��28(�$ Center=�$��Center=�� -	   $��
GridPanel2��$��1��.+��� $��Right=�$ 
Horizontal=�$��	0,20,20,0q�$��Center=�$	��300��$	��480��.+��� ���	#FFEBEBEB$ Aliased=�$��18(�$
��Left=�$��
150,0,50,0q�$��Votação Encerrada��� $��0,30,0,0q�.+�>   8System.Windows.Controls.DataVisualization.Charting.Chart  -
   $��mcChart��
 �� Top$ 80�� �� Left$ 10��$	��400��$	��250��
����İ�   Series B   <System.Windows.Controls.DataVisualization.Charting.PieSeries  -   $��
VotesChart��?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Votos��H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding ��  �� Path$	 Key�   DependentValueBinding �� $ Value�