   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ExamSystem.WpfNetCore.Views.StudentPanel(ExamSystem.WpfNetCore.Views.StudentPanel  5   	   [2clr-namespace:ExamSystem.WpfNetCore.CustomControls$ExamSystem.WpfNetCore.CustomControls  5      J    DExamSystem.WpfNetCore.Views.StudentPanel.StudentScreenExamWindowView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ExamSystem.WpfNetCore.Views.StudentPanel     5   	   McustomControls2clr-namespace:ExamSystem.WpfNetCore.CustomControls     5        � Title$
  Exam��5	   	   $	��570��5
   	   $
��1018��6    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $	��800 �6   �� 5      $	��190 �6   .+�5   
   �� $��0��6   $��0��6   ._�5      �  5      �� 5      $
��280* �6$   �� 5      $
��270* �6$    5      �� 5       .+�5"      �� $��10(�67   $��2,3,743,243q�6F   ��6   �� *	IndexText+6F   �� 5#       �� 
IsReadOnly$
 True��6   $��2q�5&   "   
�������$��Arial)�6I   $��9(�6\   ���	#FF5F5859$��62,0,0,0q�6�   <   6ExamSystem.WpfNetCore.CustomControls.RichTextBoxHelper   DocumentXaml 5$      �� *QuestionText+5&   �   �� 5)      $��1��6   $��0��6&   ._�5*      � $��	0,0,0,-20q�6    5+      �� 5,      $��3* �6,   6:   �� 5-      $��3* �6,   6:   �� 5.      $��3* �6,   6:   �� 5/      $��3* �6,   6:   �� 50      $��* �6,   69    54      �� 55      $��* �6/   6;   �� 56      $	��19* �6/   6=   .+�58      	� $��A��6D   $��0��6P   $��0��6]    d� 	IsChecked 6&   �� *	ChoiceA+6o   	� 59      $��B��6t   $��1��6�   $��0��6�    6&   �� *	ChoiceB+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   	� 5:      $��C��6t   $��2��6�   $��0��6�    6&   �� *	ChoiceC+$	 TwoWay=�$
 PropertyChanged=�6�   	� 5;      $��D��6t   $��3��6�   $��0��6�    6&   �� *	ChoiceD+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5<      $��Bottom=�6&   $
 True��6H   $��0��6Z   $��1��5=   &      MaterialDesignRichTextBox#��[  5>   &   $��2,0,0,75q�5?   N   $��2��6`    6   �� *AnswerText0+5@      �� 5A      $��Bottom=�6&   $��1��6H   $
 True��6U   $��2��6g   $��1��5B   K   $��0,0,0,75q�5D   N    6   �� *AnswerText1+5E   )   �� 5F      $��Bottom=�6&   $
 True��6H   $��2��6[   $��2��6h   $��1��5G   '   $��0,0,0,75q�5I   G    6   �� *AnswerText2+5K   )   �� 5L      $��Bottom=�6&   $��1��6I   $
 True��6Y   $��3��6l    5M      �� *AnswerText3+5N      5O      5P      �� 5Q      $��10(�67   $��2,79,743,167q�6F   ��6   �� *	RatioText+6F   5S      5U      �� 5W   
   $��0��6   $��1��6   ._�5X      �  5Y      �� 5Z      �� 5[       5]      �� 5^      .+�5`      �� $��
0,205,0,28q�6   $��1��6-   $��Finish��6:   ��6K   �� *FinisButtonClickedCommand+��5b      �� 5c      .��5d      �  � Color$ #0182FF��6+    � Offset$	 0.0Q�6;   6J   � 5e      $ 	#FF00365D��6+   $ 1Q�6=   6J   5f      5j      �� 5k      $��0��6   $��0��6&   $��Center=�66   $��Center=�6Q   ._�5l      �� -   5        $��TBCountDown��5l       $	��150��5m      $	��150��6    �� TextAlignment$ Center=�6*   $��20(�5n      5o      �� 5q      $��1��6   $��0��6&   ._�5r      ]� $��Center=�6    $��Center=�6;   .+�5t      �� $��50��6N   $��90��6Z   $��0q�6e   $��5,0,2,0q�6y   ��6!   �� *BackButtonClickedCommand+��5u      �� 5v   "   .��5w   &   � $ #0182FF��63   $	 0.0Q�6C   6R   � 5x   &   $ 	#FF00365D��63   $ 1Q�6E   6R   5y   #   .��5{      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5|   "   �� 
�������$
��Back��6D   $��18(�6P   5~      5      �� 5�      $��50��6N   $��90��6Z   $��0q�6e   $��0,0,2,0q�6y   ��6!   �� *NextButtonClickedCommand+��5�      �� 5�   "   .��5�   &   � $ #0182FF��63   $	 0.0Q�6C   6R   � 5�   &   $ 	#FF00365D��63   $ 1Q�6E   6R   5�   #   .��5�      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5�   "   �� 
�������$
��Next��6D   $��18(�6P   5�      5�      5�      5�      5�      5�      �� 5�   
   $��X��6   $
��Left=�5�      $��
151,10,0,0q�6#   $	��Top=�5�      $��40��6%   $��1��60   ��5�   
   �� *ExitButtonClick+5�   0   5�      5�      