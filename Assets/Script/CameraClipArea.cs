﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClipArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPosX(float x)
    {
        this.transform.position = new Vector3(
            this.transform.position.x + x,
            this.transform.position.y,
            this.transform.position.z
        );
	}
}
