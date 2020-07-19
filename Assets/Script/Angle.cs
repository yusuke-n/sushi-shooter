using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle : MonoBehaviour
{
    public int Value;
    private bool incr;
    private Text text;
    public bool Started;
    public bool Stopped;

    public bool Finished => this.Started && this.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        this.text = this.gameObject.GetComponent<Text>();
        this.incr = true;
        Value = 0;
        this.text.text = $"Angle: {Value}";
    }
    

    // Update is called once per frame
    void Update()
    {
        if(this.Started && !this.Stopped){
            if(Value >= 900)
            {
                Value = 900;
                this.incr = false;
            }
            if(Value <= 0)
            {
                Value = 0;
                this.incr = true;
            }
            if(this.incr)
                Value++;
            else
                Value--;
            this.text.text = $"Angle: {Value / 10}";
        }
    }

    public void Click()
    {
        if(this.Started)
            this.StopIndicator();
        else
            this.StartIndicator();
    }

    public void StartIndicator()
    {
        this.Started = true;
    }

    public void StopIndicator()
    {
        this.Stopped = true;
    }

}
