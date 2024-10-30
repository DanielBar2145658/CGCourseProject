using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    public int Damage;
    Vector3 force = new Vector3(0, 0, 0);

    public LayerMask layerMask;

    [SerializeField]
    GameObject HitBox;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.2f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerMask) 
        {
            IDamagable thing = other.GetComponent<IDamagable>();

            thing.Damage(Damage, force);

        }



    }


}
