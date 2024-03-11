using UniRx;
using CivWar.Const;
using UnityEngine;

namespace CivWar{
    [System.Serializable]
    public class ResourcePacket
    {
        [SerializeField] private ResourceType type;
        [SerializeField] private ReactiveProperty<int> amount = new ReactiveProperty<int>();

        public ResourceType Type => type;
        public ReactiveProperty<int> Amount => amount;

        public ResourcePacket(ResourceType type = ResourceType.None, int amount = 0)
        {
            this.type = type;
            this.amount.Value = amount;
        }

        public bool IsEnoughResource(ResourcePacket resourcePacket)
        {
            if(resourcePacket.type != this.type) return false;
            if(resourcePacket.amount.Value < this.amount.Value) return false;
            return true;
        }

        public void Add(ResourcePacket resourcePacket)
        {
            if(resourcePacket.type == ResourceType.None) return;
            if(this.type != resourcePacket.type) return;
            this.amount.Value += resourcePacket.amount.Value;
        }

        public void Remove(ResourcePacket resourcePacket)
        {
            if(resourcePacket.type == ResourceType.None) return;
            if(resourcePacket.type != this.type) return;
            this.amount.Value -= resourcePacket.amount.Value;
            if(this.amount.Value < 0) this.amount.Value = 0;
        }
    }
}