using System;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets.GUI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Image shovelIcon;


        private void OnShovelCollected()
        {
            shovelIcon.enabled = true;
        }
    }
}