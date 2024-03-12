using System;
using CivWar.Const;
using TMPro;
using UniRx;
using UnityEngine;

namespace CivWar{
    public class TownStorageView : MonoBehaviour
    {
        [SerializeField] private TownHall townHall;
        [SerializeField] private TMP_Text
        woodAmountText,
        stoneAmountText,
        wheatAmountText;

        private void Awake()
        {
            foreach(ResourcePacket resourcePacket in townHall.p_TownStorage.p_ResourcePackets)
            {
                switch(resourcePacket.Type)
                {
                    case ResourceType.Wood:
                        resourcePacket.Amount
                        .Subscribe(woodAmount => 
                        {
                            woodAmountText.text = String.Format("Wood : {0}", woodAmount);
                        })
                        .AddTo(this);
                        break;
                    case ResourceType.Stone:
                        resourcePacket.Amount
                        .Subscribe(stoneAmount => 
                        {
                            stoneAmountText.text = String.Format("Stone : {0}", stoneAmount);
                        })
                        .AddTo(this);
                        break;
                    case ResourceType.Wheat:
                        resourcePacket.Amount
                        .Subscribe(wheatAmount => 
                        {
                            wheatAmountText.text = String.Format("Wheat : {0}", wheatAmount);
                        })
                        .AddTo(this);
                        break;
                }
            }
        }
    }
}
