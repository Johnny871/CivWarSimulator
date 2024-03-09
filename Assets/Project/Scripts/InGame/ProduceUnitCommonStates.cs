using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ProduceUnitCommonStates
{
    private int carryingResourceCapacity;
    private int onceExtractionCapacity;
    private float gatheringInterval;

    public int CarryingResourceCapacity => carryingResourceCapacity;
    public int OnceExtractionCapacity => onceExtractionCapacity;
    public float GatheringInterval => gatheringInterval;
    public ProduceUnitCommonStates(int carryingResourceCapacity, int onceExtractionCapacity, float gatheringInterval)
    {
        this.carryingResourceCapacity = carryingResourceCapacity;
        this.onceExtractionCapacity = onceExtractionCapacity;
        this.gatheringInterval = gatheringInterval;
    }
}
