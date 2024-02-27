using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CivWar{
    public class ObjectPool : SingletonMonoBehaviour<ObjectPool>
    {
        Transform pool;
        private List<GameObject> poolObjs = new List<GameObject>();
        void GetObject(GameObject obj , Vector3 pos , Quaternion qua)
        {
            foreach(Transform t in pool)
            {
                //オブジェが非アクティブなら使い回し
                if( ! t.gameObject.activeSelf)
                { 
                    t.SetPositionAndRotation(pos,qua); 
                    t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                } 
            } 
            //非アクティブなオブジェクトがないなら生成
            Instantiate(obj , pos , qua , pool);//生成と同時にpoolを親に設定
        } 
    }
}
