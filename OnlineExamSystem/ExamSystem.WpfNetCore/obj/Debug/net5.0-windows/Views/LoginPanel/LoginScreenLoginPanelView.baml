   M S B A M L   `   `   `  ����P  LExamSystem.WpfNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ExamSystem.WpfNetCore.Views.LoginPanel&ExamSystem.WpfNetCore.Views.LoginPanel  5      [2clr-namespace:ExamSystem.WpfNetCore.CustomControls$ExamSystem.WpfNetCore.CustomControls  5      S.clr-namespace:ExamSystem.WpfNetCore.Converters ExamSystem.WpfNetCore.Converters  5      F    @ExamSystem.WpfNetCore.Views.LoginPanel.LoginScreenLoginPanelView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:ExamSystem.WpfNetCore.Views.LoginPanel     5      McustomControls2clr-namespace:ExamSystem.WpfNetCore.CustomControls     5      E
converters.clr-namespace:ExamSystem.WpfNetCore.Converters     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        � 	Resources  5      0  *ExamSystem.WpfNetCore.Converters.BoolToVis   	BoolToVis��%   &	          5   
   6   5      .��5      �� $	��415��6   $	��545��6   .+�5   
   � $��	0 80 0 80q�6   $	��249��6"   .+�5      �� -   5         ��Name$ UsernameTextBox��5      
���   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �� ��
�����F�$��14(�5      )  #MaterialDesignThemes.Wpf.HintAssist   HintOpacity$	 0.5Q�5         
Background
 ����    
Foreground
 �� ��$��70,98,70,101q�5"       % !MaterialDesignFloatingHintTextBox#��[ 6,   ��5      �� *UsernameTextBoxText+   Hint 5!      �� *UsernameHintText+5"   i   �� 5&      $*��$../../Images/PasswordTextBoxIcon.png��6   $
��Left=�6B   $��27��6]   $	��Top=�6i   $��25��6�   $��320,209,0,0q�6�   �� 5'      $*��$../../Images/UsernameTextBoxIcon.png��6   $
��Left=�6B   $��25��6]   $	��Top=�6i   $��25��6�   $��320,112,0,0q�6�   >   8ExamSystem.WpfNetCore.CustomControls.BindablePasswordBox  5(      $��Center=�5+      $��	0,187,0,0q�6.   $	��Top=�5,         HintText 5)      �� *PasswordHintText+   Password 5*      �� *PasswordTextBoxText+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5,      50      � 51   
   $	��136��6   .+�52      �� -   5         ��Name$ LoginButton��52        MaterialDesignRaisedButton#��[ 55      $��48��57      $��104,0,104,80q�58      $��0q�59      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5:      ��53      �� *LoginButtonClickedCommand+��5>      �� 5?      .��5@      �  � Color$ #2fdd2e��6'    � Offset$	 0.0Q�67   � 5A      $ #34c282��6'   $ 1Q�67   5B      .��5F      � .+�5G      �� 
�������$��	0,0,-13,0q�5H   A   ��6    �� *LoginButtonText+6A   5I      5L      <   6ExamSystem.WpfNetCore.CustomControls.LoadingContentBar  5M      -   5          Name$ 
LoadingBar��5P      $
��Left=�5Q      $��79��5R   &   $��
157,57,0,0q�5S   &   $	��Top=�5T   &   $	��100��5U   &   y�5N      �� *IsCycleShow+ �� 	Converter# [  5W      �� 5X      
�����F�$��300,102,0,0q�5[      $	��Top=�6)    � Cursor$
 Hand��5\      $��50��5]      $	��150��5^      $	��200��5_      ��5X      �� *CreateAccountText+ J� InputBindings 5a      d� 5b       d� MouseAction$ 	LeftClicke�6Q    �� Command 6#   �� *RegisterLabelClickCommand+6k   5d      �� 5e      $��50��5f      $	��100��5g      $
��Left=�5h      $	��200��5i      
�����F�$��3,102,262,0q�5k      $	��Top=�6&   $
 Hand��5l      ��5e      �� *ForgotEmailText+ 5n      d� 5o      $ 	LeftClicke�6O    6#   �� *ForgotLabelClickCommand+5q      5s      �� 5u      
��� � �$��12(�5w      $��70,-49,47,152q�5y      ��5x      �� *CurrentSuccessInfoText+5y      �� 5z      -   5         ��Name$ 
ErrorLabel��5z      $��70,-49,47,152q�5{      
���  ��$��12(�5|   !   ��5}      �� *CurrentErrorInfoText+�� 5~      -   5        $ ErrorLabel2��5~      $��70,-49,47,152q�5      
���  ��$��12(�5�   !   ��5�      �� *CurrentErrorInfoText+5�      5�      5�      