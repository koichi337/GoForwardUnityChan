using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10.0f;

	// cubeの効果音を扱うための変数
	AudioSource cubeAudio;


	void Start () {
		// AudioSourceコンポーネントを取得
		cubeAudio = GetComponent<AudioSource> ();
	}

	void Update () {
		// キューブを移動させる
		transform.Translate(speed, 0, 0);

		// 画面外に出たら破棄する
		if(transform.position.x < deadLine){
			Destroy (gameObject);
		}
	}

	// プレイヤー以外にcubeが接触したらAudioClip内の音を再生
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag != "Player") {
			cubeAudio.Play();
		}
	}

}
