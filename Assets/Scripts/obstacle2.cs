using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle2 : MonoBehaviour
{
    public int damage = 1; //Karakterin her canavarı yediğinde aldığı hasar.
    public float speed; // Canavarın hızı.

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<bunny2>().health -= damage; // Karakterin her canavar yediğinde can sayısının eksiltilmesi.
            Debug.Log(other.GetComponent<bunny2>().health); // Can sayısı eksildikçe konsol ekranına yazdırılması.
            Destroy(gameObject); // Canavar yenildikçe yok edilmesi.

        }
    }
}
