using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    
    [SerializeField] Canvas bloodCanvas;
    [SerializeField] float impactTime = 0.3f;

    private void Start()
    {
        bloodCanvas.enabled = false;
    }

    public void showBloodImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        bloodCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        bloodCanvas.enabled = false;
    }
}
