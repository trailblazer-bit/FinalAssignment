   M S B A M L   `   `   `  ����T  PCourseInfoSharingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CourseInfoSharingPlatform.ViewsCourseInfoSharingPlatform.Views  5   	   ;    5CourseInfoSharingPlatform.Views.MessageBoxSuccessView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:CourseInfoSharingPlatform.Views     5   	     � Title$  MessageBoxSuccessView��5   	   $	��200��5	   	   $	��350��6    � 
ResizeMode$ NoResize=�6"    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.    � AllowsTransparency . ��6[   Z� .��5      �� -   5        $��5q�5      ���#eceff1 �� CornerRadius$ 5��6-    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6      ShadowDepth$ 0Q�6,   	   Opacity$		 0.3Q�6<   
   	Direction$
 0Q�6J   ._�5   
   �  � RowDefinitions 5      �� 5      $��5* �6    �� 5      $��3* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	20,0,40,0q�62   .+�5      �� -   5         ��Name$ imageTB��5      $��40q�6-   
��� � �$	����6M   $��30(�6]   $"��../Resources/Fonts/#iconfont)�6k   $��Center=�6�   �� 5      -   5        $ infoTB��5      $��	-20,5,0,0q�6,   $��Center=�6?   $��Center=�6Z   $��16(�6w   $
��Wrap=�6�   $	��180��6�   $,��&问题中含敏感词汇,无法添加!��6�   5      �� 5      -   5        $��1��5      $��	0,-40,0,0q�6"   
���   �$��Center=�6]   $��80��6x   ���#e0f7fa���#e0f7fa$��Center=�6�   $��确认��6�   5      5      5      