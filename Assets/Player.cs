using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SaludoEnemigoCerca();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarEnemigosCerca();
        }
    }

    void AtacarEnemigosCerca()
    {
        Enemy enemy = EnemigosCerca();
        if (enemy != null)
        {
            IDaño interfaceDaño = enemy as IDaño;
            if (interfaceDaño != null)
            {
                interfaceDaño.TakeDamage(2);
            }
        }
        
    }

  
        void SaludoEnemigoCerca()
    {
        Enemy nearestEnemy = EnemigosCerca();
        if (nearestEnemy != null)
        {
            nearestEnemy.Accion();
        }
    }
    Enemy EnemigosCerca()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float minDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
