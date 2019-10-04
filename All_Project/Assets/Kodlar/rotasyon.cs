using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotasyon : MonoBehaviour       //asteroidin işi
{
    Rigidbody fizik;    //nesnemize erişmek için rigidbody türünden bir nesne oluşturuyoruz.

    public float hiz;   //nesnemizin random dönme hızını ayarlamak için oluşturulan nesne.

    void Start()
    {
        fizik = GetComponent<Rigidbody>();      //nesnemizin rigidbody komponentini fizik nesnesine atıyoruz.

        fizik.angularVelocity = Random.insideUnitSphere * hiz;    //nesnemize konumu değişmeden sadece açısal olarak random hareket veriyoruz.        
    }


}
