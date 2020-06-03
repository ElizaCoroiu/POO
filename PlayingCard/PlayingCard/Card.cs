using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCard
{
    public class Card
    {
        private int rank;
        private int suit;

        // Kind of suits
        public static int DIAMONDS = 1;
        public static int CLUBS = 2;
        public static int HEARTS = 3;
        public static int SPADES = 4;

        // Kind of ranks
        public static int ACE = 1;
        public static int DEUCE = 2;
        public static int THREE = 3;
        public static int FOUR = 4;
        public static int FIVE = 5;
        public static int SIX = 6;
        public static int SEVEN = 7;
        public static int EIGHT = 8;
        public static int NINE = 9;
        public static int TEN = 10;
        public static int JACK = 11;
        public static int QUEEN = 12;
        public static int KING = 13;

        public Card(int rank, int suit)
        {
            Debug.Assert(isValidRank(rank));
            Debug.Assert(isValidSuit(suit));
            this.rank = rank;
            this.suit = suit;
        }

        public int getSuit()
        {
            return suit;
        }

        public int getRank()
        {
            return rank;
        }

        private bool isValidSuit(int suit)
        {
            return DIAMONDS <= suit && suit <= SPADES;
        }

        private bool isValidRank(int rank)
        {
            return ACE <= rank && rank <= KING;
        }

        public static String rankToString(int rank)
        {
            switch (rank)
            {
                case 1:
                    return "Ace";
                case 2:
                    return "Deuce";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return null;
            }
           
        }
        public static String suitToString(int suit)
        {
            switch (suit)
            {
                case 1:
                    return "Diamonds";
                case 2:
                    return "Clubs";
                case 3:
                    return "Hearts";
                case 4:
                    return "Spades";
                default:
                    return null;
            }
        }
    }
}
