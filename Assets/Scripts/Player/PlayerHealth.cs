using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP=100;
    public static int currentHP;
    public int damage=5;

    public HealthBar healthBar;

    public TextMeshProUGUI HP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
        HP.text = ""+ currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "" + currentHP;
        healthBar.SetHealth(currentHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mins")
        {
            if (currentHP <= 0)
            {
                PlayerManager.gameOver = true;
                FindObjectOfType<AudioManager>().PlaySound("GameOver");
            }
            else
            {
                currentHP -= damage;
                healthBar.SetHealth(currentHP);
                HP.text = "" + currentHP;
                FindObjectOfType<AudioManager>().PlaySound("Hurt");
            }           
        }
    }
    
    public static void Die()
    {
        if (currentHP<=0 && BossHealth.currentHP1>0)
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}
