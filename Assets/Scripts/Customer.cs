using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
	public float startTime;
	private float remaining;
	public Image timer;

    // Start is called before the first frame update
    void Start()
    {
    	remaining=startTime;
    }

    // Update is called once per frame
    void Update()
    {
    	startTime -= Time.deltaTime;
		timer.fillAmount = startTime/remaining;

		if(timer.fillAmount <= 0) {
			Destroy(this.gameObject);
		}
    }
}
