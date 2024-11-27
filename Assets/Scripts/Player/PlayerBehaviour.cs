using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IDamagable
{

    public Transform orientaion;
    public Transform player;
    public GameObject model;

    public GameObject HeavyAttack;

    [SerializeField]
    GameObject[] MuzzleFlashes;

    public GameObject Muzzle;

    bool canShoot = true;

    [SerializeField]
    bool lockMouse = true;

    public float speed;

    public float rotSpeed;

    [SerializeField]
    float MaxHealth;

    
    public LayerMask mask;

    Vector2 direction;

    float _currentHealth { get; set; }

    Rigidbody rb;

    PlayerActionMap inputActions;

    string c = "";

    float timeout = 0.5f;
    private bool isgrounded;

    private void Awake()
    {
        inputActions = new PlayerActionMap();

        rb = GetComponent<Rigidbody>();
        inputActions.Movement.Enable();

        inputActions.Movement.GunAttack.performed += GunAttack_performed;
        inputActions.Movement.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Real and true");
        if (isgrounded == true)
            rb.AddForce(transform.up * 5, ForceMode.Impulse);
    }

    private void GunAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        c += "G";
        if (canShoot == true)
            StartCoroutine(Shoot());
    }



    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = MaxHealth;
        if (lockMouse == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        direction = inputActions.Movement.Move.ReadValue<Vector2>();
        LookDir(direction);

        CheckCombo();
        if (CheckCombo() == true)
        {
            StartCoroutine(Timeout());
            if (c == "GGG")
            {

                StartCoroutine(HeavyAttackAtk());

            }
        }
    }
    IEnumerator HeavyAttackAtk()
    {
        HeavyAttack.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            int a = UnityEngine.Random.Range(0, MuzzleFlashes.Length);
            MuzzleFlashes[a].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            HeavyAttack.SetActive(false);
        }




        HeavyAttack.SetActive(false);

    }
    private IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeout);
        c = "";

    }

    
    private bool CheckCombo()
    {
        if (c != "") 
            return true;
        
        
        return false;
    }

    void FixedUpdate() 
    {
        rb.AddForce(new Vector3(direction.y * -speed, 0, direction.x * speed), ForceMode.Force);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 3f, mask))
        {
            isgrounded = true;
            Debug.Log("ground");
        }
        else
            isgrounded = false;
    
    }

    IEnumerator Shoot() 
    {
        canShoot = false;
        Muzzle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Muzzle.SetActive(false);
        canShoot = true;
    
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
