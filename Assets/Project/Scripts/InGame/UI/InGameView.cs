using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CivWar;
using TMPro;
using UniRx;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

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
            townHall.p_TownStorage.p_WoodAmount
            .Subscribe(woodAmount => 
            {
                woodAmountText.text = String.Format("Wood : {0}", woodAmount);
            })
            .AddTo(this);
            townHall.p_TownStorage.p_StoneAmount
            .Subscribe(stoneAmount => 
            {
                stoneAmountText.text = String.Format("Stone : {0}", stoneAmount);
            })
            .AddTo(this);
            townHall.p_TownStorage.p_WheatAmount
            .Subscribe(wheatAmount => 
            {
                wheatAmountText.text = String.Format("Wheat : {0}", wheatAmount);
            })
            .AddTo(this);
        }
    }
}
