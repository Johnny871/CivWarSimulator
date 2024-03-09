using System.Collections;
using System.Collections.Generic;
using CivWar.Const;
using Unity.VisualScripting;
using UnityEngine;

namespace CivWar{
    public class Wheat : Resource
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