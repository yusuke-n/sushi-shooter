using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    Text txt;
    string orig_txt_content;

    // Start is called before the first frame update
    void Start()
    {
        this.txt = this.gameObject.GetComponent<Text>();
        this.orig_txt_content = this.txt.text;
        this.gameObject.SetActive(false);
    }

    public void Show(long score)
    {
        this.txt.text = this.txt.text.Replace("$val", score.ToString());
        this.gameObject.SetActive(true);
	}

    public void Hide()
    {
        this.txt.text = this.orig_txt_content;
        this.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
