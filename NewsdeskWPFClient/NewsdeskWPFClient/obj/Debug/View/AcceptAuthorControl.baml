   M S B A M L   `   `   `  ����L  HNewsdeskWPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NewsdeskWPFClient.ViewModelNewsdeskWPFClient.ViewModel  5      0    *NewsdeskWPFClient.View.AcceptAuthorControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8vm)clr-namespace:NewsdeskWPFClient.ViewModel     5      
�������  � DataContext  5	      7   1NewsdeskWPFClient.ViewModel.AcceptAuthorViewModel  5
   
   .��5      � .+�5   
   �� -   5         ��Name$ boxNewAuthors��5       �� SelectedIndex$ -1��5      
���   ���5   *   �� *
AuthorList+��5      �� 5      .R�5      � .+�5      �� $��Namn: ��6$   �� 5      $
��Bold"�6>   ��6$   �� *
FullName+6>   �� 5      $��, ��6$   �� 5      $��
Godkänn: ��6$   �� 5       ��Name$ chkBox��6#    d� 	IsChecked 64   �� *
IsSelected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5   $   ��  �� RelativeSource ��  �� AncestorType" ��	 �� Path$	 DataContext.ChangeState���5   $   �� 
 �� ElementName$
 chkBox��
 � Tag 6T   �� *Id+5      5      5      5      5       