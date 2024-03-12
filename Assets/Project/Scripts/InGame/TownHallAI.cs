using System.Collections;
using System.Collections.Generic;
using CivWar.Const;
using UnityEngine;

namespace CivWar{
    public class TownHallAI : MonoBehaviour
    {
        private TownHall townHall;

        [SerializeField] private StrategyBalance strategyBalance = new StrategyBalance();
        private float economyRatio 
        {
            get
            {
                switch(strategyBalance)
                {
                    case StrategyBalance.SuperEconomy:
                        return 80;
                    case StrategyBalance.HighlyEconomy:
                        return 70;
                    case StrategyBalance.BitEconomy:
                        return 60;
                    case StrategyBalance.Balance:
                        return 50;
                    case StrategyBalance.BitWarfare:
                        return 40;
                    case StrategyBalance.HighlyWarfare:
                        return 30;
                    case StrategyBalance.SuperWarfare:
                        return 20;
                }
                return 0;
            }
        }
        private float warfareRatio
        {
            get { return 100 - economyRatio; }
        }

        public void Initialize(TownHall townHall)
        {
            this.townHall = townHall;
            strategyBalance = EnumUtility.GetRandom<StrategyBalance>();
            Debug.LogFormat("戦略タイプ : {0} / 内政↔戦争 : {1}%↔{2}%", strategyBalance, economyRatio, warfareRatio);
            StartCoroutine(CheckResourceAmount());
        }

        private IEnumerator CheckResourceAmount()
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            foreach(ResourcePacket resourcePacket in townHall.p_produceUnitCommonStates.p_ResourceRequestForSpawn)
            {
                //var canSpawnProduceUnit = resourcePacket.IsEnoughResource();
            }
        }
    }
}
