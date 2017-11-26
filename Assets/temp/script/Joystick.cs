using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public static Joystick instance;

    public float speed = 1.0f;
    public Vector3 pressMousePosition;
    public Vector3 dragMousePosition;
    public Vector2 moveUnitDelta;
    public bool pressed;
    public Canvas canvas;
    public Transform touchOriginJoystick;
    public Transform touchNowJoystick;
    public Vector3 touchOriginJoystickInitialPosition;
    public Vector3 touchNowJoystickInitialPosition;

	[Header("Renderer")]
	public UnityEngine.UI.Image bgRenderer2d;
	public UnityEngine.UI.Image fgRenderer2d;
	private Color bgColor;
	private Color fgColor;

    private void Awake()
    {
        instance = this;
        touchOriginJoystickInitialPosition = touchOriginJoystick.position;
        touchNowJoystickInitialPosition = touchNowJoystick.position;

		bgColor = bgRenderer2d.color;
		fgColor = fgRenderer2d.color;
		bgRenderer2d.color = new Color (bgColor.r, bgColor.g, bgColor.b, 0.0f);
		fgRenderer2d.color = new Color (fgColor.r, fgColor.g, fgColor.b, 0.0f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressMousePosition = Input.mousePosition;
            pressed = true;

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pressMousePosition, canvas.worldCamera, out pos);
            touchOriginJoystick.position = canvas.transform.TransformPoint(pos);
            touchNowJoystick.position = canvas.transform.TransformPoint(pos);

			bgRenderer2d.color = bgColor;
			fgRenderer2d.color = fgColor;
        }

        if (pressed)
        {
            dragMousePosition = Input.mousePosition;
            var delta = dragMousePosition - pressMousePosition;
            moveUnitDelta.x = delta.x;
            moveUnitDelta.y = delta.y;
            moveUnitDelta = moveUnitDelta.normalized;

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, dragMousePosition, canvas.worldCamera, out pos);
            touchNowJoystick.position = canvas.transform.TransformPoint(pos);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchOriginJoystick.position = touchOriginJoystickInitialPosition;
            touchNowJoystick.position = touchNowJoystickInitialPosition;
            pressed = false;

			bgRenderer2d.color = new Color (bgColor.r, bgColor.g, bgColor.b, 0.0f);
			fgRenderer2d.color = new Color (fgColor.r, fgColor.g, fgColor.b, 0.0f);
        }
        //if (Input.touchCount > 0)
        //{
        //    // Get movement of the finger since last frame
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {

        //    }

        //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        // Move object across XY plane
        //        transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        //    }
        //}
    }
}
