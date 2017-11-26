using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public Sprite[] stoneList;
    public Sprite[] snowList;
    public int stoneSpawnCount = 30;
    public int snowSpawnCount = 40;
    public Transform stones;
    public Transform snows;
    public System.Random rnd = new System.Random((int)System.DateTime.Now.Ticks);
    public float spawnRadius = 50;
//    public Paca[] pacaList;
//    public Paca policePaca;
    // Paca Alpacas
//    public GameObject pacaAlpacaPrefab;
//    public float pacaAlpacaSpawnRadius = 50;
//    public int pacaAlpacaSpawnCount = 10;
//    public Transform pacaAlpacas;
    // Police Alpacas
//    public GameObject policeAlpacaPrefab;
//    public float policeAlpacaSpawnRadius = 50;
//    public int policeAlpacaSpawnCount = 10;
//    public Transform policeAlpacas;

    void Awake()
    {
        RandomSpawn(snowList, snows, snowSpawnCount, snowSpawnCount);
        RandomSpawn(stoneList, stones, stoneSpawnCount, stoneSpawnCount);

//        RandomSpawnPacaAlpaca(pacaAlpacaPrefab, pacaAlpacaSpawnCount);
//        RandomSpawnPoliceAlpaca(pacaAlpacaPrefab, policeAlpacaSpawnCount);
    }

    private void RandomSpawnPoliceAlpaca(GameObject alpacaPrefab, int count)
    {
//        for (int i = 0; i < count; i++)
//        {
//            var go = Instantiate(alpacaPrefab);
//            go.GetComponent<SettingPaca>().SetData(pacaList[rnd.Next(0, pacaList.Length)]);
//            var spawnPoint = UnityEngine.Random.insideUnitCircle * pacaAlpacaSpawnRadius;
//            go.transform.position = spawnPoint;
//            go.transform.parent = pacaAlpacas;
//        }
    }

    private void RandomSpawnPacaAlpaca(GameObject alpacaPrefab, int count)
    {
//        for (int i = 0; i < count; i++)
//        {
//            var go = Instantiate(alpacaPrefab);
//            go.GetComponent<SettingPaca>().SetData(pacaList[rnd.Next(0, pacaList.Length)]);
//            var spawnPoint = UnityEngine.Random.insideUnitCircle * pacaAlpacaSpawnRadius;
//            go.transform.position = spawnPoint;
//            go.transform.parent = pacaAlpacas;
//        }
    }

    private void RandomSpawn(Sprite[] sprites, Transform spawnParent, int count, int orderInLayer)
    {
        for (int i = 0; i < count; i++)
        {
            var pick = sprites[rnd.Next(0, sprites.Length)];
            GameObject go = new GameObject(string.Format("spawn_{0}", i));
            var spriteRenderer = go.AddComponent<SpriteRenderer>();
			spriteRenderer.sortingLayerID = SortingLayer.NameToID ("BackGround");
            spriteRenderer.sprite = pick;
            var spawnPoint = UnityEngine.Random.insideUnitCircle * spawnRadius;
            go.transform.position = spawnPoint;
            go.transform.parent = spawnParent;
            spriteRenderer.sortingOrder = orderInLayer;
        }
    }
}
