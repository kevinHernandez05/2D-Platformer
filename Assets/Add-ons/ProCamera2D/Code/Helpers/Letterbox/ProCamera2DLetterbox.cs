﻿using UnityEngine;
using System.Collections;

namespace Com.LuisPedroFonseca.ProCamera2D
{
    [ExecuteInEditMode]
    public class ProCamera2DLetterbox : MonoBehaviour
    {
        [Range(0, .5f)]
        public float Amount = 0f;

        public Color Color;

        Material _material;

        Material material
        {
            get
            {
                if (_material == null)
                {
                    _material = new Material(Shader.Find("Hidden/ProCamera2D/Letterbox"));
                    _material.hideFlags = HideFlags.HideAndDontSave;  
                }
                return _material;
            }
        }

        void Start()
        {
            if (!SystemInfo.supportsImageEffects)
            {
                enabled = false;
                return;
            }
        }

        void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (Mathf.Approximately(Amount, 0f) || material == null)
            {
                Graphics.Blit(sourceTexture, destTexture);
                return;
            }

            Amount = Mathf.Clamp01(Amount);
            material.SetFloat("_Top", 1 - Amount);
            material.SetFloat("_Bottom", Amount);
            material.SetColor("_Color", Color);
            Graphics.Blit(sourceTexture, destTexture, material);
        }

        void OnDisable()
        {
            if (_material)
            {
                DestroyImmediate(_material);  
            }
        }

        public void TweenTo(float targetAmount, float duration)
        {
            StopAllCoroutines();
            StartCoroutine(TweenToRoutine(targetAmount, duration));
        }

        IEnumerator TweenToRoutine(float targetAmount, float duration)
        {
            var initialAmount = Amount;

            var t = 0f;
            while (t <= 1.0f)
            {
                t += Time.deltaTime / duration;

                Amount = Utils.EaseFromTo(initialAmount, targetAmount, t, EaseType.EaseOut);

                yield return null;
            }

            Amount = targetAmount;

            yield return null;
        }
    }
}