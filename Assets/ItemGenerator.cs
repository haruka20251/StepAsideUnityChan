using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private float startPos = 80;
    private float goalPos = 360;
    private float posRange = 3.4f;//アイテムを出すｘ方向
    
    

    // Start is called before the first frame update
    void Start()
    {

        //スタートからゴールまでz方向（画面奥方向）に15mずつスペースをあけてアイテムを生成
        for (float i = startPos; i < goalPos; i += 15)
            {
                //障害物（cone）を生成するか、アイテム（coinまたはcar）を生成するかを決める
                int num = Random.Range(1, 11);

                //numが2以下の場合（つまり、20%の確率）、障害物を生成
                if (num <= 2)
                {
                    //x座標を-1から1まで0.4ずつ変化させながら繰り返す
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        //conePrefabを元に、障害物オブジェクトを生成
                        GameObject cone = Instantiate(conePrefab);
                        //生成した障害物の位置を、x座標（横）は4 * j、z座標（奥）はiに設定
                        //z方向（奥）に一定間隔で並び、x方向（横）に少しずつ位置がずれた複数の障害物が生成
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                //numが3以上の場合（つまり、80%の確率）、アイテムを生成
                else
                {
                    //x座標(横列）を-1から1まで1ずつ変化させながら繰り返す
                    for (int j = -1; j <= 1; j++)
                    {
                        //1から10までのランダムな整数を生成し、itemに格納
                        //この乱数によって、coinを生成するかcarを生成するかが決まる
                        int item = Random.Range(1, 11);

                        //z座標のオフセットを-5から5の範囲でランダムに生成
                        int offsetZ = Random.Range(-5, 6);

                        //↓この処理によって、z方向に一定間隔で並び、x方向に少しずつ位置がずれた複数のアイテム（coinまたはcar）がランダムに生成
                        //1から6の場合（つまり、60%の確率）、coinを生成
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab);
                            //生成したcoinの位置を、x座標（横）はposRange * j、z座標(奥）はi + offsetZに設定
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }

                        //itemが7から9の場合（つまり、30%の確率）、carを生成
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab);

                            //生成したcarの位置を、x座標はposRange * j、z座標はi + offsetZに設定
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }


                    }

                }


            }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   


}
