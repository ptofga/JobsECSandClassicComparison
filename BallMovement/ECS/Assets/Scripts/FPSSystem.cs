
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class FPSSytem : ComponentSystem
{
    public Text FPSText;

    public void SetFPSUI()
    {
        FPSText = GameObject.Find("FPS").GetComponent<Text>();
    }
    protected override void OnUpdate()
    {
        FPSText.text = "FPS: " + 1 / Time.deltaTime;
    }
}
