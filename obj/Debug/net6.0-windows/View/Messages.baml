   M S B A M L   `   `   `  ????F  BDevopsCase4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DevopsCase4.ViewDevopsCase4.View  5          DevopsCase4.View.Messages   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      ,localclr-namespace:DevopsCase4.View   5      -   5          >?Name$  
ucMessages??5      .??5
      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??339* ?6   .+?5   
   ? $??0??6   .+?5      ??  ?? Orientation$ Vertical=?6   .+?5      ?? $
??Left=?6   $??Messages??67   $??32(?6G   $??SemiBold"?6U   
???????6k   ?? 5      $
??Left=?6   $/??)Send private messages to different users.??67   
???????$??0 0 0 15q?6{   6?   5      5      ?? 5   
   $??1??6    ?? CornerRadius$ 	30 0 10 0??5      ???	#FF323842._?5      ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6'   ?? 5      $??* ?6'   .+?5      ? $??0??6   $??20    q?6'    5      ?? 5      $??50 ?6(   ?? 5      $??* ?6(   .+?5!      ]? $??0??6    .+?5"      ?? -   5         ??Name$ BtnSearchPersonChat??5"   !    ? Cursor$
 Hand??6>   $??Right=?6M      ChatPersonSearchButton#??[  6d   .??5#      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Magnify=?64   5$      ?? 5%      -   5         ??Name$ txtSearchPersonChat??5%   "   $
??Left=?6?     textboxChatPersonSearch#??[ 6U   6?   5&      &   System.Windows.Controls.DataGrid  5'      -   5        	  Name$	 MessageUserList??5'   ?  $??1??6   $y?Visible=?6`     DataGridStyle2#???  6u     DataGridCellStyle2
   	CellStyle#
 ?  6?     DataGridColumnHeaderStyle3   ColumnHeaderStyle# ?  6?     DataGridRowStyle2   RowStyle# ?  6   ? 	Resources 5(       ?? Color??%?  (??       5)   .   * SystemColors.HighlightBrushKey+)(?? )     5+   .   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(?? R     5-   .   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)?? 5)      $ Transparent??5*      ?? 5+      $ Transparent??5,      ?? 5-      $
 Gray??5.      50         Columns 52      4  .System.Windows.Controls.DataGridTemplateColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$  ??65      
IsReadOnly$
 True??6?      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R      CellTemplate 54   "   ?? 55   &   .R?56   *   ?? $ 
Horizontal=?65   .+?57   .   ?? $??0??68   $??Center=?6H   
?????????6x   ?? *Email+58   +   59   '   5;      5=      5>      ? 5?      $??1??6   ???	#FF393F4A 5@      ?? 5A      $??* ?6(   ?? 5B      $??70 ?6(   .+?5D        -   5        $	 MessagesList??5D     $??0??6   $y?Visible=?6-   #???  6B   #
 ?  6k   # ?  6?   # ?  6?    5E      ??%?  (??       5F   .   * SystemColors.HighlightBrushKey+)(?? )     5H   .   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(?? R     5J   .   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)?? 5F      $ Transparent??5G       ?? 5H      $ Transparent??5I       ?? 5J      $
 Gray??5K       5L       5N        5O      $ #??65   $
 True??6@      CanUserResize$ False??6R   $
 auto 6h    5P   "   ?? 5Q   &   .R?5R   *   ?? $ 
Horizontal=?65   .+?5S   .   ??  K? Capitals$ AllSmallCaps=?68   $??Center=?6[   ??6v   ?? *Name+6?   ?? 5T   .   $ AllSmallCaps=?68   $??Center=?6[   $??: ??6v   6?   5U   +   5V   '   5X        5Z      $ #??65   $
 True??6@   $ False??6R   $
 auto 6h    5[   "   ?? 5\   &   .R?5]   *   ?? $ 
Horizontal=?65   .+?5^   .   ?? $ AllSmallCaps=?68   $??Center=?6[   ??6v   ?? *	Content+6?   5_   +   5`   '   5b      5f      ]? 5g      $??1??6    $??Stretch=?6-   $??10q?6K   .+?5i      ?? -   5        $ BtnChatSend??5i   !   $
 Hand??66   $??Right=?6E     textboxChatButton#??[ 6]   $
??Send??6?   6?   ?? 5j      -   5        $ txtChatMessageBox??5j   "   $
??Left=?6=     textboxChatSend#??[ 6S   6   5k      5l      5m      5n      5o      5p      