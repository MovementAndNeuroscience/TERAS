using UnityEngine;
using TMPro;

public class UpdateQRFixationPointsCounter : MonoBehaviour
{
    private TMP_Text fixationCounter;
    public GameObject serviceLayer;
    private FixationService fixationService;
    // Start is called before the first frame update
    void Start()
    {
        fixationCounter = GetComponent<TMP_Text>();
        fixationService = serviceLayer.GetComponent<FixationService>();
    }

    // Update is called once per frame
    void Update()
    {
        fixationCounter.text = fixationService.GetQRFixationPoints().ToString();
    }
}