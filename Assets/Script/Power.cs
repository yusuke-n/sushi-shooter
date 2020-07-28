using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public int Value;
    private Slider slider;
    private MeterUpdater meter;

    public bool Started;
    public bool Stopped;
    public int IncrementValue = 1;

    public bool Finished => this.Started && this.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        this.slider = this.gameObject.GetComponent<Slider>();
        Value = 0;
        this.meter = new MeterUpdater(0, 1000, 30, true, this.IncrementValue);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.Started && !this.Stopped){
            this.Value = this.meter.Update();     
            this.slider.value = this.Value / 10;
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
        var img = this.slider.transform.Find("Fill Area/Fill").GetComponent<Image>();
        img.color = new Color { r = 1, g = 0.6191381f, b = 0.3726415f, a = 1 };
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
	}
}
