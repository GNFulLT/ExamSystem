   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ExamSystem.WpfNetCore.ViewsExamSystem.WpfNetCore.Views  5   	   [2clr-namespace:ExamSystem.WpfNetCore.CustomControls$ExamSystem.WpfNetCore.CustomControls  5   	   4    .ExamSystem.WpfNetCore.Views.EducatorScreenView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ExamSystem.WpfNetCore.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   GcustomControls2clr-namespace:ExamSystem.WpfNetCore.CustomControls  5   	     � Title$  EducatorScreen��5   	   $	��680��6    $
��1280��6-    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.    � AllowsTransparency$
 True��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $3 -../CustomControls/Themes/PaginationTheme.xaml?�6%   %    5      .��5      �� .+�5   
   � $	��130��6   $	��Top=�6   ���#F5F5F5.+�5      �� -   5        $��/Images/Logo.png��5      $
��Left=�5      $
��50 0q�6/   �� 5       -   5        $��45��5    Y   $��45��6d   $��1134,0,9.6,95q�6p   ��6   Z� ��6B   Z� .��5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6*   
����+��$��	-15 0 0 0q�6X    � Cursor$
 Hand��6k   6{   5"      �� 5#      -   5        $��45��5#   W   $��45��6b   $��1230,0,9.6,95q�6n   $
 Hand��6�   ��6   Z� ��6@   Z� .��5$        $ 	ExitToApp=�6+   
����+��$��25��6T   $��25��6_   $��	-15 0 0 0q�6k   $
 Hand��6~   6�   5%      �� 5&      $
��Left=�65   $��Center=�6P   ���#606363$��18(�6�   $��200 0q�6�   ��6   �� *NameSurname+6�   5'      �� 5(   
   $	��420��6   $	��Top=�5)      ���#F5F5F5.+�5.      �� $��Center=�5/      $��5��50      $	��Top=�6$   $��0 10 0 0q�51      $	��800��6*   	 J� Opacity$		 0.5Q�66   ��52      �� 53      .��54      � 
 � Color$
 #9f40ff��6'    � Offset$ 0Q�67   6D   � 55      $
 #7f00ff��6'   $	 0.5Q�67   6F   � 56      $
 #6600cc��6'   $ 1Q�67   6D   57      59      � 5:      $��10q�6   $	��380��6   .+�5=      �� -   5         ��Name$ ListBox��5=      $��Stretch=�5@      $	��980��5A      $��136,8,136,44q�6   ��5>      �� *UnseenQuestions+5A      5   /ExamSystem.WpfNetCore.CustomControls.Pagination  5C      $��179,341,191,-5q�5D         Count 5E      �� *Count+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   CountPerPage 5F      �� *CountPerPage+$ TwoWay=�$ PropertyChanged=�   Current 5G      �� *	Current+$ TwoWay=�$ PropertyChanged=�   CountLocalization 5H      �� *	CountText+   JumpLocalization 5I      �� *
JumpText+5M      �� 5O      $��Center=�5P      $��5��6.   $��Bottom=�5Q      $��0 0 0 10q�6,   $	��800��6>   $		 0.5Q�6J   ��5R      �� 5S      .��5T      � $
 #9f40ff��6'   $ 0Q�67   6D   � 5U      $
 #7f00ff��6'   $	 0.5Q�67   6F   � 5V      $
 #6600cc��6'   $ 1Q�67   6D   5W      5Y      5Z      � 5[   
   $	��130��6   $	��Top=�6   ���#F5F5F5 � ColumnDefinitions 5\      �� 5]      $	��31* �6#   �� 5^      $	��36* �6#   .+�5`      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   $��2��6j   $��364,42q�6~   .+�5a      �� $��45��5c      $	��241��6!   $��0q�6-   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 26��6B   $��0 0 25 0q�6p   $
 Hand��6�   ��5b   	   �� *CreateQuestionClickedCommand+��5d      �� 5e      .��5f      � $
 #3399FF��6+   $	 0.0Q�6;   6J   � 5g      $
 #0182FF��6+   $ 1Q�6;   6H   5h      .��5j      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5k      �� 
�������$��Create Question��6<   $��18(�6S   $��40 0 5 0q�6a     5l      $
 Plus=�62   
�������$��25��6Q   $��25��6\   $��Center=�6h   $��Right=�6�   $��20 0 0 0q�6�   5m      5n      �� 5o      $��45��6   $	��260��6%   $��0q�61   $ 26��6F   ��5p      �� 5q      .��5r      � $
 #3399FF��6+   $	 0.0Q�6;   6J   � 5s      $
 #0182FF��6+   $ 1Q�6;   6H   5t      .��5v      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5w      �� 
�������$��Create Special Question��6<   $��18(�6[     5x      $
 Plus=�62   
�������$��25��6Q   $��25��6\   $��Center=�6h   $��Right=�6�   $��0 0 5 0q�6�   5y      5z      5{      5|      5}      5~      