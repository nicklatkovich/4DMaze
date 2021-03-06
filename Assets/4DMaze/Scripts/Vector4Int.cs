using UnityEngine;

public struct Vector4Int {
	public static readonly Vector4Int zero = new Vector4Int(0, 0, 0, 0);
	public static readonly Vector4Int one = new Vector4Int(1, 1, 1, 1);
	public static readonly Vector4Int right = new Vector4Int(1, 0, 0, 0);
	public static readonly Vector4Int left = new Vector4Int(-1, 0, 0, 0);
	public static readonly Vector4Int up = new Vector4Int(0, 1, 0, 0);
	public static readonly Vector4Int down = new Vector4Int(0, -1, 0, 0);
	public static readonly Vector4Int front = new Vector4Int(0, 0, 1, 0);
	public static readonly Vector4Int back = new Vector4Int(0, 0, -1, 0);
	public static readonly Vector4Int ana = new Vector4Int(0, 0, 0, 1);
	public static readonly Vector4Int kata = new Vector4Int(0, 0, 0, -1);

	public int x;
	public int y;
	public int z;
	public int w;

	public static explicit operator Vector4(Vector4Int a) {
		return new Vector4(a.x, a.y, a.z, a.w);
	}

	public static Vector4Int operator -(Vector4Int a) {
		return a * -1;
	}

	public static Vector4Int operator +(Vector4Int a, Vector4Int b) {
		return new Vector4Int(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
	}

	public static Vector4Int operator -(Vector4Int a, Vector4Int b) {
		return new Vector4Int(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
	}

	public static Vector4Int operator %(Vector4Int a, Vector4Int b) {
		return new Vector4Int(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
	}

	public static Vector4Int operator *(Vector4Int a, int b) {
		return new Vector4Int(a.x * b, a.y * b, a.z * b, a.w * b);
	}

	public static Vector4 operator *(Vector4Int a, float b) {
		return ((Vector4)a) * b;
	}

	public static bool operator ==(Vector4Int a, Vector4Int b) {
		return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
	}

	public static bool operator !=(Vector4Int a, Vector4Int b) {
		return !(a == b);
	}

	public Vector4Int(int x, int y, int z, int w) {
		this.x = x;
		this.y = y;
		this.z = z;
		this.w = w;
	}

	public override string ToString() {
		return "(" + new[] { x, y, z, w }.Join(";") + ")";
	}

	public Vector4Int AddMod(Vector4Int other, Vector4Int _base) {
		Vector4Int preres = this + other;
		return new Vector4Int(NumMod(preres.x, _base.x), NumMod(preres.y, _base.y), NumMod(preres.z, _base.z), NumMod(preres.w, _base.w));
	}

	private static int NumMod(int a, int _base) {
		return a < 0 ? (_base + a % _base) % _base : a % _base;
	}

	public override bool Equals(object obj) {
		return base.Equals(obj);
	}

	public override int GetHashCode() {
		return base.GetHashCode();
	}
}
