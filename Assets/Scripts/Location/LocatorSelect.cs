using System;
using System.Collections.Generic;
using UnityEngine;

namespace Location
{
    public class LocatorSelect : MonoBehaviour
    {
        [SerializeField] private List<PositionPoint> _positionPoints;
        
        private void OnEnable()
        {
            PositionPoint.PointClicked += PositionPointOnPointClicked;
        }
        
        private void OnDisable()
        {
            PositionPoint.PointClicked -= PositionPointOnPointClicked;
        }

        private void PositionPointOnPointClicked(PositionPoint point)
        {
            point.GetCamera().Priority = 10;
            Cursor.visible = false;
        }
    }
}