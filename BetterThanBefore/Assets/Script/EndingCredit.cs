using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EndingCredit : MonoBehaviour
{
    public float speed; //�̵� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� �������� speed��ŭ ������ �ݴϴ�.
        Vector2 vec = new Vector2(0, 1);

        transform.Translate(vec * speed * Time.deltaTime);

        if (transform.position.y > 12.5f)
        {
            string path = Path.Combine(Application.dataPath, "database.json");

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            SceneManager.LoadScene("StartScene");
        }
    }
}
