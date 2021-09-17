using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Level1
{
    public class Enemy : BaseGameObject
    {
        private float _speed;
        private float _acceleration;
        private Vector3 _targetPosition;
        public Vector3 TargetPosition => _targetPosition;
        public float Speed => _speed;
        public float Acceleration => _acceleration;

        public bool Finished = false;

        private float _cold = 0;
        public float Cold => _cold;

        private float _coldTime = 0;
        public float ColdTime => _coldTime;

        protected HealthComponent healthComponent;
        protected NavMeshAgent agent;

        public void SetAcceleration(float acceleration)
        {
            _acceleration = acceleration;
            if (agent != null)
                agent.acceleration = acceleration;
        }

        public void SetHealth(float health)
        {
            healthComponent.SetHealth(health);
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
            if (agent != null)
                agent.speed = speed;
        }
        public void SetTarget(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            if (agent != null)
                agent.SetDestination(targetPosition);
        }

        public void SetDamage(float damage)
        {
            healthComponent.SetDamage(damage);
        }

        public void SetCold(float cold, float time)
        {
            _cold = cold;
            _coldTime = time;
            var description = _gameObject.GetComponent<EnemyDescription>();

            if (!(CurrentState is EnemyColdState))
            {
                description.currentColdTime = 0;
                MoveToState<EnemyColdState>();
            }
            else
                description.currentColdTime = 0;
                
        }

        protected override void CreateComponents()
        {
            base.CreateComponents();
            healthComponent = _gameObject.GetComponent<HealthComponent>();
                healthComponent.enabled = true;
            agent = _gameObject.AddComponent<NavMeshAgent>();
                agent.enabled = true;
        }

    }
}

