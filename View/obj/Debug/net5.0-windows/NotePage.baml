   M S B A M L   `   `   `  ?????  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5      /clr-namespace:View.ViewModelView.ViewModel  5   P       View.NotePage   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:View     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ,	viewmodelclr-namespace:View.ViewModel  6P     ? WindowStartupLocation$  CenterScreen=?5   !   $	??500??5	      $	??800??6    ? Title$
 Note??5
       ? Cursor$
 Hand??6   .??5      ? ???	#ffdadada.+?5   
   ?? $	??300??6   $??15q?6    
???????$	??Top=?6?    ?? Padding$ 15q?6W   $	??800??6d    ?? CornerRadius$ 10??6s    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q?6#      Color$ #4671D5??63      ShadowDepth$ 0Q?6C   6U   ._?5      ? .+?5      ?? $??30??6   $	??300??6'   $
??Left=?63   $??Новая заметка??6N      MaterialDesignFlatButton#??[  6f   ???#1240AB$
 Hand??6?   ?? 5      $??30??6   $	??300??6'   $??Right=?6V   $!??Список заметок??6r   ???#1240AB
???????$
 Hand??6?   ??63   ?? *ChangePageList+6?   5      5      ?? 5   
   $	??300??6   $??
15,90,15,5q?6    
???????$??Bottom=?6G   $ 30q?6c   $	??800??6p   $ 15??6   $	??350??6?    5        5      $ 20Q?6#   $ #4671D5??63   $ 0Q?6C   6U   ._?5      ?? .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Название??6V    % !MaterialDesignFloatingHintTextBox#??[ 6?   
 ?? TextAlignment$
 Center=?5      $??Stretch=?62   $??Stretch=?6N      
IsFloating$ False??5      ??5      ?? *Title+ ?? UpdateSourceTrigger$ PropertyChanged=?.??5   K    ? 	Resources 5       (  "MaterialDesignThemes.Wpf.SmartHint ?? 
TargetType ?? Property ?? Value??%V   '        ?? 5!      "  6    .?5"      ??  ? ??$ Center=?6F   5#      5$      .??6)   5%      ?? 5&      $	??210??6U    ?? TextWrapping$
 Wrap=?6b    ?? AcceptsReturn$
 True??6v   $??Visible=?6?   ??6   ?? *Info+$ PropertyChanged=?6?   ?? 5'      $??Сохранить??6   $
??0 20q?6L   $
 Hand??6Z   ???#1240AB??6-   ?? *
AddCommand+6h   5(      5)      5+      5,      