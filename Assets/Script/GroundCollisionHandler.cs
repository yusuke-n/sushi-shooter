using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!SceneObserver.State.ShootStarted) {
            return;
        }
        Debug.Log("collision enter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
