   M S B A M L   `   `   `  ????F  BDevopsCase4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DevopsCase4.ViewDevopsCase4.View  5           DevopsCase4.View.Customers   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ,localclr-namespace:DevopsCase4.View   5      -   5          >?Name$  ucCustomers??5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??58* ?6   ?? 5      $
??auto ?6   ?? 5      $
??339* ?6   .+?5   
   ? $	??300??6   $
??Left=?6   .+?5      ?? $
??20 0q?6   $??Center=?6&    J? IsHitTestVisible$ False??6A    K? ZIndex$ 1??6Z   
???????6k   ?? 5      -   5         ??Name$ txtSearchBar??5         textboxSearch#??[  6,   .  (MahApps.Metro.IconPacks.PackIconMaterial  5         Kind$ Magnify=?6$   $??15??63   $??15??6>   $??Center=?6J   $??0 0 15 0q?5   %   
???????$??Right=?6J   5      ? 5   
   $??1??6   .+?5      ?? $
??Left=?6   $
??Left=?63   $??	Customers??6I   $??32(?6Z   $??SemiBold"?6h   
???????$??0 0 0 10q?6?   ?? 5      -   5         ??Name$ btnAddCustomer??5        AddCustomer#??[ 6-    ? Cursor$
 Hand??6R   $??5 0 0 0q?6`   ???	#FF462AD8
???????$??Right=?6?   .??5      ??  ?? Orientation$ 
Horizontal=?6   .+?5         $??9??6,   $	??5 0q?66   $
 Plus=?6C   ?? 5!      $??Add Customer??6    66   5"      5#      5$      ?? 5%   
   $??2??6   	 ?? CornerRadius$	 	30 0 10 0??5&      ???	#FF323842._?5'      ?? .+?5(      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 CustomerList??5(   ?   $y?Visible=?6     DataGridStyle1#???  60     DataGridCellStyle1   	CellStyle# ?  6Y     DataGridColumnHeaderStyle2   ColumnHeaderStyle# ?  6?     DataGridRowStyle1   RowStyle# ?  6?   $??30q?6   ? 	Resources 5)       ?? Color??%?  (??       5*   *   * SystemColors.HighlightBrushKey+)(?? )     5,   *   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(?? R     5.   *   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)?? 5*      $ Transparent??5+      ?? 5,      $ Transparent??5-      ?? 5.      $
 Gray??5/      51         Columns 52      4  .System.Windows.Controls.DataGridTemplateColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ #??61      
IsReadOnly$
 True??6<      CanUserResize$ False??6N      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6d      CellTemplate 54      ?? 55   "   .R?56   &   ?? $ 
Horizontal=?61   .+?57   *   ??  K? Capitals$ AllSmallCaps=?64   $??Center=?6W   ??6r   ?? *Id+6?   58   '   59   #   5;        5<      $
 Name??61   $
 True??6?   $ * 6Q    5=      ?? 5>   "   .R?5?   &   ?? $ 
Horizontal=?61   .+?5@   *   ?? $??25??61   $??25??6<   $	 50??6H   $??0 0 10 0q?6Z   
???? ??._?5A   .   ?? $??Center=?6Q   $??Center=?6l   
???????$??0 0 0 1q?6?   ??68   ?? *	Name[0]+6?   5B   +   ?? 5C   *   $??Center=?64   ??6O   ?? *Name+6g   ?? 5D   *   $??Center=?64   $?? ??6O   ?? 5E   *   $??Center=?64   ??6O   ?? *
LastName+6k   5F   '   5G   #   5I        5K      $ Email Address??61   $
 True??6H   $ * 6Z    5L      ?? 5M   "   .R?5N   &   ?? $??Center=?60   ??6K   ?? *Email+6d   5O   #   5Q        5S      $
 City??61   $
 True??6?   $ * 6Q    5T      ?? 5U   "   .R?5V   &   ?? $ 
