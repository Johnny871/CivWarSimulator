using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    private ProduceUnitCommonStates produceUnitCommonStates;
    [SerializeField] private int carryingResourceCapacity;
    [SerializeField] private int onceExtractionCapacity;
    [SerializeField] private float gatheringInterval;

    public ProduceUnitCommonStates p_ProduceUnitCommonStates => produceUnitCommonStates;

    private void Awake()
    {
        produceUnitCommonStates = new ProduceUnitCommonStates(carryingResourceCapacity, onceExtractionCapacity, gatheringInterval);
    }
}
