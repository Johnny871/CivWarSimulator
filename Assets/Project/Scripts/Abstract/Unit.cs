using CivWar.Const;
using UniRx;
using UnityEngine;

namespace CivWar{
    public abstract class Unit : MonoBehaviour, IDamageable, IDestroyable
    {
        private ReactiveProperty<int> healthPoint = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> p_HealthPoint => healthPoint;
        private UnitType unitType;
        public UnitType p_UnitType => unitType;

        public void Initialize(UnitType unitType, int healthPoint)
        {
            this.unitType = unitType;
            this.healthPoint.Value = healthPoint;
            this.healthPoint.Subscribe(healthPoint =>
            {
                if(healthPoint <= 0) Destroy();
            })
            .AddTo(this);
        }

        public void Damage(int damage)
        {
            healthPoint.Value -= damage;
        }

        public virtual void Destroy()
        {

        }
    }
}
