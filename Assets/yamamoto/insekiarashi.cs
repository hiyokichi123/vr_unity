
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class insekiarashi : UdonSharpBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    public const int LOOP_NUM = 20; /* ループ回数 */
    int cnt = 0;  
    private float time;

    void Update()
    {
        time = time + Time.deltaTime;
        while ((cnt <= LOOP_NUM) && (time > 3.0f))
        {

            
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            // 経過時間リセット
            time = 0f;
            cnt += 1;
        }
    }
}
