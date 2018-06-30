using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_NumberWars
{
    class Program
    {
        private const int maxCounter = 1_000_000;
        static void Main(string[] args)
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCards =new Queue<string>(Console.ReadLine().Split());

            var turnsCounter = 0;
            bool gameOver = false;

            while (turnsCounter<1_000_000 && firstAllCards.Count>0 && secondAllCards.Count>0 && !gameOver)
            {
                turnsCounter++;

                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();
                if (GetNumebr(firstCard) > GetNumebr(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumebr(firstCard) < GetNumebr(secondCard))
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string> {firstCard, secondCard};
                    while (!gameOver)
                    {
                        if(firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandsCard = firstAllCards.Dequeue();
                                var secondHandCard = secondAllCards.Dequeue();
                                firstSum += GetChar(firstHandsCard);
                                secondSum = GetChar(secondHandCard);

                                cardsHand.Add(firstHandsCard);
                                cardsHand.Add(secondHandCard);

                            }
                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsHand, firstAllCards);
                                break;
                            }
                            else if(firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsHand,secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }

                }
            }
            var result = "";
            if (firstAllCards.Count == secondAllCards.Count)
            {
                result = "Draw";
            }
            else if (firstAllCards.Count > secondAllCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }
            Console.WriteLine($"{result} after {turnsCounter} turns");
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c=>GetNumebr(c)).ThenByDescending(c=>GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        static int GetNumebr(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetChar(string card)
        {
            return (int) card[card.Length - 1];
        }
    }
}
