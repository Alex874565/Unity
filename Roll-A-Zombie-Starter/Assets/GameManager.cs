using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePosition = 0;

    public Text scoreText;

    private int score;

    public GameObject selectedZombie;

    public List<GameObject> zombies;

    public Vector3 selectedSize;

    public Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        SelectZombie(selectedZombie);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")){
            GetZombieLeft();
        }

        if (Input.GetKeyDown("right")){
            GetZombieRight();
        }

       if (Input.GetKeyDown("up")){
            PushUp();
       } 
    }

    void GetZombieLeft(){
        GameObject oldZombie = zombies[selectedZombiePosition];
        UnselectZombie(oldZombie);
        if (selectedZombiePosition == 0){
            selectedZombiePosition = 3;
        }else{
            selectedZombiePosition -= 1;
        }
        GameObject newZombie = zombies[selectedZombiePosition];
        SelectZombie(newZombie);
    }

    void GetZombieRight(){
        GameObject oldZombie = zombies[selectedZombiePosition];
        UnselectZombie(oldZombie);
        if (selectedZombiePosition == 3){
            selectedZombiePosition = 0;
        }else{
            selectedZombiePosition += 1;
        }
        GameObject newZombie = zombies[selectedZombiePosition];
        SelectZombie(newZombie);
    }

    void UnselectZombie(GameObject oldZombie){
        oldZombie.transform.localScale = defaultSize;
    }

    void SelectZombie(GameObject newZombie) {
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;
    }

    void PushUp(){
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
        rb.AddForce (0, 0, 10, ForceMode.Impulse);
    }

    public void AddPoint(){
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
