using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] obstaclePattern; 
    private float timeBtwSpawn; 
    public float startTimeBtwSpawn; // Canavarın oluşma süresi
    public float decreaseTime; // Canavar sıklığını arttırma
    public float minTime = 0.65f; // Maksimum canavar oluşma sıklığı
    private void Update()
    {
        if (timeBtwSpawn <= 0)
            
        {
            int rand = Random.Range(0, obstaclePattern.Length-1); // Canavarı random oluşturma
            Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity); // Canavarı random yerleştirme
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime) // Başlangıçta verilen canavar oluşumu sıklık değeri, minTime değeri olan 0.65'den
                                             // büyük oldukça çalıştır.
            {
                startTimeBtwSpawn -= decreaseTime; // Her çalıştırıldığında başlangıç değerinden 0.5 düşerek sıklığı arttırma.
            }
        } else
        {
            timeBtwSpawn -= Time.deltaTime; // Canavar oluşma sıklığının stabil olması.
        }
    }
}
