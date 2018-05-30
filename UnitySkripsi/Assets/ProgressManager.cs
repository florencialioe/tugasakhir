using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class ProgressManager
    {
        public Dictionary<string, int> configs;

        public ProgressManager()
        {
            configs = new Dictionary<string, int>()
            {
                {"Progress_Mendengar_HewanDarat_Kuis1", 0},
                {"Progress_Mendengar_HewanDarat_Kuis2", 0},
                {"Progress_Mendengar_HewanAir_Kuis1", 0},
                {"Progress_Mendengar_HewanAir_Kuis2", 0},
                {"Progress_Mendengar_HemanAmfibi_Kuis1", 0},
                {"Progress_Mendengar_HemanAmfibi_Kuis2", 0},
                {"Progress_Guratan_HewanDarat_Kuis1", 0},
                {"Progress_Guratan_HewanDarat_Kuis2", 0},
                {"Progress_Guratan_HewanAir_Kuis1", 0},
                {"Progress_Guratan_HewanAir_Kuis2", 0},
                {"Progress_Guratan_HemanAmfibi_Kuis1", 0},
                {"Progress_Guratan_HemanAmfibi_Kuis2", 0},
                {"Progress_Kosakata_HewanDarat_Kuis1", 0},
                {"Progress_Kosakata_HewanDarat_Kuis2", 0},
                {"Progress_Kosakata_HewanAir_Kuis1", 0},
                {"Progress_Kosakata_HewanAir_Kuis2", 0},
                {"Progress_Kosakata_HemanAmfibi_Kuis1", 0},
                {"Progress_Kosakata_HemanAmfibi_Kuis2", 0},
            };

             Load();
        }
        public string separator = "_";
        public string CreateKey(JenisSoal js, JenisHewan jh, KuisKe kk)
        {
            return "Progress_" + js + separator + jh + separator + kk;
        }

        public void Load()
        {
            foreach (string s in configs.Keys.ToList())
            {
                configs[s] = PlayerPrefs.GetInt(s);
            }
        }
        public void Save()
        {
            foreach (var kv in configs)
            {
                PlayerPrefs.SetInt(kv.Key, configs[kv.Key]);
            }
        }
        public void Complete(JenisSoal js, JenisHewan jh, KuisKe kk)
        {

            configs[CreateKey(js, jh, kk)] += 1;
        }

        public int CurrentProgress() // 0 s/d 18
        {
            var total = 0;
            foreach (var kv in configs)
            {
                if (kv.Value > 0)
                {
                    ++total;
                }
            }
            return total;
        }

        public int TotalProgress()
        {
            return configs.Keys.Count;
        }
    }
