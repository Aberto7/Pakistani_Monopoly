using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;

namespace Monopoly
{
    public class Board : MonoBehaviour
    {
        public List<Location> locations;
        public List<Card> chanceCards;
        public List<Card> communityChestCards;

        public void RemovePiece(GameObject piece)
        {
            Destroy(piece);
        }

        // Refactor this to make it easier to read
        public void SetUpLocations()
        {
            this.locations = new List<Location>();
            this.locations.Add(new Location("GO", new Vector3(-25.0f, 0f, 25.0f)));
            this.locations.Add(new Property("M.A. Jinnah Road", 6000, 500, 20, new Vector3(-19.0f, 0f, 25.0f), new int[] {1, 3}));
            this.locations.Add(new Location("Community Chest", new Vector3(-15.0f, 0f, 25.0f)));
            this.locations.Add(new Property("Denso Hall", 6000, 500, 40, new Vector3(-11.0f, 0f, 25.0f), new int[] {1, 3}));
            this.locations.Add(new Tax("Income Tax", 200, new Vector3(-6.0f, 0f, 25.0f)));
            this.locations.Add(new Railroad("City Station RailRoad", new Vector3(-2.0f, 0f, 25.0f)));
            this.locations.Add(new Property("Burns Road", 1000, 500, 60, new Vector3(3.0f, 0f, 25.0f), new int[] {6, 8, 9}));
            this.locations.Add(new Location("Chance", new Vector3(7.0f, 0f, 25.0f)));
            this.locations.Add(new Property("Liaquatabad", 1000, 500, 60, new Vector3(12.0f, 0f, 25.0f), new int[] {6, 8, 9}));
            this.locations.Add(new Property("Numaish", 1200, 500, 80, new Vector3(16.0f, 0f, 25.0f), new int[] {6, 8, 9}));
            this.locations.Add(new Location("Jail", new Vector3(23.0f, 0f, 25.0f)));
            this.locations.Add(new Property("Bolten Market", 1400, 1000, 100, new Vector3(23.0f, 0f, 19.0f), new int[] {11, 13, 14}));
            this.locations.Add(new Utility("Electric Company", new Vector3(23.0f, 0f, 14.0f)));
            this.locations.Add(new Property("Tower", 1400, 1000, 100, new Vector3(23.0f, 0f, 10.0f), new int[] {11, 13, 14}));
            this.locations.Add(new Property("Tariq Road", 1600, 1000, 120, new Vector3(23.0f, 0f, 5.0f), new int[] {11, 13, 14}));
            this.locations.Add(new Railroad("Cantt Station", new Vector3(23.0f, 0f, 0.0f)));
            this.locations.Add(new Property("Soldier Bazzar", 1800, 1000, 140, new Vector3(23.0f, 0f, -4.0f), new int[] {16, 18, 19}));
            this.locations.Add(new Location("Community Chest", new Vector3(23.0f, 0f, -8.0f)));
            this.locations.Add(new Property("New Karachi", 1800, 1000, 140, new Vector3(23.0f, 0f, -13.0f), new int[] {16, 18, 19}));
            this.locations.Add(new Property("Malir Cantt", 2000, 1000, 160, new Vector3(23.0f, 0f, -17.0f), new int[] {16, 18, 19}));
            this.locations.Add(new Location("Free Parking", new Vector3(23.0f, 0f, -24.0f)));
            this.locations.Add(new Property("Haideri Market", 2200, 1500, 180, new Vector3(17.0f, 0f, -24.0f), new int[] {21, 23, 24}));
            this.locations.Add(new Location("Chance", new Vector3(12.0f, 0f, -24.0f)));
            this.locations.Add(new Property("Sadddar Market", 2200, 1500, 180, new Vector3(8.0f, 0f, -24.0f), new int[] {21, 23, 24}));
            this.locations.Add(new Property("Empress Market", 2400, 1500, 200, new Vector3(3.0f, 0f, -24.0f), new int[] {21, 23, 24}));
            this.locations.Add(new Railroad("Drigh Road Station", new Vector3(-1.0f, 0f, -24.0f)));
            this.locations.Add(new Property("Sarafa Bazzar", 2600, 1500, 220, new Vector3(-6.0f, 0f, -24.0f), new int[] {26, 27, 29}));
            this.locations.Add(new Property("Jama Cloth Market", 2600, 1500, 220, new Vector3(-10.0f, 0f, -24.0f), new int[] {26, 27, 29}));
            this.locations.Add(new Utility("Water Works", new Vector3(-15.0f, 0f, -24.0f)));
            this.locations.Add(new Property("Gulshan-e-Iqbal", 2800, 1500, 240, new Vector3(-19.0f, 0f, -24.0f), new int[] {26, 27, 29}));
            this.locations.Add(new Location("Go To Jail", new Vector3(-25.0f, 0f, -24.0f)));
            this.locations.Add(new Property("Gulzar-e-Hijri", 3000, 2000, 260, new Vector3(-25.0f, 0f, -18.0f), new int[] {31, 32, 34}));
            this.locations.Add(new Property("Juna Market", 3000, 2000, 260, new Vector3(-25.0f, 0f, -14.0f), new int[] {31, 32, 34}));
            this.locations.Add(new Location("Community Chest", new Vector3(-25.0f, 0f, -9.0f)));
            this.locations.Add(new Property("I.I. Chundrigar Road", 3200, 2000, 280, new Vector3(-25.0f, 0f, -4.0f), new int[] {31, 32, 34}));
            this.locations.Add(new Railroad("Landhi Station", new Vector3(-25.0f, 0f, 0.0f)));
            this.locations.Add(new Location("Chance", new Vector3(-25.0f, 0f, 5.0f)));
            this.locations.Add(new Property("Clifton", 3500, 2000, 350, new Vector3(-25.0f, 0f, 10.0f), new int[] {37, 39}));
            this.locations.Add(new Tax("Luxury Tax", 100, new Vector3(-25.0f, 0f, 14.0f)));
            this.locations.Add(new Property("Keamari", 4000, 2000, 500, new Vector3(-25.0f, 0f, 19.0f), new int[] {37, 39}));

            SetUpHouseLocations();
        }

