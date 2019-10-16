using Poolgramming.Enums;

namespace Poolgramming
{
    public struct ShotResult
    {
        public bool Invalid;
        public bool Foul;
        public bool End;
        public Player? Winner;
    }
}