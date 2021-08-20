using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OstCetCatalogJuicerConsole.MaterialTransfer;
using OstCetCatalogJuicerConsole.OverwriteProductReferences;
using OstCetCatalogJuicerConsole.Repopulator;
using OstToolsBc.CetCatalogBc;

namespace OstCetCatalogJuicerConsole
{
    class Program
    {
        private const string _dbConnectionString = "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Volo\\TML.db3";

        static async Task Main(string[] args)
        {
            await OverwriteOldProductReferences();
            // await RunOptionAnalyzer();
        }


        #region Material Application Copier

        private static Task MaterialApplicationCopier()
        {
            const string copyConnectionString = "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Tables\\TBL.db3";
            const string pastConnectionString = "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Trig\\TRG.db3";

            var copier = new MaterialApplicationCopier.MaterialApplicationCopier(copyConnectionString, pastConnectionString);
            return copier.CopyMaterialApplications();
        }

        #endregion

        #region Product Matcher

        public static async Task ProductMatcher()
        {
            const string symbolDir = "C:\\Users\\Johnnie\\Documents\\CET Documents\\Intrinsic\\not reviewed";
            const string xrfPath = "C:\\Users\\Johnnie\\Documents\\CET Documents\\Intrinsic\\not reviewed\\INRXRF.TXT";
            var productMatcher = new ProductMatcher.ProductMatcher(_dbConnectionString, symbolDir, xrfPath);
            await productMatcher.MatchProducts();
        }

        #endregion Product Matcher

        #region Option Analyzer

        private static async Task RunOptionAnalyzer()
        {
            const string exportPath = "C:\\Users\\Johnnie\\Documents\\CET Documents";
            var analyzer = new OptionAnalyzer.OptionAnalyzer(_dbConnectionString, exportPath);
            await analyzer.SortOptions(GoodCodes, BadCodes);
            await RunMaterialTransfer(_dbConnectionString);
            await RunOptionRepopulator(_dbConnectionString, GoodCodes);

        }

