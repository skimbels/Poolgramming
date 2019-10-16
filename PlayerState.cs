using System;

using Poolgramming.Enums;

namespace Poolgramming
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
                switch (value)
                {
                    case Colour.Red:
                        _player1 = Colour.Red;
                        _player2 = Colour.Yellow;
                        return;
                    case Colour.Yellow:
                        _player1 = Colour.Yellow;
                        _player2 = Colour.Red;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        }

        public Colour Player2
        {
            get => _player2;
            set
            {
                switch (value)
                {
                    case Colour.Red:
                        _player2 = Colour.Red;
                        _player1 = Colour.Yellow;
                        return;
                    case Colour.Yellow:
                        _player2 = Colour.Yellow;
                        _player1 = Colour.Red;
                        return;
                    default:
                       throw new ArgumentOutOfRangeException();
                }
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
            switch (_currentPlayer)
            {
                case Player.Player1:
                    _currentPlayer = Player.Player2;
                    return;
                case Player.Player2:
                    _currentPlayer = Player.Player1;
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
