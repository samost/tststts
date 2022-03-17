using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RotationCamera;
using UnityEngine;

namespace Location
{
    public class PositionPoint : MonoBehaviour
    {
        public static event Action GameStarted = null;
        
        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public static event Action<PositionPoint> PointClicked = null; 
        private void OnMouseUp()
        {
            PointClicked?.Invoke(this);
            GameStarted?.Invoke();
            StartCoroutine(EnableCameraRoutine());
        }

        public CinemachineVirtualCamera GetCamera()
        {
            return _cinemachineVirtualCamera;
        }

        private IEnumerator EnableCameraRoutine()
        {
            yield return new WaitForSeconds(2f);
            _cinemachineVirtualCamera.GetComponent<CameraRotation>().enabled = true;
        }
    }
}