using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AnimatedWindow : MonoBehaviour
{
    [Header("Animation time")]
    [SerializeField] private float _scaleDuration = 1f;
    [SerializeField] private float _fadeDuration = 1f;
    [Header("End values")]
    [SerializeField] private Vector3 _scale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private float _alpha = 0f;
    private CanvasGroup _canvasGroup;
    private Vector3 _scaleOrigin;
    private float _alphaOrigin;
    private Sequence _openSequence, _closeSequence;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _scaleOrigin = transform.localScale;
        _alphaOrigin = _canvasGroup.alpha;

        _openSequence = DOTween.Sequence()
            .Pause()
            .SetAutoKill(false)
            .SetRecyclable(true)
            .Insert(0, transform.DOScale(_scaleOrigin, _scaleDuration))
            .Insert(0, _canvasGroup.DOFade(_alphaOrigin, _fadeDuration));

        _closeSequence = DOTween.Sequence()
            .Pause()
            .SetAutoKill(false)
            .SetRecyclable(true)
            .Insert(0, transform.DOScale(_scaleOrigin - _scale, _scaleDuration))
            .Insert(0, _canvasGroup.DOFade(_alpha, _fadeDuration))
            .OnComplete(() => gameObject.SetActive(false));
    }

    public void Open()
    {
        if (gameObject.activeSelf) {
            Close();
            return;
        }
        gameObject.SetActive(true);
        if (_openSequence.IsPlaying()) return;

        transform.localScale = _scaleOrigin - _scale;
        _canvasGroup.alpha = _alpha;

        _openSequence.Restart();
    }

    public void Close()
    {
        if (!gameObject.activeSelf) return;
        if (_closeSequence.IsPlaying()) return;

        transform.localScale = _scaleOrigin;
        _canvasGroup.alpha = _alphaOrigin;

        _closeSequence.Restart();
    }
}
