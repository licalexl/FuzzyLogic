using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rg;
    [SerializeField] float velocity = 1;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();

    }

    void Update()
    {  
        Mov();
        
    }
    void Mov()
    {
        // Movimiento
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;
        movement += new Vector3(hor, 0, ver) * velocity * Time.deltaTime;
        
        rg.MovePosition(transform.position+movement);
              
    }
}
