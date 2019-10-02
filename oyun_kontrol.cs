using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyun_kontrol : MonoBehaviour
{
    public GameObject asteroid;     //asteroidimize ulaşmak için oluşturduğumuz nesne.

    public Vector3 random_pozisyon;     //asteroidimiz oluşturulurken pozisyonunu alacağı vector3 türünden değişken.

    public float baslangic_bekleme;     //fonksiyona girmeden önce ne kadar bekleyeceğini tutan değişken.
    public float olusturma_bekleme;     //fonksiyondan çıkmadan önce ne kadar bekleyeceğini tutan değişken
    public float dongu_bekleme;         //diğer döngüye geçerken ne kadar bekleyeceğini tutan değişken.

    public Text text;   //score u ekranda göstermek için oluşturulan text değişkeni.

    public Text oyun_bitti_text;    //oyun bitince ekranda gösterilecek olan yazıyı tutumak için oluşturulan text değişkeni.

    public Text yeniden_basla_text;     //oyun bitiminde ekranda gösterilecek diğer bir yazıyı tutuan text değişkeni.

    bool oyun_bitti_kontrol = false;    //koşullarda oyunun bitip bitmediğini belirlemek için oluşturulan bool değişken.

    bool yeniden_basla_kontrol = false;     //oyunun tekrar başlamasını kontrol etmek için oluşturulan bool değişkeni.

    int score;      //oyunda patlattığımız asteroidleren topladığımız puanları tutmak için oluşturulan değişken.

    void Start()
    {
        score = 0;  //ilk değerini atıyoruz.

        text.text = "score = " + score;     //ekranda score u yazdırıyoruz.

        StartCoroutine (olustur());      //ilk start kodu çalışıcak ve yazdığımız fonksiyonu çağıracak. Fonksiyon türünden dolayı böyle çağırdık.
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yeniden_basla_kontrol==true)     //oyunu restartlamak için yapılan kontrol.
        {
            SceneManager.LoadScene("level_1");      //oyun yeniden başladığında hangi sahnenin başlayacağının seçimi.
        }
    }

    IEnumerator olustur()      //random asteroid oluşturmak için yazdığımız IEnumerator döndüren fonksiyon.
    {
        yield return new WaitForSeconds(baslangic_bekleme); //fonkisyon çalışmaya başladıktan 2 saniye sonra döngümüze giriyor.

        while (true)    //sonsuza kadar süren döngü
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-random_pozisyon.x, random_pozisyon.x), 0, random_pozisyon.z);   //Instantiate kodu içerisindeki pozisyon
                                                                                                                        //parametresinde kullanmak için
                                                                                                                        //oluşturduğumuz nesne.
                                                                                                                        //Random pozisyonunda range ile aralık
                                                                                                                        //verdik. Yani oluşan nesne hep bu
                                                                                                                        //aralıktaki pozisyonda oluşacak.

                Instantiate(asteroid, vec, Quaternion.identity);        //random asteroid oluşturma kodumuz.

                yield return new WaitForSeconds(olusturma_bekleme);     //kaç saniyede bir çalışacağının parametresini verip return ediyoruz.
            }

            if (oyun_bitti_kontrol == true)     //oyunun bitip bitmediğini 
            {
                yeniden_basla_text.text = "RESTART R";      //eğer oyun bittiyse ekranda gösterilecek yazı.

                yeniden_basla_kontrol = true;       //bool değişkenin değerini değiştirip diğer koşul ifadesinde kullanıyoruz.
                break;      //eğer oyun bittiyse döngümüzü kırıyor.
            }

            yield return new WaitForSeconds(dongu_bekleme);     //for döngüsü bittikten sonra while döngüsüne geçerken kaç saniye bekleyeceğini söylüyoruz.

                      

        }
    }

    public void score_arttir(int gelen_score)   //score u arttırma fonksiyonumuz. Score u paramatre olarak alıyor.
    {
        score += gelen_score;   //score umuzu gelen score la toplayıp eşitliyor.

        text.text = "score = " + score;     //ekranda score u yazdıran text değişkenimize score u atıyoruz.

    }

    public void oyun_bitti()        //oyun bittiğinde çağırılacak fonksiyon.
    {
        oyun_bitti_text.text = "GAME OVER";     //ekranda gösterilecek yazıyı text değişkenimize atıyoruz.
        oyun_bitti_kontrol = true;      //oyunun bitip bitmediğinin kontrolunu yapmak için oluşturulan bool değişkenimiz.
    }


}
