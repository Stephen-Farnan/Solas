using UnityEngine;

public class Tile_Space : MonoBehaviour
{

    public bool available = true;

    public bool is_Puzzle_Goal = false;

    public enum Column_Number
    {
        ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT
    }

    public Column_Number local_Colum_Number;

    public enum Row_Letter
    {
        A, B, C, D, E, F, G, H
    }

    public Row_Letter local_Row_Letter;
}
