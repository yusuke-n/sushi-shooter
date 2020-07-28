using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle : MonoBehaviour
{
    public int Value;
    private Text text;
    public bool Started;
    public bool Stopped;
    MeterUpdater meter;

    public bool Finished => this.Started && this.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        this.text = this.gameObject.GetComponent<Text>();
        Value = 0;
        this.text.text = $"Angle: {Value}";
        this.meter = new MeterUpdater(0, 900, 30);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(this.Started && !this.Stopped){
            this.Value = this.meter.Update();
            this.text.text = $"Angle: {this.Value / 10}";
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

	public void Disable()
	{
        this.gameObject.SetActive(false);
	}

}
