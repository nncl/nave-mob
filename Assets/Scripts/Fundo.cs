using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo : MonoBehaviour {

	public float limiteY;
	public float posicaoY;
	public float velocidade;

	void Update () {

		// Movimenta o fundo para a esquerda
		transform.Translate (Vector2.down * velocidade * Time.deltaTime); 

		// Reposiciona o fundo para ficar em looping
		if(transform.position.y <= limiteY){
			transform.position = new Vector3 (0.0f, posicaoY, 0.0f);
		}

	}
}
