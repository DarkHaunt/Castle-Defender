namespace Game.Extensions
{
    public static class MathfExtensions
    {
        /// <summary>
        /// Clamps value to be more or equal than 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns>[0; +∞]</returns>
        public static float PositiveClamp(float value)
            => value < 0 ? 0 : value;
    }
}