Horizontal=?61   .+?5W   *   ?? $??Center=?64   ??6O   ?? *City+6g   5X   '   5Y   #   5[        5]      $ #??61   $
 True??6<   $ False??6N   $
 auto 6d    5^      ?? 5_   "   .R?5`   &   ?? $ 
Horizontal=?61   .+?5a   *   ?? $ AllSmallCaps=?64   $??Center=?6W   $??|??6r   6}   5b   '   5c   #   5e        5g      $ Actions??61   $
 True??6B   $ 85 6T    5h      ?? 5i   "   .R?5j   &   ?? $ 
Horizontal=?61   .+?5k   *   ?? $ btnCustomerEdit??61   -   5          Tablebuttons#??[ 5k   J   $
 Hand??6p   
??? ???
???????$??Right=?6?   .??5l   .   ?? .+?5m   2     $	 Pen=?6H   5n   /   5o   +   ?? 5p   *   $ btnCustomerDelete??61   -   5        #??[ 5p   L   $
 Hand??6r   $??5 0 0 0q?6?   
???  ??
???????$??Right=?6?   .??5q   .     $ TrashCan=?6D   5r   +   5s   '   5u   #   5w      5z      ? 5{      -   5         ?Name$ addCustomersField??5{      $y?Hidden=?62   $??30q?6F    5|      ?? 5}      $
??auto ?6(   ?? 5~      $
??auto ?6(   ?? 5      $
??auto ?6(   ?? 5?      $
??auto ?6(   .+?5?      ?? $??0??6!   $	??0 5q?6.   $ 
Horizontal=?6;   .+?5?      ?? $ Vertical=?6%   .+?5?      ?? $??Name:??6)     AddCustomerTextBlock#??[ 66   6f   ?? 5?      -   5        $ txtAddCustomerName??5?   &     AddCustomerInput#??[ 6B   5?      ?? 5?      $ Vertical=?6%   .+?5?      ?? $??	Lastname:??6)   #??[ 6:   6j   ?? 5?      -	   5        $ txtAddCustomerLastName??5?   &   #??[ 6F   5?      ?? 5?      $ Vertical=?6%   .+?5?      ?? $??Email:??6)   #??[ 67   6g   ?? 5?      -
   5        $ txtAddCustomerEmail??5?   &   #??[ 6C   5?      5?      ?? 5?      $??1??6!   $	??0 5q?6.   $ 
Horizontal=?6;   .+?5?      ?? $ Vertical=?6%   .+?5?      ?? $??Country:??6)   #??[ 69   6i   ?? 5?      -   5        $ txtAddCountry??5?   &   #??[ 6=   5?      ?? 5?      $ Vertical=?6%   .+?5?      ?? $??	Province:??6)   #??[ 6:   6j   ?? 5?      -   5        $ txtAddProvince??5?   &   #??[ 6>   5?      5?      ?? 5?      $??2??6!   $	??0 5q?6.   $ 
Horizontal=?6;   .+?5?      ?? $ Vertical=?6%   .+?5?      ?? $??City:??6)   #??[ 66   6f   ?? 5?      -   5        $ 
txtAddCity??5?   &   #??[ 6:   5?      ?? 5?      $ Vertical=?6%   .+?5?      ?? $??Street:??6)   #??[ 68   6h   ?? 5?      -   5        $ txtAddStreet??5?   &   #??[ 6<   5?      ?? 5?      $ Vertical=?6%   .+?5?      ?? $??HouseNr:??6)   #??[ 69   6i   ?? 5?      -   5        $ txtAddHouseNr??5?   &   #??[ 6=   5?      5?      ?? 5?      $??3??6!   $	??0 5q?6.   $ 
Horizontal=?6;   .+?5?      ?? -   5        $ btnAddCustomerAdd??5?   !   ???	#FF462AD8
???????$
 Hand??6f    	 AddCustomerFieldButtons#??[	 6t   $?? ??6?   6?   ?? 5?      -   5        $ btnAddCustomerCancel??5?   !   
???????
???????$
 Hand??6d   #??[	 6r   $??Cancel??6?   6?   5?      5?      5?      5?      5?      5?      