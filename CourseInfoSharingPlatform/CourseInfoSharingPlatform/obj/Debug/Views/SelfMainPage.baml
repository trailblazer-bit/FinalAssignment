   M S B A M L   `   `   `  ����T  PCourseInfoSharingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CourseInfoSharingPlatform.ViewsCourseInfoSharingPlatform.Views  5   	   2    ,CourseInfoSharingPlatform.Views.SelfMainPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   9local-clr-namespace:CourseInfoSharingPlatform.Views  5   	     � Title$  我的主页��5	   	   $	��650��6   $	��450��6#    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.    � AllowsTransparency . ��6[   Z� .��5      �� -   5        $��5q�5      ���#eceff1 �� CornerRadius$ 10��6-    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      ShadowDepth$ 0Q�6,   	   Opacity$		 0.3Q�6<   
   	Direction$
 0Q�6J   ._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��50 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      .+�5      �� -   5           BackBtnTemplate#��[  5      $��	0,10,10,0q�6W   $	����6j   
���   �$��20(�6�   $	��Top=�6�   $��Right=�6�   �� 5      $��1��6   $��20,0,0,0q�6%   $��个人主页��67   $
��Left=�6C   $	��Top=�6^   $��Black"�6v   $��22(�6�   �� 5      $��1��6   $��0,30,0,0q�6#     MaterialDesignDivider#���  65   $��2��6j    J� Opacity$ .5Q�6u   $��Stretch=�6�    J� SnapsToDevicePixels . 5      �� 5      $��2��6   $��
20,10,20,0q�6&   .+�5      �� -   5         ��Name$ ModifyInfoBtn��5      $��编辑资料��6L   $��0,-10,-10,0q�6[   $��Right=�6p   $��90��6�   $��30��6�   $��14(�6�   ���	#7FB4E1E8
����������	#FF8B8B7B6�   �� 5      -   5        $ PutChangeBtn��5      $��提交修改��6K   $��0,-10,-10,0q�6Z   $��Right=�6o   $	��Top=�6�   $��90��6�   $��30��6�   $��14(�6�   ���	#7FB4E8C0
����������	#FF8B8B7B$y�	Collapsed=�6  �� 5       �� Orientation$ 
Horizontal=�6   $��	20,30,0,0q�66   .+�5       �� $��30,0,0,0q�6   $��昵称��6.   $��15(�6<   $��Center=�6K   $��Center=�6h   ���	#FF5F5F5F6�   �� 5!      $ 5��6   $��30��6/   $��20,0,0,0q�6;   $	��240��6M   $��1q�6Z   
����ح�._�5"      �� -   5         ��Name$ 
userNameTB��5#   )   $��10,0,0,0q�5"   #    �� 
IsReadOnly . $��	啊哈哈��5#      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5$      $��0q�5%      $	��200��5&      $��13(�6-   $��Center=�5'      5(      5)      �� 5*      $ 
Horizontal=�6   $��	20,30,0,0q�66   .+�5+      �� $��30,0,0,0q�6   $��年级��6.   $��15(�6<   $��Center=�6K   $��Center=�6h   ���	#FF5F5F5F6�   �� 5,      $ 5��6   $��30��6/   $��20,0,0,0q�6;   $	��240��6M   $��1q�6Z   
����ح�._�5-      �� -   5        $ gradeTB��5.   *   $��10,0,0,0q�5-   #    . $
��2019��5.      $ Hidden=�5/      $��0q�50      $	��200��51      $��13(�6-   $��Center=�52      53      54      �� 55      $ 
Horizontal=�6   $��	20,30,0,0q�66   .+�56      �� $��30,0,0,0q�6   $��专业��6.   $��15(�6<   $��Center=�6K   $��Center=�6h   ���	#FF5F5F5F6�   �� 57      $ 5��6   $��30��6/   $��20,0,0,0q�6;   $	��240��6M   $��1q�6Z   
����ح�._�58      �� -   5        $ majorTB��58   6   $��10,0,0,0q�6#   $��计算机学院��59       . $ Hidden=�5:      $��0q�5;      $	��200��5<      $��13(�6-   $��Center=�5=      5>      5?      �� 5@      $ 
Horizontal=�6   $��	20,30,0,0q�66   .+�5A      �� $��30,0,0,0q�6   $��性别��6.   $��15(�6<   $��Center=�6K   $��Center=�6h   ���	#FF5F5F5F6�   	� 5B      -   5         	�Name$
 male��5B   H   $��20,0,0,0q�6"    	� 	GroupName$ gender��65   $	��男��6V   $��Center=�6b   $��Center=�6   $��12(�6�   ��.  � UseLayoutRounding . 6�   	� 5C      -	   5        $ female��5C   H   $��10,0,0,0q�6"   $ gender��65   $	��女��6X   $��Center=�6d   $��12(�6   ��.  . 6�   	� 5D      -
   5        $ secret��5D   G   $��10,0,0,0q�6"   $ gender��64   $��保密��6W   $��Center=�6d   $��12(�6    . ��. 6�   5E      5F      � 5G      $��3��6    � ColumnDefinitions 5H      �� 5I      $��5* �6'   �� 5J      $��8* �6'   .+�5L      �� $��0��6   $��40,0,0,0q�6(   $��个人简介��6:   $��15(�6J   $��Center=�6Y   $��Center=�6v   ���	#FF5F5F5F6�   �� 5M      -   5        $ introductionTB��5N      $��1��5M      $��
-15 20 0 0q�6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 什么都没有留下��6>    . $ Hidden=�5O      $��1q�6W   $	��200��6k   $	��150��6w    �� TextWrapping$
 Wrap=�6�   $��Center=�5P      $
��Left=�65   ���#b0bec5$��Visible=�5Q      5R      �� 5T      -   5        $��4��5T      $��Center=�69   $��80��6T     MaterialDesignRaisedButton#���  6_   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6�   $��重置��5U      ���#ffecb3���#ffecb3
���   �6N   5V      5W      5X      