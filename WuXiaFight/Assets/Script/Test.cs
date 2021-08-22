using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour {

	public int a = 0;
	// Use this for initialization
	void Start () 
	{
		//DeBug.Log("-------------------------------------");
		Debug.Log("------------------------------------------");

		Tween myTween = DOTween.To(() => a, x => a = x, 100, 2);
		myTween.OnComplete(complete);
		/*
		Tween myTween = transform.DOMoveX(100, 1)
			.SetEase(Ease.OutQuint)
			.SetLoops(1)
			.OnComplete(complete);
		*/

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(a.ToString());
		//DeBug.Log(a);
	}

	void complete()
	{
		Debug.Log("-------------------------");
		//DeBug.Log("====================");
	}

}
