   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:ExamSystem.WpfNetCore.Views.EducatorPanel)ExamSystem.WpfNetCore.Views.EducatorPanel  5   	   [2clr-namespace:ExamSystem.WpfNetCore.CustomControls$ExamSystem.WpfNetCore.CustomControls  5   	   O    IExamSystem.WpfNetCore.Views.EducatorPanel.EducatorPanelQuestionWindowView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:ExamSystem.WpfNetCore.Views.EducatorPanel     5   	   McustomControls2clr-namespace:ExamSystem.WpfNetCore.CustomControls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        � Title$  EducatorQuestionPanel��5
   	   $	��600��6'   $
��1400��64    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6   ���	#FFCCCCCC.��5      �� .+�5   
   � $	��675��6   $	��581��6   $
��Left=�6(   $��
10,10,0,10q�6C   .+�5      �� $��1q�6   
�������$��
0,0,10,365q�6<    �� CornerRadius$ 10��6P   ._�5      �� -   5         ��Name$ RichText��5      $
��Left=�5      $	��210��6   $	��650��6*   $��10q�66   $	��Top=�6B   
�������$��Arial)�6m   $��9(�6�   ���	#FF5F5859<   6ExamSystem.WpfNetCore.CustomControls.RichTextBoxHelper   DocumentXaml 5      �� *QuestionText+ �� Mode$ TwoWay=�5      5      �� 5      $
��Left=�5      $	��184��62   $��	5,230,0,0q�6?   $	��Top=�6R   $	��665��6j   ���	#FFE1E1E1$��Arial)�6�   
���������5      �� *WrongAnswersHeaderText+.��5      � .+�5      �� -   5        $ RichAnswer0��5!      $��25��5   *   $��0,0,10,0q�5       $	��Top=�5"      $	��568��6%   
����������	#FF5F5859$��Right=�5$       5      �� *WrongAnswer0+5$      �� 5%      $��1)��6   $��25��6)   $��20��64   $��Right=�6@   $��0,10,600,104q�6\   ���	#FF5F58596r   �� 5&      -   5        $ RichAnswer1��5*      $��25��5'   P   $��	0,45,10,0q�5(      $	��Top=�5)      $	��568��6   
����������	#FF5F5859$��Right=�5+        5'   	   �� *WrongAnswer1+5+       �� 5,      $��2)��6   $��25��6)   $��20��64   $��Right=�6@   $��0,50,600,64q�6\   ���	#FF5F58596q   �� 5-      -   5        $ RichAnswer2��50   "   $��25��5-   "   $��	0,85,10,0q�5/      $	��Top=�51      $	��568��6    
����������	#FF5F5859$��Right=�53   	    5.      �� *WrongAnswer2+53   	   �� 55      $��3)��6   $��25��6)   $��20��64   $��Right=�6@   $��0,90,600,24q�6\   ���	#FF5F58596q   56      57      �� 58      $
��Left=�6B   $	��110��6]   $��
5,465,10,0q�6j   $	��Top=�6~   $	��665��6�   ���	#FFE1E1E1$��ARİAL)�6�   
���������6   �� *CorrectAnswerHeaderText+.��59      � .+�5:      �� -   5        $ RichAnswer3��5<      $��25��5=      $��	0,15,10,0q�6   $	��Top=�5>      $	��568��6#   
����������	#FF5F5859$��Right=�5@       5;      �� *CorrectAnswer0+5@      �� 5A      $��1)��6   $��25��6)   $��20��64   $��Right=�6@   $��0,10,600,10q�6\   ���	#FF5F58596q   5B      5C      5D      � 5E   
   $	��230��6   $	��581��6   $
��Left=�6(   $��690,-600,0,0q�6C   .+�5F      � $	��200��6   .+�5G      ��  �� DisplayMemberPath$	 Key��5I       �� SelectedValuePath$ Value��5K      $
��Left=�6   $��	10,32,0,0q�68   $	��Top=�6K   $	��180��6c   
����������	#FF5F5859���	#FF5F5859��5H   
   �� *	LessonMap+	 �� SelectedValue	 5J   	   �� *Lesson+5K   �   �� 5L      $	 Key��5O      $ Value��5P      $
��Left=�5R      $��	10,78,0,0q�6+   $	��Top=�6>   $	��180��6V   
����������	#FF5F5859���	#FF5F5859��5N   
   �� *	UnitMap+	 5Q      �� *Unit+5R   �   �� 5S      $	 Key��5U      $ Value��5V      $
��Left=�5X   
   $��
10,124,0,0q�6%   $	��Top=�69   $	��180��6Q   
����������	#FF5F5859���	#FF5F5859��5T      �� *
SectionMap+	 5W      �� *	Section+5X   �   5Y      5Z      � 5[   
   $	��453��6   $	��581��6   $
��Left=�6(   $��920,-600,0,0q�6C   .+�5\      �� $��1q�6   
�������$��
0,25,0,180q�6<   $ 10��6P   ._�5]      �� $	��440��5^   P   $	��365��6\   ��6   �� *
ImageUri+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6k   5_      �� 5`      $��45��6   $	��260��6!   $��0q�6-   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 26��6A   $��40 310 25 0q�6o   ��5a      �� 5b      .��5c      �  � Color$ #3399FF��6'    � Offset$	 0.0Q�67   6F   � 5d      $ #0182FF��6'   $ 1Q�67   6D   5e      .��5g      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5h      �� 
�������$��18(�5i   =   $��20 0 5 0q�6K   ��6   �� *AddPictureTextBoxText+6K   5j      5k      �� 5l      -   5        $��45��5o      $	��260��6   $��0q�6)   $ 26��6=   $��40 460 25 0q�6k   ��5n   
   �� *$"QuestionCreateButtonClickedCommand+��5p      �� 5q      .��5r      � $ #3399FF��6'   $	 0.0Q�67   6F   � 5s      $ #0182FF��6'   $ 1Q�67   6D   5t      .��5v      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5w      �� 
�������$��18(�5y      $��40 0 5 0q�6    ��5x      �� *ConfirmQuestionTextButtonText+5y       5z      5{      5|      �� 5}   
   $��30��5      $��30��6   $��1363.687,-1070,-0.088,100q�5�       � Cursor$
 Hand��64   ��5}      Z� ��5~      Z� ��5�      �� *ExitButtonClickedCommand+.��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�6&   
����+��$��25��6O   $��25��6Z   $��	-20 0 0 0q�6f   $
 Hand��6y   6�   5�      5�      5�      