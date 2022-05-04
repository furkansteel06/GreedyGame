using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
public class bunny2 : MonoBehaviour
{
    public double score = 1;
    public GUIStyle puanStili;
    public bool bool1 = false;
    private Vector2 targetPos; // Karakterin pozisyonu
    public float YIncrement; //Karakterin Y koordinatındaki durumu
    public float speed; // Oyun hızı
    public float maxHeight; // Karakterin yukarı yönde hareket alanı
    public float minHeight; // Karakterin aşağı yönde hareket alanı
    public float maxBack;
    public float backMotion; // Karakteri geri yönde hareketi
    public int health; // Karakterin can değeri


    private void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);

    }
    void OnGUI()
    {

        System.IO.StreamReader Oku = new System.IO.StreamReader("Assets/Drawable/score.txt");
        string metin = Oku.ReadLine();
        Oku.Close();
        GUI.Label(new Rect(10, 30, 100, 50), "Skor: " + Math.Round(score, 0), puanStili);
        GUI.Label(new Rect(10, 1350, 100, 50), "Önceki Skor: " + metin, puanStili);
        GUI.Label(new Rect(10, 5, 100, 50), "Kalan Can Sayısı: " + health, puanStili);

    }

    private void Update()
    {
        score += 0.001;

        if (health <= 0)
        {

            targetPos = new Vector2(transform.position.x - 20, transform.position.y); // Yukarı yön tuşuna basıldığında Y ekseninde yukarıya çıkarma

            System.IO.StreamWriter Yaz = new System.IO.StreamWriter("Assets/Drawable/score.txt");
            Yaz.Write(Math.Round(score, 0));
            Yaz.Close();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //Yukarı ok tuşuna ne zaman basıldığını algıla
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight) // Yukarı yön tuşu
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + YIncrement); // Yukarı yön tuşuna basıldığında Y ekseninde yukarıya çıkarma
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) // Aşağı yön tuşu
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - YIncrement); //Aşağı yön tuşuna basıldığında Y ekseninde aşağıya indirme
        }
        if (bool1 == false && transform.position.x > maxBack) // Yukarı yön tuşu
        {
            if (health == 2) // Yukarı yön tuşu
            {
                targetPos = new Vector2(transform.position.x - backMotion, transform.position.y); // Yukarı yön tuşuna basıldığında Y ekseninde yukarıya çıkarma
                bool1 = true;
            }
        }
        if (bool1 == true && transform.position.x > maxBack) // Yukarı yön tuşu
        {
            if (health == 1) // Yukarı yön tuşu
            {
                targetPos = new Vector2(transform.position.x - backMotion, transform.position.y); // Yukarı yön tuşuna basıldığında Y ekseninde yukarıya çıkarma
                bool1 = false;
            }
        }
    }
}
