using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;

namespace CivWar{
    public class TownHall : MonoBehaviour
    {
        [SerializeField] private GameObject
        produceUnitPref,
        soldierUnitPref;
        [SerializeField] private Transform spawnPoint;
        private TownHallModel model;
        public void Initialize(TeamColor team)
        {
            if(model == null)
            {
                model = new TownHallModel(team);
            }
            var color = GetColor(model.Team);
            if(color != Color.white)
            {
                var render = GetComponent<Renderer>();
                render.material.color = color;
            }
        }

        private Color GetColor(TeamColor team)
        {        
            switch(team)
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

        public void InstantiateUnit(UnitType type)
        {
            switch(type)
            {
                case UnitType.Producer:
                    var unit = Instantiate(produceUnitPref, spawnPoint);
                    unit.GetComponent<ProduceUnit>().Initialize(model.Team, this.transform);
                    break;
                case UnitType.Soldier:
                    break;
            }
        }
    }
}
