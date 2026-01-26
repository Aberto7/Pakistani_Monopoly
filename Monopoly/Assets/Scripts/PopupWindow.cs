using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections.Generic;

namespace Monopoly
{
    public class PopupWindow : MonoBehaviour
    {

        [SerializeField]
        private Text windowText;

        private Dictionary<int, string> propertyColours;

        void Start() {
            InitializeColours();
        }

        public void DisplayText(string text) {
            windowText.text = text;
            this.gameObject.SetActive(true);
        }

        public void DisplayOwnedProperties()
        {
            string text = "<b>My Properties</b>";

            bool[] ownedProperties = (bool[])PhotonNetwork.LocalPlayer.CustomProperties["OwnedProperties"];
            for (int i = 0; i < 40; i++) {
                if (ownedProperties[i] == true) {
                    if (propertyColours.ContainsKey(i)) { // Put a coloured square corresponding to properties
                        text = text +"\n" + "<color="+ propertyColours[i] +">"+ "■</color> " + GameManager.instance.board.locations[i].name;
                    }
                    else {
                        text = text + "\n" + "<color=8C8C8C>■</color> " + GameManager.instance.board.locations[i].name;
                    }
                }
            }
            windowText.text = text;
            this.gameObject.SetActive(true);
        }
        public void DisplayPropertyInfo(int propertyNum)
        {
            if (propertyNum == -1) {
                string text = "<b>City Station Railroad</b>";
                Railroad readingRailroad = (Railroad)GameManager.instance.board.locations[5];
                if (readingRailroad.owner == null) {
                    text = text + " - Owner: None";
                } else text = text + " - Owner: " + readingRailroad.owner.NickName;

                Railroad pennsylvaniaRailroad = (Railroad)GameManager.instance.board.locations[15];
                text = text + "\n<b>Cantt Station</b>";
                if (pennsylvaniaRailroad.owner == null) {
                    text = text + " - Owner: None";
                } else text = text + " - Owner: " + pennsylvaniaRailroad.owner.NickName;

                Railroad bAndORailroad = (Railroad)GameManager.instance.board.locations[25];
                text = text + "\n<b>Drigh Road Station</b>";
                if (bAndORailroad.owner == null) {
                    text = text + " - Owner: None";
                } else text = text + " - Owner: " + bAndORailroad.owner.NickName;

                Railroad shortLine = (Railroad)GameManager.instance.board.locations[35];
                text = text + "\n<b>Landhi Station</b>";
                if (shortLine.owner == null) {
                    text = text + " - Owner: None";
                } else text = text + " - Owner: " + shortLine.owner.NickName;

                text = text + "\n\nPrice: PKR 2000\n\nRent:\n1 owned: PKR 25\n2 owned: PKR 50\n3 owned: PKR 100\n4 owned: PKR 200";
                windowText.text = text;
            }

            else if (propertyNum == -2) {
                string text = "<b>Electric Company</b>\n";
                Utility electricCompany = (Utility)GameManager.instance.board.locations[12];
                if (electricCompany.owner == null) {
                    text = text + "Owner: None";
                } else text = text + "Owner: " + electricCompany.owner.NickName;

                text = text + "\n\n<b>Water Works</b>\n";
                Utility waterWorks = (Utility)GameManager.instance.board.locations[28];
                if (waterWorks.owner == null) {
                    text = text + "Owner: None";
                } else text = text + "Owner: " + waterWorks.owner.NickName;

                text = text + "\n\nPrice: PKR 1500";
                text = text + "\n\nRent:\n1 utility owned: PKR 40 x diceroll";
                text = text + "\n2 utility owned: PKR 100 x diceroll";
                windowText.text = text;
            }

            else if (GameManager.instance.board.locations[propertyNum] is Property) {
                Property property = (Property)GameManager.instance.board.locations[propertyNum];
                string text = "<b>" + property.name + "</b>\n";
                if (property.owner == null) {
                    text = text + "Owner: None";
                } else text = text + "Owner: " + property.owner.NickName;

                text = text + "\nPrice: PKR " + property.price;
                text = text + "\nHouse price: PKR " + property.housePrice;
                text = text + "\nNumber of houses built: " + property.numHouses;
                int baseRent = property.baseRent;

                text = text + "\n\nRent:\n0 houses: PKR " + baseRent;
                text = text + "\n1 house: PKR " + (baseRent * 5);
                text = text + "\n2 houses: PKR " + (baseRent * 15);
                text = text + "\n3 houses: PKR " + (baseRent * 45);
                text = text + "\n4 houses: PKR " + ((baseRent * 45)+200);
                text = text + "\n5 houses (hotel): PKR " + ((baseRent * 45)+400);
                windowText.text = text;
            }
            this.gameObject.SetActive(true);
        }

        private void InitializeColours() {
            propertyColours = new Dictionary<int, string>();
            propertyColours.Add(1, "#7B4800");
            propertyColours.Add(3, "#7B4800");

            propertyColours.Add(6, "#3CBEE0");
            propertyColours.Add(8, "#3CBEE0");
            propertyColours.Add(9, "#3CBEE0");

            propertyColours.Add(11, "#EC36A0");
            propertyColours.Add(13, "#EC36A0");
            propertyColours.Add(14, "#EC36A0");

            propertyColours.Add(16, "#E08110");
            propertyColours.Add(18, "#E08110");
            propertyColours.Add(19, "#E08110");

            propertyColours.Add(21, "#CF2C14");
            propertyColours.Add(23, "#CF2C14");
            propertyColours.Add(24, "#CF2C14");

            propertyColours.Add(26, "#E2CB1F");
            propertyColours.Add(27, "#E2CB1F");
            propertyColours.Add(29, "#E2CB1F");

            propertyColours.Add(31, "#199F1B");
            propertyColours.Add(32, "#199F1B");
            propertyColours.Add(34, "#199F1B");

            propertyColours.Add(37, "#152098");
            propertyColours.Add(39, "#152098");
        }
    }
}