using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {



	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("hole"))
		{
			Destroy(gameObject);
		}
	} //enemy가 맨 아래에 있는 cube를 만나면 사라지게 함. 

}
