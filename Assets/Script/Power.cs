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

    public void ResetAndEnable()
    {
        this.Started = false;
        this.Stopped = false;
        this.Value = 0;
        this.slider.value = 0;
        this.UpdateFillColor(1, 0.9311996f, 0.6933962f);
        this.meter.Reset();
        this.gameObject.SetActive(true);
	}

    public void StopIndicator()
    {
        this.Stopped = true;
        this.UpdateFillColor(1, 0.6191381f, 0.3726415f);
    }

    void UpdateFillColor(float r, float g, float b)
    {
        var img = this.slider.transform.Find("Fill Area/Fill").GetComponent<Image>();
        img.color = new Color { r = r, g = g, b = b, a = 1 };
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
	}
}
