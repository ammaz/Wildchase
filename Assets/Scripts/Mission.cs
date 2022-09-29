using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public static bool isAtck = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator BossEnd()
    {
        yield return new WaitForSeconds(1.5f);       
        
        PlayerController.forwardSpeed = 0f;
        //animator.SetBool("isBossFighting", true);

        for (int a = 0; PlayerHealth.currentHP >= 0; a++)
        {
            if (PlayerHealth.currentHP != 0)
            {
                BossHealth.currentHP1 -= 5;
                PlayerHealth.currentHP -= 5;
                isAtck = true;
                Debug.Log("Enemy Health");
                //PlayerController.animator.SetBool("isAttacking", true);
                yield return new WaitForSeconds(1f);
            }
            if (PlayerHealth.currentHP <= 0)
            {
                PlayerHealth.Die();
                isAtck = false;
                yield return new WaitForSeconds(0f);
                break;
            }
            if (BossHealth.currentHP1 <= 0)
            {
                BossHealth.Die();
                isAtck = false;
                yield return new WaitForSeconds(0f);
                break;
            }

            Debug.Log("PlayerHP" + PlayerHealth.currentHP);
            Debug.Log("EnemyHP" + BossHealth.currentHP1);
        }
    }
}
