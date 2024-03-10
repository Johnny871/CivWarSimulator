using UnityEngine;
using CivWar.Const;
using DG.Tweening;

namespace CivWar{
    public abstract class Resource : MonoBehaviour
    {
        protected ResourceType resourceType;
        public ResourceType p_ResourceType => resourceType;
        protected int resourceAmount;
        public int ResourceAmount => resourceAmount;
        protected int maxAmount;
        protected bool duaringWorked = false;
        public bool DuaringWorked => duaringWorked;

        public virtual void Initialize(int resourceAmount, int maxAmount, ResourceType resourceType)
        {
            this.resourceAmount = resourceAmount;
            this.maxAmount = maxAmount;
            this.resourceType = resourceType;
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
            if(resourceAmount + requireAmount > maxAmount) return false;
            resourceAmount += requireAmount;
            return true;
        }

        public bool Remove(int requireAmount)
        {
            if (resourceAmount < requireAmount) return false;
            resourceAmount -= requireAmount;
            if(resourceAmount <= 0) BecomeEmpty();
            this.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.07f).SetLoops(2, LoopType.Yoyo);
            return true;
        }
    }
}
