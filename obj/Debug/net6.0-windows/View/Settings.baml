   M S B A M L   `   `   `  ????F  BDevopsCase4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DevopsCase4.ViewDevopsCase4.View  5          DevopsCase4.View.Settings   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DevopsCase4.View     5      -   5          >?Name$  
ucSettings??5      .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??auto ?6   ?? 5      $
??339* ?6   .+?5   
   ? $??0??6   .+?5      ??  ?? Orientation$ Vertical=?6   .+?5      ?? $
??Left=?6   $??Settings??67   $??32(?6G   $??SemiBold"?6U   
???????6k   ?? 5      $
??Left=?6   $/??)Change your profile and account settings.??67   
???????$??0 0 0 15q?6{   6?   5      5      ?? 5   
   $??1??6    ?? CornerRadius$ 	30 0 10 0??5      ???	#FF323842._?5      ? $??30q?6    5      ?? 5      $
??auto ?6$   ?? 5      $
??auto ?6$   ?? 5      $
??auto ?6$   ?? 5      $
??auto ?6$   .+?5      ?? $??0??6   $	??0 5q?6*   $ 
Horizontal=?67   .+?5      ?? $ Vertical=?6!   .+?5       ?? $??Name:??6%      AddCustomerTextBlock#??[  62   6b   ?? 5!      -   5         ??Name$ txtChangeName??5!   "     AddCustomerInput#??[ 69   5#      ?? 5$      $ Vertical=?6!   .+?5%      ?? $??	Lastname:??6%   #??[  66   6f   ?? 5&      -   5        $ txtChangeLastName??5&   "   #??[ 6=   5(      ?? 5*      $ Vertical=?6!   .+?5+      ?? $??Email:??6%   #??[  63   6c   ?? 5,      -   5        $ txtChangeEmail??5,   "   #??[ 6:   5.      5/      ?? 51      $??1??6   $	??0 5q?6*   $ 
Horizontal=?67   .+?52      ?? $ Vertical=?6!   .+?53      ?? $??Country:??6%   #??[  65   6e   ?? 54      -   5        $ txtChangeCountry??54   "   #??[ 6<   56      ?? 57      $ Vertical=?6!   .+?58      ?? $??	Province:??6%   #??[  66   6f   ?? 59      -   5        $ txtChangeProvince??59   "   #??[ 6=   5;      5>      ?? 5?      $??2??6   $	??0 5q?6*   $ 
Horizontal=?67   .+?5@      ?? $ Vertical=?6!   .+?5A      ?? $??City:??6%   #??[  62   6b   ?? 5B      -   5        $ txtChangeCity??5B   "   #??[ 69   5D      ?? 5E      $ Vertical=?6!   .+?5F      ?? $??Street:??6%   #??[  64   6d   ?? 5G      -   5        $ txtChangeStreet??5G   "   #??[ 6;   5I      ?? 5K      $ Vertical=?6!   .+?5L      ?? $??HouseNr:??6%   #??[  65   6e   ?? 5M      -	   5        $ txtChangeHouseNr??5M   "   #??[ 6<   5O      5P      ?? 5R      $??3??6   $	??0 5q?6*   $ 
Horizontal=?67   .+?5S      ?? -
   5         ??Name$ BtnUserEdit??5S      ???	#FF462AD8
??????? ? Cursor$
 Hand??6\     AddCustomerFieldButtons#??[ 6j   $??Save changes??6?   6?   ?? 5T      -   5        $ BtnUserEditCancel??5T      
???????
???????$
 Hand??6]   #??[ 6k   $??Cancel??6?   6?   5U      5V      5W      5X      5Y      