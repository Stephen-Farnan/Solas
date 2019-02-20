using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GlowComposite : MonoBehaviour
{
    [Range(0, 10)]
    public float Intensity = 2;

    private Material _compositeMat;
    public GlowPrePass glow;

    private void Start()
    {
        if (glow != null)
        {
            StartCoroutine("setup");
        }

    }

    IEnumerator setup()
    {
        yield return new WaitForSeconds(1f);
        glow.enabled = true;
    }

    void OnEnable()
    {
        _compositeMat = new Material(Shader.Find("Hidden/GlowComposite"));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        _compositeMat.SetFloat("_Intensity", Intensity);
        Graphics.Blit(src, dst, _compositeMat);
    }
}
