using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public
    int x;
    public
    int y;

    public void setPos(Vector2 vector)
    {
        x = (int)vector.x;
        y = (int)vector.y;
    }

    public void setPos(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    public void setX(int x)
    {
        this.x = x;
    }

    public void setY(int y)
    {
        this.y = y;
    }

    public int getX() { return x; }
    public int getY() { return y; }
    public Vector2 getPos() { return new Vector2(x, y); }

}
