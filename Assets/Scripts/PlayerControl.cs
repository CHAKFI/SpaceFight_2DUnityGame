using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Pour le mouvement Droite/Gauche
        float x = Input.GetAxisRaw("Horizontal");
        
        // Pour un mouvement Avant/Arrière
        float y = Input.GetAxisRaw("Vertical");

        // Direction du vecteur
        Vector2 direction = new Vector2(x, y).normalized;
        
        // Appel de la fonction Move (Voir au dessous l'implémentation de la fonction Move)
        Move (direction);

    }
    
    // La fonction Move permet de régler la position du joueur
    void Move(Vector2 direction)
    {
        //Limiter le mouvement du joueur par l'ecran
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); // C'est la limite de l'écran en bas à gauche
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // C'est la limite de l'écran en haut à droite

        max.x -= 0.225f; // Soustraire la moitié de la largeur du joueur pour axe X
        min.x += 0.225f; // Additionner la moitié de la longeur du joueur pour axe X

        max.y -= 0.285f; // Soustraire la moitié de la largeur du joueur pour axe Y
        min.y += 0.285f; // Additionner la moitié de la longeur du joueur pour axe Y

        Vector2 pos = transform.position; // Retourner la position du joueur
        pos += direction * speed * Time.deltaTime; // Calculer la nouvelle position
        
        // Vérifions si la position du joueur n'est pas hors-limites de l'ecran
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        
        // mettre à jour la nouvelle position du joueur
        transform.position = pos;

    }
}

/* Additional Notes:
Since our player spaceship sprites contain transparent space, 
we used photoshop to measure the width and height of the actual visible image of the spaceship.
 The width is 45 pixels and the height is 57 pixels. To calculate the spaceship half width and height we did the following:
Half width = 45 / 2 / PixelToUnits = 0.225
Half Height = 57 / 2 / PixelToUnits = 0.285
PixelToUnits = 100 (From tutorial Part 1) */