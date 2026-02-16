using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class PlungerStop : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.name == "Plunger")
            {
                collider.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
                collider.attachedRigidbody.linearVelocity = Vector2.zero;
            }
        }
        //void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if(collision.gameObject.name == "Plunger")
        //    {
        //        collision.rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //    }
        //}
    }
}