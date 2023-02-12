using System;
using RoboRyanTron.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class CollectableUI : GameEventListener
    {
        [SerializeField] private Color activeColor;
        [SerializeField] private Color inactiveColor;

        [SerializeField] private Image image;

        private void Start()
        {
            SetColorActive(false);
        }

        public void SetColorActive(bool active)
        {
            image.color = active
                ? activeColor
                : inactiveColor;
        }
    }
}