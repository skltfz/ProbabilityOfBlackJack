using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMIGOD.Classes
{
    public class BlackSecret
    {
        public static int g_idx = 0;
        public static double prob = 0;
        public static List<TraverseSet> proHolder = new List<TraverseSet>();
        public static List<TraverseRecurSet> trReSet_main = new List<TraverseRecurSet>();
        public static List<TraverseRecurSet> trReSet_sub = new List<TraverseRecurSet>();
        public static Boolean done = false;
        public static BurstRateExgtract GetBankerBust(string card)
        {
            //try
            //{
            proHolder.Clear();
            int z = -1;
            cardType upperCard;
            if (int.TryParse(card, out z))
            {
                upperCard = (cardType)z;
                done = false;
                Tuple<int, int> input = BasicFact.FetchValue(upperCard);
                CalBust_Recur_Init(input);
                while (!done)
                    CalBust_Recur();
                return null;
            }
            else throw new Exception("Invalid Input");
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }
        public static Boolean WillBust(int val, int val2)
        {
            return val + val2 > BasicFact.bustThreshold;
        }
        public static Boolean WillHalt(int val, int val2)
        {
            //it properly will not get card anymore and will just stand as it is
            return val + val2 <= BasicFact.bustThreshold && val + val2 >= BasicFact.minThreshold;
        }
        public class CardTypeSet
        {
            public int value { get; set; }
            public cardType cardType { get; set; }
            public CardTypeSet(int value)
            {
                this.value = value;
                this.cardType = BasicFact.IntToCard(value);
            }
        }
        public class TraverseRecurSet
        {
            public int idx;
            public int currVal { get; set; }
            public List<CardTypeSet> cardList;
            public Boolean compareCount()
            {
                int val = 0;
                foreach (CardTypeSet x in cardList)
                {
                    val += (int)x.value;
                }
                return val == currVal;
            }
            public TraverseRecurSet(List<CardTypeSet> list, int card2, int valSum)
            {
                this.idx = g_idx++;
                this.cardList = list;
                cardList.Add(new CardTypeSet(card2));
                currVal = valSum + card2;
            }
            public TraverseRecurSet(int card1, int card2)
            {
                this.idx = g_idx++;
                cardList = new List<CardTypeSet>();
                cardList.Add(new CardTypeSet(card1));
                cardList.Add(new CardTypeSet(card2));
                currVal = card1 + card2;
            }
        }
        public static void PropagateBurstChecking(TraverseRecurSet trs)
        {
            foreach (cardType card in Enum.GetValues(typeof(cardType)))
            {
                Tuple<int, int> propValue = BasicFact.FetchValue(card);
                if (WillBust(trs.currVal, propValue.Item1))
                {
                    List<CardTypeSet> cards = trs.cardList.ToList();
                    cards.Add(new CardTypeSet(propValue.Item1));
                    TraverseSet tmp = new TraverseSet(cards);
                    proHolder.Add(tmp);
                }
                else if (WillHalt(trs.currVal, propValue.Item1))
                {
                    //do nothing it is not busting anymore, rest in peace
                }
                else
                {
                    //Add to trReSet
                    TraverseRecurSet tRsItem = new TraverseRecurSet(trs.cardList.ToList(), propValue.Item1, trs.currVal);
                    int cnt = trs.cardList.Count(x => x.value == propValue.Item1);
                    if (!(cnt > 3))
                        trReSet_sub.Add(tRsItem);
                }

                if (propValue.Item2 > 0)
                {
                    //case of Ace
                    if (WillBust(trs.currVal, propValue.Item2))
                    {
                        //simply ignore this, as no one will choose to A=11 when it will bust the hand
                    }
                    else if (WillHalt(trs.currVal, propValue.Item2))
                    {
                        //do nothing it is not busting anymore, rest in peace
                    }
                    else
                    {
                        //Add to trReSet
                        TraverseRecurSet tRsItem = new TraverseRecurSet(trs.cardList.ToList(), propValue.Item2, trs.currVal);
                        int cnt = trs.cardList.Count(x => x.value == propValue.Item2);
                        if (!(cnt > 3))
                            trReSet_sub.Add(tRsItem);
                    }
                }

            }
            //  trReSet.RemoveAll(x => x.idx == trs.idx);//done this and remove afterwards
        }
        public static void CalBust_Recur_Init(Tuple<int, int> input)
        {
            #region initial 
            foreach (cardType card in Enum.GetValues(typeof(cardType)))
            {
                Tuple<int, int> propValue = BasicFact.FetchValue(card);
                //Normal Case
                if (WillBust(input.Item1, propValue.Item1))
                {
                    List<CardTypeSet> cards = new List<CardTypeSet>();
                    cards.Add(new CardTypeSet(input.Item1));
                    cards.Add(new CardTypeSet(propValue.Item1));
                    TraverseSet tmp = new TraverseSet(cards);
                    proHolder.Add(tmp);
                }
                else if (WillHalt(input.Item1, propValue.Item1))
                {

                }
                else
                {
                    //Add to trReSet
                    TraverseRecurSet tRsItem = new TraverseRecurSet(input.Item1, propValue.Item1);
                    trReSet_main.Add(tRsItem);
                }

                if (propValue.Item2 > 0)
                {
                    //case of Ace
                    if (WillBust(input.Item1, propValue.Item2))
                    {
                        //simply ignore this, as no one will choose to A=11 when it will bust the hand
                    }
                    else if (WillHalt(input.Item1, propValue.Item2))
                    {

                    }
                    else
                    {
                        //Add to trReSet
                        TraverseRecurSet tRsItem = new TraverseRecurSet(input.Item1, propValue.Item2);
                        trReSet_main.Add(tRsItem);
                    }
                }
            }
            #endregion
        }
        public static void CalBust_Recur()
        {
            if (trReSet_main.ToList().Count > 0)
            {
                //Fetch from trReSet, input is useless anymore
                foreach (TraverseRecurSet trs in trReSet_main)
                {
                    PropagateBurstChecking(trs);
                }
            }
            trReSet_main = trReSet_sub.ToList();
            trReSet_sub.Clear();
            if (!trReSet_main.Any()) done = true;
        }
        public class TraverseSet
        {
            public List<CardTypeSet> cards;
            public string content { get; set; }
            public float prob { get; set; }
            public TraverseSet(List<CardTypeSet> cards)
            {
                this.cards = cards;
                prob = 1;
                content += "=";
                string contentSub = string.Empty;
                float numOfCardInDeck = BasicFact.numOfCardInDeck;
                foreach (CardTypeSet item in cards)
                {
                    prob *= BasicFact.FetchRate(item.cardType,numOfCardInDeck);
                    content += string.Format("{0} *", BasicFact.FetchRate(item.cardType,numOfCardInDeck));
                    contentSub += item.cardType.ToString() + ",";
                    numOfCardInDeck--;
                }
                content += string.Format("({0})\n", contentSub);
                content = string.Format("{0}{1}", prob, content);
            }
        }
        public class BurstRateExgtract
        {
            public List<string> transactions;
            public int bankerUpper;
        }
        public enum cardType { A = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
        public class BasicFact
        {
            public static int numOfDeck = 1;
            public static float numOfCardInDeck = 52;
            public static int bustThreshold = 21;
            public static int minThreshold = 17;

            public static cardType IntToCard(int input)
            {
                switch (input)
                {
                    case 1:
                    case 11:
                        return cardType.A;
                    default:
                        return (cardType)input;
                }
            }
            public static float FetchRate(cardType card,float numOfCardLeft)
            {
                switch (card)
                {
                    case cardType.A:
                    case cardType.Two:
                    case cardType.Three:
                    case cardType.Four:
                    case cardType.Five:
                    case cardType.Six:
                    case cardType.Seven:
                    case cardType.Eight:
                    case cardType.Nine:
                        return 4 / numOfCardLeft;
                    case cardType.Ten: //statically it is the same for all card when under independent event, but it can be different if the calculation solution is based on the dependent event of probaility.
                        return 16 / numOfCardLeft;
                }
                return -1;
            }
            public static int FetchNumber(cardType card)
            {
                switch (card)
                {
                    case cardType.A:
                    case cardType.Two:
                    case cardType.Three:
                    case cardType.Four:
                    case cardType.Five:
                    case cardType.Six:
                    case cardType.Seven:
                    case cardType.Eight:
                    case cardType.Nine:
                        return 4;
                    case cardType.Ten:
                        return 16;
                }
                return -1;
            }
            public static Tuple<int, int> FetchValue(cardType card)
            {
                switch (card)
                {
                    case cardType.A:
                        return new Tuple<int, int>(1, 11);
                    case cardType.Two:
                    case cardType.Three:
                    case cardType.Four:
                    case cardType.Five:
                    case cardType.Six:
                    case cardType.Seven:
                    case cardType.Eight:
                    case cardType.Nine:
                    case cardType.Ten:
                        return new Tuple<int, int>((int)card, -1);
                }
                return new Tuple<int, int>(-1, -1);
            }
        }
    }
}
