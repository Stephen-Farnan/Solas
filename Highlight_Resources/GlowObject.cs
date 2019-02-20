using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObject : MonoBehaviour
{
    public Color GlowColor;
    public float LerpFactor = 10;
    bool highlight_Is_On = false;



    public Renderer[] Renderers
    {
        get;
        private set;
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
    }

    private List<Material> _materials = new List<Material>();
    private Color _currentColor;
    private Color _targetColor;

    void Start()
    {
        Renderers = GetComponentsInChildren<Renderer>();

        foreach (var renderer in Renderers)
        {
            _materials.AddRange(renderer.materials);
        }

        StartCoroutine("Custom_Update");
    }


    public void Turn_On_Highlight()
    {
        if (!highlight_Is_On)
        {
            _targetColor = GlowColor;
            enabled = true;
            highlight_Is_On = true;
        }

    }

    public void Turn_Off_Highlight()
    {
        highlight_Is_On = false;
        _targetColor = Color.black;
        enabled = true;
    }



    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>



    IEnumerator Custom_Update()
    {
        while (true)
        {
            _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

            for (int i = 0; i < _materials.Count; i++)
            {
                _materials[i].SetColor("_GlowColor", _currentColor);
            }

            if (_currentColor.Equals(_targetColor))
            {
                enabled = false;
            }
            yield return new WaitForSeconds(.02f);
        }

    }
}
