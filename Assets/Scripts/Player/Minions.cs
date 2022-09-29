using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minions : MonoBehaviour
{
    public GameObject[] minion;
    public static int playerscore;
    public int numberoftotalcubes;
    public Text score12,bonus;
    public GameObject MinionsSet;

    // Start is called before the first frame update
    void Start()
    {
        playerscore = 0;
        numberoftotalcubes = 35;
 
    }

    // Update is called once per frame
    void Update()
    {
        score12.text = "" + playerscore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Modify")
        {
            playerscore++;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            Mini();
        }

        if (other.tag == "Bossarena1")
        {
            MinionsSet.SetActive(false);
            PlayerHealth.currentHP += playerscore;
            bonus.text = "+" + playerscore;
            bonus.gameObject.SetActive(true);
            Invoke("DisableText", 4f);
        }

    }

    public void Mini()
    {
        int countnumberofcubesenabled = 0;
        for (int ab = 0; ab <= numberoftotalcubes; ab++)
        {
            if (minion[ab].activeSelf)
            {
                countnumberofcubesenabled++;
            }
        }

        //This will check if all minions are enabled or not if playerscore is heigher than 40
        /*if (playerscore >= numberoftotalcubes)
        {
            for (int aa = 0; aa <= numberoftotalcubes; aa++)
            {
                if (!minion[aa].activeSelf)
                {
                    minion[aa].SetActive(true);
                }
            }
        }*/

        //This will check if playerscore is lower than 40 then
        /*if (playerscore < numberoftotalcubes)
        {*/
        //First it will count number of cubes enabled

        //Then it will enable cubes if requried(If countnumberofcubesenable) are less than playerscore
        if (countnumberofcubesenabled < playerscore)
        {
            for (int ac = 0; ac <= numberoftotalcubes; ac++)
            {
                    minion[ac].SetActive(false);
            }

            for (int ac = 0; ac <= countnumberofcubesenabled; ac++)
            {
                if (!minion[ac].activeSelf)
                {
                    minion[ac].SetActive(true);
                }
            }
        }

        if (countnumberofcubesenabled > playerscore)
        {
            int aaa = countnumberofcubesenabled;
            for(int ac = 0; ac <= numberoftotalcubes; ac++)
            {
                if (aaa!=0)
                {
                    minion[ac].SetActive(true);
                    aaa--;
                }
                else
                {
                    minion[ac].SetActive(false);
                }
            }
        }

        if (playerscore == 0)
        {
            for (int ac = 0; ac <= numberoftotalcubes; ac++)
            {                 
                minion[ac].SetActive(false);
            }

        }
    }

    public void DisableText()
    {
        bonus.enabled = false;
    }
}
