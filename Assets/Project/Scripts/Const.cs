using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CivWar.Const{

        public enum UnitType
        {
            Producer,
            Soldier
        }

        public enum ResourceType
        {
            None,
            Wood,
            Stone,
            Wheat
        }

        public enum TeamColor
        {
            None = 0,    
            Red = 1,
            Blue = 2,
            Yellow = 3,
            Green = 4
        }

        public enum ProduceUnitState
        {
            DoNothing,
            Searching,
            Gathering,
            Carrying
        }

        public class ConstFormatter
        {
            public static Color GetColor(TeamColor teamColor)
            {
                switch(teamColor)
                {
                    case TeamColor.Red:
                        return Color.red;
                        break;
                    case TeamColor.Blue:
                        return Color.blue;
                        break;
                    case TeamColor.Yellow:
                        return Color.yellow;
                        break;
                    case TeamColor.Green:
                        return Color.green;
                        break;
                }
                return Color.white;
            }
        }
    }

