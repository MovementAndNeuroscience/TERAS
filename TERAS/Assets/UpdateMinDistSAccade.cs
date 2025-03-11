
using UnityEngine;
using TMPro;

public class UpdateMinDistSAccade : MonoBehaviour
{
    public GameObject services;
    private SaccadeService sacService;
    private TMP_InputField minDistSac;
    // Start is called before the first frame update
    void Start()
    {
        sacService = services.GetComponent<SaccadeService>();
        minDistSac = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        sacService.SetMinSaccadeLength(int.Parse(minDistSac.text));
    }
}
