   M S B A M L   `   `   `  ����T  PCourseInfoSharingPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:CourseInfoSharingPlatform.Converters$CourseInfoSharingPlatform.Converters  5   	   7    1CourseInfoSharingPlatform.Views.SimilarCourseView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:CourseInfoSharingPlatform.Converters     5   	     � Title$  SimilarCourseView��5   	   $	��650��6$   $	��500��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � AllowsTransparency . ��6[   Z�  � 	Resources 5      9  3CourseInfoSharingPlatform.Converters.ScoreConverter 
  scoreC7  1CourseInfoSharingPlatform.Converters.CNoConverter  cnoC9  3CourseInfoSharingPlatform.Converters.CTYpeConverter 
 ctypeC?  9CourseInfoSharingPlatform.Converters.TeacherNameConverter  tnC;  5CourseInfoSharingPlatform.Converters.LikeNumConverter  likeNumC;  5CourseInfoSharingPlatform.Converters.HeatNumConverter  heatNumC��%�   &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6     5   
   6     5   
   6     5   
   6%     5   
   6!     5   
   6!   5      .��5      �� -   5        $��5q�5      ���#fbe8e7 �� CornerRadius$ 10��6-    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6   	   ShadowDepth$	 0Q�6,   
   Opacity$	
 0.3Q�6<      	Direction$ 0Q�6J   ._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��80 �6    �� 5      �� 5      $��20 �6    .+�5      �� -   5        $��0��5      $��	0,10,10,0q�68     BackBtnTemplate#��[ 6K   $��30��6w   $��30��6�   $	��Top=�6�   $��Right=�6�   ���#263238$	����5    0   �� 5!      $��1��6   ._�5"      �� $-��'收藏了该课程的学生还收藏了��6   ���#ffa000$��25(�6F   $	��Top=�6U   $��Center=�6m   5#      �� 5$      -   5         ��Name$ 
courseList��5$   (   $��2��6   ��5%      �� 5&      .R�5'      ��  �� Orientation$ Vertical=�6%   $��20,-20,20,0q�6<   5(      ��5*      �� 5+      .R�5,      �� $��0,10,0,0q�6"   $	��128��64   $ 10��6A   
����ح����#EEE$��0,0,0,3q�6~   ._�5-      �  5.   "   �� 5/   &   $��5* �64   �� 50   &   $��4* �64   �� 51   &   $��3* �64   .+�53   "   �� $ 
Horizontal=�6-   .+�54   &   �� $��Black"�6w   $	��150��6�   $��18(�6�   $��20 0 0 0q�6�   $��Center=�6�   ��60   �� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 55   &   $��80��6i   $��	200,0,0,0q�6t   ���#ff3d00$��16(�6�   $��Center=�6�   ��60   �� *Score+ �� 	Converter# [  6�   56   #   �� 57   "   $��1��6-   $ Vertical=�6:   $��
370,-5,0,0q�6R   .+�58   &   �� ���#fb8c00$��12(�6�   $��Center=�6�   ��60   �� *	HeatNum+# [ 6�   �� 59   &   $��0,5,0,0q�6m   ���#fb8c00$��12(�6�   $��Center=�6�   ��60   �� *	LikeNum+# [ 6�   5:   #   �� 5;   "   $��2��6-   $ 
Horizontal=�6:   $��
380,0,3,10q�6T   .+�5<   &   �� -   5        #��[ 5<   -   $	����6Y   $��18(�6l   ���#ff9800$��Center=�6�   6�   �� 5=   &   $��详情��60   $��Center=�6:   $��12(�6U   $��2,0,0,0q�6c   5>   #   �� 5?   "   $ 
Horizontal=�6-   $��Center=�6F   $��1��6a   .+�5@   &   �� $��10(�6k   $��20,0,0,0q�6y   ��61   �� *
CourseId+# [ 6y   �� 5A   &   $��10(�6h   $��10,0,0,0q�6v   ��60   �� *Type+# [ 6v   �� 5B   &   $��10(�6m   $��10,0,0,0q�6{   ��61   �� *TeacherName+# [ 6{   5C   #   �� 5D   "   $��2��6L   ��6/   �� *tags+��5E   &   �� 5F   *   .R�5G   .   �� $ 
Horizontal=�69   $��15,0,0,0q�6R   5H   +   ��5J   &   �� 5K   *   .R�5L   .   �� ���#EEE$	��5,5q�6G   $ 5��6V   ._�5M   2   �� ���#607d8b$
��12,3q�6j   ��6<   �� *Detail+6j   5N   /   5O   +   5Q   #   5R      5S      5T      5V      5W      5X      5Y      