using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Canvas WinCanvas;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.enabled = false;
        WinCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void HandleWin()
    {
        WinCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource.Stop();
    }
}
