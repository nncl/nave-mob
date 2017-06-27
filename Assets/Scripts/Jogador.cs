using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	public float velocidade;
	public float alturaY;
	public int vida;
	Vector3 posicaoInicial;
	Vector3 posicaoMouse;
	SpriteRenderer sr;
	Collider2D col;
	bool controlar;

	// Use this for initialization
	void Start () {
		// Capta a posição inicial do jogador
		posicaoInicial = transform.position;

		// Acesso ao componente sprite render
		sr = GetComponent<SpriteRenderer> ();

		// Acesso ao componente Collider2D
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controlar) {
			ControleTouch ();
		}
	}

	void ControleTouch () {
		// Pixel p/ cartesiano
		// Input fire 1 -> ctrl lado esquerdo, mouse botao esq ou touch
		if (Input.GetButton("Fire1")) {
			posicaoMouse = Input.mousePosition;
			posicaoMouse = Camera.main.ScreenToWorldPoint (posicaoMouse);
			posicaoMouse = new Vector3 (posicaoMouse.x, posicaoMouse.y + alturaY, posicaoMouse.z);

			// Transporta o jogador para onde a tela é tocada
			transform.position = Vector2.Lerp (transform.position, posicaoMouse, velocidade * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Asteroide") {
			StartCoroutine (Invencivel());
			transform.position = posicaoInicial;
		}
	}

	IEnumerator RetornarControle() {
		controlar = false;
		yield return new WaitForSeconds (1.0f);
		controlar = true;
	}

	IEnumerator Invencivel(){
		// Desabilita o collider
		col.enabled = false;

		for (int i = 0; i <= 3; i++) {
			sr.enabled = false;
			yield return new WaitForSeconds(0.5f);
			sr.enabled = true;
			yield return new WaitForSeconds(0.5f);
		}

		col.enabled = true;
	}
}
