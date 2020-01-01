using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start() {
		StartCoroutine(Example());
	}

	IEnumerator Example() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel ("loading");
	}

}
