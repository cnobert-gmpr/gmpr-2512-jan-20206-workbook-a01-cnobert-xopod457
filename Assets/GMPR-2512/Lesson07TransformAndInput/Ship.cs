
using UnityEngine;
using UnityEngine.InputSystem;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5, _rotationSpeed = 200, _scaleSpeed = 1.2f;
        [SerializeField] private float _minRotation = -25, _maxRotation = 25;

        [SerializeField] private GameObject _projectilePrefab;
        private InputAction _moveAction, _rotateAction, _scaleAction, _fireAction;
        void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotateAction = InputSystem.actions.FindAction("Player/Rotate");
            _scaleAction = InputSystem.actions.FindAction("Player/Scale");
            _fireAction = InputSystem.actions.FindAction("Player/Jump");
        }
        void OnEnable()
        {
            _moveAction?.Enable();
            _rotateAction?.Enable();
            _scaleAction?.Enable();
            if(_fireAction != null)
            {
                _fireAction?.Enable();
                _fireAction.performed += FireButtonPressed;
                _fireAction.canceled += FireButtonReleased;
            }
        }
        void OnDisable()
        {
            _moveAction?.Disable();
            _rotateAction?.Disable();
            _scaleAction?.Disable();
        }
        void Update()
        {
            #region Movement
            Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
            moveDirection.y = 0;
            Vector2 translation = moveDirection.normalized * _moveSpeed * Time.deltaTime;
            transform.Translate(translation, Space.World);
            #endregion
            #region Rotation
            float rotationValue = _rotateAction.ReadValue<float>() * _rotationSpeed* Time.deltaTime;
            transform.Rotate(0, 0, rotationValue);
            Vector3 eulers = transform.eulerAngles;
            if(eulers.z > 180)
            {
                eulers.z -= 360;
            }
            eulers.z = Mathf.Clamp(eulers.z, _minRotation, _maxRotation);
            transform.eulerAngles = eulers;
            #endregion
            #region scaling
            float scaleValue = _scaleAction.ReadValue<float>() * _scaleSpeed * Time.deltaTime;

            transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
            Vector3 scale = transform.localScale;
            if (scale.x < 0)
            {
                scale.x = 0;
            }
            if (scale.y < 0)
            {
                scale.y = 0;
            }
            if (scale.z < 0)
            {
                scale.z = 0;
            }
            transform.localScale = scale;
            
            #endregion

        }
        void FireButtonPressed(InputAction.CallbackContext context)
        {
            Vector3 projectileStartPosition = transform.GetChild(0).position;
            GameObject theProjectile = Instantiate(_projectilePrefab, projectileStartPosition, transform.rotation);
            Projectile projectileScript = theProjectile.GetComponent<Projectile>();
            projectileScript.Speed = 5;
            projectileScript.Direction = transform.up;


        }
        void FireButtonReleased(InputAction.CallbackContext context)
        {
            

        }
    }
}
