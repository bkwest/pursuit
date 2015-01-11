using UnityEngine;
using System.Collections;

public class startGameButton : MonoBehaviour {

	void OnMouseDown() {
		Application.LoadLevel ("test");
	}
}
