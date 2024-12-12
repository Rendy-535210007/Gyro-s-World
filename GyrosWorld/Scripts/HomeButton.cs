using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public GameObject confirmButton;
    public GameObject cancelButton;
    bool isOpenConfirmation = false;

    public void Home()
    {
        if(isOpenConfirmation)
        {
            isOpenConfirmation = false;
            confirmButton.SetActive(false);
            cancelButton.SetActive(false);
        } else
        {
            isOpenConfirmation = true;
            confirmButton.SetActive(true);
            cancelButton.SetActive(true);
        }
    }

    public void Cancel()
    {
        isOpenConfirmation = false;
        confirmButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public void Confirm()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
