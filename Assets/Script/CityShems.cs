using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityShems : MonoBehaviour {

    [SerializeField]
    private int food;
    [SerializeField]
    private int people;
    [SerializeField]
    private int souls;
    [SerializeField]
    private int maxpopulation;
    private float time;
    [SerializeField]
    private int delta_food;
    [SerializeField]
    private int delta_people;
    [SerializeField]
    private int delta_souls;


    //Getter
    public int Get_food() {
        return food;
    }
    public int Get_people()
    {
        return people;
    }
    public int Get_souls()
    {
        return souls;
    }
    public int Get_maxpopulation()
    {
        return maxpopulation;
    }
    public float Get_time()
    {
        return time;
    }
    public int Get_delta_food()
    {
        return delta_food;
    }
    public int Get_delta_people()
    {
        return delta_people;
    }
    public int Get_delta_souls()
    {
        return delta_souls;
    }

    public void Set_food(int setfood)
    {
        food = setfood;
    }
    public void Set_people(int setpeople)
    {
        people = setpeople;
    }
    public void Set_souls(int setsouls)
    {
        souls = setsouls;
    }
    public void Set_maxpopulation(int setmaxpop)
    {
        maxpopulation = setmaxpop;
    }
    public void Set_delta_food(int setdelta_food)
    {
        delta_food = setdelta_food;
    }
    public void Set_delta_people(int setdelta_people)
    {
        delta_people=setdelta_people;
    }
    public void Set_delta_souls(int setdelta_souls)
    {
        delta_souls = setdelta_souls;
    }


    public void Lunar_Cycle_Update()
    {
    }

    public void update_deltas()
    {

    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}
}
