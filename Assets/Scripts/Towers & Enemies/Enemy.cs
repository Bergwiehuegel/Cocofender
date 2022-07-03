using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  
    private Transform targetWaypoint;
    private int waypointIndex = 0;
    private bool updateIndex = false;
    

    [Header("Attributes")]
    public float startHealth = 100f;
    private float health;
    public float startSpeed = 10f;
    private float speed;
    public float rotationSpeed = 180f;
    public float amplitude = 0.7f;
    public float offset = 2.5f;
    private float randomPeriod;
    public int worth = 50;
    public int spawnShipsOnDeath = 0; //maybe make it a global variable and change it in the wavespawner to raise difficulty?
    public bool hasArmor = false; //if yes only takes damage when hit by a cannon first
    private bool isDead = false;

    [SerializeField] private AudioSource enemy_dies;
    [SerializeField] private AudioSource player_damage;

    [Header("Unity Setup Fields")]
    public Canvas enemyCanvas;
    private Camera mainCamera;
    public Image healthBar;
    public GameObject ufoPrefab;

    
    

    void Start()
    {
        targetWaypoint = Waypoints.points[0];
        mainCamera = Camera.main;
        health = startHealth;
        speed = startSpeed;
        randomPeriod = Random.Range(4f, 6f);
    }

    void Update()
    {
        //handle pathfinding and movement
        Vector3 dir = targetWaypoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * randomPeriod) * amplitude + offset, transform.position.z);
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        Vector3 dist = targetWaypoint.position - transform.position;
        dist.y = 0;
        if (dist.magnitude <= 1f || updateIndex)
        {
            updateIndex = false;
            GetNextWaypoint();
        }

        //rotate healthbars to main camera
        Vector3 lookPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        enemyCanvas.transform.LookAt(lookPos);
    }
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        targetWaypoint = Waypoints.points[waypointIndex];
    }

    public void setNextWaypoint(int index) //gets called when the mothership spawns new ufos so they dont go back to the start
    {
        waypointIndex = index - 1;
        updateIndex = true;
    }

    void EndPath()
    {
        for (int i = 0; i < spawnShipsOnDeath; i++)
        {
            PlayerStats.Lives--;
            //WaveSpawner.EnemiesAlive--
        }

        PlayerStats.Lives--;
        player_damage.Play();
        //WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);

    }

    public void TakeDamage(float amount)
    {
        if (!hasArmor)
        {
            health -= amount;
            healthBar.fillAmount = health / startHealth;

            if (health <= 0 && !isDead)
            {
                Die();
                enemy_dies.Play();
            }
        }
    }

    public void removeArmor()
    {
        hasArmor = false;
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    private void Die()
    {
        isDead = true;
        
        
        for (int i = 0; i < spawnShipsOnDeath; i++)
        {
            GameObject ufoObject = (GameObject)Instantiate(ufoPrefab, transform.position, transform.rotation);
            Enemy ufo = ufoObject.GetComponent<Enemy>();
            ufo.setNextWaypoint(waypointIndex);
        }

        PlayerStats.Money += worth;

        //WaveSpawner.EnemiesAlive--;
        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);


        Destroy(gameObject);
    }
}