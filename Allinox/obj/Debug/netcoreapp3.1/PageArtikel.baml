   M S B A M L   `   `   `  ����B  >Allinox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AllinoxAllinox  5          Allinox.PageArtikel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Allinox     5        N� Title$  PageArtikel��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $	��168 �6   6+   �� 5      $��50 �6   6*   �� 5      $��27 �6   6*   �� 5      $��30 �6   6*   �� 5      $��25 �6   6*   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   �� 5      $��60 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   �� 5      $	��120 �6   6-   .+�5   
   �� -   5         ��Name$ lblSearchArtikel��5      $��10,0,0,0q�6*   $��0��6<   $��0��6I   $��4��6Y   $��Search Artikel��6m   $
��Left=�6�   $	��Top=�6�   $
��Bold"�6�   �� 5!   
   -   5         ��Name$ 	txbSearch��5!      $��10,0,0,0q�6%   $	��440��67   $��1��6C   $��0��6P   $��4��6`   $
��Left=�6u   $��Search artikel��6�   $	��Top=�6�   6�   &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ 	dgArtikel��5#      $��10,0,0,0q�6&   $	��440��68   $��2��6D   $��0��6Q   $��4��6a   $
��Left=�6u   $	��Top=�6�      AutoGenerateColumns$ False��6�   $   HorizontalScrollBarVisibility$ Disabled=�6�   $��10(�6�      CanUserAddRows$ False��6)  	   CanUserDeleteRows$	 False��6@  
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ artNr��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *artNr+6[     5&      $ artOmschrijving��6%   $	 360 6b    6>   �� *artOmschrijving+6p   5(      �� 5*   
   -   5        $ lblArtikelnr��5*      $��10,0,0,0q�6&   $��3��68   $��0��6E   $��4��6U   $��Seleted Artikel��6i   $
��Left=�6�   $��Bottom=�6�   $
��Bold"�6�   �� 5,   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0��6;   $��4��6K   .+�5-      �� -   5        $ txbArtikelNr��5-      $��10,0,0,0q�6,   $
��Left=�6>   $�� ��6Z    �� TextWrapping$
 Wrap=�6b   $��Bottom=�6v   $��80��6�   ${�False��6�   $
��Bold"�6�   ���#ffdd006�   �� 5.      -   5        $ txbArtikelOmschrijving��5.      $��10,0,0,0q�66   $
��Left=�6H   $�� ��6c   $
 Wrap=�6k   $	��345��6   $��Bottom=�6�   $
��Bold"�6�   ���#ffdd00${�False��6�   5/      �� 51   
   -   5        $ lblArtikelPrio��51      $��10,0,0,0q�6(   $��6��6:   $��0��6G   $��Prio Artikels��6X   $
��Left=�6p   $	��Top=�6�   
����  �$
��Bold"�6�     53   
   -   5        $ dgArtikelPrio��53      $	��100��6*   $��10,0,0,0q�6:   $	��440��6L   $��7��6X   $��0��6e   $��4��6u   $
��Left=�6�   $	��Top=�6�   $ False��6�   $ Disabled=�6�   $��10(�6  $ False��6A  $	 False��6X  
 54        55      $ artNr��6%   $ 80 6N    64   �� *artNr+6[     56      $ artOmschrijving��6%   $	 360 6b    6>   �� *artOmschrijving+6p   58      �� 5:   
   -	   5         ��Name$ btnReset��5:      $��20,0,0,0q�6#   $��11��65   $��0��6C   $��80��6S   $��30��6^   $��Reset��6j   $
��Left=�6z   $	��Top=�6�   6�   �� 5;   
   -
   5        $ btnAdd��5;      $��11��6"   $��1��60   $��2��6@   $��80��6U   $��30��6`   $��Add to prio��6l   $��Center=�6�   $	��Top=�6�   6�   �� 5<   
   -   5        $ 	btnPallet��5<      $��20,0,0,0q�6$   $��11��66   $��3��6D   $��80��6T   $��30��6_   $��Pallet��6k   $
��Left=�6|   $	��Top=�6�   6�   5?      5@      