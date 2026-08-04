namespace Enums
{
    public enum StatTypes
    {
        //Body
        Tendons,
        Skeleton,
        Organ,
        Muscles,
        Reaction,

        //Spirits
        Fire,
        Water,
        Earth,
        Wood,
        Metal
    }

    public static class StatTypesExtensions
    {
        public static bool IsBodyStat(StatTypes type)
        {
            return type <= StatTypes.Reaction;
        }

        public static bool IsSpritStat(StatTypes type)
        {
            return type > StatTypes.Reaction;
        }
    }
}