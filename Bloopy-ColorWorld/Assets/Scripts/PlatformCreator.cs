using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject platformPrefab; // Olu�turulacak platform prefab�
    public Transform oyuncu; // Oyuncu referans�
    public float yaratmaMesafesi = 50f; // Oyuncudan ne kadar yukar�ya kadar platform yarat�laca��
    public float yaratmaAraligi = 2f; // Platformlar�n yaratma aral���

    private float sagSinir; // Kamera sa� s�n�r�
    private float solSinir; // Kamera sol s�n�r�
    private float sonYaratilanY; // Son yarat�lan platformun y pozisyonu

    private void Start()
    {
        // Kameran�n sol ve sa� s�n�rlar�n� d�nya koordinatlar�na d�n��t�rerek s�n�rlar� belirle
        Vector3 sagKose = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 solKose = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        sagSinir = sagKose.x;
        solSinir = solKose.x;

        // Ba�lang��ta hi� platform olu�turulmad��� i�in son yarat�lan y pozisyonunu sol s�n�ra ayarla
        sonYaratilanY = solSinir;
    }

    private void Update()
    {
        if (oyuncu != null)
        {
            // Oyuncunun mevcut y pozisyonunu al
            float oyuncuY = oyuncu.position.y;

            // Oyuncu yaratmaMesafesi birim yukar�ya ��kt�k�a ve son yarat�lan platformun y pozisyonundan uzakla�t�k�a yeni platform yarat
            for (float y = sonYaratilanY + yaratmaAraligi; y <= oyuncuY + yaratmaMesafesi; y += yaratmaAraligi)
            {
                YaratPlatform();
            }
        }
    }

    private void YaratPlatform()
    {
        // Yeni platformu yarat
        float rastgeleX = Random.Range(solSinir, sagSinir);
        Vector3 pozisyon = new Vector3(rastgeleX, sonYaratilanY, 0f);
        Instantiate(platformPrefab, pozisyon, Quaternion.identity);

        // Olu�turulan platformun y pozisyonunu son yarat�lan y pozisyonu olarak g�ncelle
        sonYaratilanY += yaratmaAraligi;
    }
}
