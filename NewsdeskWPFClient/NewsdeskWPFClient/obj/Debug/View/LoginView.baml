   M S B A M L   `   `   `  ����L  HNewsdeskWPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NewsdeskWPFClient.ViewModelNewsdeskWPFClient.ViewModel  5      &     NewsdeskWPFClient.View.LoginView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      8vm)clr-namespace:NewsdeskWPFClient.ViewModel     5      -   5          �Name$  LoginWindow��5       � Title$ Login��5      $	��350��6   $	��525��6   
�������.��5      � .+�5	      �� -   5        $��LoginHeading��5	   F   $��23��6   $
��Left=�6   $��	10,10,0,0q�63   $��Login:��5
      $	��Top=�6   $��17(�62   $��ExtraCondensed&�6@   �� 5      -   5        $��textBlockHeading��5   F   $��50��6   $
��Left=�6   $��	24,48,0,0q�63   $	��Top=�5      $��12(�6$   $��Italic$�62    �� Padding$ 5q�6E   OBS: Du måste logga in.�� 5      .,Om du inte har ett konto kan du klicka här �� 5      �� 6   $��14(�68   $��Normal$�6F    �� Command 6   �� *
Register+.�6Y   Skapa konto6f   6r    för att registrera ett.5      �� 5      -   5        $��lblEmail��5      $��23��5      $
��Left=�6   $��
66,120,0,0q�63   $��Email��5      $	��Top=�6)   $��67��6A   �� 5      -   5        $��lblPassword��5      $��23��5      $
��Left=�6   $��
58,168,0,0q�63   $��Password��5      $	��Top=�6/   $��77��6G   �� 5      -   5        $��txtEmail��5   
   $��23��5      $
��Left=�6   $��118,115,0,0q�62   $	��Top=�5      $	��247��62   ��5   G   �� *
TxtEmail+ �� Mode$ TwoWay=�5   2   G� 5      -   5        $��txtPassword��5   	   $��23��5      $
��Left=�6   $��118,168,0,0q�65   $	��Top=�5      $	��247��64   0   *NewsdeskWPFClient.ViewModel.PasswordHelper   Attach .    Password 5   )   �� *TxtPassword+$ TwoWay=��� 5      -   5        $��btnLogin��5   	   $��Login��5   	   $��23��6   $
��Left=�6%   $��118,211,0,0q�6@   $	��Top=�5      $	��104��61   ��6=   �� *LoginCommand+�� 5!   
   $��65��6   $
��Left=�6    $	��Top=�5"      $	��400��6$   $��
70,253,0,0q�60    J� OpacityMask
 �<�����	#FFE5572C��5!   ;   �� *ErrorMessage+5"   [   5$      5&      