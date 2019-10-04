using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patlama_silme : MonoBehaviour      //patlama efekti olan prefabın içine yazdığımız kod.
{

    void Start()
    {
        Destroy(gameObject, 3);     //patlama efekti ikinci parametredeki saniye sonra yok edilecek.
        
    }
  
}
