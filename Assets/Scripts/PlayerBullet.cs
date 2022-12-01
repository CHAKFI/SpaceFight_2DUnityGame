using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        // obtenir la position actuelle de la bulle
        Vector2 position = transform.position;
        
        // calculer la nouvelle position de la bulle
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        
        // mettre à jour la position de la bulle
        transform.position = position;
        
        // les limites des bulles par ecran
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // C'est la limite de l'écran en haut à droite
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // C'est la limite de l'écran en bas à gauche
        
        // Lorsque les bulles dépassent la limite d'ecran en haut, l'objet va être detruit
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
        
        
        
    }
}
