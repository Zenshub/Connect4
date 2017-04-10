# Connect4
Connect4 web game built using a combination of C# asp.net and javascript

It uses MVC pattern. There are two models Board and Matches, with Board.cs displaying the grid on the view while Matches.cs doing the check to find out if there is winner or not. IfIsWinner method check if there is a consecutive 4 pieces horizontally, vertically and diagonally. It has got current player and grid passed in as parameters.

Board data is retained in the current session and displayed on the view. Users has option to choose the dimensions of the grid and user input data is sent to the controller updated on view through modal.js.

MVCflash message is used to display messages when there is a winner and when game is over.
