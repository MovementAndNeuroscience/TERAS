using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class AdjustAnalysisProgress : MonoBehaviour
{
    public GameObject progresbar;
    public GameObject percentTextField;
    public GameObject Services; 
    private QRService qrService;
    private TMP_Text percent;
    private RectTransform progressMask;
    private double videoLength;
    private double videoTime; 
    // Start is called before the first frame update
    void Start()
    {
        qrService = Services.GetComponent<QRService>();
        percent = percentTextField.GetComponent<TMP_Text>();
        progressMask = progresbar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        videoLength = qrService.GetQRVideoLength();
        videoTime = qrService.GetQRVideoTime();

        var percentage = videoTime / (videoLength / 100);
        percent.text = percentage.ToString().Substring(0, 7) + " %";
        progresbar.transform.localScale = new Vector3((float)percentage/100, 1, 1); 

    }
}
