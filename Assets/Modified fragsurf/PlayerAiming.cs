using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAiming : MonoBehaviour
{
	[Header("References")]
	public Transform bodyTransform;

	[Header("Sensitivity")]
	public float sensitivityMultiplier = 1f;
	public float horizontalSensitivity = 1f;
	public float verticalSensitivity   = 1f;

	[Header("Restrictions")]
	public float minYRotation = -90f;
	public float maxYRotation = 90f;
	public float minXRotation = 0;
	public float maxXRotation = 0;

	[Header("Aimpunch")]
	[Tooltip("bigger number makes the response more damped, smaller is less damped, currently the system will overshoot, with larger damping values it won't")]
	public float punchDamping = 9.0f;

	[Tooltip("bigger number increases the speed at which the view corrects")]
	public float punchSpringConstant = 65.0f;

	[HideInInspector]
	public Vector2 punchAngle;

	[HideInInspector]
	public Vector2 punchAngleVel;

	//The real rotation of the camera without recoil
	private Vector3 _realRotation;
	private Vector2 _lookAxis;

	private void Start()
	{
		// Lock the mouse
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible   = false;
	}

	private void Update()
	{
		// Fix pausing
		if (Mathf.Abs(Time.timeScale) <= 0)
			return;

		DecayPunchAngle();

		// Input
		float xMovement = _lookAxis.x * horizontalSensitivity * sensitivityMultiplier;
		float yMovement = -_lookAxis.y * verticalSensitivity  * sensitivityMultiplier;

		// Calculate real rotation from input
		var xRot = _realRotation.y + xMovement;
		if (minXRotation != 0 && maxXRotation != 0)
			xRot = Mathf.Clamp(xRot, minXRotation, maxXRotation);
		_realRotation   = new Vector3(Mathf.Clamp(_realRotation.x + yMovement, minYRotation, maxYRotation), xRot, _realRotation.z);
		_realRotation.z = Mathf.Lerp(_realRotation.z, 0f, Time.deltaTime * 3f);

		//Apply real rotation to body
		bodyTransform.eulerAngles = Vector3.Scale(_realRotation, new Vector3(0f, 1f, 0f));

		//Apply rotation and recoil
		Vector3 cameraEulerPunchApplied = _realRotation;
		cameraEulerPunchApplied.x += punchAngle.x;
		cameraEulerPunchApplied.y += punchAngle.y;

		transform.eulerAngles = cameraEulerPunchApplied;
	}

	public void OnCameraMove(InputAction.CallbackContext context)
	{
		_lookAxis = context.ReadValue<Vector2>();
	}

	public void ViewPunch(Vector2 punchAmount)
	{
		//Remove previous recoil
		punchAngle = Vector2.zero;

		//Recoil go up
		punchAngleVel -= punchAmount * 20;
	}

	private void DecayPunchAngle()
	{
		if (punchAngle.sqrMagnitude > 0.001 || punchAngleVel.sqrMagnitude > 0.001)
		{
			punchAngle += punchAngleVel * Time.deltaTime;
			float damping = 1 - (punchDamping * Time.deltaTime);

			if (damping < 0)
				damping = 0;

			punchAngleVel *= damping;

			float springForceMagnitude = punchSpringConstant * Time.deltaTime;
			punchAngleVel -= punchAngle * springForceMagnitude;
		}
		else
		{
			punchAngle    = Vector2.zero;
			punchAngleVel = Vector2.zero;
		}
	}
}
