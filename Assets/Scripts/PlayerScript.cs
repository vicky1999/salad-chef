using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public string veg;
	public GameObject left,right;
	public GameObject plate1,plate2;

	bool player_has=false;
	float hor_min,hor_max;
	int ind=0;


	void Start() {
		hor_min=Camera.main.ScreenToWorldPoint(left.transform.position).x+1.25f;
		hor_max=Camera.main.ScreenToWorldPoint(right.transform.position).x-1.25f;
		if(this.gameObject.tag=="Player2") 
			ind=1;
	}

	void check(KeyCode key1,string inp) {
       	if(Input.GetKeyDown(key1) && !player_has) {
    		player_has=true;
    		veg=inp;
    		Debug.Log(inp+" taken!");
    	}
	}

	bool isOnPosition() {
		if(this.transform.position.y < -2.8f && ind==0 &&
			this.transform.position.x > 1.78f && this.transform.position.x < 3f) {
			return true;
		}
		if(this.transform.position.y < -2.8f && ind==1 &&
			this.transform.position.x > -2.6f && this.transform.position.x < -1f) {
			return true;
		}
		
		return false;
	}

	IEnumerator Wait(Image img)
    {
    	if(ind==0)
	    	GameObject.Find("InputManager").GetComponent<Players>().player1_speed=0f;
    	else 
    		GameObject.Find("InputManager").GetComponent<Players>().player2_speed=0f;	
        float remaining=30f;
		while(remaining>0) {
			remaining-=1f;
			img.fillAmount = remaining/25f;
	        yield return new WaitForSeconds(0.1f);
		}
		if(ind==0)
	    	GameObject.Find("InputManager").GetComponent<Players>().player1_speed=3f;
    	else 
    		GameObject.Find("InputManager").GetComponent<Players>().player2_speed=3f;	
        player_has=false;
        img.fillAmount=1f;
        plate1.SetActive(false);
        plate2.SetActive(false);
		StopCoroutine("Wait");
    }


	void startChopping() {
		GameObject plate;
		if(ind==0) plate=plate1;
		else plate=plate2;

		plate.SetActive(true);
		Image img=plate.GetComponent<Image>();
		
		StartCoroutine("Wait",img);
	}

    // Update is called once per frame
    void Update()
    {
    	if(this.transform.position.x<=hor_min+0.5f && ind==0) {
        	// check("Potato");
        	check(KeyCode.LeftControl,"Potato");
        	check(KeyCode.LeftShift,"Tomato");
        	check(KeyCode.CapsLock,"Carrot");
        }

        if(this.transform.position.x<=hor_min+0.5f && ind==1) {
        	// check("Potato");
        	check(KeyCode.RightControl,"Potato");
        	check(KeyCode.RightShift,"Tomato");
        	check(KeyCode.Backslash,"Carrot");

        }

        if(this.transform.position.x>=hor_max-0.5f && ind==0) {
        	check(KeyCode.Z,"Bean");
        	check(KeyCode.X,"Beetroot");
        	check(KeyCode.C,"onion");
        }

        if(this.transform.position.x>=hor_max-0.5f && ind==1) {
        	check(KeyCode.Slash,"Bean");
        	check(KeyCode.Period,"Beetroot");
        	check(KeyCode.Comma,"onion");
        }

        if(player_has && ind==0 && Input.GetKeyDown(KeyCode.F)&& isOnPosition()) {
        	startChopping();
        }
        if(player_has && ind==1 && Input.GetKeyDown(KeyCode.RightAlt)&& isOnPosition()) {
        	startChopping();
        }
    }
}
