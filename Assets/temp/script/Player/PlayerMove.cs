using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    private enum Direction {
        Left, Right
    }
    private IEnumerator moveCo;
    private Transform _tr;
    private float _playerSpeed = 20f;
    private Direction _currentDir = Direction.Left;
    private SpriteRenderer _spriteRenderer;
	private Animator animator;

	void Start(){
		animator = gameObject.GetComponent<Animator> ();
		GameController.instance.gameStart ();
	}

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        moveCo = move();
        GameController.instance.onGameStart += () => {
            StartCoroutine(moveCo);
        };
        GameController.instance.onGameStop += () => {
            StopCoroutine(moveCo);
        };
    }

    private IEnumerator move() {
        while (true) {
            yield return null;
            if (Player.instance.dead)
            {
                yield break;
            }
            if (Time.timeScale == 0)
            {
                yield return null;
                continue;
            }
            Vector3 delta = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.up * Input.GetAxisRaw("Vertical");
            if (Joystick.instance.pressed)
            {
                delta += new Vector3(Joystick.instance.moveUnitDelta.x, Joystick.instance.moveUnitDelta.y, 0);
            }
            if (delta.x != 0) {
                transform.localScale = new Vector3(delta.x > 0.0f ? -1.0f : 1.0f, 1.0f, 1.0f);
                animator.SetBool("isMove", true);
            } else {
                if (delta.y != 0) {
                    animator.SetBool("isMove", true);
                } else {
                    animator.SetBool("isMove", false);
                }
            }
            transform.Translate(delta * _playerSpeed * Time.deltaTime);
        }
    }
}
