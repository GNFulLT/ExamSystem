   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ExamSystem.WpfNetCore.Views.LoginPanel&ExamSystem.WpfNetCore.Views.LoginPanel  5      [2clr-namespace:ExamSystem.WpfNetCore.CustomControls$ExamSystem.WpfNetCore.CustomControls  5	      S.clr-namespace:ExamSystem.WpfNetCore.Converters ExamSystem.WpfNetCore.Converters  5      I    CExamSystem.WpfNetCore.Views.LoginPanel.LoginScreenRegisterPanelView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:ExamSystem.WpfNetCore.Views.LoginPanel     5      McustomControls2clr-namespace:ExamSystem.WpfNetCore.CustomControls     5	      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      ?
converters.clr-namespace:ExamSystem.WpfNetCore.Converters  5        � 	Resources  5      0  *ExamSystem.WpfNetCore.Converters.BoolToVis   	BoolToVis��%   &	          5   
   6   5      .��5      �� .+�5   
   � $��0,80,0,0q�6   $	��309��6!   $	��415��6.   .+�5      �� -   5         ��Name$ UsernameTextBox��5      $��2��5      $
��Left=�5      $��45��5      $��
70,177,0,0q�6    �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��275��6)    % !MaterialDesignFloatingHintTextBox#���  5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �� ��
�����F�$��14(�5!      )  #MaterialDesignThemes.Wpf.HintAssist   HintOpacity$	 0.5Q�5"         
Background
 ����    
Foreground
 �� ��
���   �   
HelperText 5      �� *CurrentUsernameHelperText+   Hint 5$      �� *UsernameHintText+��5'      �� *UsernameTextBoxText+�� 5)      -   5        $ EmailTextBox��5,      $��1��5)      $
��Left=�5-      $��45��5.      $��
70,119,0,0q�6   $
 Wrap=�5/      $	��Top=�50      $	��275��6)   #���  51      
 �� ��
�����F�$��14(�55      $	 0.5Q�56      
 ���� 
 �� ��
���   � 5*      �� *CurrentEmailHelperText+ 58      �� *EmailHintText+��5;      �� *EmailTextBoxText+�� 5?      $��0��6   $
��Left=�5A      $��45��5B      $��	70,59,0,0q�6   $
 Wrap=�5C      $	��Top=�5D      $	��275��6)   #���  5E      
 �� ��
�����F�$��14(�5I      $	 0.5Q�5J      
 ���� 
 �� ��
���   � 5@      �� *CurrentNameSurnameHelperText+ 5L      �� *NameSurnameHintText+��5O      �� *NameSurnameTextBoxText+.��5P      5R      5U      � 5W   
   $	��156��6   .+�5X      >   8ExamSystem.WpfNetCore.CustomControls.BindablePasswordBox  $��3��5Z      $��Center=�5[      $��0,-85,0,180q�5\   B   	   Password	 5Y      �� *PasswordTextBoxText+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   
HelperText 5\      �� *CurrentPasswordHelperText+   HintText 5]      �� *PasswordHintText+5`      �� 5b      -   5         ��Name$ RegisterButton��5b      $��4��5c        MaterialDesignRaisedButton#��[ 5d      $��48��5e      $��104,20,98,80q�5f      $��0q�5g      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5h      ��5i      �� *RegisterButtonClickedCommand+��5m      �� 5n      .��5o      �  � Color$ #2fdd2e��6'    � Offset$	 0.0Q�67   � 5p      $ #34c282��6'   $ 1Q�67   5q      .��5u      � .+�5v      �� 
�������$��	0,0,-13,0q�5x       ��5w      �� *RegisterText+5x       5y      5|      �� 5}      $
��Left=�5~      $��5��5      
�����F�$��339,122,0,0q�5�      $	��Top=�6&    � Cursor$
 Hand��5�      ��5}      �� *
BackText+ J� InputBindings 5�      d� 5�       d� MouseAction$ 	LeftClicke�6O    �� Command 6#   �� *BackLabelClickedCommand+6i   5�      <   6ExamSystem.WpfNetCore.CustomControls.LoadingContentBar  5�      $
��Left=�5�      $��79��5�      $��
157,77,0,0q�5�      $	��Top=�5�      $	��100��5�      y�5�      �� *IsCycleShow+ �� 	Converter# [  5�      5�      5�      5�      