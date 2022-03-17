using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UI : MonoBehaviour
    {
        private List<WindowBase> _windowBases;
        
        private void Awake()
        {
            LoadWindow();
        }

        public void ShowWindow<T>(bool hideOther = false) where T: WindowBase
        {
            foreach (var window in _windowBases)
            {
                if (typeof(T) == window.GetType())
                {
                    window.Show();
                }
            }
        }
        
        public void HideWindow<T>(bool hideOther = false) where T: WindowBase
        {
            foreach (var window in _windowBases)
            {
                if (typeof(T) == window.GetType())
                {
                    window.Hide();
                }
            }
        }

        private void LoadWindow()
        {
            _windowBases = new List<WindowBase>();
            
            foreach (Transform item in transform)
            {
                var window = item.gameObject.GetComponent<WindowBase>();
                if (window != null)
                {
                    _windowBases.Add(window);
                }
            }
        }
    }
}