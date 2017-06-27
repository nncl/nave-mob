using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour {

	public float velocidadeMinima, velocidadeMaxima;
	public GameObject explosaoPrefab;
	float tamanhoMinimo = 1.0f;
	float tamanhoMaximo = 2.5f;
	float velocidade;

	int vida;
	float tamanho;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// Acesso ao componente RigidBody
		rb = GetComponent<Rigidbody2D> ();

		// Atribui micro gravidade
		rb.gravityScale = 0.0f;

		// Define o tamanho do asteroide
		tamanho = Random.Range(tamanhoMinimo, tamanhoMaximo);

		// Velocidade
		velocidade = Random.Range(velocidadeMinima, velocidadeMaxima);

		// Atribui pontos de vida ao asteróide
		if (tamanho < 1.5f) {
			vida = 1;
		} else if (tamanho < 2.0f) {
			vida = 2;
		} else {
			vida = 3;
		}

		// Aplica escala ao objeto
		transform.localScale = new Vector3(tamanho,tamanho,tamanho);

	}
	
	// Update is called once per frame
	void Update () {
		// Move o asteróide
		transform.Translate (Vector2.down * velocidade * Time.deltaTime);
	}

	// Verifica colisão com o projétil
	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Projetil") {
			vida--;

			// Gera a explosão e destrói o asteróide
			if (vida == 0) {
				Instantiate (explosaoPrefab, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
