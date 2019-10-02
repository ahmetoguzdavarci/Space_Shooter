using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_kontrol : MonoBehaviour     //uzay gemimizin içi
{
    Rigidbody fizik;    //nesnemize erişmek için öncelikle rigidbody türünden nesne oluşturuyoruz.

    float horizontal = 0;   //nesnemizin yatay konumunu tutmak için oluşturulan nesne.
    float vertical = 0;     //nesnemizin dikey konumunu tutmak için oluşturulan nesne.

    Vector3 hareket;            //nesnemize hareket özelliği vermek için oluşturulan vector3 türündeki nesne.
    public float karakter_hiz;  //nesnemizin hızını ayarlamak için oluşturulan nesne.

    public float min_x, max_x;  //nesnemizin yatayda oyun ekranından çıkmaması için oluşturulan sınır değerler.
    public float min_z, max_z;  //nesnemizin dikeyde oyun ekranından çıkmaması için oluşturulan sınır değerler.

    public float egim;      //nesnemizin hareketi sırasında alacağı eğim açısı.

    float ates_zamani;                   //nesnemizin fareye tıklandığında ne zaman ateş edeceğini yakalamak için oluşturulan değişken.
    public float ates_etme_araligi;     //nesnemizin kurşunu kaç saniyede bir ateşleyeceğini belirlemek için oluşturulan değişken.

    public GameObject kursun;               //nesnemizin ateşleyeceği kurşunu yapmak için oluşturulan değişken.
    public Transform kursun_pozisyonu;      //nesnemizin ateşleyeceği kurşunun hareketine hangi pozisyondan başlayacağını belirlemek
                                            //için oluşturulan değişken.

    AudioSource audio;      //ateş ettiğimizde ses çalması için oluşturduğumuz nesne.

    void Start()
    {
        fizik = GetComponent<Rigidbody>();  //nesnemizin rigidbody kompenentini fizik nesnesine atıyoruz.

        audio = GetComponent<AudioSource>();    //nesnemizin audiosource kompenentini audio nesnemize atıyoruz.
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > ates_zamani)    //nesnemize ateş ettirmek için ilk koşulla hangi tuşa basılacağını belirtiyoruz
        {                                                           //ikinci koşulumuzda ateş zaman aralığını belirliyoruz
            ates_zamani = Time.time + ates_etme_araligi;            //yani ateş etme aralığını kaç saniye belirlediysek o kadar sürede bir
                                                                    //nesnemiz ateş ediyor.

            Instantiate(kursun, kursun_pozisyonu.position, Quaternion.identity);    //nesnemizin atacağı kurşunu üretme kodu.

            audio.Play();   //kodumuz çalıştığında müzik çalıcak yani her ateşlemede ses çıkacak.
        }
    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");   //nesnemizin yatay konumunu alıyoruz.
        vertical = Input.GetAxis("Vertical");       //nesnemizin dikey konumunu alıyoruz.

        hareket = new Vector3(horizontal, 0, vertical);     //aldığımız konumları nesnemizin hareket nesnesine atıyoruz.

        fizik.velocity = hareket * karakter_hiz;    //nesnemizin hızını atıyoruz. addforce dan farkı istediğimiz hıza daha çabuk ulaşması.

        fizik.position = new Vector3(Mathf.Clamp(fizik.position.x, min_x, max_x),       //nesnemizin oyun ekranından çıkmaması için
            0.0f,                                                                       //pozisyonundaki x,y ve z vektörlerini sınırlıyoruz.
            Mathf.Clamp(fizik.position.z, min_z, max_z)
            );

        fizik.rotation = Quaternion.Euler(fizik.velocity.z * 2, 0, fizik.velocity.x * (-egim)); //nesnemizin verdiğimiz parametre eksenlerde
                                                                                                //hareket ederken rotasyon kazanmasını sağlar.
    }
}
