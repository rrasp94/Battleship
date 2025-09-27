# Battleship

![battleship](/images/screenshot1.png)

![battleship](/images/screenshot2.png)

A simulation of [Battleship game](<https://en.wikipedia.org/wiki/Battleship_(game)>) which should enable a user to play against computer.

Main purpose of the game is to cover basic topics of object-oriented design and UML diagrams.

## Description

Strategy game with 2 players playing one against another

1. Each player draws two rectangular grids with 10 x 10 squares (number of squares may vary depending on the rules) and marks rows with numbers 1 - 10 and columns with letters A - J. Each square on the grid is identified by a letter-number pair. For example, square "A-1" is the square in the left top corner of the grid, "J-1" is the square in the top right corner. On the primary grid player will arrange his/her fleet (consisting of a number of ships with different lengths) and record opponent's shots. On the secondary grid player will record results of shooting the opponent's fleet. The grid with fleet remains hidden from the opponent all through the game.
2. Each player selects 5 horizontal or vertical consecutive squares on the primary grid where longest ship will be placed. Player frames selected squares to mark the ship.
3. Players repeat step 2 for other ships consisting of 4 horizontal or vertical consecutive squares (2 ships), 3 squares (3 ships) and 2 squares (4 ships) taking care that squares belonging to different ships must not overlap or be adjacent (number of ships and their lengths may vary depending on the rules).
4. After both players have arranged their fleets, randomly selected player starts the game.
5. First player selects a square on the opponent's grid he is targeting and asks the opponent for the result of shooting that square by pronouncing the square identifier, e.g. "B-4".
6. Opponent records the square shot on his primary grid and answers with:

- "Missed" if square doesn't contain a ship,
- "Hit" if there is a ship on that square or
- "Sunk" if the square is the last hit square belonging to a ship.

7. First player records the shooting result on his secondary grid.
8. Players exchange their roles and repeat steps 5-7.
9. Players repeat steps 5-8 until all ships in one of player's fleet are sunk.
10. Winner is the player whose fleet has at least one ship not sunk.

![battleship](/images/battleship.png)

### Domain Model

![battleship](/images/domain_model.png)

### Arranging the Fleet

#### Use Case: Arranging the Fleet

**Actors**: Player

**Postcondition** : Player has the fleet arranged

1. Player draws a rectangular grid with 10 x 10 squares
2. Player selects consecutive 5 horizontal or vertical squares where the longest will be placed, marks them as a ship
3. Player checks for a consecutive 4 horizontal or vertical squares for the next 2 ships taking care that ships must not
   overlap or touch each other
4. Player repeats step 3 for ships of length 3 and 2 squares.

#### Sequence Diagram: Arranging the Fleet

![battleship](/images/arranging_fleet_sequence_diagram.png)

#### Eliminating Squares After Ship Is Created

After a ship is placed, squares belonging to ship have to be removed from the grid. Since the grid must provide only valid placements for the next ship, squares surrounding the ship must be removed too in order to prevent two ships touching each other. On figures below ships are marked gray and surrounding squares to be removed are crosshatched.

<table cellspacing="0" cellpadding="0">
  <tr>
    <td align="left"><img align="left" src="/images/eliminate_squares1.png"></td>
    <td align="right"><img align="right" src="/images/eliminate_squares2.png"/></td>
  </tr>
    <td align="center" colspan="2"><img align="center" src="/images/removing_squares.png"/></td>
</table>

#### Getting Available Placements

Figures below depict how available placements for ships are evaluated. Left figure shows all possible placements for a ship consisting of 3 squares on a grid with 1 row and 4 columns and a grid with 5 rows and 1 column, respectively. Right figure shows all possible placements for a ship consisting of 2 squares when one square (crosshatched square) is eliminated.

<table cellspacing="0" cellpadding="0">
  <tr>
    <td align="left"><img align="left" src="/images/available_placements1.png"></td>
    <td align="right"><img align="right" src="/images/available_placements2.png"/></td>
  </tr>
</table>

To find a given number _n_ of consecutive free squares, a counter is used which starts from 0 and is incremented for each available square. When counter reaches _n_, last _n_ squares are appended to the collection of available placements. If already eliminated square is encountered, counter is reset. Figure below depicts the procedure for a sequence of 3 consecutive squares.

![battleship](/images/counting_available_squares.png)

While placing ships, it may happen that all available placements on the grid are exhausted and there is no place for the next ship, as shown on the figure below.

![battleship](/images/no_more_squares.png)

### Shooting Opponent's Fleet

#### Use Case: Shooting Opponent's Fleet

**Actors:** 2 opponent players shooting each other's fleet

**Precondition:** Both players have there fleets set and have evidence grid prepared

**Postcondition:** All ships in the fleet of one of the players are sunken

1. Randomly selected player A starts the game.
2. Player A checks his evidence grid to see squares that haven't been targeted yet.
3. Player A selects one of the free squares (e.g. C-5) and asks the opponent (player B) if the square with provided coordinates belongs to one of his ships.
4. The player B marks the targeted square on his grid with fleet and answers:
   - "Missed" if the square doesn't belong to any ship,
   - "Hit" if square belongs to one of the ships, but not all squares of the ship have bin hit yet,
   - "Sunken" if square belongs to a ship and it is the last hit square belonging to that ship.
5. Player A marks the result of shooting on his evidence grid.
6. Players exchange their roles and steps 1-5 are repeated.
7. Steps 2-6 are repeated as long as all ships belonging to one of players are not sunken.
8. Winner is the player who has at least one ship not sunken.

#### Sequence Diagram: Shooting the Fleet

![battleship](/images/sequence_diagram_shooting.png)

![battleship](/images/sequence_diagram_shooting_ship.png)

#### Shooting Tactics

There are three tactics interchanged:

1. Initially squares are targeted randomly.
2. After a square is hit, tactics is changed and target is selected from one of the squares that are just left to, above, right to or below the square hit (on the left figure below square hit first is black, target candidates are gray).
3. After a second square is hit, next target is selected from one of two squares in the sequel of squares hit (on the right figure below two squares hit are black, target candidates are gray).
4. When ship is sunken, tactics changes to random again and the above sequence is repeated.

![battleship](/images/shooting_tactics.png)

#### State Chart Diagram: Shooting Tactics

![battleship](/images/shooting_statechart.png)
