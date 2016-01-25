using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GridGenerator : MonoBehaviour {
	public GameObject prefab;
<<<<<<< HEAD
	public float gridX;
	public float gridY;
	public float spacing;
=======
	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 2f;
>>>>>>> c8aef8e6b4b2a7d1415a3bcf4e976536cdd0b7f5
	void Start() {

		for (int y = 0; y < gridY; y++) {
			for (int x = 0; x < gridX; x++) {
				Vector2 pos = new Vector2(x, y) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
				RNDColorGenerator();
<<<<<<< HEAD
				Debug.Log(pos);


=======
>>>>>>> c8aef8e6b4b2a7d1415a3bcf4e976536cdd0b7f5
			}
		}
	}
	public void RNDColorGenerator(){
		int RNDint = Random.Range (1, 5);
		switch(RNDint){
		case 1:
			prefab.GetComponent<SpriteRenderer>().color = Color.red;
			break;
		case 2:
			prefab.GetComponent<SpriteRenderer>().color = Color.blue;
			break;
		case 3:
			prefab.GetComponent<SpriteRenderer>().color = Color.yellow;
			break;
		case 4:
			prefab.GetComponent<SpriteRenderer>().color = Color.green;
			break;
		case 5:
			prefab.GetComponent<SpriteRenderer>().color = Color.gray;
			break;
		}


	}


}