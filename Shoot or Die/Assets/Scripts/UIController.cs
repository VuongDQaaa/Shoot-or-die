using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Transform HpBarData;
    public Slider slider;
    public Text ammoText;
    [SerializeField] GameObject reloadingText;
    [SerializeField] GameObject keySymbol;
    [SerializeField] GameObject victoryPopup;
    [SerializeField] GameObject defeatPopup;
    [SerializeField] GameObject bossHPUI;
    [SerializeField] GunController gunController;
    [SerializeField] PlayerController playerController;

    private void FixedUpdate()
    {
        this.UpdateHPBar();
        SetAmmoText();
        SetKeySymbol();
        SetVictoryPopUp();
        SetDefeatePopup();
    }

    protected virtual void UpdateHPBar()
    {
        if (this.slider == null) return;
        IHealthPoint healthPoint = this.HpBarData.GetComponent<IHealthPoint>();
        if (healthPoint == null) return;
        this.slider.value = healthPoint.HP();
    }

    void SetAmmoText()
    {
        ammoText.text = gunController.currentAmmor.ToString();
        SetReloadingText();
    }

    void SetReloadingText()
    {
        if (playerController.ammored == true
        && gunController.currentAmmor == 0
        || gunController.currentAmmor <= 30
        && Input.GetKey(KeyCode.R))
        {
            reloadingText.SetActive(true);
        }
        else
        {
            reloadingText.SetActive(false);
        }
    }

    void SetKeySymbol()
    {
        if (PlayerController.instance.haveKey == true)
        {
            keySymbol.SetActive(true);
        }
        if (GamePlayController.instance.stage3 == true)
        {
            keySymbol.SetActive(false);
        }
    }

    void SetDefeatePopup()
    {
        if (PlayerController.instance.HealthPoint <= 0)
        {
            Time.timeScale = 0;
            defeatPopup.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    void SetVictoryPopUp()
    {
        if (GamePlayController.instance.killedBoss == true)
        {
            Destroy(bossHPUI);
            Time.timeScale = 0;
            victoryPopup.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void ReStartButton()
    {
        SceneManager.LoadScene("Game Play");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;

    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
