using UnityEngine;

namespace GMPR2512.Lesson04Scripting01
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private int _year = 1000;
        private float _seconds = 0;

        private int _deathcount = 0;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            Debug.Log($"I'm awake the year is {_year}");
            _year += 1026;

        }
        void Start()
        {
            Debug.Log($"I'm in the start method the year is {_year}");
        }

        // Update is called once per frame
        void Update()
        {
            _seconds += Time.deltaTime;


            //Debug.Log($"This scene has been running for {_seconds} seconds.");
        }
        void OnTriggerEnter2D(Collider2D collider)
        {

            _deathcount++;
            //Debug.Log($"This bumped into me {collider.gameObject.name}");
            
            Debug.Log($"DeathZone has deathed this many: {_deathcount}");

            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //rb.LinearVelocity = Vector2.zero;

                Destroy(rb);
            }

            Destroy(collider.gameObject);
        }
    }
}
