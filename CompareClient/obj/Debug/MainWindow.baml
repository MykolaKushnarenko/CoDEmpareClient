   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    	CoDEmpare   TextGUIModule.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3system&clr-namespace:System;assembly=mscorlib  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
CoDEmpaire��5   	   $	��600��6   $��900         ��6)    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�6!    � WindowStyle$
 None=�6F    � 	Resources 5       �� MergedDictionaries �� Source  MenuOpen	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose�� 5   
    5      �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %�  &	       &	 �     �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 GridMenu��6e   .\�5        $ 0��6+   $ 51Q�67     5      $ 	0:0:0:0.5��6+   $	 200Q�6?   5      5      �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 GridMenu��6e   .\�5         $ 0��6+   $	 200Q�67     5!      $ 	0:0:0:0.5��6+   $ 51Q�6?   5"      5#      5$       � Triggers 5'      :� 5(   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ OpemMenuButton��66   .[�5)      �� #��[ 6   5*      :� 5+   
   $ ButtonBase.Click��6   $ CloseMenuButton��66   .[�5,      �� #��[ 6   5-      .��5/      � .+�50   
   � -   5         �Name$ Title��50      $��50��6   $	��Top=�6*   ���	#FF4D0080.+�51      �� $��	CoDempare��6   $��Center=�6)   $��Center=�6F   $��24(�6a   $(��"/CoDEmpare;component/Fonts/#HACKED)�6o   �� 52      $��Center=�6    �� Orientation$ 
Horizontal=�64   $��Right=�6M   .+�54      '  !MaterialDesignThemes.Wpf.PopupBox  $��10q�6+      PlacementMode$ BottomAndAlignRightEdges=�67      	StaysOpen .     PopupContent. 55      �� $	��150��6!   .+�56      �� -   5         ��Name$ AccountInfo��56   !   $��Account��66   6H   �� 57      $��Setting��6!   �� 58      -   5        $ HelpButt��58   !   $
��Help��63   6B   �� 59      �� 5:      -   5        $ loOutBut��5:   !   $��Logout��63   6D   5;      5<      5>      5?      �� 5@   
   $	��545��6   $
��1028��6"   $��Bottom=�6/   $��Right=�6J   .+�5A      � -   5        $ GridContentAction��5A      $
��auto��6.   5B      � 5C   
   -   5        $ GridMenu��5C      $��51��6!   $
��Left=�6,   ���	#FF4D0080.+�5D      �� .+�5E      � $	��150��6   #���  6$   .+�5F      �� -   5        $ CloseMenuButton��5F      $��60��66   $��60��6A   $	��Top=�6z   $��Right=�6�   $y�	Collapsed=�6�   ��6M   Z� ��6c   Z� .��5G      '  !MaterialDesignThemes.Wpf.PackIcon  
����+���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowLeft=�6J   $��25��6[   $��25��6f   5H      �� 5I      -   5        $ OpemMenuButton��5I      $��60��65   $��60��6@   $	��Top=�6y   $��Right=�6�   ��6L   Z� ��6b   Z� .��5J        
����+��$
 Menu=�6J   $��25��6V   $��25��6a   5K      �� 5L      -	   5         ��Name$ 	UserPhoto��5L   !   $��20q�64   $y�	Collapsed=�6@   .+�5M      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 80Q�6.   $��85��6H   $��85��6T   $	��Top=�6_   $
��Left=�6w   .��5N      �� -
   5         ��Name$ ProfilImage��5N   $   $��70��69   $��70��6D   $4��.Мангеке_Шаринган_Саске.ico��6P   5O      �� 5P      -   5         ��Name$ NameUser��5P   $   $��Nicholas Kushnarenko��67   $(��"/CoDEmpare;component/Fonts/#HACKED)�6S   $��16(�6�   $��0 10 0 0q�6�   5Q      5S      5T      � 5U      $��	0 150 0 0q�6   $
��Left=�6&   $	��200��6A   .+�5V      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitionContentSlide��5V   6   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6V   D	  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension	  *SlideInFromLeft+ 	  Duration$ 0:0:0.2X�.��5W      � -   5        $ GridSelection��5W      $��10��62   $��75��6=   
��� ���$
��Left=�6\   $	��Top=�6w   5X      �� 5Y      -   5         ��Name$ ListViewMenu��5Y   '   $	��200��6   .@�5Z      �� $��75��6#   $��
0 10 10 10q�6/   .��5[      �� $ 
Horizontal=�6%   .+�5\        $
 File=�66   $��55��6B   $��55��6M   $��0q�6Y   �� 5]      $��Добавить файл��6(    �� TextAlignment$ Center=�6=   $��Center=�6T   $��Center=�6o   5^      5_      �� 5`      $��75��6#   $��
0 10 10 10q�6/   .��5a      �� $ 
Horizontal=�6%   .+�5b        $ DatabaseSearch=�66   $��55��6L   $��55��6W   �� 5c      $$��Добавить и найти��6(   $ Center=�6@   $��Center=�6W   $��Center=�6r   5d      5e      �� 5f      $��75��6#   $��
0 10 10 10q�6/   .��5g      �� $ 
Horizontal=�6%   .+�5h        $ Database=�66   $��55��6F   $��55��6Q   �� 5i      $��Поиск с базы��6(   $ Center=�6<   $��Center=�6S   $��Center=�6n   5j      5k      �� 5l      $��75��6#   $��
0 10 10 10q�6/   .��5m      �� $ 
Horizontal=�6%   .+�5n        $ History=�66   $��55��6E   $��55��6P   �� 5o      $��История��6(   $ Center=�67   $��Center=�6N   $��Center=�6i   5p      5q      5r      5s      5u      5v      5w      