   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:View.ConvertersView.Converters  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD.clr-namespace:Model.MineSweeper;assembly=ModelModel.MineSweeper 5      $    View.Screens.MineSweeperScreen   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4
convertersclr-namespace:View.Converters     5      FmineSweeper.clr-namespace:Model.MineSweeper;assembly=Model     5        � 	Resources  5
      +   %View.Converters.SquareStatusConverter   squareStatusToEllipseFill   	Uncovered   Covered   Flagged �� ImageSource   Mine/   )View.Converters.SquareStatusGameLostBombs  LostGameBombStatus   Mine0  *View.Converters.SquareStatusTextVisibility ! squareNeighborCountVisibility4   .View.Converters.NeighboringMinesColorConverter " neighboringMinesColorConverter)  #View.Converters.GameStatusConverter  gameStatusString
   Won   Lost	   
InProgress
 �� 
TargetType  TimeElapsedTextStyle��%�  &	        &	 �     &	 �     &	     &	     &	 m      5   
   $ 
lightgreen��5   +   $ transparant��5   +    5      �� 5      $ 	/flag.png��6    5      �� 5      $ 	/bomb.jpg��6   5        5   
    5      �� 5      $ 	/bomb.jpg��6   5        5   
   6X     5"   
   64     5%   
   $ You Won!��6B   $ 	You Lost!��6Q   $	 Game in progress!��6b   �� 5(   
   "
 ��6   6'   5*      .��5+      � .+�5-   
   �� $	��Top=�6   $��Center=�6,   $��20(�6I   $��MineSweeper��6W   6l   �� 50   
   $	��Top=�6   $��Center=�6,   $��	0,30,80,5q�6I   $��18(�6\   ��6j   �� *(&GameViewModel.currentGame.Value.Status+ �� 	Converter# [ 6�   �� 53   
   -   5         ��Name$ TimeElapsedTextBlock��53   k   $	��Top=�6   $��Center=�6,   $��
150,30,0,5q�6I   $��18(�6]   $��00:00:00��6�   #��[ 6�   �� 56   
   $��Bottom=�6   $��Center=�6,   $��0,0,0,5q�6I   $	��135��6Z   $��25��6f   $��Start New Game��6r   ��6�   �� *StartNewGameCommand+�� 59   
   $��Bottom=�6   $��Center=�6,   $��	305,0,0,5q�6I   $	��135��6\   $��25��6h   $��Go To Setting Screen��6t   ��6�   �� *SwitchToSettingScreen+�� 5<   
   $��Bottom=�6   $��Center=�6,   $��	0,0,305,5q�6I   $	��135��6\   $��25��6h   $��Get Hint��6t   ��6�   �� *	GetHint+(� 5?   
    (� Stretch$ Uniform=�6   $��0, 70, 0, 50q�6$   .��5A      �� $��Center=�6   $��Center=�66   ��6S   �� *GameViewModel.Board.Rows+��5B      �� 5D      .R�5E      �� ��6#   �� *	Squares+��5F      �� 5H      .R�5I   "   ��  �� Orientation$ 
Horizontal=�6-   5J      ��5L      �� 5N      .R�5O   "   �� $��32��6E   $��32��6P   ��6)   �� *	Uncover+ J� InputBindings 5P   &   d� 5R   *    d� MouseAction$ 
RightClicke�67    �� Command 6P   �� *
ToggleFlag+ �� CommandParameter 6o   ��  �� RelativeSource �� *Self+��5T   &   �� 5V   *    �� 
TargetType" ��6:   .R�5W   .   �� $��border��5X   1   
�������
�������$��1q�5[   1   ._�5\   2   �� 5]   /    �� Triggers 5^   .   P� 5`   2    P� Property �@J�IsMouseOver P� Value$
 True��6Q   . �5a   6   ��  �� 
TargetName$ border��6=    �� Property � �� �� Value
 ��+��6h   5b   3   �� 5d   2   $  Model.MineSweeper.SquareStatus   Mine �� Value# Z 6f    �� Binding 6>   �� *Square.Value.Status+.a�5e   6   �� $ border��6=    � ��
 �   �6h   5f   3   5i   +   ��5l   &   � 5m   *   .+�5o   .   �� $��25��68   $��25��6C   ��6O   �� *IsGameOverAndMine.Value+# [ �� 5q   .   ��68   �� *Square.Value.Status+# [  �� 5r   .   $��Center=�5u   1   $��Center=�5v   1   ��5s   1   �� *#!Square.Value.NeighboringMineCount+y�5t   1   �� *Square.Value+# [ 5w   /   5x   +   ��5|   &   �� 5~   *   "
 ��60   .�5   .   ��  � �� 6K   �� *#!Square.Value.NeighboringMineCount+# [ 5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      