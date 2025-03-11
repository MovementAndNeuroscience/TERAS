using UnityEngine;
using TMPro;
public class UpdateQRSaccadeTime : MonoBehaviour
{
    private TMP_Text totalSaccadeTime;
    public GameObject serviceLayer;
    private SaccadeService saccadeService;
    // Start is called before the first frame update
    void Start()
    {
        totalSaccadeTime = GetComponent<TMP_Text>();
        saccadeService = serviceLayer.GetComponent<SaccadeService>();
    }

    // Update is called once per frame
    void Update()
    {
        totalSaccadeTime.text = saccadeService.GettotalQRSaccadeTime().ToString().Substring(0, 7) + " s";
    }
}
