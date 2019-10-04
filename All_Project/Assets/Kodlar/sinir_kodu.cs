using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinir_kodu : MonoBehaviour     //sınır nesnemizin içi
{

    void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);       //bu sınırlardan çıkınca nesnemiz yok olucak. 
        
    }
}
