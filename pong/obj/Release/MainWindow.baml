   M S B A M L   `   `   `  ���� ?  ;pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:pongpong      pong.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:pong     -     � Title$  
MainWindow��$	��421��$	��768�� � WindowStartupLocation$ CenterScreen=�.���� -    ��Name$	 Cvs��$��0,0,2,0q����	#FF1B1B2F.+�o� -   $��MainMenu�� o� 
IsMainMenu . $
��Left=�$��21��$	��Top=�$��43�� �� Left$ 10��
 �� Top$ 10��.@�m� $
��Menu��$��43��|�.  $��21��.@�m� -   $��start��$��Start��m� -   $��newGame��$��	Parameter��m� -   $
��ende��$
��Ende���� -    ��Name$ RectFeld�����	#FFE43F5A$	��301��$ 67��$ 34��$	��573���� -    ��Name$ tbCountLeft��$
��Wrap=�$��0��$	 335��$ 11��
�������$
��Bold"�$��16(��� -	   $ tbCountRight��$
��Wrap=�$��0��$	 362��$ 11��
�������$
��Bold"�$��16(��� -
    ��Name$ btnApplyBallVelocity��$��Apply
Speed��$��43��$	 309��$ 10��$��26��	 �� 	IsDefault	 . $��8(��� -   
 ��Name$
 lbBallVelocity��$��1��$ 24��$ 94��$��30��
������� J� RenderTransformOrigin$ 0.655,0.962&��� -    ��Name$ sliderBallVelocity��$ 26��$	 285��$	��167�� � Maximum$ 2Q� � Minimum$	 0.1Q� � Value$ 1Q� � Cursor$ Arrow��|�.   �� IsSnapToTickEnabled .  �� TickFrequency$	 0.1Q�$��22��z�V� .~��� �� ��  �� Angle$ 270.577Q�T�  T� X$ -1.851Q� T� Y$ -3.403Q��� -   $

 lbP1��$	��p1:��$ 67��$	 340��
�������$
��Bold"��� -   $
 lbZero��$	��0.1��$ 24��$	 282��$��27��$��29��
�������$ 0.172,1.481&��� -   $
 lbFPS��$�� ��$ 1.821,0.554&�$	 724��$ 5�����	#FFEAEAEA�� $�� ��$ 15��$	 278���� -   $
 lbBallSpeed��$��
Ball speed��$ 63��
�������$
��Bold"��� -   $ lbCountBreak��$
��Wrap=�$��:��$	 351��$ 10��
�������$
��Bold"�$��16(��� -   $

 lbP2��$	��p2:��$	 376��$	 340��
�������$
��Bold"�$ 0.607,0.269&��� -   $
 lbFPSSee��$	��FPS��$	 700��$ 5��
�������