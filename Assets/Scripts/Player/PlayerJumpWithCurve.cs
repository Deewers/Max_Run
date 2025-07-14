using Unity.VisualScripting;
using UnityEngine;

public class JumpWithCurve : MonoBehaviour
{
    [Header("Параметры прыжка")]
    [Tooltip("Общая длительность прыжка (сек)")]
    public float jumpDuration = 0.6f;
    [Tooltip("Максимальная высота прыжка (м)")]
    public float jumpHeight = 2f;
    [Tooltip("Кривая прыжка: по X — время [0…1], по Y — относительная высота [0…1]")]
    public AnimationCurve jumpCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private bool isJumping = false;
    private float elapsedTime = 0f;
    private float initialY = 0f;


    public void move_y(GameObject gameObject)
    {
        if (isJumping)
            return;

        isJumping = true;
        elapsedTime = 0f;
        initialY = transform.position.y;
    }

    private void Update()
    {
        if (!isJumping)
            return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / jumpDuration);

        float yOffset = jumpCurve.Evaluate(t) * jumpHeight;

        Vector3 pos = transform.position;
        pos.y = initialY + yOffset;
        transform.position = pos;

        if (t >= 1f)
            isJumping = false;
    }
}
