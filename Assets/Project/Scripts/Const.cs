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
            var result = Color.white;
            switch(teamColor)
            {
                case TeamColor.Red:
                    result = Color.red;
                    break;
                case TeamColor.Blue:
                    result = Color.blue;
                    break;
                case TeamColor.Yellow:
                    result = Color.yellow;
                    break;
                case TeamColor.Green:
                    result = Color.green;
                    break;
            }
            return result;
        }
    }
}

