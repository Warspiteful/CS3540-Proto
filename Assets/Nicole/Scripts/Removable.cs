using System;
using UnityEngine;

namespace Nicole.Scripts
{
    public class Removable : MonoBehaviour
    {

        private bool visible;

        public void Update()
        {
            bool isActive = gameObject.activeSelf;
            if (visible != isActive)
            {
                Renderer objectRenderer = gameObject.GetComponent<Renderer>() as Renderer;
                objectRenderer.enabled = isActive;
                visible = isActive;
            }
           
        }
    }
}