using UnityEngine;


namespace GMPR2512.Lesson09Platformer
{
    public class Shooter : MonoBehaviour
    {
        private Transform _lastObjectHit;
        [SerializeField] float _laserLenght = 8;
        [SerializeField] float _rotaionSpeed = 50;
        private LineRenderer _laserLine;
        void Awake()
        {
            if(_laserLine == null)
                _laserLine = GetComponent<LineRenderer>();
            if(_laserLine != null)
            {
                _laserLine.positionCount = 2;
                _laserLine.useWorldSpace = true;
                _laserLine.startWidth = 0.05f;
                _laserLine.endWidth = 0.05f;
            }
        }
        void Update()
        {
            #region Rotaion
                

            //float rotaionInput = 0;

            // if (Input.GetKey(KeyCode.Comma))
            // {
            //     rotaionInput = 200;
            // }
            // else if (Input.GetKey(KeyCode.Period))
            // {
            //     rotaionInput = -200;
            // }
            transform.parent.Rotate(new Vector3(0,0,_rotaionSpeed * Time.deltaTime));
            #endregion
            int layerMask = LayerMask.GetMask("Player");
            RaycastHit2D rh2d = Physics2D.Raycast(transform.position,-transform.right,_laserLenght,layerMask);
            Vector3 endPoint = transform.position + -transform.right * _laserLenght;
            if(rh2d.collider != null)
                endPoint = rh2d.point;
            _laserLine?.SetPosition(0,transform.position);
            _laserLine?.SetPosition(1,endPoint);

            if(rh2d.transform != null)
                Destroy(rh2d.transform.gameObject);
            // if(rh2d.transform != null)
            // {
            //     rh2d.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
            //     if(_lastObjectHit != null && rh2d.transform != _lastObjectHit)
            //         _lastObjectHit.gameObject.GetComponent<Renderer>().material.color = Color.white;
            //     _lastObjectHit = rh2d.transform;
            // }
            // else if(_lastObjectHit != null)
            //         _lastObjectHit.gameObject.GetComponent<Renderer>().material.color = Color.white;

    }
//        void OnrawGizmos()
//        {
//            Gizmos.color = Color.yellowNice;
//            Gizmos.DrawRay(transform.position, transform.right * 10);
//        }
    }
}
