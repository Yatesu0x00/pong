   M S B A M L   `   `   `  ���� ?  ;pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:pongpong      pong.StartDlg   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:pong       � Title$  StartDlg��$��336.422��$��411.469�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.���� $��	0,0,0,147q�.+��� $��Ball Radius:��$
��Left=�$	��Top=� �� Left$ 56��
 �� Top$	 109��$��15(��� -    ��Name$ radius��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$��35��$	 141��$	 113��$��10�� J� RenderTransformOrigin$ 0.414,1.783&�$��15(��� -    ��Name$ OK��$��OK��$ 43��$	 253��$��90��	 �� 	IsDefault	 . $��15(�$��30���� -   $ cancel��$��CANCEL��$	 181��$	 253��$��90��
 �� IsCancel
 . $��15(�$��30���� $��(0 < Radius < 16)��$	 181��$	 109��$	��137��$��15(��� $��
Spieler 1:��$
��Left=�$	��Top=�$ 16��$ 22��$��15(��� $��
Spieler 2:��$
��Left=�$	��Top=�$ 16��$ 53��$��15(��� -   $ tbNameP1��$
��Left=�$��26��$
 Wrap=�$	��Top=�$��85��$ 91��$ 26��$��	Spieler 1��$ 0.414,1.783&�$��15(��� -   $ tbNameP2��$
��Left=�$��26��$
 Wrap=�$	��Top=�$��85��$ 91��$ 57��$��	Spieler 2��$ 0.414,1.783&�$��15(��� $��Paddle Höhe:��$
��Left=�$	��Top=�$ 43��$	 149��$��15(��� -   $ tbPaddleHoehe��$
��Left=�$��20��$
 Wrap=�$	��Top=�$��35��$	 141��$	 153��$	��100��$ 0.414,1.783&�$��15(��� $��(49 < Höhe < 151)��$	 181��$	 149��$	��137��$��15(��� $��Paddle Breite:��$
��Left=�$	��Top=�$ 41��$	 174��$��15(��� -   $ tbPaddleBreite��$
��Left=�$��22��$
 Wrap=�$	��Top=�$��35��$	 141��$	 178��$��25��$ 0.414,1.783&�$��15(��� $��(14 < Breite < 41)��$	 181��$	 174��$	��131��$��15(��� -   $��Automatischer Paddle��$	 181��$ 64��$��15(�$	��177�� d� 	IsChecked$
 TrueY��� $��Paddle Geschwindigkeit:��$
��Left=�$	��Top=�$ 41��$	 200��$��15(��� -	   $ 
tbPaddleVy��$
��Left=�$��22��$
 Wrap=�$	��Top=�$��35��$	 211��$	 204��$��15��$ 0.414,1.783&�$��15(��� $��(14 < Breite < 26)��$	 251��$	 200��$	��131��$��15(