using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;

namespace CivWar{
    [RequireComponent(typeof(Warehouse))]
    public class TownHall : MonoBehaviour
    {
        [SerializeField] private GameObject
        produceUnitPref,
        soldierUnitPref;
        [SerializeField] private Transform spawnPoint;
        private TeamColor teamColor;
        private TownStorage townStorage = new TownStorage(0, 0);
        public TownStorage p_TownStorage => townStorage;
        private ProduceUnitCommonStates produceUnitCommonStates = new ProduceUnitCommonStates();
        public ProduceUnitCommonStates p_produceUnitCommonStates => produceUnitCommonStates;
        [SerializeField] private int carryingResourceCapacity;
        [SerializeField] private int onceExtractionCapacity;
        [SerializeField] private float gatheringInterval;
        [SerializeField] private int initProduceUnitSpawnCount;

        public void Initialize(TeamColor team)
        {
            Debug.LogFormat("{0}チームのタウンホール初期化", team);
            this.teamColor = team;
            var color = ConstFormatter.GetColor(team);
            if(color != Color.white)
            {
                var render = GetComponentInChildren<Renderer>();
                render.material.color = color;
            }
            GetComponent<Warehouse>().Initialize(this, team);
            
            InstantiateUnit(UnitType.Producer, initProduceUnitSpawnCount);
        }

        private void Awake()
        {
            produceUnitCommonStates = new ProduceUnitCommonStates(carryingResourceCapacity, onceExtractionCapacity, gatheringInterval);
        }

        public void InstantiateUnit(UnitType type, int unitCount)
        {
            Debug.LogFormat("{0}体の生産ユニットを生成開始", unitCount);
            if(unitCount <= 0) return;
            while(unitCount > 0)
            {
                switch(type)
                {
                    case UnitType.Producer:
                        var unit = Instantiate(produceUnitPref, spawnPoint.position, Quaternion.identity);
                        unit.GetComponent<ProduceUnit>().Initialize(this, teamColor);
                        break;
                    case UnitType.Soldier:
                        break;
                }
                unitCount--;
            }
            Debug.Log("生産ユニットを生成完了");
        }

        public void AddResource(ResourceType resourceType, int resourceAmount)
        {
            townStorage.AddResource(resourceType, resourceAmount);
        }

        public void RemoveResource(ResourceType resourceType, int resourceAmount)
        {
            townStorage.RemoveResource(resourceType, resourceAmount);
        }
    }
}
