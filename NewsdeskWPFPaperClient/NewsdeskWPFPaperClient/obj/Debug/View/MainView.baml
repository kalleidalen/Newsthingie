   M S B A M L   `   `   `  ����Q  MNewsdeskWPFPaperClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NewsdeskWPFPaperClient.ViewNewsdeskWPFPaperClient.View  5   	   S.clr-namespace:NewsdeskWPFPaperClient.ViewModel NewsdeskWPFPaperClient.ViewModel  5   	   O,clr-namespace:NewsdeskWPFPaperClient.UtilityNewsdeskWPFPaperClient.Utility  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions'Microsoft.Expression.Interactivity.Core 5   	   *    $NewsdeskWPFPaperClient.View.MainView   5   	   2View)clr-namespace:NewsdeskWPFPaperClient.View  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   =vm.clr-namespace:NewsdeskWPFPaperClient.ViewModel     5   	   @Utility,clr-namespace:NewsdeskWPFPaperClient.Utility     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   oei`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions     5   	     � Title$  MainView��5   	   $	��700��6   $	��900��6'   $	��900��63    � DataContext 5
      4   .NewsdeskWPFPaperClient.ViewModel.MainViewModel  5   
    � 	Resources 5         	BoolToVis  
NewsHeader �� 
TargetType �� Property �� Value  NewsPreamble  NewsPreambleOnArticle��%�  &	        &	      &	 �     &	 �    �� 5   
   6'   �� 5   
   " ��6#   .�5      ��  � ��$ georgia,serif)�6+   �� 5       � ��$
 30px(�6)   �� 5       �@��Padding$	 8,4q�6(   �� 5       � ��$ 4q�6'   5      �� 5   
   " ��6%   .�5      ��  � �� �#0064a76+   �� 5       � ��$ georgia,serif)�6+   �� 5       � ��$
 14px(�6)   �� 5       �@��Padding$ 8,0,0,0q�6(   �� 5       � ��$ 	4,-10,0,0q�6'   5      �� 5   
   " ��6.   .�5      ��  � ��$ georgia,serif)�6+   �� 5       � ��$
 14px(�6)   �� 5        �@��Padding$ 8,0,0,0q�6(   �� 5!       � ��$ 	4,-10,0,0q�6'   5"      5#      .��5$      �  � ColumnDefinitions 5%   
   �� 5&      $
��149* �6   �� 5'      $	��70* �6    � RowDefinitions 5)   
   �� 5*      $	��24* �6   �� 5+      $	��50* �6   �� 5,      $	��62* �6   �� 5-      $
��223* �6   �� 5.      $
��510* �6   .+�50   
   �� $��0��6   $��2��6"   $��2��66   .+�51      �� $0��*pack://application:,,,/Images/daggnatt.jpg��6   52      � 54   
   $��3��6   $��1��6"    � Orientation$ 
Horizontal=�62   $��Right=�6K   $��2��55      $	��220��6'   $��0,0,20,0q�63   y�56      �� *ArticleListVisibility+	 �� 	Converter#	 [  .+�57      �� 
���   �$	��220��6+   $��2q�58      $��SENASTE NYTT��6'   .��59      � .+�5:      �� ���	#0B000000$	��220��6�   ��6   �� *ArticleListTopFive+
 �� SelectedItem
 6I   �� *SelectedArticle+.  (System.Windows.Interactivity.Interaction   Triggers 5;      /  )System.Windows.Interactivity.EventTrigger  5<         	EventName$ PreviewMouseDown��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5=   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 5>   "   ��  �� RelativeSource ��  �� AncestorType" �� �� Path$' !DataContext.TopFiveMenuButtonDown�   CommandParameter 5?   "   ��  �� ElementName$ boxCategoryList��5@      ��5B      �� 5C      .R�5D   "   � .+�5E   &   �� ��60   �� $ UpdatedDate� �� StringFormat$ HH:mm���� 5F   &   $�� ��60   6;   �� 5G   &   ��60   �� *Title+5I   #   5K      5M      5O      5P      5Q      � 5R   
   $��4��6   $��1��6"   $ 
Horizontal=�62   $��Right=�6K   $��2��6g   $	��220��6x   $��0,0,20,0q�6�   y�5S      �� *ArticleListVisibility+#	 [  .+�5T      �� 
���   �$	��220��6+   $��2q�5U      $��Vill du bli prenumerant?��6'   .��5V      � .+�5W      �� $��1��6   $��2��6/   
���   �$��0q�5X      $��Välj kategori��6'   .��5Y      �� .+�5Z      �� $	��177��6T   $	��190��6a   $
��Left=�6m   $	��Top=�6�   ���	#0B000000��6"   �� *CategoryList+ �� Mode$ TwoWay=���5[      �� 5\   "   .R�5]   *   ��  ��Name$ chkBox��5^   3   ��5]   3   �� *Name+
 � Tag 5^   C   �� *Id+ d� 	IsChecked 6V   �� *CategoryList.IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=���5_   $   ��  �� " ��$ DataContext.ChangeState�$ TwoWay=���5`   $   �� $ chkBox��5a   #   5c      �� 5e      .+�5f   "   �� $��Ange din e-postadress��6,   $	��200��6I   6W   �� 5g   "   $��0,0,0,5q�6f   ��6*   �� *Email+$ PropertyChanged=�6y   �� 5h   "   $��Skapa prenumeration��6)   $��0,0,0,5q�6p   ��6G   �� *RegisterAsSubscriber+6�   �� 5i   "   $��Avbryt prenumeration��6)   ��6H   �� *UnRegisterAsSubscriber+6u   5j      5k      5m      5n      5o      5q      � 5r   
   $ 
Horizontal=�6   $��2��6-   $	��900��6:   $��2��6F   $��0,0,-8,0q�6Z   .+�5�      �� -   5        $��boxCategoryList��5�       �� DisplayMemberPath$
 Name��6S   $��0,1,0,1q�5�   @   
�������$��0,5,0,5q�6r   ��5�   .   �� *CategoryList+
 5�      �� *SelectedCategory+ 5�        5�      $ PreviewMouseDown��6%   . 5�         5�   "   ��  �� " ��$  DataContext.MenuButtonDown� 5�   "   �� $ boxCategoryList��5�      ��5�      �� 5�      " ��6   .�5�      ��  � ��$ 	22,0,23,0q�63   5�      ��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�6%   5�      5�      5�      � 5�   
   $ 
Horizontal=�6   $
��Left=�6-   $��3��6H   $	��900��6U   $��2��5�      $��0,0,-8,0q�6(   $��2��6:   y�5�   b   �� *ArticleListVisibility+#	 [  .+�5�      � .+�5�      ��  �� SelectedIndex$ -1��5�      $��0q�6%   
���   ���5�      �� *ArticleList+
 6?   �� *SelectedArticle+��5�      �� 5�      .R�5�      �� .+�5�   "   �� #��[ 6C   ��6,   �� *Title+6C   �� 5�   "   #��[ 6F   ��6,   �� *
Preamble+6F   �� 5�   "   
�������$��0,0,0,1q�6A   ._�5�   &   �� $	��600��61   6?   5�   #   5�      5�      5�      5�      5�      � 5�   
   $ 
Horizontal=�6   $��3��6-   $	��800��6:   $��2��6�   $��146,0q�6�   $��2��6�   y�6F   �� *ArticleVisibility+#	 [  .+�5�      �� -   5         ��Name$ MyScrollViewer��5�      $
��Auto=�63   $
��Auto=�5�      .��5�      � $ Vertical=�6   $
��Left=�63   .+�5�      �� #��[ 6G   ��6    �� *SelectedArticle.Title+6G   �� 5�      #��[ 6J   ��6    �� *SelectedArticle.Preamble+6J   (  "System.Windows.Controls.WebBrowser  5�      $	��500��6w   $	��650��6�   6   0NewsdeskWPFPaperClient.Utility.WebBrowserUtility   BindableSource 6!   �� $! SelectedArticle.ArticleBody�6�   5�      5�      5�      5�      5�      