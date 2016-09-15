using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {

	// アニメーション操作のためにコンポーネントを入れる
	Animator animator;

	// Unityちゃんの物理挙動を操作するための変数
	Rigidbody2D rigid2D;

	// 地面の位置
	private float groundLevel = -3.0f;

	// ジャンプの速度
	float jumpVelocity = 20.0f;
	// ジャンプの減速係数
	private float dump = 0.8f;

	// ゲームオーバーになる位置
	private float deadLine = -9;


	void Start () {
		// アニメータコンポーネントを取得する
		animator = GetComponent<Animator>();
		// Rigidbody2Dのコンポーネントを取得
		rigid2D = GetComponent<Rigidbody2D> ();
	
	}
	

	void Update () {
		// 絶えず走るアニメーションを再生(Horizontalが0.1以上で走るアニメに切り替わるので)
		animator.SetFloat ("Horizontal", 1);

		// 着地してるかどうかを調べる(Unityちゃんの座標が-3.0fより大きければジャンプ中と判断する)
		bool isGround = (transform.position.y > groundLevel) ? false : true;
		// ジャンプ判定結果をパラメータに入れる
		animator.SetBool ("isGround", isGround);

		// ジャンプ中は足音のボリュームを0にする
		GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

		// 着地状態でクリックされた場合は上方向に力をかけてジャンプ
		if(Input.GetMouseButtonDown(0) && isGround == true){
			rigid2D.velocity = new Vector2 (0, jumpVelocity);
		}
		// クリックをやめたら上方向への速度を減速する
		if(Input.GetMouseButton(0) == false){
			if (rigid2D.velocity.y > 0) {
				rigid2D.velocity *= dump;
			}
		}

		// deadLineを超えた場合ゲームオーバーにする
		if(transform.position.x < deadLine){
			// UIControllerスクリプトからGameOver関数を呼び出し「GameOver」と表示させる
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
			// Unityちゃんを破棄する
			Destroy(gameObject);
		}
	
	}
}
