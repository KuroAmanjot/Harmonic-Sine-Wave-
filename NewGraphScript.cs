using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGraphScript : MonoBehaviour
{

    public LineRenderer LineRenderer;
    public int points;
   // private short[] bufferdata = new short[100];
  //  public float xStart;
    //public float xEnd; 
    public float speed;
    public float scale;
    [Range(-3 , 3 )]public float Yrange; 
    public int octave;

    [Range(0,1)]
    public float persistance;
    public float lacunarity; 
    public Vector2 phaseDifference; 
    public bool AutoUpdate;
    


    
    private void Awake()
    {
     //   float tau = 2 * Mathf.PI; 
        LineRenderer = GetComponent<LineRenderer>();
       
    }

    private void Start()
    {
        //CreateSinWave(); 
    }

    private void Update()
    {
        //speed *= Time.deltaTime;
        CreateSinWave();  

        

    }

    public void CreateSinWave()
    {
       float tau = 2 * Mathf.PI;
        float xStart = -tau*Yrange; 
        float xEnd = tau*Yrange;
        LineRenderer.positionCount = points;  

            //for (int j = 0; j < bufferdata.Length; j++)
            //{

            //     bufferdata[j] = (short)(amplitude*Mathf.Sin((tau * j * frequency)/points)); 
            

            //}

       for (int i = 0; i < points; i++)
        {
                 float p = (float)i/ (points);
                 float x = Mathf.Lerp(xStart + phaseDifference.x , xEnd + phaseDifference.x, p  );

            // LineRenderer.SetPosition(j , new Vector3(x , j , 0)); 
            float y = sumHarmonic(x); 

                 LineRenderer.SetPosition(i, new Vector3(x, y, 0));
           // amplitude *= persistance;
          // frequency *= lacunarity;

       }

        if (octave <1 )
        {
            octave = 1; 
        }
        if (lacunarity < 0 )
        {
            lacunarity = 0; 
        }

        if (points < 50  )
        {
            points = 50; 
        }
            




    }

    public float sumHarmonic(float positions)
    {

        

        float sumMotion = 0 ;
         float amplitude = 1;
         float frequency =1 ;

        for (int i = 0; i < octave; i++)
        {

            sumMotion += amplitude * Mathf.Sin((positions * scale * frequency + (Time.timeSinceLevelLoad*speed)) + phaseDifference.y);
            amplitude *= persistance;
            frequency *= lacunarity;
        }

        return sumMotion; 

    }



    

}
