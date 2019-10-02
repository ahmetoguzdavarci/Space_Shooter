using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_hareketi : MonoBehaviour      //asteroidin içi
{

    Rigidbody fizik;    //nesnemize erişmek için rigidbody türünden bir nesne oluşturuyoruz.

    public float hiz;   //nesnemize hız vermek için değişken oluşturuyoruz.

    void Start()
    {
        fizik = GetComponent<Rigidbody>();  //nesnemizin rigidbody komponentini fizik nesnesine atıyoruz.

        fizik.velocity = transform.forward * hiz;   //nesnemiziz ileri yönlü hızını atıyoruz forward ile.

    }
}