        private const string BadCodes =
            ";.25;.SPECIAL;.NA;.6;.8;.4;.SPL;.R;.WMY;.WMN;.T1;.T2;.TS;.T4;.T3;.SCP;.PKP;.E;.MD;.MM;.AZ;.XF;.XS;.FXM;.No;.Yes;.3;.5;.9;.26;.38;.37;.31;.17;.10;.14;.30;.22;.32;.24;.16;.35;.36;.28;.29;.39;.T;.GRINJ1B;.GRINJ1C;.GRINH3B;.GRINH3C;.GRINH2G;.GRING1KK;.GRING2D;.GRINI3B;.GRING2B;.GRING2C;.GRINAZZ;.GRINB3;.GRINB4;.GRINB1;.GRINI3A;.GRING1F;.GRING1G;.GRING1DD;.GRINJ4C;.GRINJ4D;.GRINK2G;.GRINK7E;.GRING1Q;.GRINI2T;.GRINK1T;.GRINH1X;.GRINJ2V;.GRINH1Y;.GRINH2D;.GRINI2U;.GRINH1W;.GRINH2F;.GRINH2C;.GRINJ4A;.GRINJ1JJ;.GRINJ1FF;.GRINH2B;.GRINBZZ;.GB31;.GB32;.GB33;.GC15;.GA18;.GA19;.GA3;.GA20;.GA22;.GA23;.GA24;.GA25;.GA26;.GB26;.GA28;.GB28;.GB29;.COM;.GC11;.GB34;.GC13;.GB27;.GCZ;.GA16;.GEZ;.GC12;.GC14;.GA10;.GA27;.GA12;.GB30;.200;.120;.121;.122;.123;.124;.161;.162;.163;.164;.165;.166;.167;.168;.169;.130;.131;.132;.133;.170;.171;.172;.137;.138;.139;.176;.177;.178;.179;.155;.151;.152;.153;.190;.191;.192;.193;.147;.149;.106;.101;.102;.103;.140;.141;.142;.143;.108;.109;.146;.183;.184;.185;.186;.187;.188;.189;.174;.159;.158;.126;.135;.127;.118;.128;.148;.136;.181;.182;.160;.180;.110;.111;.112;.113;.114;.115;.116;.117;.154;.119;.156;.157;.194;.195;.196;.197;.198;.199;.145;.144;.107;.105;.104;.173;.125;.134;.129;.GRINI1D;.GRINI1H;.GRINI1I;.GRINJ1I;.GRINI1L;.GRINI1M;.GRINJ1M;.GRINJ1N;.GRINJ1R;.GRINI1B;.OSY;.OSN;.GRINE2G;.GRING3E;.GRING3F;.GRINF2I;.GRINE2N;.GRIND2P;.GRINE2Q;.GRINE1S;.GRINE2J;.GRING3G;.GRINF3A;.GRINE2C;.GRINE1R;.GRINF2H;.GRINF2B;.GRINF4A;.GRINE2E;.GRINC3;.GRINC4;.GRINC1;.DGV;.DGH;.GRIND1;.GRIND3;.GRIND4;.GRING1A;.GRING1B;.GRING1C;.GRING1;.GRING2;.GRING3;.GRING4;.GRINA;.GRINB;.GRINC;.GRIND;.GRINE;.GRINF;.GRING;.GRINH;.GRINI;.GRINJ;.GRINK;.TRG;.NL;.GRIND2G;.GRINB1O;.GRINB1B;.GRINB1D;.GRIND3A;.GRINC1H;.GRINC1F;.GRIND2E;.GRINB1I;.GRINF3D;.GRINF3E;.GRINF3F;.GRINE2I;.GRIND2K;.GRINE2K;.GRINE2L;.GRINE2O;.GRINE2R;.GRINE2S;.GRIND1V;.GRINE2U;.GRINE2H;.GRINE2D;.GRINE2T;.GRINF3B;.GRINF3C;.GRINF2E;.GRING3D;.GRING2F;.GRING1U;.GRINF1X;.GRINF1Z;.GRINF2D;.GRING3C;.GRING3B;.GRINF2A;.GRINH3D;.GRINE2F;.GRINE1C;.GRING2A;.GRING3A;.GRINH3A;.4A;.NP;.GRINH1I;.GRINJ1H;.GRINH1K;.GRINI1K;.GRINI1N;.GRINI1O;.GRINI1J;.GRINH1;.GRINH3;.GRINH4;.GRINK5A;.GRINK5B;.GRINI1R;.GRINI1S;.GRINI1T;.GRINI1Y;.GRINI2B;.GRINI2C;.GRINI2D;.GRINI2E;.GRINI2F;.GRINK6A;.GRINK6B;.GRINI2I;.GRINI2J;.GRINI2L;.GRINJ1GG;.GRINI2R;.GRINK7A;.GRINK7B;.GRINK7C;.GRINK7D;.GRINK7F;.GRINK7G;.GRINK7H;.GRINK7I;.GRINJ2A;.GRINJ2B;.GRINJ2C;.GRINJ2E;.GRINJ2F;.GRINJ2G;.GRINJ2H;.GRINJ2I;.GRINJ2K;.GRINJ2M;.GRINJ2N;.GRINJ2O;.GRINJ2P;.GRINJ2U;.GRINJ2W;.GRINJ2X;.GRING1N;.GRINK1M;.GRINK1N;.GRINK1O;.GRINK1P;.GRINK1Q;.GRINK1R;.GRINK1U;.GRINK1V;.GRINK1W;.GRINK1X;.GRINK1Y;.GRINK1Z;.GRINJ4B;.GRINK2F;.GRINK2H;.GRINK2I;.GRINK2J;.GRINK2L;.GRINK2M;.GRINK2N;.GRINK2O;.GRINK2P;.GRINK2R;.GRINK2S;.GRINK2T;.GRINK2U;.GRINK2V;.GRINK2W;.GRINK2X;.GRINK2Y;.GRINK2Z;.GRINK3B;.GRINK3C;.GRINK3D;.GRINJ1DD;.GRINK3F;.GRINK3G;.GRINK3H;.GRINK3I;.GRINK3J;.GRINK3K;.GRINK3L;.GRINK3M;.GRINK3N;.GRINK3O;.GRINK3P;.GRINK3Q;.GRINK3R;.GRINK3S;.GRINK3T;.GRINK3U;.GRINK3V;.GRINK3W;.GRINH2E;.GRINK4B;.GRINK4C;.GRINK4D;.GRINK4E;.GRINJ1EE;.GRINK4G;.GRINK4H;.GRINK4J;.GRINK4K;.GRINK4L;.GRINK4M;.GRINK3E;.GRINJ1CC;.GRINJ1P;.GRINI2H;.GRINI2N;.GRINK4F;.GRINE1G;.GRINC1J;.GRIND1J;.GRINC1L;.GRINC1M;.GRIND1M;.GRIND1P;.GRIND1R;.GRIND1S;.GRIND1Y;.GRIND1A;.GRIND1B;.GRIND2A;.GRINC1N;.GRINC1I;.XXX;.GRINE4;.GRINE1;.GRINE3;.GRINH1E;.GRINF1H;.GRINE1K;.GRINF1K;.GRINF1L;.GRINF1M;.GRINF1P;.GRINF1Q;.GRINF1T;.GRINF1U;.GRINF1V;.GRINF1Y;.GRINF1J;.GRINF1B;.GRINE1D;.B;.2B;.GRINI4;.GRINI1;.GRINI3;.GRINF1W;.GRING1Y;.GRING1P;.GRINF1R;.GRINF1S;.GRINK1A;.GRINK2A;.GRINK1C;.GRINK2C;.GRINK2D;.GRINK2E;.GRINK1G;.GRINK1H;.GRINK1I;.GRINK1J;.GRINK1K;.GRINK1L;.GRINJ1L;.GRINK1B;.GRINK1E;.GRINJ1D;.GRINK1D;.GRINK2B;.GRINJ1E;.GRINJ1A;.COL;.GRINJ3;.GRINJ4;.GRINJ1;.GRINA1B;.BY;.BN;.K2P;.GRINA1C;.G4R;.G4Q;.G4N;.G4O;.G4P;.GL2;.P1;.H;.GRINEZZ;.GRINCZZ;.GRINK3;.GRINK4;.GRINK1;.GRINC1A;.GRINF1D;.GRINF1E;.GRINE1J;.GRIND1L;.GRINE1L;.GRINE1O;.GRIND1Q;.GRINE1Q;.GRINE1T;.GRIND1W;.GRIND1X;.GRIND1Z;.GRIND1K;.GRIND1U;.GRIND1D;.GRIND1E;.GRIND1F;.GRINE1P;.GRINF1F;.GRING1J;.GRINA1A;.GRINF3;.GRINF4;.GRINF1;.GRINC1K;.GRINC1D;.GRINB1A;.GRIND1O;.GRINF1A;.GRING1H;.GRINH1D;.GRINH1C;.1A;.1B;.GRINH1B;.GRINI1C;.GRINH1F;.GRINA4;.GRINA3;.GRIND3F;.GRIND2H;.GRIND2I;.GRIND2J;.GRINE2M;.GRIND1T;.GRINI2V;.GRIND3E;.GRINC1G;.GRINC1E;.GRINC1B;.GRIND3B;.GRIND2C;.GRIND3C;.GRIND3D;.GRIND2F;.1;.2;.G2T;.G2U;.G4T;.G4U;.G1B;.G3B;.G3C;.G1F;.G3E;.G3F;.G1J;.G1K;.G1L;.G1M;.G1N;.G1P;.G1Q;.G3P;.G1S;.G3S;.G3T;.G0A;.G0C;.G4C;.G4D;.G2H;.G2F;.G3D;.G5A;.G2L;.G1R;.G4M;.G3Q;.G1D;.G4F;.G2S;.XN;.XG;.COS;.GRINF2G;.GRINI1G;.BWL;.PL;.RL;.CL;.GRINJ2Q;.GRINJ2R;.BC;.GL;.FP;.PK;.CH;.RDM;.KA;.0V;.0;.V1B;~.T3;~.T4;~.T1;~.T2;.AY;.AN;.SA;.PF;.FF;.GR1L;.QY;.QN";

