using UnityEngine;
using CivWar.Const;
using DG.Tweening;
using UniRx;

namespace CivWar{
    public abstract class Resource : MonoBehaviour
    {
        protected ResourcePacket resourcePacket;
        public ResourcePacket p_ResourcePacket => resourcePacket;
        protected bool duaringWorked = false;
        public bool DuaringWorked => duaringWorked;

        public virtual void Initialize(ResourcePacket resourcePacket)
        {
            this.resourcePacket = resourcePacket;
            resourcePacket.Amount.Subscribe(resourceAmount =>
            {
                if(resourceAmount <= 0) BecomeEmpty();
            })
            .AddTo(this);
        }
        
        public void SetIsWorked(bool duaringWorked)
        {
            this.duaringWorked = duaringWorked;
        }

        private void BecomeEmpty()
        {
            Destroy(this.gameObject);
        }

        public bool Add(int requireAmount)
        {
            resourcePacket.Add(new ResourcePacket(this.resourcePacket.Type, requireAmount));
            return true;
        }

        public bool Remove(int requireAmount)
        {
            if (resourcePacket.Amount.Value < requireAmount) return false;
            resourcePacket.Remove(new ResourcePacket(this.resourcePacket.Type, requireAmount));
            this.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.07f).SetLoops(2, LoopType.Yoyo);
            return true;
        }
    }
}
