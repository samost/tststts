using System;
using System.Collections;
using Body;
using Location;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private AlliedManager _alliedManager;
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _health = 100;
        

        private SimpleAIAlliedController _currentAlliedTarget = null;
        private bool isGameStarted;
        private bool isHitted;

        private void OnEnable()
        {
            PositionPoint.GameStarted += PositionPointOnGameStarted;
        }

        private void OnDisable()
        {
            PositionPoint.GameStarted -= PositionPointOnGameStarted;
        }

        private void PositionPointOnGameStarted()
        {
            isGameStarted = true;
        }

        private void Update()
        {
            if (!isGameStarted)
            {
                return;
            }
            
            if (_currentAlliedTarget == null)
            {
                _agent.SetDestination(_alliedManager.GetAlliedPosition(out _currentAlliedTarget));
            }

            if (_agent.velocity == Vector3.zero && !isHitted)
            {
                _animator.SetTrigger("attack");
                _currentAlliedTarget = null;
            }
        }

        public void TakeDamage(BodyPart bodyPart)
        {
            StartCoroutine(HitRoutine());
            _health -= bodyPart._damage;

            if (_health <= 0)
            {
                Destroy(gameObject, 1f);
            }

            
        }

        private IEnumerator HitRoutine()
        {
            isHitted = true;
            _animator.SetTrigger("hit");
            yield return new WaitForSeconds(2f);
            isHitted = false;
        }
    }
}