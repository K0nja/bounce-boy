using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public GameObject myCamera;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private GameObject myPlat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1)
            {
                Destroy(other.gameObject);
                Instantiate(springPrefab, new Vector2(Random.Range(-2.5f, 2.5f), myCamera.transform.position.y + (5f + Random.Range(0f, .1f))), Quaternion.identity);
            }
            else
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), myCamera.transform.position.y + (5f + Random.Range(0f, .25f)));
            }
        }
        else if (other.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 7) == 1)
            {
                other.gameObject.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), myCamera.transform.position.y + (5f + Random.Range(0f, .1f)));
            }
            else
            {
                Destroy(other.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-2.5f, 2.5f), myCamera.transform.position.y + (5f + Random.Range(0f, .25f))), Quaternion.identity);
            }
        }
        else if (other.gameObject.tag.StartsWith("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
