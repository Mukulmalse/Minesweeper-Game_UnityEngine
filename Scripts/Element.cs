using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Element : MonoBehaviour {

    // Is this a mine?
    public bool mine;
    // Different Textures
    
    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    private float z;

    // Use this for initialization
    void Start () {
        ScoreScript.scoreValue = 0;

        if(DifficultyScript.e)
        {
            z = 0.05f;
        }
        else if(DifficultyScript.m)
        {
            z = 0.15f;

        }
        else if(DifficultyScript.h)
        {
            z = 0.25f;
        }


        // Randomly decide if it's a mine or not
        mine = Random.value < z;
        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

     // Load another texture
    public void loadTexture(int adjacentCount) {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }


    public bool isCovered() {
    return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton() {
        // It's a mine
        if (mine) {
            // TODO: uncover all mines
            Playfield.uncoverMines();

            SceneManager.LoadScene("GameOver");
            // GameOverScreen.Setup(scoreValue);
            print("you lose");
        }
        // It's not a mine
        else {
            TimeScript.reset = true;
            // show adjacent mine number
            // ScoreScript.scoreValue += 1;
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        loadTexture(Playfield.adjacentMines(x, y));
        
        // uncover area without mines
        Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);
            if(Playfield.isFinished())
             print("you win");
    
        }
    }
}