        public void SetUpHouseLocations()
        {
            // Last house is location for hotel - 
            // will be the same as the location for the first house so we don't store it again
            // Houses are spaced 1 unit apart
            locations[1].houseLocations = new Vector3[] {new Vector3(-16f, 0f, 21.5f), new Vector3(-17f, 0f, 21.5f), new Vector3(-18f, 0f, 21.5f), new Vector3(-19f, 0f, 21.5f)};
            locations[1].houseRotation = Quaternion.Euler(270, 0, 0);

            locations[3].houseLocations = new Vector3[] {new Vector3(-7f, 0f, 21.5f), new Vector3(-8f, 0f, 21.5f), new Vector3(-9f, 0f, 21.5f), new Vector3(-10f, 0f, 21.5f)};
            locations[3].houseRotation = Quaternion.Euler(270, 0, 0);

            locations[6].houseLocations = new Vector3[] {new Vector3(6.5f, 0f, 21.5f), new Vector3(5.5f, 0f, 21.5f), new Vector3(4.5f, 0f, 21.5f), new Vector3(3.5f, 0f, 21.5f)};
            locations[6].houseRotation = Quaternion.Euler(270, 0, 0);

            locations[8].houseLocations = new Vector3[] {new Vector3(15.5f, 0f, 21.5f), new Vector3(14.5f, 0f, 21.5f), new Vector3(13.5f, 0f, 21.5f), new Vector3(12.5f, 0f, 21.5f)};
            locations[8].houseRotation = Quaternion.Euler(270, 0, 0);

            locations[9].houseLocations = new Vector3[] {new Vector3(20f, 0f, 21.5f), new Vector3(19f, 0f, 21.5f), new Vector3(18f, 0f, 21.5f), new Vector3(17f, 0f, 21.5f)};
            locations[9].houseRotation = Quaternion.Euler(270, 0, 0);

            locations[11].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, 16f), new Vector3(21.5f, 0f, 17f), new Vector3(21.5f, 0f, 18f), new Vector3(21.5f, 0f, 19f)};
            locations[11].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[13].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, 7f), new Vector3(21.5f, 0f, 8f), new Vector3(21.5f, 0f, 9f), new Vector3(21.5f, 0f, 10f)};
            locations[13].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[14].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, 2.5f), new Vector3(21.5f, 0f, 3.5f), new Vector3(21.5f, 0f, 4.5f), new Vector3(21.5f, 0f, 5.5f)};
            locations[14].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[16].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, -6.5f), new Vector3(21.5f, 0f, -5.5f), new Vector3(21.5f, 0f, -4.5f), new Vector3(21.5f, 0f, -3.5f)};
            locations[16].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[18].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, -15.5f), new Vector3(21.5f, 0f, -14.5f), new Vector3(21.5f, 0f, -13.5f), new Vector3(21.5f, 0f, -12.5f)};
            locations[18].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[19].houseLocations = new Vector3[] {new Vector3(21.5f, 0f, -20f), new Vector3(21.5f, 0f, -19f), new Vector3(21.5f, 0f, -18f), new Vector3(21.5f, 0f, -17f)};
            locations[19].houseRotation = Quaternion.Euler(270, 0, 90);

            locations[21].houseLocations = new Vector3[] {new Vector3(16f, 0f, -21.5f), new Vector3(17f, 0f, -21.5f), new Vector3(18f, 0f, -21.5f), new Vector3(19f, 0f, -21.5f)};
            locations[21].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[23].houseLocations = new Vector3[] {new Vector3(7f, 0f, -21.5f), new Vector3(8f, 0f, -21.5f), new Vector3(9f, 0f, -21.5f), new Vector3(10f, 0f, -21.5f)};
            locations[23].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[24].houseLocations = new Vector3[] {new Vector3(2.5f, 0f, -21.5f), new Vector3(3.5f, 0f, -21.5f), new Vector3(4.5f, 0f, -21.5f), new Vector3(5.5f, 0f, -21.5f)};
            locations[24].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[26].houseLocations = new Vector3[] {new Vector3(-6.5f, 0f, -21.5f), new Vector3(-5.5f, 0f, -21.5f), new Vector3(-4.5f, 0f, -21.5f), new Vector3(-3.5f, 0f, -21.5f)};
            locations[26].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[27].houseLocations = new Vector3[] {new Vector3(-11f, 0f, -21.5f), new Vector3(-10f, 0f, -21.5f), new Vector3(-9f, 0f, -21.5f), new Vector3(-8f, 0f, -21.5f)};
            locations[27].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[29].houseLocations = new Vector3[] {new Vector3(-20f, 0f, -21.5f), new Vector3(-19f, 0f, -21.5f), new Vector3(-18f, 0f, -21.5f), new Vector3(-17f, 0f, -21.5f)};
            locations[29].houseRotation = Quaternion.Euler(270, 0, 180);

            locations[31].houseLocations = new Vector3[] {new Vector3(-21.5f, 0f, -16f), new Vector3(-21.5f, 0f, -17f), new Vector3(-21.5f, 0f, -18f), new Vector3(-21.5f, 0f, -19f)};
            locations[31].houseRotation = Quaternion.Euler(270, 0, 270);

            locations[32].houseLocations = new Vector3[] {new Vector3(-21.5f, 0f, -11.5f), new Vector3(-21.5f, 0f, -12.5f), new Vector3(-21.5f, 0f, -13.5f), new Vector3(-21.5f, 0f, -14.5f)};
            locations[32].houseRotation = Quaternion.Euler(270, 0, 270);

            locations[34].houseLocations = new Vector3[] {new Vector3(-21.5f, 0f, -2.5f), new Vector3(-21.5f, 0f, -3.5f), new Vector3(-21.5f, 0f, -4.5f), new Vector3(-21.5f, 0f, -5.5f)};
            locations[34].houseRotation = Quaternion.Euler(270, 0, 270);

            locations[37].houseLocations = new Vector3[] {new Vector3(-21.5f, 0f, 11f), new Vector3(-21.5f, 0f, 10f), new Vector3(-21.5f, 0f, 9f), new Vector3(-21.5f, 0f, 8f)};
            locations[37].houseRotation = Quaternion.Euler(270, 0, 270);

            locations[39].houseLocations = new Vector3[] {new Vector3(-21.5f, 0f, 20f), new Vector3(-21.5f, 0f, 19f), new Vector3(-21.5f, 0f, 18f), new Vector3(-21.5f, 0f, 17f)};
            locations[39].houseRotation = Quaternion.Euler(270, 0, 270);
        }

        public void SetUpCards()
        {
            this.chanceCards = new List<Card>();
            this.chanceCards.Add(new Card("You have been elected chairman of the board. Pay the bank PKR 50.", -50, null));
            this.chanceCards.Add(new Card("Advance to Boardwalk", 0, 39));
            this.chanceCards.Add(new Card("Your building loan matures. Collect PKR 150.", 150, null));
            this.chanceCards.Add(new Card("Advance to GO.", 0, 0));
            this.chanceCards.Add(new Card("Bank pays you dividend of PKR 50.", 50, null));
            this.chanceCards.Add(new Card("General repairs - pay PKR 100", -100, null));
            this.chanceCards.Add(new Card("Advance to St. Charles Place.", 0, 11));
            this.chanceCards.Add(new Card("Advance to Illinois Avenue.", 0, 24));
            this.chanceCards.Add(new Card("GO TO JAIL, pay PKR 50.", -50, 10));
            this.chanceCards.Add(new Card("Take a trip to Reading Railroad.", 0, 5));
            this.chanceCards.Add(new Card("Speeding fine PKR 15.", -15, null));

            this.communityChestCards = new List<Card>();
            this.communityChestCards.Add(new Card("Pay hospital fees of PKR 100.", -100, null));
            this.communityChestCards.Add(new Card("From sale of stock you get PKR 50.", 50, null));
            this.communityChestCards.Add(new Card("Income tax refund. Collect PKR 20.", 20, null));
            this.communityChestCards.Add(new Card("It is your birthday. Collect PKR 30", 30, null));
            this.communityChestCards.Add(new Card("You inherit PKR 100.", 100, null));
            this.communityChestCards.Add(new Card("Street repairs - pay PKR 80.", -80, null));
            this.communityChestCards.Add(new Card("Holiday fund matures. Receive PKR 100.", 100, null));
            this.communityChestCards.Add(new Card("You have won second prize in a beauty contest. Collect PKR 10.", 10, null));
            this.communityChestCards.Add(new Card("Receive PKR 25 consultancy fee.", 25, null));
            this.communityChestCards.Add(new Card("Bank error in your favour. Collect PKR 200.", 200, null));
            this.communityChestCards.Add(new Card("GO TO JAIL, pay PKR 50.", -50, 10));
            this.communityChestCards.Add(new Card("Life insurance matures. Collect PKR 100.", 100, null));
            this.communityChestCards.Add(new Card("Doctor's fees. Pay PKR 50.", -50, null));
            this.communityChestCards.Add(new Card("Advance to GO.", 0, 0));
            this.communityChestCards.Add(new Card("Pay school fees of PKR 50.", -50, null));

            // Randomize order of cards by assigning each item to random number and 
            // resorting them in ascending order of this assigned number
            System.Random rand = new System.Random();
            this.chanceCards = this.chanceCards
                .Select(x => new { value = x, order = rand.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.value).ToList();
            this.communityChestCards = this.communityChestCards
                .Select(x => new { value = x, order = rand.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.value).ToList();
        }

        public Card DrawChance()
        {
            Card first = chanceCards[0];
            // Draw card from "top" of deck and put it on the bottom
            for (int i = 1; i < chanceCards.Count; i++) {
                chanceCards[i-1] = chanceCards[i];
            }
            chanceCards[chanceCards.Count-1] = first;
            return first;
        }

        public Card DrawCommunityChest()
        {
            Card first = communityChestCards[0];
            // Draw card from "top" of deck and put it on the bottom
            for (int i = 1; i < communityChestCards.Count; i++) {
                communityChestCards[i-1] = communityChestCards[i];
            }
            communityChestCards[communityChestCards.Count-1] = first;
            return first;
        }
    }
}