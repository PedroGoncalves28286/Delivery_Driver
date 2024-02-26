using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery: MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

     void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*void Start()
    {
        Debug.Log(hasPackage);
        
    }*/
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
         {
            Debug.Log("Pachage picked up ");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
         }

        if (other.tag == "Customer" && hasPackage )
        {
            Debug.Log("Package Deliverd ");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        } 

    }
}
