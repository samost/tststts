using AI;
using UnityEngine;

namespace Body
{
    public class BodyPart : MonoBehaviour
    {
        [SerializeField] private Enemy _parentEnemy;
        
        [SerializeField] private BodyPartType _bodyPartType;
        public int _damage;

        public void TakeDamage()
        {
            _parentEnemy.TakeDamage(this);
        }
    }
}