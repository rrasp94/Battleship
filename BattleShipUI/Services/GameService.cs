using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipUI.Services
{
    public class GameService
    {
        public int GridRows { get; private set; }
        public int GridColumns { get; private set; }
        public int[] ShipLengths { get; private set; }
        public Fleet Player1Fleet { get; private set; }
        public Fleet Player2Fleet { get; private set; }

        public bool IsPlayer1Turn { get; private set; } = true;

        public List<(int row, int col, SquareState state)> Player1Hits { get; } = new();
        public List<(int row, int col, SquareState state)> Player2Hits { get; } = new();

        public bool IsGameOver =>
            Player1Hits.Count(h => h.state == SquareState.Hit || h.state == SquareState.Sunken) >= ShipLengths.Sum() ||
            Player2Hits.Count(h => h.state == SquareState.Hit || h.state == SquareState.Sunken) >= ShipLengths.Sum();

        public void InitializeGame(int gridSize, int[] shipLengths)
        {
            GridRows = gridSize;
            GridColumns = gridSize;
            ShipLengths = shipLengths;

            Player1Fleet = new FleetBuilder(GridRows, GridColumns, ShipLengths).CreateFleet();
            Player2Fleet = new FleetBuilder(GridRows, GridColumns, ShipLengths).CreateFleet();

            Player1Hits.Clear();
            Player2Hits.Clear();
            IsPlayer1Turn = true;
        }

        public HitResult PlayerShoot(int row, int col, bool isPlayer1)
        {
            if ((isPlayer1 && !IsPlayer1Turn) || (!isPlayer1 && IsPlayer1Turn) || IsGameOver)
                return HitResult.Missed;

            var targetFleet = isPlayer1 ? Player2Fleet : Player1Fleet;
            var result = targetFleet.Hit(row, col);

            var state = result switch
            {
                HitResult.Hit => SquareState.Hit,
                HitResult.Sunken => SquareState.Sunken,
                _ => SquareState.Missed
            };

            if (isPlayer1) Player1Hits.Add((row, col, state));
            else Player2Hits.Add((row, col, state));

            if (result == HitResult.Missed || result == HitResult.Sunken)
                IsPlayer1Turn = !IsPlayer1Turn;

            return result;
        }

        public bool IsPlayer1Winner() => Player2Fleet.Ships.All(ship => ship.Squares.All(sq => sq.IsHit));
        public bool IsPlayer2Winner() => Player1Fleet.Ships.All(ship => ship.Squares.All(sq => sq.IsHit));

        public bool HasPlayer1Hit(int row, int col) => Player1Hits.Any(h => h.row == row && h.col == col);
        public SquareState GetPlayer1HitState(int row, int col) => Player1Hits.FirstOrDefault(h => h.row == row && h.col == col).state;

        public bool HasPlayer2Hit(int row, int col) => Player2Hits.Any(h => h.row == row && h.col == col);
        public SquareState GetPlayer2HitState(int row, int col) => Player2Hits.FirstOrDefault(h => h.row == row && h.col == col).state;

        public bool IsPlayer1ShipAt(int row, int col) => Player1Fleet.Ships.Any(ship => ship.Contains(row, col));
        public bool IsPlayer2ShipAt(int row, int col) => Player2Fleet.Ships.Any(ship => ship.Contains(row, col));
    }
}