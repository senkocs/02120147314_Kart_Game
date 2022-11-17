using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CheckpointController : MonoBehaviour
{
    public int checkpointId;
    public Action<int> onHitByPlayer;
    void OnTriggerEnter (Collider c)
    {
        if (c.GetComponent<KartController> () != null)
        {
            onHitByPlayer(checkpointId);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
