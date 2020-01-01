using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loading : MonoBehaviour {

	public Transform LoadingBar;

	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;

	// Update is called once per frame
	void Update () {
		if (currentAmount < 100) {
			currentAmount += speed * Time.deltaTime;
			Debug.Log ((int)currentAmount);
		} else {
			Application.LoadLevel ("lang");
		}

		LoadingBar.GetComponent<Image> ().fillAmount = currentAmount / 100;
	}

}
