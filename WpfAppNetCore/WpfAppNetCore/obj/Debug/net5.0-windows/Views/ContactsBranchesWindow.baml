   M S B A M L   `   `   `  ����H  DWpfAppNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfAppNetCore.ViewsWpfAppNetCore.Views  5   	   0    *WpfAppNetCore.Views.ContactsBranchesWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfAppNetCore.Views     5   	   -   5          � Title$  ContactsBranches Edit��5   	   $	��250��6'   $	��500��64   .��5	      � -   5         �Name$ mainGrid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��WebSite��6   $��Center=�5      $��Center=�5      $��1��5      $��20(�5      $��Times New Roman)�5       �� Target 5      ��  �� ElementName$ TBox_WebSite�� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5!      �� 5"   
   $��Number Phone��6   $��Center=�5#      $��Center=�5$      $��1��5%      $��1��5&      $��20(�5'      $��Times New Roman)�5(       5)      �� $ 
TBox_Phone�� 5*        5+      5-      �� 5.   
   $��	Branch ID��6   $��Center=�5/      $��Center=�50      $��1��51      $��2��52      $��20(�53      $��Times New Roman)�54       55      �� $ TBox_BranchId�� 56        57      59      �� 5:   
   -   5         ��Name$ TBox_WebSite��5:      $��2��5;      $��0��5<      $
��5,10q�5=      .��6    5>      �� 5?   
   -   5        $ 
TBox_Phone��5?      $��2��5@      $��1��5A      $
��5,10q�5B      .��6    5C      �� 5D   
   -   5        $ TBox_BranchId��5D      $��2��5E      $��2��5F      $
��5,10q�5G      .��6    5H      �� 5I   
   -   5         ��Name$ Btn_Ok��5I      $	��Add��5J      $��Center=�5K      $��Center=�5L      $	��120��5M      $��30��5N      $��16(�6   $��Normal"�6+   $��Normal$�6?   $��3��6R   $��1��6_   ��5O      �� *SaveCommand+5P      5R      5S      