   M S B A M L   `   `   `  ����?  ;pong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:pongpong  5   	       pong.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:pong     5   	   -   5          � Title$  
MainWindow��5   	   $	��421��6   $	��768��6)    � WindowStartupLocation$ CenterScreen=�6I   .��5	      �� -   5         ��Name$	 Cvs��5	      $��0,0,2,0q�68   ���	#FF1B1B2F.+�5
   
   o� -   5        $��MainMenu��5
       o� 
IsMainMenu . $
��Left=�61   $��21��6L   $	��Top=�6X   $��43��6p    �� Left$ 10��6{   
 �� Top$ 10��6�   .@�5      m� $
��Menu��6   $��43��6%   |�.  $��21��6B   .@�5      m� -   5        $��start��5      $��Start��6(   67   m� 5      -   5        $
��ende��5      $
��Ende��6'   65   m� 5      -   5        $��newGame��5      $��Neues Spiel��6*   6?   5      5      �� 5   
   -   5         ��Name$ RectFeld��5      ���	#FFE43F5A$	��301��67   $ 67��6D   $ 34��6U   $	��573��6e   �� 5   
   -   5         ��Name$ tbCountLeft��5      $
��Wrap=�6)   $��0��6=   $	 335��6F   $ 11��6X   
�������$
��Bold"�6{   $��16(�6�   �� 5   
   -	   5        $ tbCountRight��5      $
��Wrap=�6*   $��0��6>   $	 362��6G   $ 11��6Y   
�������$
��Bold"�6|   $��16(�6�   �� 5   
   -
   5         ��Name$ btnApplyBallVelocity��5      $��Apply
Speed��6/   $��43��6N   $	 309��6Y   $ 10��6j   $��26��6�   	 �� 	IsDefault	 . $��8(�6�   �� 5   
   -   5        
 ��Name$
 lbBallVelocity��5      $��1��6(   $ 24��64   $ 94��6E   $��30��6U   
������� J� RenderTransformOrigin$ 0.655,0.962&�6s   �� 5   
   -   5         ��Name$ sliderBallVelocity��5      $ 26��6-   $	 285��6>   $	��167��6O    � Maximum$ 2Q�6[    � Minimum$	 0.1Q�6g    � Value$ 1Q�6u    � Cursor$ Arrow��6   |�.   �� IsSnapToTickEnabled .  �� TickFrequency$	 0.1Q�6�   $��22��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 270.577Q�6&   T� 5       T� X$ -1.851Q�6)    T� Y$ -3.403Q�64   5      5       �� 5!   
   -   5        $

 lbP1��5!      $	��p1:��6   $ 67��6,   $	 340��6=   
�������$
��Bold"�6a   �� 5"   
   -   5        $
 lbZero��5"      $	��0.1��6    $ 24��6.   $	 282��6?   $��27��6P   $��29��6\   
�������$ 0.172,1.481&�6z   �� 5#   
   -   5        $
 lbFPS��5#      $�� ��6   $ 1.821,0.554&�6*   $	 724��6N   $ 5��6`   ���	#FFEAEAEA6o   �� 5$   
   $�� ��6   $ 15��6   $	 278��6,   �� 5%   
   -   5        $
 lbBallSpeed��5%      $��
Ball speed��6%   $ 63��6:   
�������$
��Bold"�6]   �� 5&   
   -   5        $ lbCountBreak��5&      $
��Wrap=�6*   $��:��6>   $	 351��6G   $ 10��6Y   
�������$
��Bold"�6|   $��16(�6�   �� 5'   
   -   5        $

 lbP2��5'      $	��p2:��6   $	 376��6,   $	 340��6>   
�������$
��Bold"�6b   $ 0.607,0.269&�6t   �� 5(   
   -   5        $
 lbFPSSee��5(      $	��FPS��6"   $	 700��60   $ 5��6B   
�������6Q   5)      5*      