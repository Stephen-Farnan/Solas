using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mountain_Area_Temperature_Manager : MonoBehaviour
{


    public Player_Light_Manager local_Player_Light_Manager;
    public ThirdPerson3D local_Third_Person_3D;
    public Player_Manager local_Player_Manager;
    public AudioSource death_Pulsing;
    public Animator player_Anim;

    public float max_Player_Walk_Speed;

    public float max_Player_Run_Speed;

    public float walk_Speed_Reduction = .2f;
    public float run_Speed_Reduction = .2f;

    public float ice_Image_Fade_In_Smoothing = .2f;
    public float ice_Image_Fade_In_Target_Amount = 100f;
    public float ice_Image_Fade_In_Amount_Per_Tick = 2f;

    public Image ice_Screen_Effect_1;
    public Image ice_Screen_Effect_2;
    public Image ice_Screen_Effect_3;
    public Image ice_Screen_Effect_4;
    public Image ice_Screen_Effect_5;
    public Image ice_Screen_Effect_6;
    public Image screen_Cover_Effect;

    bool ice_Effect_1_Working = false;
    bool ice_Effect_2_Working = false;
    bool ice_Effect_3_Working = false;

    bool is_In_Danger_Zone = false;

    public float pulsing_Speed = .03f;
    public float max_Cover_Effect_Opacity = 115f;
    public float time_In_Danger_Zone_Before_Player_Dies = 15f;
    float min_Cover_Opacity = 0f;
    float current_Cover_Opacity = 0f;

    private void Start()
    {
        max_Player_Walk_Speed = local_Third_Person_3D.runSpeed;
        max_Player_Run_Speed = local_Third_Person_3D.runSpeed;
        StartCoroutine("Change_Temperature_Over_Time");

    }

    public IEnumerator Change_Temperature_Over_Time()
    {
        while (true)
        {
            switch (local_Player_Light_Manager.local_Light_Status)
            {
                case Player_Light_Manager.Light_Status.BRIGHT:
                    local_Third_Person_3D.walkSpeed = max_Player_Walk_Speed - walk_Speed_Reduction;
                    local_Third_Person_3D.runSpeed = max_Player_Run_Speed - run_Speed_Reduction;
                    break;

                case Player_Light_Manager.Light_Status.DIMMED:
                    local_Third_Person_3D.walkSpeed = max_Player_Walk_Speed - (walk_Speed_Reduction * 2);
                    local_Third_Person_3D.runSpeed = max_Player_Run_Speed - (run_Speed_Reduction * 2);
                    if (!ice_Effect_1_Working)
                    {
                        StartCoroutine(Set_Ice_Effect_Image_Opacity(ice_Screen_Effect_1, ice_Screen_Effect_2));
                        ice_Effect_1_Working = true;
                    }

                    break;

                case Player_Light_Manager.Light_Status.LOW:
                    local_Third_Person_3D.walkSpeed = max_Player_Walk_Speed - (walk_Speed_Reduction * 3);
                    local_Third_Person_3D.runSpeed = max_Player_Run_Speed - (run_Speed_Reduction * 3);
                    if (!ice_Effect_2_Working)
                    {
                        StartCoroutine(Set_Ice_Effect_Image_Opacity(ice_Screen_Effect_3, ice_Screen_Effect_4));
                        ice_Effect_2_Working = true;
                    }

                    break;

                case Player_Light_Manager.Light_Status.MINIMUM:
                    local_Third_Person_3D.walkSpeed = max_Player_Walk_Speed - (walk_Speed_Reduction * 4);
                    local_Third_Person_3D.runSpeed = max_Player_Run_Speed - (run_Speed_Reduction * 4);
                    if (!ice_Effect_3_Working)
                    {
                        StartCoroutine(Set_Ice_Effect_Image_Opacity(ice_Screen_Effect_5, ice_Screen_Effect_6));
                        ice_Effect_3_Working = true;
                    }

                    if (!is_In_Danger_Zone)
                    {
                        is_In_Danger_Zone = true;
                        StartCoroutine("Vision_Pulsing");
                        StartCoroutine("Countdown_To_Player_Death");
                    }

                    break;

                case Player_Light_Manager.Light_Status.FULLY_BRIGHT:
                    local_Third_Person_3D.walkSpeed = max_Player_Walk_Speed;
                    local_Third_Person_3D.runSpeed = max_Player_Run_Speed;
                    break;
            }
            yield return new WaitForSeconds(.2f);
        }

    }

    IEnumerator Set_Ice_Effect_Image_Opacity(Image a, Image b)
    {
        while (a.color.a < ice_Image_Fade_In_Target_Amount / 255)
        {
            var temp_Color = a.color;
            temp_Color.a += ice_Image_Fade_In_Amount_Per_Tick / 255;
            a.color = temp_Color;

            var temp_Colorb = b.color;
            temp_Colorb.a = b.color.a + ice_Image_Fade_In_Amount_Per_Tick / 255;
            b.color = temp_Colorb;


            yield return new WaitForSeconds(ice_Image_Fade_In_Smoothing);
        }

    }

    public IEnumerator Vision_Pulsing()
    {
        float t = 0f;
        death_Pulsing.Play();
        while (is_In_Danger_Zone)
        {
            current_Cover_Opacity = (Mathf.Lerp(min_Cover_Opacity, max_Cover_Effect_Opacity, t));
            t += pulsing_Speed * Time.deltaTime;

            if (t > 1.0f)
            {
                float temp = max_Cover_Effect_Opacity;
                max_Cover_Effect_Opacity = min_Cover_Opacity;
                min_Cover_Opacity = temp;
                t = 0.0f;
            }


            // animate the position of the game object...
            //    transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

            // .. and increate the t interpolater


            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.


            // current_Cover_Opacity = Mathf.Lerp(0, max_Cover_Effect_Opacity, Time.deltaTime * pulsing_Speed);

            var temp_Img = screen_Cover_Effect.color;
            temp_Img.a = current_Cover_Opacity / 255f;
            screen_Cover_Effect.color = temp_Img;
            yield return new WaitForSeconds(.002f);
        }

    }

    public void Stop_Pulsing()
    {
        death_Pulsing.Stop();
        StopCoroutine("Vision_Pulsing");
        is_In_Danger_Zone = false;
        ice_Effect_1_Working = false;
        ice_Effect_2_Working = false;
        ice_Effect_3_Working = false;
    }

    public IEnumerator Countdown_To_Player_Death()
    {
        yield return new WaitForSeconds(time_In_Danger_Zone_Before_Player_Dies);
        //call the animator to make her cold
        player_Anim.SetTrigger("Dart Trap");
        local_Player_Manager.Kill_Player();

    }

    public void Restore_Temperature()
    {
        Color tempa = new Color(ice_Screen_Effect_1.color.r, ice_Screen_Effect_1.color.g, ice_Screen_Effect_1.color.b, 0f);
        ice_Screen_Effect_1.color = tempa;

        Color tempb = new Color(ice_Screen_Effect_2.color.r, ice_Screen_Effect_2.color.g, ice_Screen_Effect_2.color.b, 0f);
        ice_Screen_Effect_2.color = tempb;

        Color tempc = new Color(ice_Screen_Effect_3.color.r, ice_Screen_Effect_3.color.g, ice_Screen_Effect_3.color.b, 0f);
        ice_Screen_Effect_3.color = tempc;

        Color tempd = new Color(ice_Screen_Effect_4.color.r, ice_Screen_Effect_4.color.g, ice_Screen_Effect_4.color.b, 0f);
        ice_Screen_Effect_4.color = tempd;

        Color tempe = new Color(ice_Screen_Effect_5.color.r, ice_Screen_Effect_5.color.g, ice_Screen_Effect_5.color.b, 0f);
        ice_Screen_Effect_5.color = tempe;

        Color tempf = new Color(ice_Screen_Effect_6.color.r, ice_Screen_Effect_6.color.g, ice_Screen_Effect_6.color.b, 0f);
        ice_Screen_Effect_6.color = tempf;

    }
}
