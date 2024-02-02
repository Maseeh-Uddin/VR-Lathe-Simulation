using UnityEngine;

public class CylinderCreator : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float pivotPos = 0.5f;
    public float radius = 0.5f;
    public float height = 1f;
    public int sides = 3;
    public float phase = 0f;

    void Start()
    {
        GetComponent<MeshFilter>().sharedMesh = CreateCylinder(direction, pivotPos, radius, height, sides, phase);
    }

    public static Mesh CreateCylinder(Vector3 aDir, float aPivot, float aRadius, float aHeight, int aSides, float aPhaseOffset)
    {
        aDir.Normalize();
        aSides = Mathf.Max(3, aSides);
        Vector3 u = Vector3.up;
        Vector2 uv = Vector2.right * 0.5f;
        if (Mathf.Abs(aDir.y) > 0.98f)
            u = -Vector3.forward;
        u = Vector3.ProjectOnPlane(u, aDir).normalized;
        u = Quaternion.AngleAxis(aPhaseOffset, aDir) * u;
        Quaternion q = Quaternion.AngleAxis(360f / aSides, aDir);
        Quaternion q2 = Quaternion.AngleAxis(360f / aSides, -Vector3.forward);
        Vector3[] vertices = new Vector3[(aSides + 1) * 4 + 2];
        Vector3[] normals = new Vector3[vertices.Length];
        Vector2[] UVs = new Vector2[vertices.Length];
        int[] triangles = new int[aSides * 12];
        // bottom / top center
        Vector3 b = vertices[0] = -aDir * aPivot * aHeight;
        Vector3 t = vertices[1] = aDir * (1f - aPivot) * aHeight;
        normals[0] = -aDir;
        normals[1] = aDir;
        UVs[0] = UVs[1] = new Vector2(0.5f, 0.5f);
        int count = aSides + 1;
        for (int i = 0; i < count; i++)
        {
            // bottom + sides bottom vertices
            vertices[2 + i] = vertices[2 + count + i] = b + u * aRadius;
            // sides top + top vertices
            vertices[2 + count * 2 + i] = vertices[2 + count * 3 + i] = t + u * aRadius;

            // bottom normal
            normals[2 + i] = -aDir;
            // top normal
            normals[2 + count * 3 + i] = aDir;
            // sides normals
            normals[2 + count + i] = normals[2 + count * 2 + i] = u;

            // bottom UV
            UVs[2 + i] = new Vector2(uv.x + 0.5f, uv.y + 0.5f);
            // sides UV
            float x = (float)i / (aSides);
            UVs[2 + count * 1 + i] = new Vector2(x, 0f);
            UVs[2 + count * 2 + i] = new Vector2(x, 1f);
            // top UV
            UVs[2 + count * 3 + i] = new Vector2(-uv.x + 0.5f, uv.y + 0.5f);

            // rotate vectors
            u = q * u;
            uv = q2 * uv;

        }
        for (int i = 0; i < aSides; i++)
        {
            // bottom face
            triangles[i * 12] = 0;
            triangles[i * 12 + 1] = 2 + i + 1;
            triangles[i * 12 + 2] = 2 + i;

            // top face
            triangles[i * 12 + 3] = 1;
            triangles[i * 12 + 4] = 2 + count * 3 + i;
            triangles[i * 12 + 5] = 2 + count * 3 + i + 1;

            // sides faces
            triangles[i * 12 + 6] = 2 + count * 1 + i;
            triangles[i * 12 + 7] = 2 + count * 1 + i + 1;
            triangles[i * 12 + 8] = 2 + count * 2 + i;

            triangles[i * 12 + 9] = 2 + count * 2 + i + 1;
            triangles[i * 12 + 10] = 2 + count * 2 + i;
            triangles[i * 12 + 11] = 2 + count * 1 + i + 1;

        }
        Mesh m = new Mesh();
        m.vertices = vertices;
        m.normals = normals;
        m.uv = UVs;
        m.triangles = triangles;
        return m;
    }
}
