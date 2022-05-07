using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile brickTile;

    static GameMaster instance = null;

    void Start()
    {
        int posX = 12;
        int posY = 8;
        for (int y = -9; y < posY; y++)
        {
            if (Random.Range(0, 3) != 1)
            {
                for (int x = -13; x < posX; x++)
                {
                    tilemap.SetTile(new Vector3Int(Random.Range(x, x+2), Random.Range(y, y+2), 0), brickTile);
                }
            }
        }
        StartCoroutine(UpdateGuysPoints());
    }

    [SerializeField]
    //int fastGuyPoints = 100, armoredGuyPoints = 200, bonusGuyPoints = 50;
    public int fastGuyPointsWorth { get { return fastGuyPointsWorth; } }
    public int armoredPointsWorth { get { return armoredPointsWorth; } }
    public int bonusGuyPointsWorth { get { return bonusGuyPointsWorth; } }
    
    public static int fastGuyDestroyed, armoredGuyDestroyed, bonusGuyDestroyed;
    public static int playerScore = 0;
    int fastGuyScore, armoredGuyScore, bonusGuyScore;
    Text fastGuyScoreText, armoredGuyScoreText, bonusGuyScoreText;
  
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator UpdateGuysPoints()
    {
        for (int i = 0; i <= GameMaster.fastGuyDestroyed; i++)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}
