using UnityEngine;
using DG.Tweening;
using Syrinj;

public class LogoIntroMover : MonoBehaviour {
    public float duration = 2f;

    public CanvasGroup CanvasGroup;
    public RectTransform Logo;

    public Ease EaseMode;

    // Start is called before the first frame update
    void Start()
    {
        // Usamos o Local Move aqui porque as coordenadas globais são afetadas pelas do pai (Canvas) 
        Logo.DOLocalMoveX(-207f, duration)
//          .SetRelative(true)    <=== Só necessário se usássemos o DoMoveX ao invés
            .SetEase(EaseMode)
//          .OnComplete(FadeGroup); <=== Versão chamando método ao completar o tween
//                                       Abaixo: versão com Método anônimo "inline" definido por lambda
            .OnComplete(() => CanvasGroup.DOFade(0f, 2f));
    }

    public void FadeGroup()
    {
        CanvasGroup.DOFade(0f, 2f);
    }
}
