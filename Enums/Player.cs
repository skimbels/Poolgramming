using System;

namespace Poolgramming.Enums
{
    public enum Player
    {
        Player1,
        Player2
    }

    static class PlayerExtensions
    {
        public static Player OppositePlayer(this Player player)
        {
            switch (player)
            {
                case Player.Player1:
                    return Player.Player2;
                case Player.Player2:
                    return Player.Player1;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }
    }
}