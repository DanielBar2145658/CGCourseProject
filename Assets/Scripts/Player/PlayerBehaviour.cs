using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IDamagable
{

    public Transform orientaion;
    public Transform player;
    public GameObject model;





    public float speed;

    public float rotSpeed;

    [SerializeField]
    float MaxHealth;


    Vector2 direction;

    float _currentHealth { get; set; }

    Rigidbody rb;

    PlayerActionMap inputActions;


    private void Awake()
    {
        inputActions = new PlayerActionMap();

        rb = GetComponent<Rigidbody>();
        inputActions.Movement.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = MaxHealth;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        direction = inputActions.Movement.Move.ReadValue<Vector2>();
        LookDir(direction);
    }

    void FixedUpdate() 
    {
        rb.AddForce(new Vector3(direction.y * -speed, 0, direction.x * speed), ForceMode.Force);
    
    }


    void LookDir(Vector2 inputDirection) 
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);


        orientaion.forward = viewDir.normalized;

        Vector3 direction = orientaion.forward * inputDirection.y + orientaion.right * inputDirection.x;

        if (direction != Vector3.zero) 
        {
            model.transform.forward = Vector3.Slerp(model.transform.forward, direction.normalized, Time.deltaTime *rotSpeed);
        }


    
    }


    
    public void Damage(float amount, Vector3 force)
    {
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    [ContextMenu("Die")]
    public void Die()
    {
        _currentHealth = 0;
        Gamemanager.Instance.ToggleDeathScreen(true);
        inputActions.Movement.Disable();

    }
}
