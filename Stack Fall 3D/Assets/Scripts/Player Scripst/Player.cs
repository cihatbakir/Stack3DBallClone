using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private Rigidbody rb;


    private bool smash; // parampar�a etmek.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()  // tek tek �al��t�racak
    {
        if (Input.GetMouseButtonDown(0))   // {} s�sl� parantez kullanabiliriz ama smash varken kullanmasakta olur 
        smash = true;

        if (Input.GetMouseButtonUp(0)) 
        smash = false;
    }

    void FixedUpdate()  //sanide update g�re fark atar
    {
        if (Input.GetMouseButton(0)) 
        {
            smash = true;
            rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
        }

        if (rb.velocity.y > 5) 
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
    }
    

    void OnCollisionEnter(Collision target)     // target = hedef         // OnCollisionEnter Bas�l� tuttu�umuzda yap���yor
    {
        if (!smash)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
        else // bu komutta gelen nesne(d��manlar�) yok etmek i�in yaz�yoruz.
        {    // ama zemin hareket etmiyor

            if(target.gameObject.tag == "enemy")
            {
                //   Destroy(target.gameObject); //objeyi yok et(tahrip etmek) sadece bulundu�u k�sm� yok eder.
                Destroy(target.transform.parent.gameObject); //buras� zeminin taman�n� yok eder


            }
            if(target.gameObject.tag == "plane")  // burada ise siyah renkli zemine gelince durmas�n� sa�layan komut

            {
                // Debug.Log("Game Over"); // eski hali
                print("Game Over");
            }

        }
    }

    void OnCollisionStay(Collision target)     // OnCollisionStay Geri eski hale gelmesini sa�l�yor.
    {
        if (!smash)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
    }

}




