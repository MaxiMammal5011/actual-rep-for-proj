using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTriger : MonoBehaviour
{
    public enum TriggerType { Start, End }
    public TriggerType triggerType;
    public Lava lava;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (triggerType == TriggerType.Start)
        {
            lava.StartLava();
        }
        else if (triggerType == TriggerType.End)
        {
            lava.StopLava();
        }
    }
}
