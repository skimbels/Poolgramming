using System;
using Poolgramming.Enums;

namespace Poolgramming.State
{
    public class PlayerState
    {
        private Colour _player1;
        private Colour _player2;
        private Player _currentPlayer;

        public PlayerState()
        {
            _player1 = Colour.None;
            _player2 = Colour.None;
            _currentPlayer = Player.Player1;
        }

        public Colour Player1
        {
            get => _player1;
            set
            {
                _player1 = value;
                _player2 = value.OppositeColour();
            }
        }

        public Colour Player2
        {
            get => _player2;
            set
            {
                _player2 = value;
                _player1 = value.OppositeColour();
            }
        }

        public Player CurrentPlayer => _currentPlayer;

        public Colour CurrentColour {
            get
            {
                switch (_currentPlayer)
                {
                    case Player.Player1:
                        return _player1;
                    case Player.Player2:
                        return _player2;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public void NextPlayer()
        {
            _currentPlayer = _currentPlayer.OppositePlayer();
        }
    }
}
