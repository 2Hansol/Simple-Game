using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCS : MonoBehaviour {

	public static bool jumpbutton;
	public AudioSource audio1;
	public AudioSource audio2;
	public Transform prefab;
	public float time;
	public Text timer;
	

	void Awake () {
		InvokeRepeating("Instantiate_fnc", 0, 10F); //prefab생성 함수를 10초에 한번씩 실행함. 
		time = 10;
		timer.text = "Time : " + time.ToString(); //10초 타이머를 재생하면서 언제 prefab이 생성될지 보여줌.
		audio2.Play(); //배경음악을 재생함. 
	}

	void Update(){
		if(time < 0f)
			time = 10f;
		else
		{
			time -= Time.deltaTime; //타이머 0초가 되면 10초 부터 다시 시작해줌. 
			int time1 = (int)time;
			timer.text = "Time : " + time1.ToString(); //10초 타이머를 재생하면서 언제 prefab이 생성될지 보여줌.
		}
		if(Input.GetKey(KeyCode.Q)){
			Application.Quit(); //q 누르면 종료하게 만듦.
		} 
		if(Input.GetKey(KeyCode.R)){
			Application.LoadLevel("project"); //r 누르면 다시 시작하게 만듦ㄴ.
		} 
	}

    void Instantiate_fnc(){
		Instantiate(prefab, new Vector3(-9.3f,25,5), Quaternion.Euler(new Vector3(90,0,0)));
		Instantiate(prefab, new Vector3(-9.3f,19,5), Quaternion.Euler(new Vector3(90,0,0)));
		Instantiate(prefab, new Vector3(-9.3f,14,5), Quaternion.Euler(new Vector3(90,0,0)));
		Instantiate(prefab, new Vector3(-9.3f,8,5), Quaternion.Euler(new Vector3(90,0,0))); 
		audio1.Play(); //x,z축은 똑같고 y축만 다르게 해서 4군데에서 prefab이 생성되게 하는 함수를 작성함. prefab이 생성될 때 소리도 나오게 함. 
	}

	public void Jump(){
		jumpbutton = true; //jump 버튼 누르는 함수 설정해줌. 
	}
}
