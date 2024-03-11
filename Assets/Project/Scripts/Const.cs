using System;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public enum StrategyBalance
    {
        SuperEconomy,
        HighlyEconomy,
        BitEconomy,
        Balance,
        BitWarlike,
        HighlyWarlike,
        SuperWarlike
    }

    [System.Serializable]
    public struct ResourcePacket
    {
        public ResourceType resourceType;
        public int resourceAmount;
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

    public class EnumUtility
    {
        public static int GetTypeNum<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static T GetRandom<T>() where T : struct
        {
            int num = Random.Range(0, GetTypeNum<T>());
            return NoToType<T>(num);
        }

        public static T NoToType<T>(int targetNum) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), targetNum);
        }
    }
}

