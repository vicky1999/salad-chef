using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    int ind = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag=="Player2")
        {
            ind = 1;
        }
        anim = this.GetComponent<Animator>();
    }

    void animations(string enable,string d1,string d2,string d3,KeyCode key,int player)
    {
        if (Input.GetKey(key) && ind == player)
        {
            anim.SetBool(enable, true);
            anim.SetBool(d1, false);
            anim.SetBool(d2, false);
            anim.SetBool(d3, false);
        }
    }

    public void setIdle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isForward", false);
        anim.SetBool("isBack", false);
        anim.SetBool("isangular", false);
    }

    // Update is called once per frame
    void Update()
    {
        string[] players = { "Player1", "Player2" };
        this.transform.position = GameObject.Find(players[ind]).transform.position;
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.D, 0);
            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.A, 0);
            transform.localScale = new Vector3(-5, 5, 1);
            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.D, 0);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.LeftArrow, 1);
            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.RightArrow, 1);
            transform.localScale= new Vector3(5, 5, 1);
            animations("isangular", "isBack", "isIdle", "isForward", KeyCode.RightArrow, 1);
        }
        animations("isBack", "isangular", "isIdle", "isForward", KeyCode.W, 0);
        animations("isForward", "isangular", "isIdle", "isBack", KeyCode.S, 0);
        animations("isangular", "isBack", "isIdle", "isForward", KeyCode.D, 0);
        animations("isangular", "isBack", "isIdle", "isForward", KeyCode.D, 0);
        
        animations("isBack", "isangular", "isIdle", "isForward", KeyCode.UpArrow, 1);
        animations("isForward", "isangular", "isIdle", "isBack", KeyCode.DownArrow, 1);
        animations("isangular", "isBack", "isIdle", "isForward", KeyCode.LeftArrow, 1);
        animations("isangular", "isBack", "isIdle", "isForward", KeyCode.RightArrow, 1);
        
    }
}
