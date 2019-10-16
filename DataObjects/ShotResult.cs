using Poolgramming.Enums;

namespace Poolgramming.DataObjects
{
    public struct ShotResult
    {
        public bool Invalid;
        public bool Foul;
        public bool End;
        public Player? Winner;
    }
}