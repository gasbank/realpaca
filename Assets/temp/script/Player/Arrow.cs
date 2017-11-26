using UnityEngine;

public class Arrow : MonoBehaviour {
    public Transform _house;
    public Transform _tr;
    private void Awake() {
        GameController.instance.onGameStart += () => {
            gameObject.SetActive(true);
        };
        GameController.instance.onGameStop += () => {
            gameObject.SetActive(false);
        };
    }

    private void Update() {
        transform.position = _tr.position + new Vector3(0, -2.5f, 0);
        var dir = _house.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
