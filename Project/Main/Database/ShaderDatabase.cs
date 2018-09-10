using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenmueHDTools.Main.Database
{
    class ShaderDatabase
    {
        public static string Suffix = "{0}?CAPS={1};";
        public static char Seperator = ';';

        /*
        /engine/assets/shaders/uber_vs.hlsl?CAPS=_SHAD;_HASPRE;_BILLBOARD;
        */

        public static void GenerateShaderFilenames()
        {
            foreach (string filename in ShaderFilenames)
            {
                uint secondHash = MurmurHash2Shenmue.GetFilenameHashPlain(filename);
                string fullFilename = MurmurHash2Shenmue.GetFullFilename(filename, secondHash);
                uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fullFilename), 0);
                FilenameDatabase.Add(hash, secondHash, fullFilename);
            }

            /*
            List<List<string>> combos = GetAllCombos(ShaderSuffixParameter);
            foreach(List<string> parameters in combos)
            {
                foreach (string fname in ShaderFilenames)
                {
                    string filename = String.Format(Suffix, fname, parameters.Aggregate((i, j) => i + ";" + j));
                    
                    uint secondHash = MurmurHash2Shenmue.GetFilenameHashPlain(filename, false);
                    string fullFilename = MurmurHash2Shenmue.GetFullFilename(filename, secondHash);
                    uint hash = BitConverter.ToUInt32(MurmurHash2Shenmue.GetFilenameHash(fullFilename), 0);
                    FilenameDatabase.Add(hash, secondHash, fullFilename);

                    Console.WriteLine("[{0:X8}|{1:X8}] {2}", hash, secondHash, filename);
                }
            }
            */
        }

        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            int comboCount = (int)Math.Pow(2, list.Count) - 1;
            List<List<T>> result = new List<List<T>>();
            for (int i = 1; i < comboCount + 1; i++)
            {
                result.Add(new List<T>());
                for (int j = 0; j < list.Count; j++)
                {
                    if ((i >> j) % 2 != 0)
                        result.Last().Add(list[j]);
                }
            }
            return result;
        }

        public static List<string> ShaderSuffixParameter = new List<string>()
        {
            "_SHAD",
            "_HASPRE",
            "_BILLBOARD",
            "_DBG", //debug shaders are missing
            "_PCF",
            "_REFLECT"
        };

        public static List<string> ShaderFilenames = new List<string>()
        {
            "/shaders/fvf/fvf_pd_t_vs.hlsl",
            "/shaders/fvf/fvf_pd_t_ps.hlsl",
            "/engine/assets/shaders/DebugDraw_vs.hlsl",
            "/shaders/original_const_vs.hlsl",
            "/shaders/original_lamb_vs.hlsl",
            "/shaders/original_vcol1_vs.hlsl",
            "/shaders/original_vcol0_vs.hlsl",
            "/shaders/fullscreen_quad_vs.hlsl",
            "/shaders/lighting_vs.hlsl",
            "/shaders/fire_vs.hlsl",
            "/shaders/sv_vs.hlsl",
            "/shaders/simple_ps.hlsl",
            "/engine/assets/shaders/DebugDraw_ps.hlsl",
            "/shaders/caf_screen_ps.hlsl",
            "/shaders/caf_ps.hlsl",
            "/shaders/gray_ps.hlsl",
            "/shaders/msf_ps.hlsl",
            "/shaders/blur_ps.hlsl",
            "/shaders/default_ps.hlsl",
            "/shaders/fvf/fvf_pnt_vs.hlsl",
            "/shaders/fvf/fvf_pd_vs.hlsl",
            "/shaders/fvf/fvf_ptd_vs.hlsl",
            "/shaders/fvf/fvf_pntds_vs.hlsl",
            "/shaders/fvf/fvf_ptds_vs.hlsl",
            "/shaders/fvf/fvf_ptd_t_vs.hlsl",
            "/shaders/white_vs.hlsl",
            "/shaders/lighting_vcol_vs.hlsl",
            "/shaders/shadow_proj_ps.hlsl",
            "/shaders/shadow_proj_vs.hlsl",
            "/shaders/fvf/fvf_pnt_ps.hlsl",
            "/shaders/fvf/fvf_pd_ps.hlsl",
            "/shaders/fvf/fvf_ptd_ps.hlsl",
            "/shaders/fvf/fvf_pntds_ps.hlsl",
            "/shaders/fvf/fvf_ptds_ps.hlsl",
            "/shaders/fvf/fvf_ptd_t_ps.hlsl",
            "/engine/assets/shaders/depth_clear_vs.hlsl",
            "/shaders/original_strip00_ps.hlsl",
            "/shaders/original_strip03_ps.hlsl",
            "/shaders/original_strip03_vs.hlsl",
            "/engine/assets/shaders/depth_ps.hlsl",
            "/engine/assets/shaders/depth_vs.hlsl",
            "/engine/assets/shaders/uber_ps.hlsl",
            "/engine/assets/shaders/uber_vs.hlsl",
            "/engine/assets/shaders/depth_prepass_ps.hlsl",
            "/engine/assets/shaders/depth_prepass_vs.hlsl",

            //shader filenames that needed to be builded because missing vertex/fragment shader extension
            "/engine/assets/shaders/depth_clear_ps.hlsl",
            "/shaders/emu/emu_pdt_vs.hlsl",
            "/shaders/emu/emu_pdt_ps.hlsl",
            "/shaders/emu/emu_pd_vs.hlsl",
            "/shaders/emu/emu_pd_ps.hlsl",
            "/engine/assets/shaders/texturedquad_vs.hlsl",
            "/engine/assets/shaders/texturedquad_ps.hlsl",
            "/shaders/abuffer_write_vs.hlsl",
            "/shaders/abuffer_write_ps.hlsl",
            "/shaders/abuffer_clear_vs.hlsl",
            "/shaders/abuffer_clear_ps.hlsl",
            "/shaders/abuffer_comp_vs.hlsl",
            "/shaders/abuffer_comp_ps.hlsl",
            "/shaders/contrast_vs.hlsl",
            "/shaders/contrast_ps.hlsl",
            "/engine/assets/shaders/texturedquad_gammacorrect_vs.hlsl",
            "/engine/assets/shaders/texturedquad_gammacorrect_ps.hlsl",
            "/engine/assets/shaders/prefilter_irrmap_vs.hlsl",
            "/engine/assets/shaders/prefilter_irrmap_ps.hlsl",
            "/engine/assets/shaders/prefilter_envmap_vs.hlsl",
            "/engine/assets/shaders/prefilter_envmap_ps.hlsl",
            "/engine/assets/shaders/envprobe_vs.hlsl",
            "/engine/assets/shaders/envprobe_ps.hlsl",
            "/engine/assets/shaders/BRDF_LUT_vs.hlsl",
            "/engine/assets/shaders/BRDF_LUT_ps.hlsl",
            "/engine/assets/shaders/simple_vs.hlsl",
            "/engine/assets/shaders/simple_ps.hlsl",
            "/engine/assets/shaders/nuklear_vs.hlsl",
            "/engine/assets/shaders/nuklear_ps.hlsl"
        };
    }
}
