using System.Collections.Generic;

namespace CivWar{
    public struct ProduceUnitCommonStates
    {
        private List<ResourcePacket> resourceRequestForSpawn;
        private int carryingResourceCapacity;
        private int onceExtractionCapacity;
        private float gatheringInterval;

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
