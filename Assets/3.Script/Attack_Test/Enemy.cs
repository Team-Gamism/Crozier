using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float curHp;
    public float CurHp
    {
        get => curHp; 
        
        set
        {
            curHp = Mathf.Clamp(value, 0, maxHp);
        }
    }
    
    [SerializeField] private float maxHp;

    [SerializeField] private Slider hpBar;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Awake()
    {
        CurHp = maxHp;
    }

    public void TakeDamage(float dmg)
    {
        CurHp -= dmg;

        hpBar.value = CurHp / maxHp;
        hpText.text = CurHp + " / " + maxHp;
    }
}
