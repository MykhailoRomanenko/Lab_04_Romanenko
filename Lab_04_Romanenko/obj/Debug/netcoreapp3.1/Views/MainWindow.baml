   M S B A M L   `   `   `  ����  Lab_04_Romanenko'    !Lab_04_Romanenko.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ People��5      $��0��5      $��0��6    $	��Top=�5   #      AutoGenerateColumns$ False��5         CanUserResizeColumns$
 True��6/      
IsReadOnly$
 True��6K      CanUserSortColumns$
 True��6]    �� SelectedItem 5      �� *SelectedPerson+	 �� Mode$	 OneWayToSource=�
 �� UpdateSourceTrigger$
 PropertyChanged=���5      �� *Users+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5      $ Surname��6%    66   �� *	Surname+  5      $ Birthday��6%    67   �� *BirthDateString+  5      $ E-Mail��6%    65   �� *EMail+  5      $ IsAdult��6%      
IsReadOnly$
 True��66    6H   �� *	IsAdult+  5      $ Western Sign��6%    6;   �� *WesternSign+  5      $ Chinese Sign��6%    6;   �� *ChineseSign+  5      $ 
IsBirthday��6%   $
 True��69    6K   �� *
IsBirthday+5       �� 5!   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K    � 	Resources 5"       �� 
TargetType �� Property �� Value��%�   '��       �� 5#      " ��6   .�5$      ��  � ��$ 
0,10,20,10q�6/   �� 5%       � ��$ 60��6.   �� 5&       � ��$ 30��6/   5'      5(      .+�5)      �� -   5        .��5)   *   Add6/   �� 5*      -   5        .��5*   +   Edit61   �� 5+      -   5        .��5+   -   Remove65   �� 5,      -   5        .��5,   '   Save6-   �� 5-      -   5        .��5-   '   Load6-   5.      5/      50      