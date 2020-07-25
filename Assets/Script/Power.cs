using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public int Value;
    private int val;
    private bool incr;
    private Text text;
    private MeterUpdater meter;

    public bool Started;
    public bool Stopped;

    public bool Finished => this.Started && this.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        this.text = this.gameObject.GetComponent<Text>();
        this.incr = true;
        Value = 0;
        val = 0;
        this.text.text = $"Power: {Value}";
        this.meter = new MeterUpdater(0, 1000, 30);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.Started && !this.Stopped){
            this.Value = this.meter.Update();     
            this.text.text = $"Power: {this.Value / 10}";
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
