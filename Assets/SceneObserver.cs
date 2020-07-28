using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneObserver : MonoBehaviour
{
	public static State State = new State();
	public PlayerController Player { get; private set; }
	public bool Started { get; private set; }
	public bool Hitted { get; private set; }
	public Power Power { get; private set; }
	public Angle Angle { get; private set; }
	private Vector3 camerapos;

	

	// Start is called before the first frame update
	void Start()
	{
		this.Player = GameObject.Find("Player").GetComponent<PlayerController>();
		this.Power = GameObject.Find("Power").GetComponent<Power>();
		this.Angle = GameObject.Find("Angle").GetComponent<Angle>();
	}

	// Update is called once per frame
	void Update()
	{
		
		if(Input.GetMouseButtonUp(0))
		{
			if(this.Power.Finished)
			{
				this.Angle.Click();
				if (this.Angle.Finished)
				{
					this.DisableIndicators();
					this.Player.Hit(this.Power.Value, this.Angle.Value);
					State.ShootStarted = true;
				}
			}
			else
			{
				this.Power.Click();
				if(this.Power.Finished) 
					this.Angle.Click();
			}
		}
	}

	void DisableIndicators()
	{
		this.Angle.Disable();
		this.Power.Disable();
	}

	
}
