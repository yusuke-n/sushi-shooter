using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	public GameObject Score;
    Rigidbody2D body;
    public float PowerScale = 10.0f;
	float orig_pos_x;
	float orig_pos_y;
	int skipped_frames = 0;
	public int SkipFrameNum = 120;
	bool hitted = false;


    // Start is called before the first frame update
    void Start()
    {
        this.body = this.gameObject.GetComponent<Rigidbody2D>();
		this.orig_pos_x = this.transform.position.x;
		this.orig_pos_y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if (this.hitted && this.skipped_frames <= this.SkipFrameNum)
			this.skipped_frames += 1;
    }

	public void ResetPos()
	{
		this.transform.position = new Vector3(this.orig_pos_x, this.orig_pos_y);
		this.skipped_frames = 0;
		this.hitted = false;
	}

	public bool IsStopped()
	{
		return this.skipped_frames > this.SkipFrameNum && this.body.velocity == Vector2.zero;
	}

    public void Hit(int pow, int angle)
	{
		if (this.hitted)
			return;

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
		this.hitted = true;
	}
}
