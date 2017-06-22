using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public float intervalo;
	public GameObject projetilPrefab;

	IEnumerator Start () {
		yield return new WaitForSeconds (intervalo);
		Instantiate (projetilPrefab, transform.position, transform.rotation);

		StartCoroutine (Start());
	}
}
