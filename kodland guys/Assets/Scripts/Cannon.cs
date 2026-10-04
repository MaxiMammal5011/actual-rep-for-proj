using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Odniesienie do prefabu bomby
    [SerializeField] GameObject projectilePrefab;
    // Punkt, w którym pojawi się bomba
    [SerializeField] Transform firePoint;
    // Czas pomiędzy wystrzałami armaty
    [SerializeField] float fireInterval = 3f;
    // Siła wystrzału
    [SerializeField] float launchForce = 500f;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb= proj.GetComponent<Rigidbody>();   
        rb.AddForce(firePoint.forward *  launchForce);
    }
}
