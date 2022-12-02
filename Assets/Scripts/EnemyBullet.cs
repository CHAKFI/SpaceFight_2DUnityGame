using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; // vitesse de la bulle
    Vector2 _direction; // direction des bulles
    bool isReady; // pour mémoriser la direction d'une bulle

    // fixer les valeurs par defaut
    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized; // normaliser la direction pour avoir un vecteur "unit"
        isReady = true; 
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            // obtenir la position actuel des bulles
            Vector2 position = transform.position; 
            
            // compter la nouvelle position des bulles
            position += _direction * speed * Time.deltaTime;
            
            // mettre à jour la position des bulles
            transform.position = position;

            
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); // C'est la limite de l'écran en bas à gauche
            Vector2 max = Camera.main.ViewportToScreenPoint(new Vector2(1,1)); // C'est la limite de l'écran en haut à droite
            
            // Il faut retirer et faire disparaître les bulles qui dépasse la limite de l'ecran

            if ((transform.position.x < min.x) || (transform.position.x > max.x) || 
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
            
        }
    }
}
