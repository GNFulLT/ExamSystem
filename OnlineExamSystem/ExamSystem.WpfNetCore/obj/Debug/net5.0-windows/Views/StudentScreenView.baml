   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ExamSystem.WpfNetCore.ViewsExamSystem.WpfNetCore.Views  5   	   3    -ExamSystem.WpfNetCore.Views.StudentScreenView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ExamSystem.WpfNetCore.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  StudentPanel��5	   	   $	��680��5
      $
��1280��6    � 
ResizeMode$ NoResize=�6    � AllowsTransparency$
 True��63    � WindowStyle$
 None=�6M    � WindowStartupLocation$ CenterScreen=�6`   .��5      �  � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $
��260* �6   �� 5      $��1030* �6   .+�5   
   �� $��0��6   $��0��6!   $	��600��6.   $	��250��6;   $��	5,40,5,40q�6G    �� CornerRadius$ 15��6Z   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 #0182FF��6#    � Offset$ 1Q�63   � 5      $
 	#FF00365D��6#   $ 0Q�65   5      ._�5      �� $��
15,110,0,0q�6   .+�5      �� $��50��5"      $��0,20,0,0q�6&   ��5      Z� ��6/   Z� ��5!      �� *DashBoardClickCommand+.��5#      ]� $	��150��6    .+�5$      �� $��/Images/homeicon.png��6    $��32��6>   $��32��6I   $��0,0,5,0q�6U   �� 5%      $��	DASHBOARD��6    
�������64   5&      5'      �� 5(      $��50��5+   0   $��0,20,0,0q�6<   ��5(      Z� ��5)      �� *ExamsClickCommand+��5+      Z� .��5,      ]� $	��150��6    .+�5-      �� $��/Images/examicon.png��6    $��32��6>   $��32��6I   $��0,0,5,0q�6U   �� 5.      $��EXAMS��6    
�������60   5/      50      �� 51      $��50��54   0   $��0,20,0,0q�6<   ��52      �� *OldExamsClickCommand+��53      Z� ��54      Z� .��55      ]� $	��150��6    .+�56      �� $��/Images/analyticsicon.png��6    $��32��6C   $��32��6N   $��0,0,5,0q�6Z   �� 57      $��	OLD EXAMS��6    
�������64   58      59      5;      5<      �� 5>   
   $��1��6   $��0��6"   $��2��6/   ._�5?      �  5@      �� 5A      $��80 �6$   �� 5B      $	��550 �6$    5D      �� 5E      $��50 �6'   �� 5F      $
��Auto �6'   .+�5I      �� $��0��6   $��0��6)   $��2��67   $��60��6K   ._�5K      � .+�5M      ]� $	��150��6$   $
��Left=�60   .+�5O      �� $��/Images/Logo.png��6$   5Q      ]� 5R      $	��150��6$   $��Right=�60   .+�5T      �� $��45��6R   $��45��6]   ��6%   Z� ��6;   Z� .��5U   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6:   
����+�� � Cursor$
 Hand��6h   $��25��6w   $��25��6�   5V      �� 5W      -   5        $��45��5W   R   $��45��6]   $
 Hand��6j   ��6%   Z� ��6;   Z� .��5X   "     $ 	ExitToApp=�6:   
����+��$��25��6c   $��25��6n   $
 Hand��6z   $��Center=�6�   $��Center=�6�   5Y      5[      5]      5_      �� 5c       K� ZIndex$ 2��6!   $��1��5d   !   $��2��5e   !   $	��990��5f   !   $	��990��5g   !   $��0��5h      $��	20,0,20,0q�5i      ��5j      �� *CurrentPanel+5m      5o      5p      5q      