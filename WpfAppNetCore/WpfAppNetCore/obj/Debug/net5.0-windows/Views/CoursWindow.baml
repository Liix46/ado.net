   M S B A M L   `   `   `  ����H  DWpfAppNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfAppNetCore.ViewsWpfAppNetCore.Views  5   	   %    WpfAppNetCore.Views.CoursWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfAppNetCore.Views     5   	   -   5          � Title$  
Cours Edit��5   	   $	��250��6   $	��650��6)   .��5	      � -   5         �Name$ mainGrid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Count Hours��6   $��Center=�5      $��Center=�5      $��1��5      $��20(�5      $��Times New Roman)�5       �� Target 5      ��  �� ElementName$ TBox_CountHours�� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5!      �� 5"   
   $��Describe��6   $��Center=�5#      $��Center=�5$      $��1��5%      $��1��5&      $��20(�5'      $��Times New Roman)�5(       5)      �� $ TBox_Describe�� 5*        5+      5-      �� 5.   
   $��Name Courses ID��6   $��Center=�5/      $��Center=�50      $��1��51      $��2��52      $��20(�53      $��Times New Roman)�54       55      �� $ TBox_NameCoursesId�� 56        57      59      �� 5:   
   $��Subjects ID��6   $��Center=�5;      $��Center=�5<      $��1��5=      $��3��5>      $��20(�5?      $��Times New Roman)�5@       5A      �� $ TBox_SubjectsId�� 5B        5C      5E      �� 5F   
   -   5         ��Name$ TBox_CountHours��5F      $��2��5G      $��0��5H      $
��5,10q�5I      .��6    5J      �� 5K   
   -   5        $ TBox_Describe��5K      $��2��5L      $��1��5M      $
��5,10q�5N      .��6    5O      �� 5P   
   -   5        $ TBox_NameCoursesId��5P      $��2��5Q      $��2��5R      $
��5,10q�5S      .��6    5T      �� 5U   
   -   5        $ TBox_SubjectsId��5U      $��2��5V      $��3��5W      $
��5,10q�5X      .��6    5Y      �� 5Z   
   -   5         ��Name$ Btn_Ok��5Z      $	��Add��5[      $��Center=�5\      $��Center=�5]      $	��120��5^      $��30��5_      $��16(�6   $��Normal"�6+   $��Normal$�6?   $��3��6R   $��3��6_   ��5`      �� *SaveCommand+5a      5b      5c      