   M S B A M L   `   `   `  ����  NewsdeskWPFClient1    +NewsdeskWPFClient.View.ModifyArticleControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      
�������  � 	Resources  5         	BoolToVis��%   &	        �� 5	   
   6'   5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��0��6#   
���   �$��2q�5      $��Rubrik��6'   .��5      � .+�5      �� $	��280��6   ��6&   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6d   5      5      �� 5   
   $��1��6   $��1��6#   
���   �$��2q�5       $��Ingress��6'   .��5!      � .+�5"      �� $	��280��6   ��6&   �� *
Preamble+$ PropertyChanged=�6g   5#      5$      �� 5%   
   $��1��6   $��2��6#   
���   �$��2q�5&      $��Författare��6'   .��5'      � y�6   �� *
IsApproved+ �� 	Converter# [  .+�5(      �� -   5        $��
boxAuthors��5)      $	��270��5*      $��70��6!    �� DisplayMemberPath$ FullName��5,       �� SelectionMode$ Multiple=�5-      ��5+      �� *	Authors+��5.      �� 5/       �� 
TargetType" ��6    .�50      ��  �� Property �@��
IsSelected	 �� Value	 6;   �� 
 �� Mode$
 TwoWay=� �� Path$ 
IsSelected�51      53      54      55      �� 56   
   $��1��6   $��3��6#   
���   �$��2q�57      $��Kategori��6'   .��58      � .+�59      �� -   5        $��boxCategories��5:       �� SelectedIndex$ -1��6*   $	��270��5;      $��70��6   $
 Name��5=      $ Multiple=�5>      ��5<      �� *
Categories+��5?      �� 5@      " ��6    .�5A      ��  �@��
IsSelected	 6;   �� $
 TwoWay=�$ 
IsSelected�5B      5D      5E      5F      5G      5K      