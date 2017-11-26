using UnityEngine;
using System.Linq;

public class Highscore : MonoBehaviour
{
    public ScoreItem[] scoreItems;

    [System.Serializable]
    public struct ScoreItemJson
    {
        public long ticks;
        public int score;
    }

    [System.Serializable]
    public struct ScoreItemArray
    {
        public ScoreItemJson[] scoreItems;
    }

    private static string HIGHSCORE_KEY = "highscore";

    private void Awake()
    {
        //AddNewHighscore(123);

        var scoreItemArray = JsonUtility.FromJson<ScoreItemArray>(PlayerPrefs.GetString(HIGHSCORE_KEY, "{}"));
        if (scoreItemArray.scoreItems == null)
        {
            return;
        }
        var scoreItemArraySorted = scoreItemArray.scoreItems.OrderByDescending(e => e.score).ThenByDescending(e => e.ticks).ToArray();
        int i = 0;
        foreach (var si in scoreItems)
        {
            if (i < scoreItemArraySorted.Length)
            {
                scoreItems[i].rankText.text = string.Format("{0}위", i + 1);
                scoreItems[i].dateTimeText.text = new System.DateTime(scoreItemArraySorted[i].ticks).ToString("yyyy년 MM월 dd일 HH:mm:ss");
                scoreItems[i].scoreText.text = string.Format("{0}개", scoreItemArraySorted[i].score);
            }
            else
            {
                scoreItems[i].rankText.text = "";
                scoreItems[i].dateTimeText.text = "";
                scoreItems[i].scoreText.text = "";
            }
            i++;
        }
    }

    public static void AddNewHighscore(int score)
    {
        var scoreItemArray = JsonUtility.FromJson<ScoreItemArray>(PlayerPrefs.GetString("highscore", "{}"));
        var sij = new System.Collections.Generic.List<ScoreItemJson>();
        if (scoreItemArray.scoreItems != null)
        {
            sij.AddRange(scoreItemArray.scoreItems);
        }
        sij.Add(new ScoreItemJson { score = score, ticks = System.DateTime.Now.Ticks });
        scoreItemArray.scoreItems = sij.ToArray();
        var str = JsonUtility.ToJson(scoreItemArray);
        PlayerPrefs.SetString(HIGHSCORE_KEY, str);
        PlayerPrefs.Save();
    }

    public void ReturnToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
}
