   M S B A M L   `   `   `  ����T  PCourseInfoSharingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CourseInfoSharingPlatform.ViewsCourseInfoSharingPlatform.Views  5   	   .    (CourseInfoSharingPlatform.Views.UserMain   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   9local-clr-namespace:CourseInfoSharingPlatform.Views  5   	     � Title$  管理员主界面��5	   	   $	��550��6   $	��600��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.    � AllowsTransparency . ��6[   Z� .��5      �� -   5        $��5q�5      
������� �� CornerRadius$ 10��6+    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      ShadowDepth$ 0Q�6,   	   Opacity$		 0.3Q�6<   
   	Direction$
 0Q�6J      
BlurRadius$ 5Q�6X   ._�5   
   �  � RowDefinitions 5      �� 5      $	��150 �6    �� 5      .+�5      �� $��0��6   ���#007DFA$	��150��67   $	��Top=�6D   $ 	10,10,0,0��6\   ._�5      � $��	30,20,0,0q�6    5      �� 5      $��50 �6(   �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   .+�5      �� $"��../Resources/Images/logo.png��6    �� 5      $��	10,10,0,0q�6$   
�������$��Center=�6J   $��课程信息分享平台��6e   $��18(�6u   5      �� 5       $ 
Horizontal=�6!   $��Right=�6:   $��2��5!   "   $	��150��63   .+�5"      o� $��Right=�6   $��40��6<   $��40��6H   $��Center=�6S   ���	#00F0F0F0.@�5#      m� $��40��6(   $��40��64   $��Center=�6?   $��Microsoft YaHei UI)�6Z   ��5$   "   �� 5%   &    �� ImageSource$" ../Resources/Images/user.png��61    j� Stretch$ Uniform=�6\   .@�5'   "   m� -   5         m�Name$ 
RestPwdBtn��5'   +   $��修改密码��6Y   �� 5(   "   m� 5)   "   -   5        $ 	SwitchBtn��5)   +   $��切换用户��6V   �� 5*   "   m� 5+   "   -   5        $ 	LogoutBtn��5+   +   $��退出应用��6W   �� 5,   "   5-      5.      �� 5/      -   5         ��Name$ 
userNameTB��5/   W   $��	10,15,0,0q�6$   $
��Wrap=�67   $	��100��6K   
�������$��Center=�6   $��13(�6�   50      51      �� 52      $��1��6    $��10,4,0,0q�6-   $����我们的目标是让学生更加全面了解自己选择课程的情况，并能提供简单的交流分享心得的功能，帮助学生收集其他人对于课程的不同看法和感受。��6?   $
��Wrap=�53       �� 
LineHeight$ 20��6/   $��13(�6?   ���#cfdbdc J� Opacity$ .8Q�6b   $	��300��6o   $
��Left=�6{   54      55      �� 57      $��1��6   $ Vertical=�6&   $��80,40,80,40q�6=   .+�58      �� -   5           MaterialDesignRaisedButton#���   58   7   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6l   $��0,20,0,0q�59      $��60��6)   $	��200��65   ���#ffcc80���#ffcc80.��5:      �� $��课程收藏夹��6    $��20(�6-   ���#2121216;   5;      �� 5<      -   5        #���   5<   6   $ Depth5=�6k   $��0,20,0,0q�5=      $��60��6+   $	��200��67   ���#ffcc80���#ffcc80.��5>      �� $��查询课程��6    $��20(�6,   ���#2121216:   5?      �� 5@      -   5        #���   5@   3   $ Depth5=�6h   $��0,20,0,0q�5A      $��60��6+   $	��200��67   ���#ffcc80���#ffcc80.��5B      �� $��个人主页��6    $��20(�6,   ���#2121216:   5C      5D      5E      5F      5G      