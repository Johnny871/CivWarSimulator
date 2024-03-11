using System.Collections.Generic;
using CivWar.Const;

namespace CivWar{
    public struct ProduceUnitCommonStates
    {
        private List<ResourcePacket> resourceRequestForSpawn;
        private int carryingResourceCapacity;
        private int onceExtractionCapacity;
        private float gatheringInterval;

        public int CarryingResourceCapacity => carryingResourceCapacity;
        public int OnceExtractionCapacity => onceExtractionCapacity;
        public float GatheringInterval => gatheringInterval;

        public ProduceUnitCommonStates(List<ResourcePacket> resourceRequestForSpawn, int carryingResourceCapacity, int onceExtractionCapacity, float gatheringInterval)
        {
            this.resourceRequestForSpawn = resourceRequestForSpawn;
            this.carryingResourceCapacity = carryingResourceCapacity;
            this.onceExtractionCapacity = onceExtractionCapacity;
            this.gatheringInterval = gatheringInterval;
        }
    }
}
