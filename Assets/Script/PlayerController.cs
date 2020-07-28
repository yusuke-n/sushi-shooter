using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public float PowerScale = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.body = this.gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int pow, int angle)
	{
		double p = pow / 10;
		double a = angle / 10;

		var rad = (double)(a * Math.PI / 180);
		var x = p * Math.Cos(rad);
		var y = p * Math.Sin(rad);
		var velocity = new Vector2() { x = (float)x * this.PowerScale , y = (float)y * this.PowerScale };
		Debug.Log($"pow: {p}, angle: {a}");
		Debug.Log($"rad: {rad}");
		Debug.Log($"x: {(float)x}, y: {(float)y}");
		this.body.AddForce(velocity);
	}
}
