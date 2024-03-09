using CivWar.Const;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UniRx;

namespace CivWar{
    public class TownStorage
    {
        private ReactiveProperty<int>
        woodAmount = new ReactiveProperty<int>(),
        stoneAmount = new ReactiveProperty<int>(),
        wheatAmount = new ReactiveProperty<int>();
        public ReactiveProperty<int> p_WoodAmount => woodAmount;
        public ReactiveProperty<int> p_StoneAmount => stoneAmount;
        public ReactiveProperty<int> p_WheatAmount => wheatAmount;

        public TownStorage(int woodAmount = 0, int stoneAmount = 0, int wheatAmount = 0)
        {
            this.woodAmount.Value = woodAmount;
            this.stoneAmount.Value = stoneAmount;
            this.wheatAmount.Value = wheatAmount;
        }

        public void AddResource(ResourceType resourceType, int resourceAmount)
        {
            if(resourceType == ResourceType.None) return;
            switch(resourceType)
            {
                case ResourceType.Wood:
                    woodAmount.Value += resourceAmount;
                    break;
                case ResourceType.Stone:
                    stoneAmount.Value += resourceAmount;
                    break;
                case ResourceType.Wheat:
                    wheatAmount.Value += resourceAmount;
                    break;
            }
        }

        public void RemoveResource(ResourceType resourceType, int resourceAmount)
        {
            if(resourceType == ResourceType.None) return;
            switch(resourceType)
            {
                case ResourceType.Wood:
                    woodAmount.Value -= resourceAmount;
                    if(woodAmount.Value < 0) woodAmount.Value = 0;
                    break;
                case ResourceType.Stone:
                    stoneAmount.Value -= resourceAmount;
                    if(stoneAmount.Value < 0) stoneAmount.Value = 0;
                    break;
                case ResourceType.Wheat:
                    wheatAmount.Value -= resourceAmount;
                    if(wheatAmount.Value < 0) wheatAmount.Value = 0;
                    break;
            }
        }
    }
}
