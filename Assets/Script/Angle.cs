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
    public int IncrementValue = 2;
    public GameObject Indicator;
    private RectTransform indic_transform;

    public bool Finished => this.Started && this.Stopped;

    // Start is called before the first frame update
    void Start()
    {
        this.indic_transform = this.Indicator.GetComponent<RectTransform>();
        this.text = this.gameObject.GetComponent<Text>();
        Value = 0;
        this.text.text = $"Angle: 0";
        this.meter = new MeterUpdater(0, 900, 30, true, this.IncrementValue);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(this.Started && !this.Stopped){
            this.Value = this.meter.Update();
            this.text.text = $"Angle: {this.Value / 10}";
            this.RotateIndicator(this.Value / 10);
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

	public void ResetAndEnable()
	{
        this.Value = 0;
        this.Started = false;
        this.Stopped = false;
        this.text.text = $"Angle: 0";
        this.RotateIndicator(0);
        this.meter.Reset();
        this.gameObject.SetActive(true);
	}

	public void Disable()
	{
        this.gameObject.SetActive(false);
	}

    private void RotateIndicator(int degree)
    {
        this.indic_transform.rotation = Quaternion.Euler(0, 0, degree);
	}

}
