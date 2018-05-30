using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

    public class AchievementConfig
    {
        public static Dictionary<string, int[]> configs = new Dictionary<string, int[]>()
        {
            {"Achievement_Mendengar_HewanDarat_Kuis1", new int[] {5,10,15}},
            {"Achievement_Mendengar_HewanDarat_Kuis2", new int[] {5,10,15}},
            {"Achievement_Mendengar_HewanAir_Kuis1", new int[] {5,10,15}},
            {"Achievement_Mendengar_HewanAir_Kuis2", new int[] {5,10,15}},
            {"Achievement_Mendengar_HemanAmfibi_Kuis1", new int[] {5,10,15}},
            {"Achievement_Mendengar_HemanAmfibi_Kuis2", new int[] {5,10,15}},
            {"Achievement_Guratan_HewanDarat_Kuis1", new int[] {3,6,9}},
            {"Achievement_Guratan_HewanDarat_Kuis2", new int[] {3,6,9}},
            {"Achievement_Guratan_HewanAir_Kuis1", new int[] {3,6,9}},
            {"Achievement_Guratan_HewanAir_Kuis2", new int[] {3,6,9}},
            {"Achievement_Guratan_HemanAmfibi_Kuis1", new int[] {3,6,9}},
            {"Achievement_Guratan_HemanAmfibi_Kuis2", new int[] {3,6,9}},
            {"Achievement_Kosakata_HewanDarat_Kuis1", new int[] {5,10,15}},
            {"Achievement_Kosakata_HewanDarat_Kuis2", new int[] {5,10,15}},
            {"Achievement_Kosakata_HewanAir_Kuis1", new int[] {5,10,15}},
            {"Achievement_Kosakata_HewanAir_Kuis2", new int[] {5,10,15}},
            {"Achievement_Kosakata_HemanAmfibi_Kuis1", new int[] {5,10,15}},
            {"Achievement_Kosakata_HemanAmfibi_Kuis2", new int[] {5,10,15}},
        };
    }

    public enum JenisSoal
    {
        Mendengar ,
        Guratan,
        Kosakata
    }

    public enum JenisHewan
    {
        HewanDarat,
        HewanAir,
        HemanAmfibi
    }

    public enum KuisKe
    {
        Kuis1,
        Kuis2
    }
    public class AchievementManager
    {
        public const string separator = "_";
        public int count;
        public JenisSoal jenisSoal;
        public JenisHewan jenisHewan;
        public KuisKe kuisKe;
        public AchievementManager(JenisSoal js, JenisHewan jh, KuisKe kk)
        {
            jenisSoal = js;
            jenisHewan = jh;
            kuisKe = kk;
            count = PlayerPrefs.GetInt(CreateKey());
        }

        public string CreateKey()
        {
            return "Achievement_" + jenisSoal + separator + jenisHewan + separator + kuisKe;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(CreateKey(),count);
        }

        public string Sringify()
        {
            return jenisSoal + " " + jenisHewan + " " + kuisKe + ": " + count + "x";
        }

        public static string ToString()
        {
            string result = "";
            foreach (JenisSoal jenisSoal in Enum.GetValues(typeof(JenisSoal)))
            {
                foreach (JenisHewan jenisHewan in Enum.GetValues(typeof(JenisHewan)))
                { 
                    foreach (KuisKe kuisKe in Enum.GetValues(typeof(KuisKe)))
                    {
                        var am = new AchievementManager(jenisSoal,jenisHewan,kuisKe);
                        result += am.Sringify() + "\n";
                        var shouldComplete = AchievementConfig.configs[am.CreateKey()]; // []int{ 1,2,3};
                        // check apakah sudah 1 bintang
                        if (am.count >= shouldComplete[0])
                        {
                            Debug.Log(am.CreateKey() +" "+am.count + " Bintang ke 1" );
                            // sudah 1 bintang
                        }
                        if (am.count >= shouldComplete[1])
                        {
                        Debug.Log(am.CreateKey() + " " + am.count + " Bintang ke 2");
                        // sudah bisa 2 bintang
                    }
                        if (am.count >= shouldComplete[2])
                        {
                        // sudah bisa 3 bintang
                        Debug.Log(am.CreateKey() + " " + am.count + " Bintang ke 3");
                    }
                    }
                }
            }
            return result;
        }

    public static int[] ToGetAchivement()
    {
        int[] result = new int[3] {0,0,0}; // Dengar, Guratan, KosaKata
        int dengar = 0;
        int guratan = 0;
        int kosakata = 0;
        foreach (JenisSoal jenisSoal in Enum.GetValues(typeof(JenisSoal)))
        {
            foreach (JenisHewan jenisHewan in Enum.GetValues(typeof(JenisHewan)))
            {
                foreach (KuisKe kuisKe in Enum.GetValues(typeof(KuisKe)))
                {
                    var am = new AchievementManager(jenisSoal, jenisHewan, kuisKe);
                    
                    var shouldComplete = AchievementConfig.configs[am.CreateKey()]; // []int{ 1,2,3};
                                                                                    // check apakah sudah 1 bintang
                    if (jenisSoal == JenisSoal.Mendengar)
                    {
                        dengar += am.count;
                    }
                    else if (jenisSoal == JenisSoal.Guratan)
                    {
                        guratan += am.count;
                    }
                    else if (jenisSoal == JenisSoal.Kosakata)
                    {
                        kosakata += am.count;
                    }
                }
            }
        }
        //maaf terlalu hardcoded :)
        //dengar
        if (dengar >= 15)
        {
            // sudah bisa 3 bintang
            result[0] = 3;

        }
        else if (dengar >= 10)
        {

            // sudah 2 bintang
            result[0] = 2;
        }
        else if (dengar >= 5)
        {

            // sudah bisa 1 bintang
            result[0] = 1;
        }

        //Guratan
        if (guratan >=9)
        {
            // sudah bisa 3 bintang
            result[1] = 3;

        }
        else if (guratan >= 6)
        {

            // sudah 2 bintang
            result[1] = 2;
        }
        else if (guratan >= 3)
        {

            // sudah bisa 1 bintang
            result[1] = 1;
        }

        //Kosakata
        if (kosakata >= 15)
        {
            // sudah bisa 3 bintang
            result[3] = 3;

        }
        else if (kosakata >= 10)
        {

            // sudah 2 bintang
            result[3] = 2;
        }
        else if (kosakata >= 5)
        {

            // sudah bisa 1 bintang
            result[3] = 1;
        }

        return result;
    }

    public int totalStar()
        {
            var shouldComplete = AchievementConfig.configs[CreateKey()];
            for (int z = shouldComplete.Length - 1; z >= 0; --z)
            {
                if (shouldComplete[z] >= count)
                {
                    return z + 1;
                }
            }
            return 0;
        }


        public static string CreateConfig()
        {
            string config = "{";
            foreach (JenisSoal jenisSoal in Enum.GetValues(typeof(JenisSoal)))
            {
                foreach (JenisHewan jenisHewan in Enum.GetValues(typeof(JenisHewan)))
                {
                    foreach (KuisKe kuisKe in Enum.GetValues(typeof(KuisKe)))
                    {
                        var am = new AchievementManager(jenisSoal, jenisHewan, kuisKe);
                        config += "{\"" + am.CreateKey() + "\", new int[]{ " + am.count + "}},\n";
                    }
                }
            }
            return config + "}";

        }
    } 
