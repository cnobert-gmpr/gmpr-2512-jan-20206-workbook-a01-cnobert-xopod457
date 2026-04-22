using UnityEngine;

namespace GMPR2512.Lesson09Platformer
{
    public class Coin : MonoBehaviour
    {
        SoundHub soundHub;
        private void Awake()
        {
            soundHub = GameObject.Find("SoundHub").GetComponent<SoundHub>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            soundHub.PlayCoinSound();
            Destroy(gameObject);
        }
    }
}
