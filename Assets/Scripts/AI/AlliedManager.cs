using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AI
{
    public class AlliedManager : MonoBehaviour
    {
        [SerializeField] private SimpleAIAlliedController[] _alliedControllers = null;

        public Vector3 GetAlliedPosition(out SimpleAIAlliedController alliedController)
        {
            foreach (var allied in _alliedControllers)
            {
                if (allied.IsLive)
                {   
                    alliedController = allied;
                    return allied.transform.position;
                }
            }

            alliedController = null;
            return default;
        }

        private void Update()
        {
            if (!_alliedControllers.Any(item => item.IsLive))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}