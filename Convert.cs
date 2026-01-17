namespace Cheat
{
    internal class Convert
    {
        public static char SuitToSymbol(Suit suit)
        {
            if (Settings.Current.useUnicode)
            {
                switch (suit)
                {
                    case Suit.heart:
                        return '♥';
                    case Suit.diamond:
                        return '♦';
                    case Suit.spade:
                        return '♠';
                    case Suit.club:
                        return '♣';
                }
            }
            else
            {
                switch (suit)
                {
                    case Suit.heart:
                        return 'H';
                    case Suit.diamond:
                        return 'D';
                    case Suit.spade:
                        return 'S';
                    case Suit.club:
                        return 'C';
                }
            }
            return '?';
        }
        public static string RankToSymbol(Rank rank)
        {
            switch (rank)
            {
                case Rank.ace:
                    return "A";
                case Rank.two:
                    return "2";
                case Rank.three:
                    return "3";
                case Rank.four:
                    return "4";
                case Rank.five:
                    return "5";
                case Rank.six:
                    return "6";
                case Rank.seven:
                    return "7";
                case Rank.eight:
                    return "8";
                case Rank.nine:
                    return "9";
                case Rank.ten:
                    return "10";
                case Rank.jack:
                    return "J";
                case Rank.queen:
                    return "Q";
                case Rank.king:
                    return "K";
                default:
                    return "?";
            }
        }
        public static T StringToT<T>(string input) where T : struct, Enum
        {
            return Enum.Parse<T>(input, true);
        }
    }
}
