using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour {

	// キューブのprefabを扱うための変数
	public GameObject cubePrefab;

	// 時間計測用の変数
	private float delta = 0;

	// キューブの生成間隔
	private float span = 1.0f;

	// キューブの生成位置 : x座標
	private float genPosX = 12;

	// キューブの生成位置オフセット
	private float offsetY = 0.3f;
	// キューブの縦方向の間隔
	private float spaceY = 6.9f;

	// キューブの生成位置オフセット
	private float offsetX = 0.5f;
	// キューブの横方向の間隔
	private float spaceX = 0.4f;

	// キューブの生成個数の上限
	private int maxBlockNum = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// 1フレーム分の時間を毎フレーム加算していく
		delta += Time.deltaTime;

		// deltaの合計値がspan秒以上になったら生成処理を開始する
		if(delta > span){
			delta = 0;
			// 生成するキューブ数をランダムに決める
			int n = Random.Range(1, maxBlockNum + 1);

			// 乱数で決まった数だけキューブを生成
			for(int i = 0; i < n; i++){
				GameObject go = Instantiate (cubePrefab) as GameObject;
				go.transform.position = new Vector2 (genPosX, offsetY + i * spaceY);
			}
			//次のキューブまでの生成時間を決める
			span = offsetX + spaceX * n;
		}
	
	}
}
