using System;
using System.Collections.Generic;
using System.Text;

namespace Allinox
{
    class GlobalVariabelen
    {
        public static string strGebruiker = "";
        public static int strGebruikerId = 0;
        public static string strGebruikerAcronym = "";
        public static int intSelectArtikel = 0;
        public static string strSelectArtikel = "";

        public static double palletHeight;
        public static double mcPerLayer;
        public static double numberOfLayers;
        public static bool paletData;
        public static bool articleBox;
        public static double abPerMc;
        public static double itPerMc;

        public static double MinPalHoogte = 50;
        public static double MaxPalHoogte = 250;
        public static double MinAantMcPerLayer = 1;
        public static double MaxAantMcPerLayer = 20;
        public static double MinAantLayer = 1;
        public static double MaxAantLayer = 20;
        public static double MinAbPerMc = 1;
        public static double MaxAbPerMc = 120;
        public static double MinItemPerMc = 1;
        public static double MaxItemPerMc = 120;
        public static double ItlimNetweightMin = 0.05;
        public static double ItlimNetweightMax = 8;

        public static double MclimGrossweightMin;
        public static double MclimGrossweightMax;
        public static double MclimLengthMin;
        public static double MclimLengthMax;
        public static double MclimWidthMin;
        public static double MclimWidthMax;
        public static double MclimHeightMin;
        public static double MclimHeightMax;
        public static double MclimPaperTareMin;
        public static double MclimPaperTareMax;
        public static double MclimPlasticTareMin;
        public static double MclimPlasticTareMax;

        public static double AblimGrossweightMin;
        public static double AblimGrossweightMax;
        public static double AblimLengthMin;
        public static double AblimLengthMax;
        public static double AblimWidthMin;
        public static double AblimWidthMax;
        public static double AblimHeightMin;
        public static double AblimHeightMax;
        public static double AblimPaperTareMin;
        public static double AblimPaperTareMax;
        public static double AblimPlasticTareMin;
        public static double AblimPlasticTareMax;

        public static double ItlimGrossweightMin;
        public static double ItlimGrossweightMax;
        public static double ItlimLengthMin;
        public static double ItlimLengthMax;
        public static double ItlimWidthMin;
        public static double ItlimWidthMax;
        public static double ItlimHeightMin;
        public static double ItlimHeightMax;
        public static double ItlimPaperTareMin;
        public static double ItlimPaperTareMax;
        public static double ItlimPlasticTareMin;
        public static double ItlimPlasticTareMax;

        public static double mcBrutoInput;
        public static double mcLengteInput;
        public static double mcBreedteInput;
        public static double mcHoogteInput;
        public static double mcKartonInput;
        public static double mcPlastiekInput;

        public static double abBrutoInput;
        public static double abLengteInput;
        public static double abBreedteInput;
        public static double abHoogteInput;
        public static double abKartonInput;
        public static double abPlastiekInput;

        public static double itBrutoInput;
        public static double itNettoInput;
        public static double itLengteInput;
        public static double itBreedteInput;
        public static double itHoogteInput;
        public static double itKartonInput;
        public static double itPlastiekInput;

    }
}
