using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;
using System;

namespace CivWar{
    [RequireComponent(typeof(Warehouse), typeof(TownHallAI))]
    public class TownHall : MonoBehaviour
    {
        [SerializeField] private GameObject
        produceUnitPref,
        soldierUnitPref;
        [SerializeField] private List<ResourcePacket>
        resourceRequestForProduceUnitSpawn,
        resourceRequestForSoldierUnitSpawn;
        [SerializeField] private Transform spawnPoint;
        private TeamColor teamColor;
        private TownStorage townStorage;
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
            //マイナス2はNone(-1)の分と配列の1要素目のIndexのゼロ分
            var resourceTypeCount = EnumUtility.GetTypeNum<ResourceType>() -2 ;
            var resourcePackets = new List<ResourcePacket>();
            while(resourceTypeCount >= 0)
            {
                var resourceType = EnumUtility.NoToType<ResourceType>(resourceTypeCount);
                resourcePackets.Add(new ResourcePacket(resourceType));
                resourceTypeCount--;
            }
            this.townStorage = new TownStorage(resourcePackets);
            var color = ConstFormatter.GetColor(team);
            if(color != Color.white)
            {
                var render = GetComponentInChildren<Renderer>();
                render.material.color = color;
            }
            GetComponent<Warehouse>().Initialize(this, team);
            GetComponent<TownHallAI>().Initialize(this);
            
            InstantiateUnit(UnitType.Producer, initProduceUnitSpawnCount);
        }

        private void Awake()
        {
            produceUnitCommonStates = new ProduceUnitCommonStates(resourceRequestForProduceUnitSpawn, carryingResourceCapacity, onceExtractionCapacity, gatheringInterval);
        }

        public void InstantiateUnit(UnitType type, int unitCount)
        {
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
        }

        public void AddResource(ResourcePacket resourcePacket)
        {
            townStorage.AddResource(resourcePacket);
        }

        public void RemoveResource(ResourcePacket resourcePacket)
        {
            townStorage.RemoveResource(resourcePacket);
        }
    }
}
