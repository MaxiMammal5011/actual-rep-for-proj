using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // To jest siła, z którą odepchniemy gracza.
    [SerializeField] float force = 20f;
    // To jest kierunek, w którym gracz zostanie odepchnięty.
    private Vector3 hitDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                // Kierunek, z którego nadszedł impakt — to znaczy, że musimy odepchnąć gracza.
                hitDir = contact.normal;
                // Branie fizyki gracza (Rigidbody) i odpychanie go z daną siłą.
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
                // Powiedzenie: "Wystarczy! Już popchnęliśmy gracza, możemy przestać."
                return;
            }
        }
    }
    

}
