   M S B A M L   `   `   `  ????F  BDevopsCase4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DevopsCase4.ViewDevopsCase4.View  5           DevopsCase4.View.Dashboard   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      ,localclr-namespace:DevopsCase4.View   5      -   5          >?Name$  ucDashboard??5       ? 	Resources 5         	BoolToVis??%   &	        ?? 5   
   6'   5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??0??6   $??2??6   .+?5      ?? $??0 0 0 30q?6   $??0??6*   $??	Dashboard??67   $??32(?6H   $??SemiBold"?6V   
???????6l   5      ?? 5   
   $??1??6   $??0??5      $??2??5       ?? CornerRadius$ 	30 0 10 0??5       ???	#FF323842._?5!      ?  5"      ?? 5#      $??* ?6'   ?? 5$      $??* ?6'   ?? 5%      $??* ?6'   ?? 5&      $??* ?6'    5)      ?? 5*      $	??200 ?6$   ?? 5+      $	??200 ?6$   ?? 5,      $	??180 ?6$   .+?5.      ?? $??0??6   $??25q?6)   $ 10??65   ???#21262d._?5/      ??  ?? Orientation$ Vertical=?50      $??center=?60   $??Center=?6K   .+?52      .  (MahApps.Metro.IconPacks.PackIconMaterial  
???????   Kind$ Clock=?6C   $??50??6P   $??50??6[   $??5q?6g   6t   ?? 53      -   5         ??Name$ txtDashboardTime??53   $   $??Center=?6>   $??20(?6[   
???????$??5q?6|   54      56      ?? 58      $??1??6   $??3??6)   $??25q?6=   $ 
10 0 10 10??6I   ???#21262d._?59      ?? $ Vertical=?6!   $??20q?68   .+?5:      ?? $??Activity??6$   $??16(?64   
???????$??0 0 0 5q?6U   6h   &   System.Windows.Controls.DataGrid  5=      -   5          Name$ ActivityList??5=     $y?Visible=?6#     DataGridStyle2#???  68     DataGridCellStyle2	   	CellStyle#	 ?  6a     DataGridColumnHeaderStyle3
   ColumnHeaderStyle#
 ?  6?     DataGridRowStyle2   RowStyle# ?  6?    5>       ?? Color??%?  (??       5?   2   * SystemColors.HighlightBrushKey+)(?? )     5A   2   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(?? R     5C   2   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)?? 5?   "   $ Transparent??5@      ?? 5A   "   $ Transparent??5B      ?? 5C   "   $
 Gray??5D      5F         Columns 5G      4  .System.Windows.Controls.DataGridTemplateColumn  5H   "   ,  &System.Windows.Controls.DataGridColumn   Header$  ??69      
IsReadOnly$
 True??6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6U      CellTemplate 5I   &   ?? 5J   *   .R?5K   .   ?? $ 
Horizontal=?69   .+?5M   2       Name$ icoActivity??6H   $??2??6]   $??Center=?6m   $??10??6?   $??Center=?6?   ???	#FF462AD8 6?   ?? *Action+6?   5O   /   5P   +   5R   #     5S   "   $  ??69   $
 True??6C   $	 120 6U    5T   &   ?? 5U   *   .R?5V   .   ?? $ 
Horizontal=?69   .+?5W   2   ?? $??0??6<   $??Center=?6L   
?????????6|   ?? *	Timestamp+5X   /   5Y   +   5[   #     5]   "   $  ??69   $
 True??6C   $ * 6U    5^   &   ?? 5_   *   .R?5`   .   ?? $??1??68   $
??Left=?6H   
?????????6v   ?? *Description+5a   +   5c   #   5e      5h      5m      ?? 5o      $??4??6   $??1??6-   $??2??6:   $??25q?6K   $ 
10 10 10 0??6W   ???#21262d._?5p      ?? $ Vertical=?5q      $??center=?60   $??Center=?6K   5r      5t      5v      5w      5x      5z      