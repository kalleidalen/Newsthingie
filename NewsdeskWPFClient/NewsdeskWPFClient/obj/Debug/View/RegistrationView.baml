   M S B A M L   `   `   `  ����L  HNewsdeskWPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NewsdeskWPFClient.ViewModelNewsdeskWPFClient.ViewModel  5   	   -    'NewsdeskWPFClient.View.RegistrationView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8vm)clr-namespace:NewsdeskWPFClient.ViewModel     5   	     � Title$  Registration��5   	   $	��387��6   $	��528��6+   
���   � � DataContext 5      7   1NewsdeskWPFClient.ViewModel.RegistrationViewModel  5   
   .��5      � $	��350��6   $	��525��6   
�������.+�5   
   �� -   5        $��textBlockHeading��5   M   $��23��6   $
��Left=�6    $��10,5,0,0q�6;   $��Skapa konto:��5   
   $	��Top=�6   $	��110��66   $��17(�6C   $��ExtraCondensed&�6Q   �� 5   
   $��451,5,12,288q�6   $��Login��6'    � Cursor$
 Hand��6T   ��67   �� *
OpenLink+��5      �� 5       �� 
TargetType" ��6"   .R�5      �� $��	Underline{�6    �� 5      5      5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��  �63    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver	 P� Value	 . . �5      ��  � ��
 �  ��6;   5      5      5       � 5!   
   $��
31,0,29,23q�6   
�������$	��264��66   $��Bottom=�6C   
 � RowDefinitions
 5"      �� 5#      $
��252* �6    .+�5%      �� -   5         ��Name$ lblErrorMessage��5%   Q   $��20��6   $
��Left=�6$   $��47,0,0,0q�6?   $	��Top=�5&      $	��408��64    J� OpacityMask
 �<�����	#FFE5572C��6n   �� *ErrorMessage+ �� UpdateSourceTrigger$ PropertyChanged=��� 5(      -   5        $��lblFirstName��5(   R   $��23��6   $
��Left=�6$   $��	67,20,0,0q�6?   $��	Förnamn:��5)      $	��Top=�6,   $	��110��6D   �� 5+      -   5        $��lblLastName��5+   R   $��23��6   $
��Left=�6$   $��	67,50,0,0q�6?   $��
Efternamn:��5,      $	��Top=�6.   $	��110��6F   �� 5.      -   5        $��lblEmail��5.   R   $��23��6   $
��Left=�6$   $��	67,80,0,0q�6?   $��E-post:��5/      $	��Top=�6+   $	��110��6C   �� 51      -   5        $��lblPassword��51   S   $��23��6   $
��Left=�6$   $��
67,107,0,0q�6?   $��
Lösenord:��52      $	��Top=�6-   $	��110��6E   �� 54      -   5        $��lblConfirmPassword��54   S   $��23��6   $
��Left=�6$   $��
67,136,0,0q�6?   $��Bekräfta lösenord:��55      $	��Top=�66   $	��110��6N   $��2��6Z   �� 57      -   5        $��txtFirstName��57   Q   $��23��6   $
��Left=�6"   $��
183,20,0,0q�6=   $	��Top=�58      $	��222��62   ��6>   �� *	FirstName+�� 5:      -	   5        $��txtLastName��5:   Q   $��23��6   $
��Left=�6"   $��
183,50,0,0q�6=   $	��Top=�5;      $	��222��62   ��6>   �� *
LastName+�� 5=      -
   5        $��txtEmail��5=   Q   $��23��6   $
��Left=�6"   $��
183,80,0,0q�6=   $	��Top=�5>      $	��222��62   ��6>   �� *Email+G� 5@      -   5        $��passwordBox��5@   V   $��23��6   $
��Left=�6&   $��183,107,0,0q�6A   $	��Top=�5A      $	��222��66   0   *NewsdeskWPFClient.ViewModel.PasswordHelper   Attach .    Password 6b   �� *
Password+ �� Mode$ TwoWay=�G� 5C      -   5        $��passwordBoxConfirm��5C   V   $��23��6   $
��Left=�6&   $��183,136,0,0q�6A   $	��Top=�5D      $	��222��66    .  6b   �� *ConfirmPassword+$ TwoWay=��� 5G      -   5        $��	btnSubmit��5H      $��Skicka��5G      $��23��6&   $
��Left=�62   $��244,204,0,0q�6M   $	��Top=�5H   *   $��70��6B   ��6M   �� *Submit+�� 5J      -   5        $��	btnCancel��5K      $��Avbryt��5J      $��23��6&   $��Right=�62   $��
0,204,60,0q�6N   $	��Top=�5K   *   $��70��6B   ��6M   �� *Cancel+5L      5M      5N      