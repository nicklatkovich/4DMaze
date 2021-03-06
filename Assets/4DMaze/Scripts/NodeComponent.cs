using UnityEngine;

public class NodeComponent : MonoBehaviour {
	private float RETINA = 60f;

	public Renderer Renderer;

	public bool Visible = true;
	public Vector4 pos;

	private Color _color;
	public Color color { get { return _color; } set { _color = value; UpdateColor(); } }

	// public float distructionAnim = 1f;

	private float initialTime;
	private float radius = 0;

	private void Start() {
		initialTime = Time.time;
	}

	public void Render(Vector4 observer, FourDimRotation lookRotation) {
		if (!Visible) {
			gameObject.SetActive(false);
			return;
		}
		Vector4 relativePos = pos - observer;
		float dist = relativePos.magnitude;
		float targetRadius = 1f;
		if (dist > 1.5f) targetRadius = 0f;
		else if (dist > 1f) targetRadius = (1.5f - dist) / .5f;
		Vector4 projDepth = Vector4.Project(relativePos, lookRotation.Front);
		float dDepth = (projDepth + lookRotation.Front).magnitude - 1;
		if (dDepth < .5f) targetRadius = Mathf.Max(0, dDepth * 2f);
		targetRadius *= Mathf.Min(1f, Time.time - initialTime);
		if (targetRadius > radius) radius = Mathf.Min(targetRadius, radius + Time.deltaTime);
		else radius = targetRadius;
		transform.localScale = Vector3.one * .2f * radius;
		float angleX = Project(relativePos, lookRotation.Right, lookRotation.Front) / RETINA;
		float angleY = Project(relativePos, lookRotation.Ana, lookRotation.Front) / RETINA;
		float angleZ = Project(relativePos, lookRotation.Up, lookRotation.Front) / RETINA;
		transform.localPosition = new Vector3(angleX, angleY, angleZ);
	}

	private float Project(Vector4 point, Vector4 right, Vector4 front) {
		Vector4 projX = Vector4.Project(point, right);
		float dx = (projX + right).magnitude - 1;
		Vector4 projDepth = Vector4.Project(point, front);
		float dDepth = (projDepth + front).magnitude - 1;
		float angle = Vector2.Angle(Vector2.up, new Vector2(dx, dDepth));
		return dx < 0 ? -angle : angle;
	}

	private void UpdateColor() {
		Renderer.material.color = color;
	}
}
