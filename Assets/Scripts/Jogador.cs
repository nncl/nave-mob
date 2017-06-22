using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	public float velocidade;
	public float alturaY;
	Vector3 posicaoMouse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ControleTouch ();
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
}
