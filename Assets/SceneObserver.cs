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
	public GameObject Score;
	public GameObject Result;
	public GameObject Background;
	Result result;
	Score score;
	BackgroundLoop bg;
	private Vector3 camerapos;

	

	// Start is called before the first frame update
	void Start()
	{
		this.Player = GameObject.Find("Player").GetComponent<PlayerController>();
		this.Power = GameObject.Find("Power").GetComponent<Power>();
		this.Angle = GameObject.Find("Angle").GetComponent<Angle>();
		this.score = this.Score.GetComponent<Score>();
		this.result = this.Result.GetComponent<Result>();
		this.bg = this.Background.GetComponent<BackgroundLoop>();
	}

	// Update is called once per frame
	void Update()
	{
		if (State.ShootStarted && this.Player.IsStopped() && !State.IsGameOver)
		{
			State.IsGameOver = true;
			this.result.Show(this.score.Value);
		}

		if (Input.GetMouseButtonUp(0))
		{
			if(State.IsGameOver)
			{
				this.Player.ResetPos();
				this.score.ResetScore();
				this.bg.ResetBackgrounds();
				this.result.Hide();
				this.Power.ResetAndEnable();
				this.Angle.ResetAndEnable();
				State.ShootStarted = false;
				State.IsGameOver = false;
			}
			else if(this.Power.Finished)
			{
				this.Angle.Click();
				if (this.Angle.Finished)
				{
					this.DisableIndicators();
					this.Player.Hit(this.Power.Value, this.Angle.Value);
					State.ShootStarted = true;
					this.score.Counting = true;
					this.score.Display();
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
