using UnityEngine;

namespace GMPR2512.Lesson09Platformer
{
    public class SoundHub : MonoBehaviour
    {
        private AudioSource[] sources;
        private void Awake()
        {
            sources = GetComponents<AudioSource>();
        }
        public void PlayCoinSound()
        {
            sources[0].Play();
        }
    }
}
