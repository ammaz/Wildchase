using UnityEngine;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 50;
    public static int currentHP1;
    public int damage = 5;

    public HealthBar healthBar;

    public TextMeshProUGUI HP;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHP1 = maxHP;
        healthBar.SetMaxHealth(maxHP);
        HP.text = "" + currentHP1;
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "" + currentHP1;
        healthBar.SetHealth(currentHP1);

        //Attacking Animation
        if (Mission.isAtck)
        {
            animator.SetBool("isAttacking", true);
        }
        if (currentHP1 <= 0 && PlayerHealth.currentHP >= 0)
        {
            animator.SetBool("isDying", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mins")
        {
            currentHP1 -= damage;
            healthBar.SetHealth(currentHP1);
            HP.text = "" + currentHP1;
        }
    }

    public static void Die()
    {
        if (currentHP1 <= 0 && PlayerHealth.currentHP >= 0)
        {
            //WinCondition
            
            Debug.Log("You win!");
        }
    }
}
