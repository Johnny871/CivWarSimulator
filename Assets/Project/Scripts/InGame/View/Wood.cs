using CivWar.Const;
using UnityEngine;

namespace CivWar{
    public class Wood : Resource
    {
        [SerializeField] private int 
        _resourceAmount,
        _maxAmount;
        [SerializeField] private ResourceType _resourceType;

        private void Awake()
        {
            base.Initialize(_resourceAmount, _maxAmount, _resourceType);
        }
    }
}
