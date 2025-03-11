using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveQRMarkers : MonoBehaviour
{
    public GameObject upLeftId; 
    public GameObject upRightId;
    public GameObject downLeftId;
    public GameObject downRightId;
    private TMP_InputField upLeftText;
    private TMP_InputField upRightText;
    private TMP_InputField downLeftText;
    private TMP_InputField downRightText;
    private Button btn;
    public GameObject serviceLayer;
    private QRService service;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickSave);
        upLeftText = upLeftId.GetComponent<TMP_InputField>();
        upRightText = upRightId.GetComponent<TMP_InputField>();
        downLeftText = downLeftId.GetComponent<TMP_InputField>();
        downRightText = downRightId.GetComponent<TMP_InputField>();
        service = serviceLayer.GetComponent<QRService>();
    }

    void OnClickSave()
    {
        service.SetQRMarkers(int.Parse(upLeftText.text), int.Parse(upRightText.text), int.Parse(downLeftText.text), int.Parse(downRightText.text)); 
    }
}
