using System.Collections.Generic;

namespace CivWar{
    public class TownStorage
    {
        private List<ResourcePacket> resourcePackets = new List<ResourcePacket>();
        public List<ResourcePacket> p_ResourcePackets => resourcePackets;

        public TownStorage(List<ResourcePacket> resourcePackets)
        {
            this.resourcePackets = resourcePackets;
        }

        public void AddResource(ResourcePacket resourcePacket)
        {
            foreach(ResourcePacket packet in this.resourcePackets)
            {
                packet.Add(resourcePacket);
            }
        }

        public void RemoveResource(ResourcePacket resourcePacket)
        {
            foreach(ResourcePacket packet in this.resourcePackets)
            {
                packet.Remove(resourcePacket);
            }
        }
    }
}
