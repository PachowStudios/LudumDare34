using DG.Tweening;
using UnityEngine;

namespace LudumDare34
{
  [AddComponentMenu("Ludum Dare 34/UI/Camera/Scale Width Camera")]
  [ExecuteInEditMode]
  public sealed class ScaleWidthCamera : MonoBehaviour
  {
    [SerializeField] private int defaultFOV = 500;
    [SerializeField] private bool useWorldSpaceUI = false;
    [SerializeField] private RectTransform worldSpaceUI = null;

    public int CurrentFOV { get; set; }

    private Camera controlledCamera;

    private Camera Camera => this.GetComponentIfNull(ref this.controlledCamera);

    private void OnEnable()
      => CurrentFOV = this.defaultFOV;

    private void OnPreRender()
    {
      Camera.orthographicSize = CurrentFOV / 32f / Camera.aspect;

      if (this.useWorldSpaceUI && this.worldSpaceUI != null)
        this.worldSpaceUI.sizeDelta =
          new Vector2(
            CurrentFOV / 16f,
            CurrentFOV / 16f / Camera.aspect);
    }

    public void AnimateFOV(int newFOV, float time)
      => DOTween.To(
          () => CurrentFOV,
          x => CurrentFOV = x,
          newFOV, time)
        .SetEase(Ease.OutQuint);
  } 
}