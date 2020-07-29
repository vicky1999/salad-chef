using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Players : MonoBehaviour
{
	public Transform player1,player2;
	public float player1_speed=3f,player2_speed=3f;

	public string winner;
	public float winnerScore;
	public GameObject left,right;
	
	void Start() {
		
	}

    // Update is called once per frame
    void Update()
    {
		
		if(player1_speed==0 && player2_speed==0)
        {
			//Game Over!
			float score_player1, score_player2;
			score_player1 = GameObject.Find("Player1").GetComponent<PlayerScript>().score;
			score_player2 = GameObject.Find("Player2").GetComponent<PlayerScript>().score;
			if (score_player1 == score_player2)
				PlayerPrefs.SetString("Winner","Draw");
			else if (score_player1 < score_player2)
				PlayerPrefs.SetString("Winner", "Player 1");
			else
				PlayerPrefs.SetString("Winner", "Player2");
			PlayerPrefs.SetFloat("WinnerScore",Mathf.Max(0f,score_player1, score_player2));
			Application.LoadLevel(1);
			Debug.Log("Game Over!");
        }
    	float player1_hor=Input.GetAxis("Player1_Horizontal");
    	float player1_vert=Input.GetAxis("Player1_Vertical");
		
		float player2_hor=Input.GetAxis("Player2_Horizontal");
    	float player2_vert=Input.GetAxis("Player2_Vertical");
		
		float hor_min=Camera.main.ScreenToWorldPoint(left.transform.position).x+1.25f;
		float hor_max=Camera.main.ScreenToWorldPoint(right.transform.position).x-1.25f;

    	if(player1.transform.position.y>1.52f && player1_vert>0 || player1.transform.position.y<-3.05 && player1_vert<0) player1_vert=0f;
		if(player2.transform.position.y>1.52f && player2_vert>0 || player2.transform.position.y<-3.05 && player2_vert<0) player2_vert=0f;

		if(player1.transform.position.x>hor_max && player1_hor>0 || player1.transform.position.x<hor_min && player1_hor<0) {
			player1_hor=0f;
		}
		if(player2.transform.position.x>hor_max && player2_hor>0 || player2.transform.position.x<hor_min && player2_hor<0) {
			player2_hor=0f;
		}
		player1.position=new Vector2(player1.position.x+player1_hor*player1_speed*Time.deltaTime,
			player1.position.y+player1_vert*player1_speed*Time.deltaTime);
        
		player2.position=new Vector2(player2.position.x+player2_hor*player2_speed*Time.deltaTime,
			player2.position.y+player2_vert*player2_speed*Time.deltaTime);

    }
}
