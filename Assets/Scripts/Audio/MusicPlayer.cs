using UnityEngine;

namespace Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip music;

        private void Start()
        {
            AudioManager.Instance.PlayMusic(music);
        }
    }
}