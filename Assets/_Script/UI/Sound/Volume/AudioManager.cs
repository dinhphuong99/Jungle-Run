using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class MixerParameter
    {
        public string mixerName;
        public string parameterName;
    }

    public AudioMixer[] audioMixers;
    public MixerParameter[] mixerParameters;

    private Dictionary<string, string> mixerParameterDict;

    private void Start()
    {
        // Khởi tạo dictionary ánh xạ mixer với parameter
        mixerParameterDict = new Dictionary<string, string>();
        foreach (var mixerParam in mixerParameters)
        {
            mixerParameterDict[mixerParam.mixerName] = mixerParam.parameterName;
        }
    }

    // Hàm để thay đổi âm lượng của một AudioMixer cụ thể
    public void SetVolumeByName(string mixerName, float volume)
    {
        if (mixerParameterDict.TryGetValue(mixerName, out string parameterName))
        {
            foreach (var mixer in audioMixers)
            {
                if (mixer.name == mixerName)
                {
                    mixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning($"No parameter found for mixer {mixerName}");
        }
    }
}
