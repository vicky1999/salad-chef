using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
	public Transform player1,player2;
	public float speed=3f;

	void Start() {
		
	}

    // Update is called once per frame
    void Update()
    {
    	float player1_hor=Input.GetAxis("Player1_Horizontal");
    	float player1_vert=Input.GetAxis("Player1_Vertical");
		
		float player2_hor=Input.GetAxis("Player2_Horizontal");
    	float player2_vert=Input.GetAxis("Player2_Vertical");
		
		player1.position=new Vector2(player1.position.x+player1_hor*speed*Time.deltaTime,
			player1.position.y+player1_vert*speed*Time.deltaTime);
        
		player2.position=new Vector2(player2.position.x+player2_hor*speed*Time.deltaTime,
			player2.position.y+player2_vert*speed*Time.deltaTime);
        
    }
}
