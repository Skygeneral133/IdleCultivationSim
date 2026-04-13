namespace Enums
{
    public enum StatTypes
    {
        //Body
        TENDONS,
        SKELETON,
        ORGAN,
        MUSCLES,
        REACTION,
        //Spirits
        FIRE,
        WATER,
        EARTH,
        WOOD,
        METAL
    }

    public static class StatTypesExtensions
    {
        public static bool IsBodyStat(StatTypes type)
        {
            return type <= StatTypes.REACTION;
        }
        public static bool IsSpritStat(StatTypes type)
        {
            return type > StatTypes.REACTION;
        }
    }
}