   M S B A M L   `   `   `  ����F  BPractica4.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Practica4._1.ComponentsPractica4._1.Components  5      .    (Practica4._1.Components.OperationControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Practica4._1.Components     5      $��40��5   "   $��40��6.   $	��975��6=   $	��975��6L   $	��450��6X   .��5	      � .+�5
   
   ��   �� Orientation$  
Horizontal=�6   .+�5      �� -   5         ��Name$ Trash��5       $   delete_1_svgrepo_comDrawingImage#��[  6#   $��25��6z   $��25��6�   $��	10 0 20 0q�6�   6�   �� 5      -   5         ��Name$ NumberTb��5      $��50��6*    �� TextAlignment$
 Left=�65   $��20(�6J   $��Center=�6X   $
��Bold"�6s   16�   �� 5      -   5         ��Name$ NameTb��5      $��25��6A   $	��200��6M   $��0 0 5 0q�6Y   ��6&   �� *	Operation+.��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61    �� 
TargetType" ��6    �� 	Resources 5        CueBannerBrush j� 
AlignmentX j� 
AlignmentY	 j� Stretch
 !� Visual��%�   &	       !� 5      $
 Left=�6A   $ Center=�6S   $
	 None=�6g   
 5   "   �� 5   &   $/��)Наименование операции��6,   ���	#FF909090$��DemiBold"�6c   5      5       �� Triggers 5      P� 5       P� Property � �� �� Empty P� Value# Z 66   . �5   "   ��  �� Property � �� �� Value# [ 6?   5      P� 5       � �� 66   Z� . �5   "   ��  � ��# [ 6?   5      P� 5       �@J�IsKeyboardFocused . . �5   "   ��  � ��
 �����6?   5       5"      .��5#   !   5$      �� 5%      -   5         ��Name$ TypeEquipmentCb��5%       �� DisplayMemberPath$
 Name��6W   $��25��6p   $	��150��6|   $��5 0 5 0q�6�    �� SelectedItem 60   �� *TypeEquipment+6�   �� 5&      -   5        $ TimeTb��5&      $��25��6U   $��50��6a   ��6&   �� *
Duration+ �� StringFormat$ hh\:mm��.��6�   ��5'      1&clr-namespace:System;assembly=mscorlibSystem 5(   1   �� 6   6sys&clr-namespace:System;assembly=mscorlib     61   " ��6    5)      ��%�   &	       !� 5*      $
 Left=�6A   $ Center=�6S   $
	 None=�6g   
 5+   "   �� 5,   &   $��	ЧЧ:ММ��6,   ���	#FF909090$��DemiBold"�6S   5.      5/       50      P� 51       � ��# Z 66   . �52   "   ��  � ��# [ 6?   53      P� 54       � �� 66   Z� . �55   "   ��  � ��# [ 6?   56      P� 57       �@J�IsKeyboardFocused . . �58   "   ��  � ��
 �����6?   59      5;      .��5<   !   5=      5>      5?      5@      