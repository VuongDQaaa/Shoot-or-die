using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{
    public Transform BossHPData;
    public Slider bossHPSlider;
    [SerializeField] GameObject bossHP;
    [SerializeField] Text bossCurrentHP;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        this.UpdateBossHPBar();
        SetBossHP();
    }

    protected virtual void UpdateBossHPBar()
    {
        if (GamePlayController.instance.stage3 == true)
        {
            BossHPData = BossController.instance.transform;
            bossHP.SetActive(true);
            if (this.bossHPSlider == null) return;
            IHealthPoint healthPoint = this.BossHPData.GetComponent<IHealthPoint>();
            if (healthPoint == null) return;
            this.bossHPSlider.value = healthPoint.HP();
            bossCurrentHP.text = BossController.instance.health.ToString();
        }
    }

    void SetBossHP()
    {
        if(GamePlayController.instance.killedBoss == true)
        {
            bossHP.SetActive(false);
        }
    }
}
