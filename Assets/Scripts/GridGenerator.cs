using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour {
	public GameObject prefab;
	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 2f;
	
	void Start() {
		for (int y = 0; y < gridY; y++) {
			for (int x = 0; x < gridX; x++) {
				Vector2 pos = new Vector2(x, y) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}
	}
}