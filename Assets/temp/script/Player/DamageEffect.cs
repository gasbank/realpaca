using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public float redFactor;
    public float redFactorSpeed = 2.0f;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.dead)
        {
            redFactor = 1.0f;
        }
        else
        {
            redFactor -= Time.deltaTime * redFactorSpeed;
            if (redFactor < 0)
            {
                redFactor = 0;
            }
        }

        foreach (var sr in spriteRenderers)
        {
            sr.color = Color.red * redFactor + Color.white * (1.0f - redFactor);
        }
    }

    public void Play()
    {
        redFactor = 1.0f;
    }
    public void Stop()
    {
        redFactor = 0.0f;
    }
}
