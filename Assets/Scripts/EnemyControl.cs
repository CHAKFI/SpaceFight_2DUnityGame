using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{    
    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // obtenir la position actuelle de l'enemy
        Vector2 position = transform.position;
        
        // calculer la nouvelle position de l'enemy
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        
        // Mettre à jour la position de l'enemy
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); // C'est la limite de l'écran en bas à gauche

        // Detruire Enemy Ship si il dépasse la limite d'ecran en bas
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
        
    }
}
