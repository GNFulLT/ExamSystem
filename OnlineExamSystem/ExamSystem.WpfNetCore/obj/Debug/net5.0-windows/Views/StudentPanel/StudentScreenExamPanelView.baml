   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ExamSystem.WpfNetCore.Views.StudentPanel(ExamSystem.WpfNetCore.Views.StudentPanel  5      I    CExamSystem.WpfNetCore.Views.StudentPanel.StudentScreenExamPanelView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:ExamSystem.WpfNetCore.Views.StudentPanel     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   .+�5   
   �� $��45��6   $	��900��6   $��0q�6)   ��6=   �� *QuestionClickedCommand+��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ #3399FF��6#    � Offset$ 0.528Q�63   � 5      $ #0182FF��6#   $
 0.01Q�63   � 5      $ #3399FF��6#   $ 1Q�63   � 5      $ #0182FF��6#   $ 1Q�63   5      .��5      �� $��-16 0 -16 0q�6   .+�5      � $��Center=�6   $��Center=�62   $��45��6O   $	��900��6[    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       ��5#      �� 5$       �� Color$ Transparent��6*   6@   .+�5'      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   $	��150��6r   $��
-720 0 0 0q�6~   .+�5(      �� 
�������$��10(�6V   $��0 0 10 0q�6d   ��6$   �� *
LeftText+6d   5)      �� 5+      $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6X   $	��200��6u   $��-220 0 10 0q�6�   .+�5,      �� $��Soru Sayısı ��6$   
�������$��10(�6P   $��0 0 10 0q�6^   �� 5-      
�������$��10(�6\   ��6$   �� *QuestionCount+6\   5.      �� 50      $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   $	��200��6r   $��
380 0 10 0q�6~   .+�51      �� $��Tarih :��6$   
�������$��10(�6K   $��0 0 10 0q�6Y   �� 52      
�������$��10(�6Z   ��6$   �� *CreatedDate+6Z   53      55      57      59      5:      5;      