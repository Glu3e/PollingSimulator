using UnityEngine;
using System.Collections;

public class changeVote : MonoBehaviour
{
    GameObject[] voters;
    Color[] votes;
    int left, right, topLeft, top, topRight, bottomLeft, bottom, bottomRight;
    int loc;
    int red = 0, blue = 0, yellow = 0, green = 0, gray = 0;
    // Use this for initialization
    void Start()
    {
        votes = new Color[8];
        voters = GameObject.FindGameObjectsWithTag("Voter");
    }

    // Update is called once per frame
    void Update()
    {
        poll();
    }


    void poll()
    {
        left = -1;
        right = 1;
        topLeft = -101;
        top = -100;
        topRight = -99;
        bottomLeft = 99;
        bottom = 100;
        bottomRight = 101;
       
        foreach (GameObject v in voters)
        {
            for (int i = 0; i < voters.Length- 1; i++)
            {
                if (v == voters[i])
                {
                    loc = i;
                }
            }
        }

        left = loc + left;
        right = loc + right;
        topLeft = loc + topLeft;
        topRight = loc + topRight;
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

        else if (topLeft < 0)
        {
            topLeft = voters.Length -1;
        }
        else if (topRight < 0)
        {
            topRight = voters.Length - 1;
        }
        else if (top < 0)
        {
            top = voters.Length - 1;
        }


        else if (bottomLeft > voters.Length)
        {
            bottomLeft = 0;
        }
        else if (bottom > voters.Length)
        {
            bottom = 0;
        }
        else if (bottomRight > voters.Length)
        {
            bottomRight = 0;
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
            Color x = c;
            switch (x.ToString().ToLower())
            {
                case "red":
                    red++;
                    break;
                case "blue":
                    blue++;
                    break;
                case "yellow":
                    yellow++;
                    break;
                case "green":
                    green++;
                    break;
                case "gray":
                    gray++;
                    break;
            }

            if (red > blue && red > yellow && red > green && red > gray)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (blue > red && blue > yellow && blue > green && blue > gray)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (yellow > blue && yellow > red && yellow > green && yellow > gray)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (green > blue && green > yellow && green > red && green > gray)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (gray > blue && gray > yellow && gray > green && gray > red)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }
    }
}
