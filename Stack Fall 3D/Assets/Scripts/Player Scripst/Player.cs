using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private Rigidbody rb;


    private bool smash; // paramparça etmek.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()  // tek tek çalýþtýracak
    {
        if (Input.GetMouseButtonDown(0))   // {} süslü parantez kullanabiliriz ama smash varken kullanmasakta olur 
        smash = true;

        if (Input.GetMouseButtonUp(0)) 
        smash = false;
    }

    void FixedUpdate()  //sanide update göre fark atar
    {
        if (Input.GetMouseButton(0)) 
        {
            smash = true;
            rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
        }

        if (rb.velocity.y > 5) 
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
    }
    

    void OnCollisionEnter(Collision target)     // target = hedef         // OnCollisionEnter Basýlý tuttuðumuzda yapýþýyor
    {
        if (!smash)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
        else // bu komutta gelen nesne(düþmanlarý) yok etmek için yazýyoruz.
        {    // ama zemin hareket etmiyor

            if(target.gameObject.tag == "enemy")
            {
                //   Destroy(target.gameObject); //objeyi yok et(tahrip etmek) sadece bulunduðu kýsmý yok eder.
                Destroy(target.transform.parent.gameObject); //burasý zeminin tamanýný yok eder


            }
            if(target.gameObject.tag == "plane")  // burada ise siyah renkli zemine gelince durmasýný saðlayan komut

            {
                // Debug.Log("Game Over"); // eski hali
                print("Game Over");
            }

        }
    }

    void OnCollisionStay(Collision target)     // OnCollisionStay Geri eski hale gelmesini saðlýyor.
    {
        if (!smash)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
    }

}




