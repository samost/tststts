
using System.Linq;
using AI;
using Body;
using UI;

using UnityEngine;

namespace Gun
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private UI.UI UI;
        
        private Vector3 Ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);

        private bool zoomState = false;
        

        private void Update()
        {
            Zoom();
            Shoot();
        }

        private void Zoom()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!zoomState)
                {
                    UI.ShowWindow<Zoom>();
                    zoomState = true;
                }
                else
                {
                    UI.HideWindow<Zoom>();
                    zoomState = false;
                }
            }
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!zoomState)
                {
                    return;
                }
                
                Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);
            
                RaycastHit[] hit; 
                hit = Physics.RaycastAll(ray, 100f);

                BodyPart bodyPart = hit.FirstOrDefault(i => i.collider.GetComponent<BodyPart>() != null).collider
                    .GetComponent<BodyPart>();
                
                if (bodyPart!= null)
                {
                    bodyPart.TakeDamage();
                }
                
            }
        }
    }
}