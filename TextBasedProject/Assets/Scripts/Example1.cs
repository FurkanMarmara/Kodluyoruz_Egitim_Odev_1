using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example1 {

    interface User
    {
        Deck GetDeck();
        void SetDeck(Deck deck);
    }

    public class Controller
    {
        private Player _user;
        private Player _user2;

        public Controller()
        {
            _user = new Player();
            _user2 = new Player();
            Start();
        }

        private void Start()
        {
            GameManager.Get().StartCoroutine(FakeUpdate(0.2f));
        }

        IEnumerator FakeUpdate(float time)
        {
            var loopTime = new WaitForSeconds(time);

            while (true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    RoundControl();
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    _user.SetDeck(new Deck(10,null,true));
                    _user2.SetDeck(new Deck(10, null, true));
                    Debug.Log("Desteler Değiştirildi");
                }
                yield return loopTime;

            }
        }

        private void RoundControl()
        {
            int playerWonCount = 0;
            int player2WonCount = 0;
            for (int i = 0; i < 10; i++)
            {
                if (_user.GetDeck().GetCard(i).Power < _user2.GetDeck().GetCard(i).Power)
                {
                    player2WonCount++;
                    //Debug.Log("AI Kazandı");
                }
                else if (_user.GetDeck().GetCard(i).Power > _user2.GetDeck().GetCard(i).Power)
                {
                    playerWonCount++;
                    //Debug.Log("User Kazandı");
                }
                else
                {
                    //Debug.Log("Berabere");
                }
            }
            if (playerWonCount > player2WonCount)
            {
                Debug.Log("Player1 Kazandı " + playerWonCount + " : " + player2WonCount);
            }
            else if (player2WonCount > playerWonCount)
            {
                Debug.Log("Player2 Kazandı " + player2WonCount + " : " + playerWonCount);
            }
            else
            {
                Debug.Log("Berabere " + playerWonCount + " : " + player2WonCount);
            }
        }
    }

    public class Player : User
    {

        private Deck _myDeck;

        public Player()
        {
            _myDeck = new Deck(10,null,true);
        }

        public Deck GetDeck()
        {
            return _myDeck;
        }

        public void SetDeck(Deck deck)
        {
            _myDeck = deck;
        }
    }

    public class Deck
    {
        private List<Card> _myCards = new List<Card>();

        public Deck(int cardCount, Card[] cards, bool randomCard)
        {
            CreateNewDeck(cardCount,null,true);
        }

        private void CreateNewDeck(int cardCount,Card[] cards, bool randomCard)
        {
            if (randomCard)
            {
                for (int i = 0; i < cardCount; i++)
                {
                    _myCards.Add(new Card());
                }
            }
            else
            {
                for (int i = 0; i < cardCount; i++)
                {
                    _myCards.Add(cards[i]);
                }
            }
        }

        public Card GetCard(int no) //GetCard with number
        {
            if (no<_myCards.Count)
            {
                return _myCards[no];
            }
            else
            {
                return null;
            }
            
        }

        public List<Card> GetAllCard() //Get All Card
        {
            return _myCards;
        }

        public void ChangeCard(Card card,int cardNo)
        {
            _myCards[cardNo] = card;
        }
    }

    public class Card
    {
        private int _power;

        public int Power  
        {
            get { return _power; }  
            set { _power = value; }  
        }

        public Card()
        {
            Power = Random.Range(0, 10);
        }

        public Card(int power)
        {
            _power = power;
        }


    }


}


