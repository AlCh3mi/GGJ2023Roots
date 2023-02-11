using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
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