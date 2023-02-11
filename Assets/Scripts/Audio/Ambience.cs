using UnityEngine;

namespace Audio
{
    public class Ambience : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        private void Awake()
        {
            source.loop = true;
        }

        private void Start()
        {
            source.Play();
        }
    }
}