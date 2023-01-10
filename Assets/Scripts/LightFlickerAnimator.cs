using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickerAnimator : MonoBehaviour {

    [SerializeField] private Vector2 _intensityRange;
    [SerializeField] private float _intensitySpeed;

    [SerializeField] private Vector2 _falloffRange;
    [SerializeField] private float _falloffSpeed;

    private Light2D _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float intensityAmp = _intensityRange.y - _intensityRange.x;
        _light.intensity = (Mathf.Sin(Time.time * _intensitySpeed) * intensityAmp) + _intensityRange.x;

        float falloffAmp = _falloffRange.y - _falloffRange.x;
        _light.pointLightOuterRadius = (Mathf.Sin(Time.time * _falloffSpeed) * falloffAmp) + _falloffRange.y;
    }
}