        private const string GoodCodes = ";.E01;.E02;.E03;.XZK;.XY5;.XZM;.XY4;.XZH;.XZ4;.XY3;.XZK;.XZ4;.XZM;.XY4;.XZH;;.XZN;.XZ1;.XZ2;.XZ3;.XZE;.XY6;.XZ8;.XZY;.XZZ;.SP;.XZ6;.XZU;.XZV;.XZW;.XY1;.XY2;.XY0;.J12;.J13;.J32;.J33;.K15;.K16;.J18;.J1A;.J1B;.J1C;.J1D;.J1E;.J3E;.J3F;.J3G;.J3H;.J3J;.J3K;.J1N;.J9G;.JM4;.J9J;.J40;.J3R;.J42;.J43;.J3U;.J3V;.J3W;.J44;.J69;.JF1;.551;.J09;.553;.J14;.J15;.J9E;.J6A;.J6B;.J9H;.J16;.J46;.J17;.JP9;.J9F;.J3M;.JN2;.J1P;.JL6;.J0C;.J04;.573;.583;.J08;.520;.J11;.J9D;.J20;.J1R;.J3T;.J45;.J47;.J48;.J49;.J98;.J99;.J2A;.J0D;.J3C;.J3D;.JD5;.J39;.J1X;.J9X;.K19;.J25;.J0G;.J3A;.HSD;.J78;.HVA;.J7B;.05;.03;.XZP;.K20;.K21;.K17;.G;.K;.Y;.J;.DW;.L;.W6;.W7;.EJ;.ER;.WB;.WE;.WH;.WJ;.WK;.WM;.WY;.WZ;.E1;.E2;.E3;.E4;.E5;.E6;.E7;.E8;.E9;.EG;.W8;.PA;.EB;.EH;.ED;.EE;.W5;.TY;.TJ;.TK;.TL;.TG;.TDW;.J9C;.HZB;.J9B;.J9A;.XZG;.K12;.K13;.K14;.JC1;.JC2;.JC3;.JBU;.JC5;.JBW;.JBY;.JC9;.K00;.K01;.K03;.K04;.K05;.JCD;.JCF;.JB1;.JB2;.JB3;.JAU;.JB5;.K08;.JCB;.JBV;.JC4;.JCA;.JC8;.JA7;.K06;.K10;.CDA;.E3A;.01;.J6M;.J2R;.J6P;.J2U;.J6R;.J2W;.J6T;.J74;.J6V;.J6W;.J77;.J6Y;.J79;.J7A;.J7C;.J7D;.J7E;.J7F;.J7G;.J7H;.J7N;.J7R;.JCG;.J7T;.J7U;.JCM;.J75;.JCX;.J6J;.JD0;.JD1;.J4B;.JD3;.J0H;.J61;.J4F;.J4G;.J4H;.J53;.J4J;.J4K;.J0P;.J6G;.J0R;.J2J;.J4U;.J0U;.J0V;.J0W;.J4T;.J0Y;.J55;.J56;.J4X;.J4Y;.J2H;.J6X;.JCT;.JB4;.J73;.J72;.J0X;.J5A;.J5B;.J5U;.J5D;.J6U;.J5F;.J76;.J5H;.J1M;.J5J;.J5K;.J4W;.J1J;.J5N;.J5T;.J1T;.J1U;.J1V;.J1W;.J28;.J5V;.J1Y;.J67;.J60;.J50;.JD2;.J4V;.J0J;.J2B;.J6N;.J2D;.J2E;.J6C;.J6D;.J6E;.J6F;.J2K;.J6H;.J52;.J2N;.J6K;.J2P;.VA;TG;.BK;.3BW;.FG;.FY;.FJ;.FDW;.FL;.FK;.FDM;.M8;.M9;.M2;.M4;.M5;.M7;;.XZK;.XY5;.XZM;.XY4;.XZH;.XZ4;.XY3;.XZK;.XZ4;.XZM;.XY4;.XZH;;.QL2;.QR1;.401;.QP5;.QV0;.QN9;.423;.K96;.K97;.K98;.K99;.QM0;.BXU;.BXV;.BXW;.BXX;.QS0;.QQ3;.150;.390;.Z21;.Z22;.Z23;.Z24;.400;.380;.238;.175;.BV2;.QT8;.404;.GRINI1E;.BN5;.BN6;.BN7;.BN2;.BN3;.BN4;.KX8;.KX9;.KXA;.KTF;.KXC;.KTH;.KXE;.KTJ;.KXG;.KXH;.KTM;.KTN;.KXK;.KTP;.KXM;.KXN;.KXP;.KTU;.KXR;.KXT;.KXU;.KXV;.KXW;.KTT;.KTR;.KTG;.KXD;.KXF;.KTK;.KTE;.KXJ;.B48;.B4A;.B4B;.B49;.B4G;.B4H;.B4J;.B4K;.B4M;.B4N;.B4P;.B4R;.A75;.A76;.KX3;.KX4;.KX5;.KX6;.B5C;.BE4;.B5E;.BE7;.BE8;.BE9;.BEA;.A63;.A64;.A65;.A66;.A67;.BEH;.A69;.BEJ;.KEE;.KEG;.BE5;.A68;.KX7;.BXT;.BEG;.B5A;.BEE;.BE3;.BE1;.A70;.A71;.A72;.B5D;.A74;.SG9;.SF0;.AP1;.AR8;.AQ0;.BMA;.BMC;.BMD;.BME;.BMF;.BMG;.BMH;.BMJ;.BMK;.BMM;.BMN;.BMP;.BMR;.BMT;.BMU;.BMV;.BM7;.BM8;.BM9;.BMW;.BMX;.BM6;.BM5;.Z9N;.Z9P;.Z9R;.Z9T;.Z9U;.Z9V;.Z9W;.Z9X;.ZAC;.ZAD;.ZAE;.ZAF;.ZAG;.ZA8;.ZA9;.ZAH;.ZA7;.ZAA;.Z9J;.Z9K;.Z9M;.Z9F;.Z9G;.Z9H;.ZA2;.ZC1;.ZA4;.ZA5;.ZA1;.ZA3;.ZA0;.Z9Y;.Z4A;.Z4C;.Z4D;.Z4E;.Z4F;.Z4G;.Z4H;.Z4J;.Z42;.Z43;.Z44;.Z45;.Z46;.Z47;.Z48;.Z49;.SJ3;.BPP;.SM3;.SL5;.ST0;.SR4;.SQ6;.SP8;.SN1;.Z9C;.Z9D;.Z9E;.Z9A;.Z97;.Z98;.Z99;.KK7;.KK8;.KK9;.KKA;.KKC;.KK3;.KK4;.KK5;.KK6;.ZAR;.ZAT;.ZAU;.ZAV;.ZAW;.ZAX;.ZAY;.Z3A;.Z3C;.Z3D;.Z3E;.Z3F;.Z3G;.Z3H;.Z3J;.Z3K;.Z34;.Z35;.Z36;.Z37;.Z38;.Z39;.ZAJ;.ZAK;.ZAM;.ZAN;.ZAP;.ZCA;.ZC3;.ZC4;.ZC5;.ZC6;.ZC7;.ZC8;.ZC9;.ZCC;.KJX;.B4X;.B4Y;.BG7;.BG8;.BJ7;.KK0;.KK1;.BFP;.KJY;.BFR;.KK2;.B4V;.AJ2;.AJ3;.AJ4;.AJ5;.AH8;.AH9;.AJ1;.AH2;.AH6;.AH4;.AH7;.AH5;.AJ0;.AH3;.KGA;.KGC;.KGD;.KGE;.KGF;.KGG;.KGH;.KGJ;.KG3;.KG4;.KJ2;.KG6;.KG7;.KG8;.KG9;.KG5;.KHJ;.KH5;.KH8;.KHG;.KHA;.KHF;.KHC;.KHD;.KHE;.KH6;.KH7;.KHH;.KH9;.KHK;.KHM;.KHN;.KHP;.KJ0;.KHR;.KJ1;.KHT;.KHU;.KHV;.KHW;.KHX;.KHY;.L4M;.L4N;.L4P;.L50;.L42;.L25;.L45;.L4A;.L4B;.L4D;.L4E;.L4F;.L4G;.L4H;.L4J;.L4K;.KR0;.KR1;.KR2;.KR3;.KPE;.KPF;.KPG;.KPH;.KPJ;.KPK;.KPM;.KPN;.KPP;Z3M;.KPR;.KPT;.KPU;.KPV;.KPW;.KPX;.KPY;.Z3N;.Z3P;.Z3R;.Z3T;.Z3U;.Z3V;.Z3W;.Z3X;.Z3Y;.Z0T;.Z0U;.Z0V;.Z0G;.Z0X;.Z0J;.Z0K;.Z0W;.Z0M;.Z0N;.Z0H;.Z0P;.Z0F;.Z0R;.KGK;.KGR;.KGM;.KGN;.KGU;.KGP;.KH0;.KH1;.KH2;.KGT;.KH4;.KGV;.KGW;.KGX;.KGY;.KH3;.Z2A;.Z2C;.Z2D;.Z2E;.Z26;.Z2G;.Z28;.Z29;.Z2J;.Z2K;.Z2M;.Z2H;.Z2F;.Z27;.KDN;.KDP;.KDR;.KDT;.KDU;.KDV;.KDH;.KDJ;.KDK;.KDM;.B0R;.B30;.B0T;.B0U;.B0V;.B0W;.B0X;.B0Y;.KDA;.KDC;.KDD;.KDE;.KDF;.KDG;.KD8;.KD9;.K1D;.K1E;.K1F;.K1G;.K1H;.K1J;.K1K;.K1M;.K1N;.K1P;.K1R;.K22;.K23;.K1U;.K1V;.K1W;.K27;.K28;.K29;.K2A;.K2C;.K2D;.K26;.K1T;.K1Y;.K1X;.K24;.K25;.BBP;.BBR;.BC2;.BC3;.BC4;.BC5;.BBW;.BBX;.BBY;.BPR;.BPT;.BPU;.BPV;.BC1;.BBU;.BBV;.BR9;.BRJ;.BRK;.BRM;.BRH;.BRP;.BRA;.BRR;.BRG;.BRD;.BRE;.BRF;.BR7;.BR8;.K30;.K2R;.K32;.K2T;.K2U;.K35;.K36;.K37;.K2Y;.K39;.K3A;.K3C;.K3D;.K3E;.K38;.K2V;.K31;.K34;.K2E;.K2F;.K2G;.K2H;.K2X;.K2J;.K2K;.K33;.K2M;.K2N;.K2W;.Z12;.Z1C;.Z14;.Z15;.Z16;.Z0Y;.Z19;.Z1A;.Z13;.Z18;.Z10;.Z11;.K4N;.K4P;.K50;.K4R;.K52;.K4T;.K54;.K4V;.K56;.K4X;.K4Y;.K59;.K5A;.K5C;.K5D;.K5E;.K5F;.K5G;.K4U;.K57;.K58;.K51;.K4W;.K4G;.K4H;.K53;.K4J;.K4K;.K55;.K4M;.KUN;.KUP;.KV0;.KUR;.KV2;.KUT;.KV4;.KUV;.KV6;.KUX;.KYU;.KYV;.KYW;.KYX;.KUW;.KYT;.KV7;.KV8;.KV5;.KYR;.KV3;.KV1;.KUU;.KUY;.K5H;.K5J;.K5K;.K5M;.K5N;.K5P;.K60;.K5R;.K62;.K5T;.K5U;.K5V;.K66;.K5X;.K68;.K69;.K64;.K63;.K5W;.K6A;.K65;.K6C;.K6D;.K6E;.K6F;.K6G;.K6H;.K67;.K61;.K5Y;.Z1D;.Z1E;.Z1F;.Z1G;.Z1H;.Z1J;.Z1K;.Z1M;.Z1N;.Z1P;.Z20;.Z1R;.Z1T;.Z1U;.Z1V;.Z1W;.Z1X;.Z1Y;.FZL;.FZH;.KWK;.KWM;.KWN;.KWP;.KWV;.KWR;.KWU;.KWT;.KWE;.KWF;.KWW;.KWH;.KWG;.KWJ;.K3F;.K3G;.K3H;.K3J;.K3K;.K3M;.K3N;.K3P;.K40;.K41;.K42;.K3T;.K3U;.K3V;.K46;.K47;.K3Y;.K49;.K4A;.K4C;.K4D;.K4E;.K4F;.K48;.K44;.K3X;.K3R;.K3W;.K43;.K45;.BFE;.BFF;.BFG;.BFH;.BFJ;.KX0;.KX1;.BFM;.BFN;.KWX;.KWY;.AQ1;.AQ3;.AQ4;.AQ5;.AQ6;.AQ7;.BXP;.B9P;.GEB;.BF1;.BF2;.BF3;.BF4;.BF5;.BF6;.BF8;.BF9;.BFK;.AR0;.AR1;.AR2;.AR3;.AQ9;.KX2;.BFA;.AQ8;.BFC;.BFD;.KYJ;.KT0;.KT1;.KYM;.KYN;.KT4;.KYP;.KT6;.KT7;.KT8;.KT9;.KTA;.KTC;.KTD;.KRR;.KRY;.KRT;.KRU;.KRV;.KRW;.KY1;.KY2;.KY3;.KY4;.KY5;.KY6;.KY7;.KXY;.KY9;.KRX;.KY8;.KYK;.KT2;.KT3;.KT5;.KXX;.KYA;.KY0;.KYC;.KYD;.KYE;.KYF;.KYG;.KYH;.K02;.KV9;.KVA;.KVC;.KVD;.KVE;.KVF;.KVG;.KVH;.KVJ;.KVK;.KVM;.KVN;.KVP;.KW0;.KW1;.KW2;.KW3;.KW4;.KW5;.KVW;.KW7;.KW8;.KW9;.KWA;.KVR;.KWC;.KWD;.KVY;.KVU;.KVX;.KW6;.KVT;.KVV;.Z30;.Z31;.Z32;.Z2T;.Z2U;.Z2V;.Z2W;.Z2X;.Z2Y;.Z2N;.Z2R;.Z2P;.Z56;.Z57;.Z58;.Z54;.Z55;.Z4P;.Z4R;.Z4K;.Z4M;.Z4N;.K11;.K0W;.K0X;.K0Y;.K0V;.Z4W;.Z4T;.Z4U;.Z4V;.Z4X;.Z4Y;.Z51;.Z52;.Z53;.AG5;.AG7;.AG0;.AG9;.AG1;.AG3;.AG4;.GB;.GS;.GHP;~.G;~.Y;~.J;~.K;~.L;~.DW;~.TK;~.TL;~.TG;~.TDW;~.TY;~.TJ;~.FY;~.FJ;~.FK;~.FL;~.FG;~.FDW;~.PA;.V52;.V53;.V38;.V39;.V49;.V43;.V48;.V51";

        
        private const string UnknownCodes = "";

