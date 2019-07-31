using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player_move : MonoBehaviour {

	public float moveSpeed;
	
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	public GameObject gameOverPanel1;
	public GameObject gameOverPanel2;

	public Text clearText;
	public Text gameoverText;
	
	bool isJumping = false; // 이중점프가 안되도록 만들기 위해 변수를 선언함.
	bool up_ladder = false; // 사다리와 겹쳐졌을 때만 y축으로 올라가는게 가능하게 하도록 변수를 선언함.

	void Awake(){
		
		gameOverPanel1.SetActive(false); //enemy에 부딪히면 text를 사용하고 싶어서, 일단 canvas를 false 상태로 둠.
		gameOverPanel2.SetActive(false); //object에 도둘하면 text를 사용하고 싶어서, 일단 canvas를 false 상태로 둠.

	}
	
	void Update () {

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
			
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 좌우 방향키와 A,D키로 좌우 움직이게 함.

		if(Input.GetKeyDown(KeyCode.Space) || MainCS.jumpbutton == true)// 스페이스바나 jump버튼을 누르면 점프가 됨.
			if (isJumping == false) {
				isJumping = true;
				transform.Translate(Vector3.up * 42 *Time.deltaTime);  // 이중점프가 안되도록 isJumping이 false일때만 스페이스바나 jump 버튼을 눌렀을 때 점프가 되도록 만듦.
				audio1.Play(); //점플할 때 소리가 나게함.
			}
			MainCS.jumpbutton = false;

		if (up_ladder)
		{
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
				transform.Translate(Vector3.up * 8 * Time.deltaTime);
				up_ladder = false;
		} // up_ladder가 1이 된 경우에만 up키와 W키 사용해서 올라갈 수 있게 만듦.
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("enemy"))
		{
			audio2.Play();
			gameOverPanel1.SetActive(true);
			gameoverText.text = "LOSE";
			Destroy(gameObject, 0.2f);
		} //enemy와 충돌하면 사운드가 발생하면서 LOSE텍스트가 뜨게됨. 

		if(other.gameObject.CompareTag("target"))
		{	
			audio3.Play();
			gameOverPanel2.SetActive(true);
			clearText.text = "WIN!";
			audio3.Play();
			Destroy(other.gameObject);
		} //맨 위에 있는 object와 만나면 object가 사라지면서 win이라는 텍스트가 나오게됨.
		if (other.gameObject.CompareTag("ground"))
			isJumping = false; //ground와 닿아았을 때만 isJumping이 false 되게함.
	}

    void OnTriggerStay(Collider other) 
	{
    	if (other.gameObject.CompareTag("ladder"))
            {
                up_ladder = true;
            } //사다리와 겹쳤을 때 up_ladder변수가 1이됨.

	}
}
