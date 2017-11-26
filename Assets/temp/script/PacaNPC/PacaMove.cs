using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PacaMove : MonoBehaviour {
	[Header("MoveDist")]
	public float minMoveDist = 2.0f;
	public float maxMoveDist = 5.0f;

	[Header("WaitTime")]
	public float minWaitTime = 1f;
	public float max_wait_time = 2f;

	[Header("BalanceControll")]
	public float outRecognizeDist = 120.0f;

	private IEnumerator moveCo;
    private SpriteRenderer _spriteRenderer;

	[Header("Flee")]
    public float fleeSpeed = 10.0f;
    public float fleeTime = 3.0f;

    private void Awake() {
        moveCo = Move();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.instance.onGameStart += () => {
            StartCoroutine(moveCo);
        };
        GameController.instance.onGameStop += () => {
            StopCoroutine(moveCo);
        };
    }

	public void StartMove() {
		if (null == moveCo)
			moveCo = Move ();
		StartCoroutine (moveCo);
	}

    private IEnumerator Move() {
		while (true) {
			Vector3 dest = Vector3.right;
			if (transform.position.magnitude >= outRecognizeDist) {
				dest = transform.position.normalized * (-1);
			} else {
				float angle = Random.Range(0.0f, 360.0f);
				dest = Quaternion.Euler (0.0f, 0.0f, angle) * dest;
			}
            float dist = Random.Range(minMoveDist, maxMoveDist);
            Vector3 _targetPos = dist * dest;
            Vector3 deltaMove = _targetPos / 150f;
            for (int i = 0; i < 150; i++)
            {
                yield return new WaitForSeconds(0.02f);
                transform.Translate(deltaMove);
                if (deltaMove.x != 0)
                    transform.localScale = new Vector3(deltaMove.x > 0.0f ? -1.0f : 1.0f, 1.0f, 1.0f);
            }
            float sec = Random.Range(minWaitTime, max_wait_time);
            yield return new WaitForSeconds(sec);
        }
    }

    public static Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector2(x, y);

    }

    public void StartFlee()
    {
        StopAllCoroutines();
        StartCoroutine(Flee());
    }

    public IEnumerator Flee()
    {
        var fleeDelta = RandomPointOnUnitCircle(1.0f);
        
        while (fleeTime > 0)
        {
            transform.Translate(fleeDelta * fleeSpeed * Time.deltaTime);
            fleeTime -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
