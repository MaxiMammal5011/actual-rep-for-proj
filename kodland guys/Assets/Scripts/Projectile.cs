using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Projectile : MonoBehaviour
{
    // Czas przed eksplozją
    [SerializeField] float explosionDelay = 5f;
    // Promień wybuchu (dystans od bomby, w którym gracz zostanie odepchnięty)
    [SerializeField] float explosionRadius = 10f;
    // Siła eksplozji (jak mocno gracz zostanie odepchnięty)
    [SerializeField] float explosionForce = 700f;
    // Odniesienie do efektu eksplozji
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    // Odniesienie do prefabu Canvas
[SerializeField] GameObject timerUIPrefab;
    // Obiekt do klonowania Canvasa
    GameObject timerUI;
    // Odniesienie do tekstu timera
    TextMeshProUGUI timerText;
    void Start()
    {
        // Tworzenie UI nad pociskiem
        timerUI = Instantiate(timerUIPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        // Odłączanie go od pocisku
        timerUI.transform.SetParent(null);
        // Znajdowanie tekstu timera i przechowywanie go w zmiennej
        timerText = timerUI.GetComponentInChildren<TextMeshProUGUI>();
        explosionDelay = Random.Range(1, explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
        
            explosionDelay -= Time.deltaTime;

            if (explosionDelay <= 0f)
            {
                Explode();
            }
        timerUI.transform.position = transform.position + Vector3.up * 1.5f;
        timerUI. transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        timerText.text = explosionDelay.ToString("F1");

    }



    void Explode()
    { 
        Collider[] coliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in coliders)
        {
            if (hit.CompareTag("Player") && hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(timerUI);

    }

    
}
