using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject LabelText;
    public GameObject ValueText;
	public long Value { get; private set; }
	public GameObject Player;
    Text valuetxt;
    PlayerController pl;
    public bool Visible = false;
    public bool Counting = false;

    float origin_pl_pos;
    float current_pl_pos;


    // Start is called before the first frame update
    void Start()
    {
        this.valuetxt = this.ValueText.GetComponent<Text>();
        this.pl = this.Player.GetComponent<PlayerController>();
        this.origin_pl_pos = this.pl.transform.position.x * 1000;
        this.current_pl_pos = this.pl.transform.position.x * 1000;
    }

    public void Hide()
    {
        this.Visible = false;
        this.SetActives(false);
	}

    public void SetActives(bool val) {
        this.LabelText.SetActive(val);
        this.ValueText.SetActive(val);
	}

    public void Display()
    {
        this.Visible = true;
        this.SetActives(true);
    }

    public void ResetScore()
    {
        this.Hide();
        this.Value = 0;
        this.UpdateValueText(0);
	}    

    void UpdateValueText(long val)
    {
        this.valuetxt.text = val.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        if (!this.Counting)
            return;

        this.current_pl_pos = this.pl.transform.position.x * 1000;
        this.Value = (long)Math.Floor(Math.Abs(this.current_pl_pos - this.origin_pl_pos)/1000);
        this.UpdateValueText(this.Value);
    }
}
