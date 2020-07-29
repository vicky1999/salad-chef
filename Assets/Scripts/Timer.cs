using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public float GameTime=100f;
	public float Remaining;
	public Image timer;

    // Start is called before the first frame update
    void Start()
    {
		Remaining=GameTime;
    	timer.fillAmount=1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.fillAmount<=0)
        {
            if (this.GetComponent<PlayerScript>().ind == 0)
                GameObject.Find("InputManager").GetComponent<Players>().player1_speed = 0f;
            if (this.GetComponent<PlayerScript>().ind == 1)
                GameObject.Find("InputManager").GetComponent<Players>().player2_speed = 0f;

        }
       	Remaining-=Time.deltaTime;
       	timer.fillAmount=Remaining/GameTime;
       	
    }
}
