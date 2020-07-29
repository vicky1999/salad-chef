using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Customer : MonoBehaviour
{
	string[] dishes={"Bean","Carrot","Tomato","Potato","Beetroot","Onion"};
	string[] powers={"Time","Score","Speed"};
	public float startTime;
	public TextMeshProUGUI text;
	private float remaining;
	public Image timer;
	public GameObject[] customers;
	public GameObject player1,player2;
	string needed;

    // Start is called before the first frame update
    void Start()
    {
    	startTime=30f;
    	remaining=startTime;
		needed=dishes[Random.Range(0,5)];
		text.text=needed;
    }

    // Update is called once per frame
    void Update()
    {
    	startTime -= Time.deltaTime;
		timer.fillAmount = startTime/remaining;

		if(timer.fillAmount <= 0) {
			Instantiate(customers[Random.Range(0,1)],new Vector3(this.transform.position.x,
    			this.transform.position.y,this.transform.position.z),Quaternion.identity);
			timer.fillAmount=1f;
			player1.GetComponent<PlayerScript>().score-=10f;
			player2.GetComponent<PlayerScript>().score-=10f;
			Destroy(this.gameObject);		
		}
    }



    public void OnTriggerEnter2D(Collider2D col) {
    	//Check...
    	string ready=col.GetComponent<PlayerScript>().veg;
    	if(ready==needed) {
    		//Destroy this customer and instantiate new customer.
    		col.GetComponent<PlayerScript>().veg="";
    		Instantiate(customers[Random.Range(0,1)],new Vector3(this.transform.position.x,
    			this.transform.position.y,this.transform.position.z),Quaternion.identity);

    		col.GetComponent<PlayerScript>().score+=30f;
			if(timer.fillAmount >= 0.3) {
				string power=powers[Random.Range(0,3)];
				Debug.Log(power);
				if(power=="Time") 
					col.GetComponent<Timer>().Remaining+=20f;
				else if(power=="Score")
					col.GetComponent<PlayerScript>().score+=20f;
				else 
					col.GetComponent<PlayerScript>().UpdateSpeed();
			}    	
			Destroy(this.gameObject);
    	} 
    }
}
