using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

	public float velocidade;
	public float intervalo;

	// Use this for initialization
	void Start () {
		// Aciona o tempo p destruir o projetil
		Destroy(gameObject, intervalo);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D c) {
		// Destroi o projetil somente se ele colidir com meteoro
		if (c.gameObject.tag == "Meteoro") {
			Destroy (gameObject);
		}
	}
}
