using UnityEngine;
using System.Collections;

public class changeVote : MonoBehaviour
{
    public GameObject[] voters;
    public Color[] votes;
    public GameObject square;
    GridGenerator grid = new GridGenerator();
    public int left, right, topLeft, top, topRight, bottomLeft, bottom, bottomRight;
    public int loc;
    public int red = 0, blue = 0, yellow = 0, green = 0, gray = 0;
    int RNG;
    // Use this for initialization
    void Start()
    {
        square = this.gameObject;
        votes = new Color[8];
        voters = GameObject.FindGameObjectsWithTag("Voter");
    }

    // Update is called once per frame
    void Update()
    {
        RNG = Random.Range(1, 11);
        if (RNG.Equals(1))
        {
            poll();
        }
    }


    void poll()
    {
        left = -1;
        right = 1;

        //top
        topLeft = (int)grid.gridX + 1;
        top = (int)grid.gridX;
        topRight = (int)grid.gridX - 1;
        //bottom
        bottomLeft = (int)grid.gridX - 1;
        bottom = (int)grid.gridX;
        bottomRight = (int)grid.gridX + 1;

        bottomLeft -= 1;
        bottomRight += 1;

        foreach (GameObject v in voters)
        {
            for (int i = 0; i < voters.Length - 1; i++)
            {
                if (square.Equals(voters[i]))
                {
                    loc = i;
                }
            }

            left = loc + left;
            right = loc + right;

            topLeft = loc + topLeft;
            topRight = loc + topRight;
            top = loc + top;

            bottomLeft = loc + bottomLeft;
            bottom = loc + bottom;
            bottomRight = loc + bottomRight;

            if (left < 0)
            {
                left = voters.Length - 1;
            }
            else if (right > voters.Length)
            {
                right = 0;
            }

            else if (topLeft > voters.Length - 1)
            {
                topLeft = 0;
            }

            else if (topRight > voters.Length - 1)
            {
                topRight = 0;
            }

            else if (top > voters.Length - 1)
            {
                top = 0;
            }

            else if (bottomLeft < 0)
            {
                bottomLeft = voters.Length - 1;
            }
            else if (bottom < 0)
            {
                bottom = voters.Length - 1;
            }
            else if (bottomRight < 0)
            {
                bottomRight = voters.Length - 1;
            }

            votes[0] = voters[left].GetComponent<SpriteRenderer>().color;
            votes[1] = voters[right].GetComponent<SpriteRenderer>().color;

            votes[2] = voters[topLeft].GetComponent<SpriteRenderer>().color;
            votes[3] = voters[top].GetComponent<SpriteRenderer>().color;
            votes[4] = voters[topRight].GetComponent<SpriteRenderer>().color;

            votes[5] = voters[bottomLeft].GetComponent<SpriteRenderer>().color;
            votes[6] = voters[bottom].GetComponent<SpriteRenderer>().color;
            votes[7] = voters[bottomRight].GetComponent<SpriteRenderer>().color;

            //math that add colors
            foreach (Color c in votes)
            {
                switch (c.ToString())
                {
                    case "RGBA(1.000, 0.000, 0.000, 1.000)":
                        red++;
                        break;
                    case "RGBA(0.000, 0.000, 1.000, 1.000)":
                        blue++;
                        break;
                    case "RGBA(1.000, 0.920, 0.160, 1.000)":
                        yellow++;
                        break;
                    case "RGBA(0.000, 1.000, 0.000, 1.000)":
                        green++;
                        break;
                    default:
                        gray++;
                        break;
                }
            }

            if (red > blue && red > yellow && red > green)
            {
                square.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (blue > red && blue > yellow && blue > green)
            {
                square.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (yellow > blue && yellow > red && yellow > green)
            {
                square.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (green > blue && green > yellow && green > red)
            {
                square.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

        red = 0;
        green = 0;
        yellow = 0;
        blue = 0;
    }
}