        #endregion Option Analyzer

        #region Material Transfer

        public static async Task RunMaterialTransfer(string copyTo = _dbConnectionString)
        {
            var copyFrom = new List<string>
            {
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Capture\\CAP.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Choices\\T2U.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Intrinsic\\INR.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\LessIsMore\\TLM.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Seating\\TSG.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Tables\\TBL.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Trendwall\\TWL.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Trig\\TRG.db3",
                "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Volo\\TML.db3",
            };

            copyFrom.Remove(copyTo);
            var materialTransferer = new MaterialTransferer(copyFrom, copyTo);
            await materialTransferer.TransferMaterialReferences();
        }

        #endregion

        #region Option Repopulator

        private static async Task RunOptionRepopulator(string dbConnectionString = _dbConnectionString, string codeCsv = GoodCodes)
        {
            var repopulator = new OptionRepopulator(dbConnectionString, codeCsv);
            await repopulator.BindMaterialsToOptions();
        }

        #endregion

        private static async Task OverwriteOldProductReferences()
        {
            const string xrfPath = "C:\\Users\\Johnnie\\Documents\\CET Documents\\Volo\\XRF.TXT";
            var writer = new ProductReferenceOverWriter(_dbConnectionString, xrfPath);
            await writer.OverwriteProductReferences();
        }
    }
}
