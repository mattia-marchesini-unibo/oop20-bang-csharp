using model.effects;
using System;
using System.Collections.Generic;

namespace model
{
    public class Card
    {
        private static readonly Dictionary<String, IEffects> cardsEffects = new Dictionary<string, IEffects>()
        {
            /*{
                "bang", new Bang()
            },
            {
                "shofield", new Weapon(2, "shofield")
            },
            {
                "remington", new Weapon(3, "remington")
            },
            {
              "rev carabine", new Weapon(4, "rev carabine")
            },
            {
               "winchester", new Weapon(5, "winchester")
            },
            {
                 "scope", new Scope()
            },
            {
                "mustang", new ModifyRetreat(1)
            },
            {
                "hideout", new ModifyRetreat(1)
            },
            {
                "emporium", new Emporium()
            },
            {
                "panic", new Panic()
            },
            {
                "beer", new ModifyLifePoints(1)
            },
            {
                "indians", new Indians()
            },
            {
                "dodge", new Dodge()
            },
            {
                "wells fargo", new DrawCardsFromDeck(3)
            },
            {
                "stagecoach", new DrawCardsFromDeck(2)
            },
            {
                "saloon", new Saloon(1)
            },
            {
               "gatling", new Gatling()
            },
            {
              "cat balou", new CatBalou()
            },
            {
                "jail", new Jail()
            },
            {
                "volcanic", new Weapon(1, "volcanic")
            }*/
        };

        private String LocalName { get; set; }
        public String RealName { get; }
        private String CardId { get; set; }
        public Color Color { get; set; }
        public IEffects Effect { get; set; }

        public Card(String cardId, String color, String localName, String realName)
        {
            this.CardId = cardId;
            this.LocalName = localName;
            this.RealName = realName;
            this.Color = (Color) Enum.Parse(Color.GetType(), color);
            //this.effect = cardEffects.get(realName);
            this.Effect = cardsEffects.GetValueOrDefault(realName);
        }
    }
}
