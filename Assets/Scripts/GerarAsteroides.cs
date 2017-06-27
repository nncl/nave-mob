using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAsteroides : MonoBehaviour {

	public float limiteEsquerdo, limiteDireito;
	public float intervaloInicial, intervaloFinal;
	public GameObject asteroidePrefab;

	float px;

	// Coroutine
	IEnumerator Start () {
		// Aguarda intervalo p gerar asteróide
		yield return new WaitForSeconds (Random.Range(intervaloInicial, intervaloFinal));

		px = Random.Range (limiteEsquerdo, limiteDireito);
		Vector3 posicao = new Vector3 (px, transform.position.y, transform.position.x);

		// Gera o asteróide
		Instantiate(asteroidePrefab, posicao, transform.rotation);

		// Retornar
		StartCoroutine(Start());
	}
}
