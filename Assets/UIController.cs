using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	// ゲームオーバーテキストを弄るための変数
	private GameObject gameOverText;

	//走行距離を弄るためのテキスト
	private GameObject runLengthText;

	// 走った距離
	private float len = 0;

	//走る速度(1フレームあたりの距離)
	private float speed = 0.03f;

	// ゲームオーバーの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		// 検索したゲームオブジェクトを変数に格納
		gameOverText = GameObject.Find("GameOver");
		runLengthText = GameObject.Find ("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
		// ゲームオーバーフラグがfalseなら走った距離を更新し続ける
		if(isGameOver == false){
			len += speed;
			runLengthText.GetComponent<Text>().text = "Distance" + len.ToString("F2") + "m";
		}

		// ゲームオーバーになった場合
		if(isGameOver == true){
			// クリックされたらシーンをロードする
			if(Input.GetMouseButtonDown(0)){
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void GameOver(){
		// ゲームオーバーになった時に、画面上にゲームオーバーを表示する
		gameOverText.GetComponent<Text>().text = "GameOver";
		isGameOver = true;
	}
}
