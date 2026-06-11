using UnityEngine;
using UnityEngine.InputSystem;

public class FractalZoomManager : MonoBehaviour
{
    [System.Serializable]
    public class CapaFractal
    {
        public string nombreNivel;
        public Transform contenedorNivel;
        public float escalaMinima = 1f;
        public float escalaMaxima = 50f;
    }

    [Header("Secuencia de Niveles")]
    public CapaFractal[] niveles;
    private int indiceCapaActual = 0;

    [Header("Configuración de Movimiento")]
    public float velocidadZoom = 2f;
    public float suavizado = 5f; // Ahora puedes bajarlo a 2 o 3 para máxima inercia sin que haya "pops"

    [Header("Controles")]
    public float multiplicadorTeclado = 1f;
    [Tooltip("El scroll de ratón suele devolver 120. Multiplicadores como 0.05 o 0.1 funcionan mejor aquí.")]
    public float multiplicadorScroll = 0.05f;

    private float inputZoom;
    private float escalaObjetivoCapaActual;

    void Start()
    {
        if (niveles.Length > 0)
        {
            escalaObjetivoCapaActual = niveles[0].contenedorNivel.localScale.x;
        }
    }

    public void OnZoomKeyboard(InputValue valor)
    {
        inputZoom = valor.Get<float>() * multiplicadorTeclado;
    }

    public void OnZoomScroll(InputValue valor)
    {
        float scrollDelta = valor.Get<float>();

        // Multiplicador recomendado para scroll: 0.01f o 0.05f
        // Aquí NO usamos Time.deltaTime porque esto no es continuo, es un golpe directo
        float incremento = scrollDelta * multiplicadorScroll * escalaObjetivoCapaActual;

        // Inyectamos el crecimiento directo a la meta. 
        // El bucle for del Update se encargará de suavizarlo visualmente.
        escalaObjetivoCapaActual += incremento;
    }

    void Update()
    {
        if (niveles.Length == 0) return;

        // 1. Calculamos la meta de escala basada en nuestro Input
        if (inputZoom != 0)
        {
            float incremento = inputZoom * velocidadZoom * escalaObjetivoCapaActual * Time.deltaTime;
            escalaObjetivoCapaActual += incremento;
        }

        // 2. Evaluamos los límites matemáticos (Sin tocar los gráficos)
        EvaluarCambioDeCapa();

        // 3. LA SOLUCIÓN AL "POP": Actualizamos TODAS las capas al mismo tiempo.
        // Esto permite que las capas viejas terminen de suavizarse hacia su meta mientras la capa nueva empieza a moverse.
        for (int i = 0; i < niveles.Length; i++)
        {
            CapaFractal capa = niveles[i];
            float metaDeEstaCapa = capa.escalaMinima; // Por defecto

            if (i < indiceCapaActual)
            {
                // Capas exteriores que ya superamos: su destino es quedarse en su escala máxima
                metaDeEstaCapa = capa.escalaMaxima;
            }
            else if (i > indiceCapaActual)
            {
                // Capas profundas a las que aún no llegamos: su destino es su escala mínima
                metaDeEstaCapa = capa.escalaMinima;
            }
            else
            {
                // La capa activa en la que estamos navegando: su destino es lo que diga nuestro teclado/scroll
                metaDeEstaCapa = escalaObjetivoCapaActual;
            }

            // Aplicamos el suavizado (Lerp) de forma individual a cada capa hacia su respectiva meta
            Vector3 escalaDestino = new Vector3(metaDeEstaCapa, metaDeEstaCapa, metaDeEstaCapa);
            capa.contenedorNivel.localScale = Vector3.Lerp(capa.contenedorNivel.localScale, escalaDestino, Time.deltaTime * suavizado);
        }
    }

    void EvaluarCambioDeCapa()
    {
        CapaFractal capaActual = niveles[indiceCapaActual];

        // Transición hacia adentro profundo
        if (escalaObjetivoCapaActual > capaActual.escalaMaxima && indiceCapaActual < niveles.Length - 1)
        {
            indiceCapaActual++;
            escalaObjetivoCapaActual = niveles[indiceCapaActual].escalaMinima;
        }
        // Transición hacia afuera
        else if (escalaObjetivoCapaActual < capaActual.escalaMinima && indiceCapaActual > 0)
        {
            indiceCapaActual--;
            escalaObjetivoCapaActual = niveles[indiceCapaActual].escalaMaxima;
        }

        // Seguros para no salirnos de los límites de inicio y fin del juego
        if (indiceCapaActual == 0 && escalaObjetivoCapaActual < niveles[0].escalaMinima)
        {
            escalaObjetivoCapaActual = niveles[0].escalaMinima;
        }
        else if (indiceCapaActual == niveles.Length - 1 && escalaObjetivoCapaActual > niveles[niveles.Length - 1].escalaMaxima)
        {
            escalaObjetivoCapaActual = niveles[niveles.Length - 1].escalaMaxima;
        }
    }
}