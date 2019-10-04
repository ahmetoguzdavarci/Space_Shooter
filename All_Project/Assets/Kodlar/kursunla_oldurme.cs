using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunla_oldurme : MonoBehaviour   //asteroidin içi
{
    public GameObject patlama;  //asteroide temas olduğunda patlama efektini vermek için oluşturduğumuz obje.

    public GameObject gemi_patlama;     //asteroid gemiye çarptığında patlama efekti vermek için oluşturduğumzu obje. 

    GameObject oyunkontrol; //diğer script e ulaşmak için önce nesnemizi oluşturuyoruz.
    oyun_kontrol kontrol;   //diğer scriptin türünde bir nesne oluşturuyoruz.

    void Start()
    {
        oyunkontrol = GameObject.FindGameObjectWithTag("oyunun_kontrolu");  //diğer scripti tagı ile bulup nesnemize atıyoruz.

        kontrol = oyunkontrol.GetComponent<oyun_kontrol>();     //ulaşmak için ürettiğimiz nesnemiz üzerinden diğer scripte ulaşıp nesnesine atıyoruz.
        
    }


    void OnTriggerEnter(Collider col)   //şuan asteroidin içine yazıyoruz bu kodu.
    {
        if (col.tag != "sinir")
        {
            
            Destroy(col.gameObject);    //asteroid nesnemize çarpan nesnenin yok olma kodu.
            Destroy(gameObject);        //asteroid nesnemizin yok olma kodu.  

            Instantiate(patlama, transform.position, transform.rotation);   //asteroide temas olduğunda patlama efektini üretmek için yazdığımız kod.

            kontrol.score_arttir(10);   //bu kod her çalıştığında diğer scriptteki score_Arttir fonksiyonunu çağırıp skoru 10 arttırma.

        }

        if (col.tag=="Player")
        {
            Instantiate(gemi_patlama, col.transform.position, col.transform.rotation);  //asteroid gemiye çarptığında patlama efekti 
                                                                                        //üretmek için yazılan kod.

            kontrol.oyun_bitti();   //diğer scriptteki oyun_bitti fonksiyonunu çağıran kod.
        }
        
    }
}
