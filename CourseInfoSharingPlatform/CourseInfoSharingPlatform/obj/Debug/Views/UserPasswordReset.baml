   M S B A M L   `   `   `  ����T  PCourseInfoSharingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CourseInfoSharingPlatform.ViewsCourseInfoSharingPlatform.Views  5   	   7    1CourseInfoSharingPlatform.Views.UserPasswordReset   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:CourseInfoSharingPlatform.Views     5   	     � Title$  修改密码��5   	   $	��500��6   $	��400��6#    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � AllowsTransparency . ��6[   Z�  � 	Resources 5
      7   1CourseInfoSharingPlatform.Views.PassWordConverter   passWordConverter��%   &	          5   
   6"   5      .��5      �� -   5        
������� �� CornerRadius$ 10��5   Q    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6   	   ShadowDepth$	 0Q�6,   
   Opacity$	
 0.3Q�6<      	Direction$ 0Q�6J   ._�5   
   �  � RowDefinitions 5      �� 5      $��5* �6!   6/   �� 5      $��2* �6    6.   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   .+�5      �� -   5          BackBtnTemplate#��[ 5      $��	0,10,10,0q�6[   $	����6n   
���   �$��20(�6�   $	��Top=�6�   $��Right=�6�   �� 5      $��	0,20,0,20q�6   ._�5      �� $��Center=�6    $��Center=�6;   $��30(�6X   ���	#FF6EC4D8$
��Bold"�6}   修改密码6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��	用户名��6   $��20(�6*   $��Center=�68   $��
50,32,0,20q�6S   $��80��6g   �� 5      -   5         ��Name$ UserNameBlock��5       $��	啊哈哈��67   ���#ef6c00$��18(�6W   $��
10,32,0,20q�6e   $��Center=�6z   5      �� 5      $ 
Horizontal=�6   .+�5       �� $��	原密码��6   $��20(�6*   $��Center=�68   $��
50,20,0,20q�6S   $��80��6g   6t   G� 5!      -   5         G�Name$ OldPwdTextBox��5!   "   $��20(�69   $��Center=�6G   $	��180��6b   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $��	新密码��6   $��20(�6*   $��Center=�68   $��80��6S   $��
50,20,0,20q�6^   6t   G� 5%      -   5        $ NewPwdTextBox��5%   "   $��20(�6:   $��Center=�6H   $	��180��6c   6q   5&      5'      �� 5(      $��1��6   $ Vertical=�6&   .+�5)      �� $��50��6   ._�5*      �� -   5        $ PwdStatusText��5*       $��Center=�67   $	��Top=�6T   ���#dd2c00$��15(�6�   6�   5+      �� 5,      ._�5-      �� -   5         ��Name$ 	ModifyBtn��5-      $��提交��6H   $��40��6V   $��80��6b   $��Center=�6m   $��Center=�6�   ���	#FFB01AE4���	#FF04E4CF���	#FFDAF5F4$��20(�6�   5.      5/      50      51      52      