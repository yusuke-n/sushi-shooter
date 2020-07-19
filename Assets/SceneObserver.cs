using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneObserver : MonoBehaviour
{
	public static State State = new State();
	public PlayerController Player { get; private set; }
	public Camera MainCamera { get; private set; }
	public bool Started { get; private set; }
	public bool Hitted { get; private set; }
	public Power Power { get; private set; }
	public Angle Angle { get; private set; }
	private Vector3 camerapos;

	public float CameraOffsetY = 2.0f;

	// Start is called before the first frame update
	void Start()
	{
		this.Player = GameObject.Find("Player").GetComponent<PlayerController>();
		this.Power = GameObject.Find("Power").GetComponent<Power>();
		this.Angle = GameObject.Find("Angle").GetComponent<Angle>();
		this.MainCamera = Camera.main;
		this.camerapos = new Vector3{ z = -10 };
	}

	// Update is called once per frame
	void Update()
	{
		this.FollowCameraToPlayer();
		if(Input.GetMouseButtonUp(0))
		{
			if(this.Power.Finished)
			{
				this.Angle.Click();
				if(this.Angle.Finished){}
					this.Player.Hit(this.Power.Value, this.Angle.Value);
			}
			else
			{
				this.Power.Click();
				if(this.Power.Finished) 
					this.Angle.Click();
			}
		}
	}

	void FollowCameraToPlayer()
	{
		this.camerapos.x =this.Player.transform.position.x;
		this.camerapos.y = this.Player.transform.position.y + this.CameraOffsetY;
		this.MainCamera.transform.position = this.camerapos;
	}
}
