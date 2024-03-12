using System.Collections.Generic;
using UnityEngine;

namespace CivWar{
    [System.Serializable]
    public struct ProduceUnitCommonStates
    {
        [SerializeField] private List<ResourcePacket> resourceRequestForSpawn;
        [SerializeField] private int carryingResourceCapacity;
        [SerializeField] private int onceExtractionCapacity;
        [SerializeField] private float gatheringInterval;

        public List<ResourcePacket> p_ResourceRequestForSpawn => resourceRequestForSpawn;
        public int p_CarryingResourceCapacity => carryingResourceCapacity;
        public int p_OnceExtractionCapacity => onceExtractionCapacity;
        public float p_GatheringInterval => gatheringInterval;

        public ProduceUnitCommonStates(List<ResourcePacket> resourceRequestForSpawn, int carryingResourceCapacity, int onceExtractionCapacity, float gatheringInterval)
        {
            this.resourceRequestForSpawn = resourceRequestForSpawn;
            this.carryingResourceCapacity = carryingResourceCapacity;
            this.onceExtractionCapacity = onceExtractionCapacity;
            this.gatheringInterval = gatheringInterval;
        }
    }
}
