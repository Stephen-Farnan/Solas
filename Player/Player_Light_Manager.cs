using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Player_Light_Manager : MonoBehaviour
{
    public Light player_Light;
    public ParticleSystem local_Fire_Particles;
    public PostProcessingProfile local_PostProcessingProfile;
    public float light_Amount = 12.5f;
    public float light_Reduction_Per_Tick = .1f;
    public float light_Decay_Smoothing = .02f;

    public float Max_Light_Intensity;
    public float Max_Fog_End_Distance;
    public float Max_Vignette_Intensity;
    public float Max_Fire_Particle_Emission;

    public float light_Intensity_Reduction_Rate;
    public float Fog_Increase_Rate;
    public float Vignette_Increase_Rate;
    public float Fire_Particle_Decrease_Rate;

    float target_Light_Intensity;
    float target_Fog_End_Distance;
    float target_Vignette_Intensity;
    float target_Fire_Particle_Emission;

    float smooth_Ref_Light = 0.00f;
    float smooth_Ref_Fog = 0.00f;
    float smooth_Ref_Vignette = 0.00f;
    float smooth_Ref_Fire_Particles = 0.00f;

    float damp_Smoothing_Time = 3f;





    public enum Light_Status
    {
        FULLY_BRIGHT,
        BRIGHT,
        DIMMED,
        LOW,
        MINIMUM
    }

    public Light_Status local_Light_Status;


    void Start()
    {
        Max_Light_Intensity = player_Light.intensity;
        Max_Fog_End_Distance = RenderSettings.fogEndDistance;
        local_PostProcessingProfile.vignette.Set_Intensity(.345f);
        Max_Vignette_Intensity = local_PostProcessingProfile.vignette.settings.intensity;
        Max_Fire_Particle_Emission = local_Fire_Particles.emission.rateOverTime.constant;

    }



    public void Restore_Light()
    {
        local_Light_Status = Light_Status.FULLY_BRIGHT;
        light_Amount = 12.5f;
        target_Light_Intensity = Max_Light_Intensity;
        target_Vignette_Intensity = Max_Vignette_Intensity;
        target_Fog_End_Distance = Max_Fog_End_Distance;
        target_Fire_Particle_Emission = Max_Fire_Particle_Emission;
    }


    IEnumerator Lower_Light_Value()
    {
        while (true)
        {



            if (light_Amount >= 10f)
            {
                local_Light_Status = Light_Status.FULLY_BRIGHT;
                damp_Smoothing_Time = .04f;
            }

            else if (light_Amount >= 7.5f)
            {
                local_Light_Status = Light_Status.BRIGHT;
                damp_Smoothing_Time = 3f;
            }

            else if (light_Amount >= 5f)
            {
                local_Light_Status = Light_Status.DIMMED;
                damp_Smoothing_Time = 3f;
            }

            else if (light_Amount >= 2.5f)
            {
                local_Light_Status = Light_Status.LOW;
                damp_Smoothing_Time = 3f;
            }

            else
            {
                local_Light_Status = Light_Status.MINIMUM;
                damp_Smoothing_Time = 3f;
            }

            switch (local_Light_Status)
            {
                case Light_Status.FULLY_BRIGHT:
                    target_Light_Intensity = Max_Light_Intensity;
                    target_Fog_End_Distance = Max_Fog_End_Distance;
                    target_Vignette_Intensity = Max_Vignette_Intensity;
                    target_Fire_Particle_Emission = Max_Fire_Particle_Emission;
                    break;

                case Light_Status.BRIGHT:
                    target_Light_Intensity = Max_Light_Intensity - light_Intensity_Reduction_Rate;
                    target_Fog_End_Distance = Max_Fog_End_Distance - Fog_Increase_Rate;
                    target_Vignette_Intensity = Max_Vignette_Intensity + Vignette_Increase_Rate;
                    target_Fire_Particle_Emission = Max_Fire_Particle_Emission - Fire_Particle_Decrease_Rate;
                    break;

                case Light_Status.DIMMED:
                    target_Light_Intensity = Max_Light_Intensity - (light_Intensity_Reduction_Rate * 2);
                    target_Fog_End_Distance = Max_Fog_End_Distance - (Fog_Increase_Rate * 2);
                    target_Vignette_Intensity = Max_Vignette_Intensity + (Vignette_Increase_Rate * 2);
                    target_Fire_Particle_Emission = Max_Fire_Particle_Emission - (Fire_Particle_Decrease_Rate * 2);
                    break;

                case Light_Status.LOW:
                    target_Light_Intensity = Max_Light_Intensity - (light_Intensity_Reduction_Rate * 3);
                    target_Fog_End_Distance = Max_Fog_End_Distance - (Fog_Increase_Rate * 3);
                    target_Vignette_Intensity = Max_Vignette_Intensity + (Vignette_Increase_Rate * 3);
                    target_Fire_Particle_Emission = Max_Fire_Particle_Emission - (Fire_Particle_Decrease_Rate * 3);
                    break;

                case Light_Status.MINIMUM:
                    target_Light_Intensity = Max_Light_Intensity - (light_Intensity_Reduction_Rate * 4);
                    target_Fog_End_Distance = Max_Fog_End_Distance - (Fog_Increase_Rate * 4);
                    target_Vignette_Intensity = Max_Vignette_Intensity + (Vignette_Increase_Rate * 4);
                    target_Fire_Particle_Emission = Max_Fire_Particle_Emission - (Fire_Particle_Decrease_Rate * 4);
                    break;
            }

            //here lerp the light intensity, fog, and vignette(maybe) towards their new values

            RenderSettings.fogEndDistance = Mathf.SmoothDamp(RenderSettings.fogEndDistance, target_Fog_End_Distance, ref smooth_Ref_Fog, damp_Smoothing_Time);
            player_Light.intensity = Mathf.SmoothDamp(player_Light.intensity, target_Light_Intensity, ref smooth_Ref_Light, damp_Smoothing_Time);
            local_PostProcessingProfile.vignette.Set_Intensity(Mathf.SmoothDamp(local_PostProcessingProfile.vignette.settings.intensity, target_Vignette_Intensity, ref smooth_Ref_Vignette, damp_Smoothing_Time));
            var em = local_Fire_Particles.emission;
            var emission_Rate_Temp = em.rateOverTime;
            emission_Rate_Temp.constant = Mathf.SmoothDamp(local_Fire_Particles.emission.rateOverTime.constant, target_Fire_Particle_Emission, ref smooth_Ref_Fire_Particles, damp_Smoothing_Time);
            em.rateOverTime = emission_Rate_Temp;

            light_Amount -= light_Reduction_Per_Tick;
            if (light_Amount < 0)
            {
                light_Amount = 0;
            }
            yield return new WaitForSeconds(light_Decay_Smoothing);
        }
    }
}
