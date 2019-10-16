using Poolgramming.DataObjects;
using Poolgramming.Enums;

namespace Poolgramming.State
{
    public class GameState
    {
        private PlayerState _players;
        private int _yellowsLeft;
        private int _redsLeft;

        public GameState()
        {
            _players = new PlayerState();
            _yellowsLeft = 7;
            _redsLeft = 7;
        }

        public ShotResult MakeShot(TableState tableState, bool foul)
        {
            if (tableState.YellowCount > _yellowsLeft || tableState.RedCount > _redsLeft)
            {
                return new ShotResult { Invalid = true };
            }

            var loss = DetectLoss(tableState);
            var win = !loss && tableState.Black;

            if (win || loss)
            {
                var winner = DetermineWinner(win, loss);
                return new ShotResult
                {
                    End = true,
                    Winner = winner
                };
            }

            foul |= DetectFoul(tableState.YellowCount, tableState.RedCount, tableState.White);
            ProcessShot(tableState.YellowCount, tableState.RedCount, foul);

            return new ShotResult
            {
                Foul = foul
            };
        }

        private bool DetectLoss(TableState tableState)
        {
            if (!tableState.Black)
            {
                return false;
            }

            // Player pots black and white
            if (tableState.White)
            {
                return true;
            }

            var currentColour = _players.CurrentColour;
            switch (currentColour)
            {
                // Player pots black without clearing his own colours.
                case Colour.Yellow when _yellowsLeft > 0:
                case Colour.Red when _redsLeft > 0:
                // Player pots opponents ball and black.
                case Colour.Yellow when tableState.RedCount > 0:
                case Colour.Red when tableState.YellowCount > 0:
                    return true;
                default:
                    return false;
            }
        }

        private Player? DetermineWinner(bool win, bool loss)
        {
            if (win)
            {
                return _players.CurrentPlayer;
            }

            if (loss)
            {
                return _players.CurrentPlayer.OppositePlayer();
            }

            return null;
        }

        private bool DetectFoul(int yellows, int reds, bool white)
        {
            if (white)
            {
                // TODO add non standard foul on break
                return true;
            }

            var currentColour = _players.CurrentColour;
            if (currentColour == Colour.Red && yellows > 0
                || currentColour == Colour.Yellow && reds > 0)
            {
                return true;
            }

            return false;
        }

        private void ProcessShot(int yellows, int reds, bool foul)
        {
            _yellowsLeft -= yellows;
            _redsLeft -= reds;

            if (!foul)
            {
                _players.NextPlayer();
            }
        }
    }
}
