   M S B A M L   `   `   `  ����F  BPractica4.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Practica4._1.PagesPractica4._1.Pages  5          Practica4._1.Pages.Sech   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Practica4._1.Pages     5        N� Title$
  Sech��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��68* �6   .+�5   
   � $��0��6   .+�5      �� $��Center=�6    �� Orientation$ 
Horizontal=�64   .+�5      �� $��24(�6   ���	#FFBB0C07$
��Bold"�6A   $��	30 0 20 0q�6S   Цех6k   �� 5      -   5         ��Name$ 
WorkshopCb��5       �� DisplayMemberPath$
 Name��6/   $	��200��6H   6�   5      �� 5      $ 
Horizontal=�6   $��Center=�62   $��Right=�6M   .+�5      �� -   5         ��Name$ ClearBtn��5         StilyzedButton#��[  6+   $	��100��6S   $��0 0 30 0q�6_   .��6�   Очистить6�   �� 5      -   5        $ SaveBtn��5      #��[  6*   $	��200��6R   $��0 0 30 0q�6^   .��6�   '%Сохранить изменения6�   5      5      �� 5   
   -   5         ��Name$ canvas��5      $��1��6!   $��10q�6.   z�5      V� 5      .~�5       �� -   5        scaleTransform��5    %   T� 5!      -   5        translateTransform��5!   )   5"      .+�5$      �� -   5         ��Name$ Origin��5$      
���  ��$��1��63   $��1��6=    �� Left$	 350��6H   
	 �� Top$		 250��6Z   6m   �� 5%      -   5        $��	PlanImage��5%      
 J� 	AllowDrop
 . $��10q�67   $	��500��6C   $	��800��6S   5&      �� 5(   
   -	   5         ��Name$ MyFilterPanel��5(       J� RenderTransformOrigin$ 0.5,0.5&�6-   $y�Visible=�6M   
�������$��Right=�6u   $	��200��6�   $��0 5 0 0q�6�   $��1��6�   z�5)      T� 5*      -
   5        myTranslateTransform��5*   E    J� Effect 5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-         	Direction$	 221Q�6#      
BlurRadius$ 20Q�63      ShadowDepth$ 5Q�6C      Color$ 	#FFACACAC��6S   6g   .+�50      �� $	��Top=�6   $��Center=�61   $	��180��6N   .+�51      �� $
��Auto=�6   $	��470��6B   $��5 5 0 0q�6O   $��Disabled=�6`   .��52      � -   5         �Name$ 	ItemPanel��52       65   53      54      55      56      57      