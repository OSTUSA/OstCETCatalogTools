﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XrfParser;
using XrfParser1 = XrfParser.XrfParser;

namespace DwgCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            const string catalogName = "Intrinsic";
            var directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CET Documents", catalogName, "DWG");
            var files = Directory.GetFiles(directoryPath, "*XRF.txt");
            var xrfModels = new List<XrfModel>();

            var dwgCopier = new DwgCopier(catalogName);
            foreach (var file in files)
            {
                xrfModels.AddRange(new XrfParser1(file).ParseFile());
            }

            var matchedXrf = new List<XrfModel>();
            var csv = "LCAK;ZFTUPXZ1;ZFTUPXZ2;ZFLCK.105;ZFTUPXZ4;ZFTUPXZ5;ZFLCK.108;ZFLCK.109;ZFPT;ZFLCK.110;ZFLCK.111;ZFLCK.112;ZFLCK.113;ZFLCK.114;ZFLCK.115;ZFLCK.116;ZFLCK.117;ZFLCK.118;ZFLCK.119;SICELECM;LKS;LEDTL31;ZFLCK;ZFLCK.120;ZFLCK.121;LCAK.103;ZFLCK.123;LCAK.105;LCAK.106;LCAK.107;ZFLCK.127;LCAK.109;ZFLCK.129;ZFKEY;ZFCK;LCAK.110;LCAK.111;ZFLCK.131;ZFLCK.132;LCAK.114;ZFLCK.134;LEDTL44DCMP;CLCK.106;LCAK.118;LCAK.119;ZFLCK.139;ZFPD-93065;ZFSMP6XZ1;ZFSMP6XZ2;ZFSMP6XZ3;ZFSMP6XZ4;ZFSMP6XZ5;LCAK.120;LCAK.121;LCAK.122;LCAK.123;LCAK.124;CLCK.114;LCAK.126;CLCK.116;LCAK.128;LCAK.129;CLCK.119;LEDTL58DCJC;LCAK.130;CLCK.120;CLCK.121;CLCK.122;CLCK.123;LCAK.135;LCAK.136;CLCK.126;LCAK.138;CLCK.128;CLCK.129;SIZFCMGG30;LCAK.140;CLCK.130;LCAK.142;CLCK.132;LCAK.144;LCAK.145;CLCK.135;CLCK.136;CLCK.137;CLCK.138;CLCK.139;LCAK.150;SIZFCMGG42;CLCK.141;CLCK.142;CLCK.143;CLCK.144;CLCK.145;SIZFCMGG48;CLCK.147;CLCK.148;CLCK.149;PLCAK;ZFPSSB;CLCK.150;VWC3;LEDTL58DCMP;PLKS;SIZFCMGG66;PLCAK.101;PLCAK.102;PLCAK.103;PLCAK.104;PLCAK.105;PLCAK.106;PLCAK.107;PLCAK.108;PLCAK.109;ZFLCK.107;ZFLCK.122;PLCAK.142;ZFLCK.124;PLCAK.120;ZFLCK.130;ZFLCK.146;ZFLCK.136;TLCK.102;ZFLCK.125;TLCK.133;ZFLCK.128;PLCAK.110;PLCAK.111;PLCAK.112;PLCAK.113;PLCAK.114;TLCK.103;PLCAK.116;TLCK.105;Special-Packaging;TLCK.107;TLCK.108;TLCK.109;LCAK.137;ZFLCK.143;CLCK.109;PLCAK.135;ZFLCK.104;ZFLCK.149;ZFLCK.137;ZFLCK.133;CLCK.134;ZFLCK.145;ZFLCK.150;LCAK.147;TLCK.110;ZFLCK.106;ZFTUPXZ3;ZFLCK.135;PLCAK.148;ZFLCK.142;INSTALL2;INSTALL3;CLCK.113;INSTALL5;PLCAK.121;PLCAK.122;PLCAK.123;PLCAK.124;PLCAK.125;TLCK.114;TLCK.115;PLCAK.128;PLCAK.129;TLCK.118;TLCK.119;LCAK.101;ZFLCK.126;CLCK.115;ZEFSMP6XZ1;PLCAK.132;PLCAK.141;ZFLCK.140;TLCK.116;ZEFSMP6XZ2;CLCK.133;PLCAK.118;LEDTL58;LCAK.143;LCAK.146;CLCK.140;LCAK.117;CLCK.110;ZFLCK.144;CLCK.104;LCAK.115;LEDTL44;PLCAK.130;PLCAK.131;TLCK.120;PLCAK.133;TLCK.122;ZEFSMP6XZ5;TLCK.124;TLCK.125;TLCK.126;TLCK.127;TLCK.128;TLCK.129;TLCK.131;ZFRL;ZFLCK.103;CLCK.111;CRK;TLCK.104;TwayDesign;CLCK.124;CLCK.101;LCAK.113;TLCK.111;TLCK.106;PLCAK.139;PLCAK.146;PLCAK.127;LCAK.125;LEDTL31DCMP;CLCK.146;LCAK.132;LCAK.127;CLCK.102;PLCAK.140;HWM30;TLCK.130;PLCAK.143;TLCK.132;PLCAK.145;TLCK.134;PLCAK.147;TLCK.136;PLCAK.149;TLCK.138;TLCK.139;LCAK.148;LCAK.116;LCAK.134;LCAK.141;CLCK.118;CLCK.105;ZFLCK.138;SPECIAL-INTRINSIC;PLCAK.137;TLCK.113;PLCAK.144;TLCK.137;CLCK.125;TLCK.101;SIZFCMGG36;SPECIAL-INREXEC;PLCAK.117;TLCK.135;PLCAK.126;LEDTL31DCJC;LCAK.149;PLCAK.150;CLCK.131;TLCK.140;TLCK.141;TLCK.142;TLCK.143;TLCK.144;TLCK.145;TLCK.146;TLCK.147;TLCK.148;TLCK.149;LCAK.139;CLCK.127;ZFTUPKIT;LCAK.133;LCAK.131;CLCK.108;CLCK.103;PLCAK.138;PLCAK.136;TLCK.123;PLCAK.134;ZEFSMP6XZ3;ZFLCK.147;LCAK.108;ZFLCK.148;CLCK.117;CLCK.112;ZFLCK.141;PLCAK.115;LCAK.102;TLCK.117;TLCK.112;LEDTL44DCJC;TLCK.150;CLCK.107;LCAK.112;PLCAK.119;TLCK.121;LEDTLOS;LCAK.104;ZFLCK.102;ZFLCK.101";
            // csv = string.Join(';', csv.Split(';').Where(s => s.StartsWith("APWSL") || s.StartsWith("APWSR")));
            // var csv = "TRGRECD2060.NN.GN;TRGRECD3072.NN.GN;TRGRECD2066.NN.GN;TRGRECD2466.NN.GN;TRGRECD2060.NN.GY;TRGRECD3054.NN.GY;TRGRECD2048.NN.GY;TRGRECD2448.NN.GY;TRGRECD3060.NN.GN;TRGRECD2054.NN.GN;TRGRECD3066.NN.GY;TRGRECD3048.NN.GY;CM553BW;TRGRECD2454.NN.GN;TRGRECD2072.NN.GY;TRGRECD3054.NN.GN;TRGRECD2072.NN.GN;TRGRECD2460.NN.GY;TRGRECD3060.NN.GY;TRGRECD2066.NN.GY;TRGRECD2054.NN.GY;TRGRECD3048.NN.GN;TRGRECD2048.NN.GN;TRGRECD3072.NN.GY;TRGRECD2454.NN.GY;TRGRECD2448.NN.GN;TRGRECD2466.NN.GY;TRGRECD2472.NN.GY;TRGRECD3066.NN.GN;TRGRECD2460.NN.GN;TRGRECD2472.NN.GN";
            foreach (var s in csv.Split(';'))
            {
                matchedXrf.AddRange(xrfModels.Where(x => x.PartNumber == s));
            }

            dwgCopier.CopyToInchesXrf(matchedXrf);
            // dwgCopier.CopyToMeterXrf(matchedXrf);
            // dwgCopier.CopyToInchesCsv("TRGWEGSL248420.NN.GY;SCNSMPS6636;TRGWEGSR208424.NN.GY;TRGWEGDR245430.NN.GN;TRGWEGSL306020.NN.GN;TRGWEGSL306024.NN.GN;TRGWEGDR205430.NN.GY;SCNTDMU723030;TRGWEGDR245430.NN.GY;TRGWEGSL306624.NN.GN;TRGWEGSL306020.NN.GY;SCNTDMU483024;TRGWEGSL306024.NN.GY;SCNSMPU363030;SCNSMPS5436;TRGWEGSL306624.NN.GY;TRGWEGDL245420.NN.GN;TRGWEGDR246030.NN.GN;TRGWEGDR205424.NN.GN;TRGWEGDR246630.NN.GN;TRGWEGDR206030.NN.GY;TRGWEGSL307220.NN.GN;TRGWEGDR246030.NN.GY;TRGWEGSL307224.NN.GN;TRGWEGDR205424.NN.GY;SCNTDMU483030;TRGPND2PB;TRGWEGSL307824.NN.GN;TRGWEGSL307220.NN.GY;SCNSMPS7224;TRGWEGSL307224.NN.GY;SCNSMPU722430;SCNSMPS5430;TRGWEGSL306620.NN.GY;TRGWEGSL308420.NN.GY;TRGWEGSL307824.NN.GY;SCNSMPU482424;TRGWEGDR206024.NN.GN;TRGWEGSR205430.NN.GY;SCNTDMU722430;SCNSMPS4830;TRGWEGDR247230.NN.GN;TRGWEGDL246020.NN.GY;TRGWEGDR206624.NN.GN;TRGPND2PW;TRGWEGSR208424.NN.GN;SCNSMPU722424;TRGWEGDL307224.NN.GN;TRGWEGDR206024.NN.GY;SCNSMPS3030;TRGWEGSL246620.NN.GY;TRGWEGSL246620.NN.GN;TRGWEGDR247230.NN.GY;TRGWEGSL308424.NN.GN;TRGWEGDR206624.NN.GY;SCNSMPS6024;TRGPND1P1UW;SCNSMPU603024;SCNSMPS3630;SCNSMPU723036;SCNSMPU422430;SCNSMPS7236;TRGWEGSR246030.NN.GY;SCNSMPU723030;TRGWEGSL308424.NN.GY;TRGWEGDL306624.NN.GN;SCNSMPU482430;SCNTDMU542430;TRGWEGDL305424.NN.GN;SCNSMPU723024;SCNTDMU423024;SCNTDMU662430;TRGWEGDR207224.NN.GN;SCNSMPU543036;TRGWEGSL307820.NN.GN;TRGPND1P1DB;TRGWEGSR206630.NN.GY;TRGWEGDL247220.NN.GY;SCNTDMU603030;SCNSMPU543030;SCNSMPS3036;SCNTDMU362424;SCNTDMU603024;TRGWEGDR207224.NN.GY;SCNSMPS6030;TRGWEGDL246620.NN.GY;TRGWEGSR206024.NN.GN;TRGWEGDL246620.NN.GN;TRGWEGSR245430.NN.GN;SCNSMPU543024;SCNSMPS6036;SCNTDMU362430;SCNSMPU422436;SCNSMPU363024;SCNSMPS3024;SCNSMPU602424;TRGPND1P1DW;SCNTDMU423030;SCNSMPU363036;TRGWEGSR245430.NN.GY;SCNTDMU482430;SCNSMPU662424;TRGWEGDR206030.NN.GN;TRGWEGSR206624.NN.GN;SCNTDMU723024;TRGWEGSR205424.NN.GY;TRGWEGDL305420.NN.GY;TRGWEGDL247220.NN.GN;SCNSMPU422424;TRGWEGSR206624.NN.GY;TRGWEGDL305424.NN.GY;TRGWEGSR207230.NN.GY;SCNTDMU482424;TRGWEGSR206030.NN.GN;SCNSMPS6624;SCNTDMU363024;SCNSMPS2424;TRGWEGSR246030.NN.GN;SCNTDMU662424;TRGWEGSR206630.NN.GN;SCNSMPU542430;TRGWEGSR206024.NN.GY;TRGWEGSL248420.NN.GN;TRGWEGSR246630.NN.GN;SCNSMPU602430;SCNSMPS4824;TRGWEGDR205430.NN.GN;SCNTDMU542424;TRGWEGDL306024.NN.GN;TRGWEGSL247220.NN.GN;SCNSMPU483024;SCNSMPU722436;TRGWEGDR246630.NN.GY;SCNSMPU603036;TRGWEGSR246630.NN.GY;TRGWEGDL306020.NN.GY;SCNSMPU662436;SCNSMPS6630;SCNSMPU603030;TRGWEGDL306024.NN.GY;TRGPND1P1UB;TRGWEGDL306620.NN.GY;TRGWEGSL246020.NN.GN;SCNSMPU663030;TRGWEGSR206030.NN.GY;TRGWEGDL306624.NN.GY;SCNSMPU423036;SCNSMPU423030;SCNTDMU543024;TRGWEGSR207230.NN.GN;SCNSMPU662430;SCNSMPU423024;TRGWEGSR247230.NN.GN;TRGWEGSL246020.NN.GY;SCNSMPS3624;SCNTDMU722424;SCNSMPU482436;SCNSMPU602436;TRGWEGSR247830.NN.GN;TRGWEGDL307220.NN.GN;SCNSMPS4836;TRGWEGDR207230.NN.GY;TRGWEGDR207230.NN.GN;TRGWEGSR247230.NN.GY;TRGWEGSL308420.NN.GN;TRGWEGSR207830.NN.GY;SCNTDMU543030;TRGWEGSR208430.NN.GN;TRGWEGSR208430.NN.GY;TRGWEGSR247830.NN.GY;TRGWEGDL307220.NN.GY;TRGWEGSL247820.NN.GN;TRGWEGDL306020.NN.GN;SCNSMPU483036;TRGWEGDL307224.NN.GY;SCNSMPS4236;SCNSMPU663036;SCNTDMU422430;SCNTDMU663030;SCNTDMU663024;TRGWEGSR205430.NN.GN;SCNSMPU483030;SCNSMPS3636;TRGWEGSR207224.NN.GN;SCNSMPS5424;TRGWEGDR206630.NN.GY;SCNTDMU363030;TRGWEGSR248430.NN.GN;TRGWEGSL247220.NN.GY;TRGWEGSR207824.NN.GN;TRGWEGDL246020.NN.GN;SCNSMPU663024;TRGWEGDL306620.NN.GN;TRGWEGSL307820.NN.GY;SCNSMPU542424;SCNSMPU362436;TRGWEGDR206630.NN.GN;TRGWEGSL247820.NN.GY;TRGWEGSR248430.NN.GY;SCNSMPU362424;TRGWEGSR207824.NN.GY;SCNTDMU422424;SCNSMPU362430;TRGWEGSR207224.NN.GY;SCNSMPS7230;TRGWEGSR205424.NN.GN;TRGWEGSL305420.NN.GN;SCNTDMU602424;SCNTDMU602430;TRGWEGDL305420.NN.GN;TRGWEGSL305424.NN.GN;SCNSMPU542436;SCNSMPS2430;SCNSMPS4224;TRGWEGDL245420.NN.GY;SCNSMPS4230;TRGWEGSR207830.NN.GN;TRGWEGSL305420.NN.GY;SCNSMPS2436;TRGWEGSL245420.NN.GY;TRGWEGSL306620.NN.GN;TRGWEGSL305424.NN.GY;TRGWEGSL245420.NN.GN");
            // dwgCopier.CopyToMeterCsv("RTFXT3660.BC.NG;ZEFSQT42CLM;ECLHATC664224.C.GN;EVRHAT3048TFL.GN;SICECHBC244872LH;RTFXT3660.BC.NN;CHATE22442.S.GN;HRFXT3060.BC.EN;RTFXT1848.BC.NN;TZFXT3060.GL.EN;EVRHAT3048TFL.GY;RTFXT1872.GL.NG;RD30EB0;RTFXT1872.GL.NN;CHATE13036.C.GN;SICCEHATT3048TFLY.C;ECRHATE2244266.C.GN;SICEHATTTFL2466N;RTFLDT2472.BC.NN;SICHATBASEE22472;CHATE13036.C.GY;RTDFXT2448.BC.EN;EVRHAT3672TFL.GN;TTRT2442URE;RTFXT3048.GL.NG;TTHRT2448TFL.GY1;SICCEHATT2448TFLN.C;EVRHAT3672TFL.GY;RTFXT3048.GL.NN;SICECHBE1244266LH;HRFLPT2448.BC.NG;SICECHBE2244866LH;RHATE22448.GN;RHATE23042.GY;HRFLPT2448.BC.NN;TTFDTB22.BCB;EVRHAT3066TFL.GN;RHATE23660.GY;RTFLPT1848.BC.EN;ECRHATC244266.C.GN;SICCHX33.GL;RDTT30DSK.RDC;ZEFRTT3672CLM;RTFXT3672.GL.NG;RTDFXT3048.GL.NG;ZFMBC;ECRHATE2244260.C.GN;TTFXTB22.BCB;RTDFXT3048.GL.NN;ZFCT;ZEFRDT36;HRFXT2448.BC.NN;TZFXT2448.GL.NN;RHATE13036.GY;RHATC3036.GN;ZEFMMC;CHATE13042.S.GN;TTRT2460URE;RHATC3036.GY;CHATE13042.S.GY;RT3048FTB4.NN;RDCH42DSK.SDC;RHATE23060.GN;ZFRDT36;ZEFRDT42;RT3054EB3.NN;SICECHBE2304260;RHATE22466.GN;SICECHBE2304266;RTDFXT3072.BC.NG;ECRHATC244260.C.GN;TZFLPT3060.BC.EN;SICCEHATT2448Y.S;RTDFXT3072.BC.NN;RHATE22466.GY;RTFXT1860.GL.EN;SICECHBE1304260LH;RDTT30DSK.SDC;RTFLDT2460.BC.EN;SICECHBE2244272LH;RHATE13054.GN;ZFSQCHT36DSK.RDC;SQTT36.GL;SICEHATTTFL3660N;SICECHBE2304272;SICTTX27.BC;RTFLPT3072.BC.EN;RHATE13054.GY;ZEFRECT3672CLM;SICEHATTTFL3660Y;RHATE13672.GY;SICHATBASEC3036;RHATC3672.GN;CHATE12436.S.GN;RHATC3054.GY;TRGRECT3672SL.EN;RHATC3672.GY;CHATE12436.S.GY;TTTZT3060HPL.GY1;RTFLDT3060.GL.NG;EVRHAT2454TFL.GN;SICHATBASEC3042;RTFLDT3060.GL.NN;SICHATBASEC3048;SICECHBC244860;RTFXT1848.GL.EN;SICECHBC244866;TZFLPT2448.BC.NN;RHATE13072.GN;RTFLDT3660.BC.NG;ZFSQCHT36DSK.SDC;ECRHATE2304266.C.GN;RTFXT2460.BC.NG;SQ30FTB8;RTFLDT3660.BC.NN;SICHATBASEE23660;TTMMOD72;RHATE13072.GY;RHATC3072.GN;SICHATBASEE23666;ZFRDCHT42DSK.RDC;SICHATBASEC3054;EVRHAT2472.GY;RHATC3072.GY;ZEFRTT3672;SICEHATT3672N;ECRHATE1244272.C.GN;TTQR24TFL;RTDFXT3060.BC.EN;ZFRECT3672CLM;SICECHBC304860LH;RTFXT1872.BC.EN;TTTZT2448HPL.GY1;SICEHATT3672Y;RT3672EB9.NN;ECRHATC304266.C.GN;RTDFXT2460.BC.NN;SQ30EB8;EVCHAT2448TFL.C.GN;RT3072FTB1.NN;HRFLPT3060.BC.NG;ECRHATE2304260.C.GN;RHATE12442.GN;SICECHBE1304866LH;SICECHBE1244260;RTFLPT2460.BC.EN;SICECHBE1244266;HRFXT2448.GL.EN;RTFLPT1860.BC.NG;TTHRT3060HPL.GY1;ZFRDCHT42DSK.SDC;RTFXT3072.GL.EN;ZFSQT42DSK.RDC;RTFLPT1860.BC.NN;TTRT2436URE;ECLHATE1604230.C.GN;HRFXT3060.BC.NG;RHATC2442.GY;TZFXT3060.GL.NG;RTFXT2472.GL.NN;RD36FTB8;RDTT30.BC;RHATE23036.GN;CHATE23036.C.GN;ECLHATC604224.C.GN;SICFPB31;SICECHBE1304860;ECRHATC304260.C.GN;RTFXT3672.BC.EN;RTDFXT3048.BC.EN;RHATE23036.GY;CHATE23036.C.GY;SICEHATT3666Y;SICTTCB23.BC;TZFXT2448.BC.EN;ZFRTT3672CLM;SICTTX27.GL;RTDFXT3072.GL.EN;RTDFXT2448.BC.NN;SICCEHATT3048TFLN.C;RTDFXT2472.GL.NG;ECLHATE2664230.C.GN;RHATE12460.GN;RTDFXT2472.GL.NN;SICEVHATBASE24;SICCEHATT3048TFLN.S;EVCHAT3048.C.GN;RHATE12460.GY;RHATC2460.GN;RTFLPT2448.BC.EN;EVCHAT3048TFL.C.GN;SICHATBASEC2442;RTFLPT1848.BC.NG;ZFSQT42DSK.SDC;EVCHAT3048.C.GY;TTHRT2448HPL.GY1;RHATC2460.GY;RDCH30DSK.RDC;RTFLPT1848.BC.NN;EVCHAT3048TFL.C.GY;ZEFRTT3672DSK;SICECHBE2304872LH;SICEVHATBASE30;RHATE23672.GN;RHATE23054.GY;CHATE23042.S.GN;TTPGMP36;RHATE23672.GY;SICHATBASEC2454;SICECHBE2304260LH;CHATE23042.S.GY;RDTT36DSK.RDC;RHATE13048.GN;EVRHAT3660.GN;EVRHAT2448.GN;SICECHBC244266LH;ZFMT;SQTT30.BC;TZFLPT3060.BC.NG;RHATC3048.GN;RTFXT2460.GL.EN;TTPGMP48;SICCEHATT2448N.C;EVRHAT2448.GY;RTFXT1860.GL.NG;SICHATBASEC2466;RTFLDT3060.BC.EN;RDCH30DSK.SDC;RHATC3048.GY;RTFLDT2460.BC.NG;SICECHBE1244860LH;RHATE23072.GN;SICCEHATT2448N.S;CHATE22448.C.GN;RTFLPT3072.BC.NG;RHATE23072.GY;EVRHAT3660TFL.GN;RTFLPT3072.BC.NN;ZEFSQT36;ZEFRECT3672DSK;TTMTLP30;SICHATBASEC2472;RTDFXT2460.GL.EN;EVRHAT3660TFL.GY;CHATE22436.S.GY;TRGRECT3672SL.NN;RHATE13066.GN;RT2448EB4.NN;EVRHAT3054TFL.GN;SICECHBE2244266;ZFSQT36;ZEFSQT42;RHATC3066.GN;EVRHAT3054TFL.GY;TTMTLP42;RTFXT2448.GL.EN;RHATC3066.GY;EVCHAT2448.S.GN;SICTTCB23.GL;SQCH30.GL;RHATE22442.GN;CHATE22442.C.GN;RTFXT1848.GL.NN;ZFRDT36DSK.RDC;SICECHBE2304860;RTFXT3060.BC.NN;RHATE22442.GY;CHATE22442.C.GY;RTFLDT2472.GL.NG;TTPGMP72;RTFLDT2472.GL.NN;TTES48;TTMTLP54;RTDFXT2448.GL.EN;ZFSQCHT42DSK.RDC;RTFLDT3672.BC.EN;RHATE12436.GN;ZEFSQCHT36DSK.RDC;RTFXT2472.BC.EN;TZFXT3060.BC.EN;EVRHAT3072TFL.GN;RTFXT1872.BC.NG;ZFRDCHT30DSK.RDC;RHATE12436.GY;RHATC2436.GN;RD30FTB0;CHATE13036.S.GN;RTFXT1872.BC.NN;TRGRECT4272SL.EN;SICEHATT3060N;RHATC2436.GY;CHATE13036.S.GY;TTQR30HPL;SICEHATT3060Y;TTQR36TFL;ECLHATC664230.C.GN;RTFLPT2460.BC.NG;TTTZT3672HPL.GY1;RHATE22460.GY;ZEFRDT36DSK.RDC;HRFXT2448.GL.NG;RTFXT3048.BC.NN;RTFLPT2460.BC.NN;TTES60;SICTTCB17.BC;RTFXT3072.GL.NG;HRFXT2448.GL.NN;RTFXT3072.GL.NN;SQTT30.GL;SICEHATTTFL3060N;RT3060EB3.NN;ZEFRDT36CLM;ECRHATE2244272.C.GN;ZEFCT;SICEHATTTFL3060Y;CHATE13042.C.GY;SICTTFX17.BC;ZFRDCHT30DSK.SDC;TTRT3042URE;RHATC2454.GN;SICEHATT3660N;BT3672FTB8.NN;RTFXT3672.BC.NN;TZFXT2448.BC.NG;TTES72;EVRHAT3072TFL.GY;ECLHATE2724230.C.GN;RTDFXT3072.GL.NG;SICFPB26;ZFRTT3672DSK;TZFXT2448.BC.NN;ECLHATE1724224.C.GN;EVRHAT3666.GY;RT3660FTB2.NN;RTDFXT3072.GL.NN;ZEFRDCHT42DSK.RDC;ZEFRDT42CLM;RTDFXT2460.BC.EN;RDTT42.BC;RT3696FTB4.NN;SICHATBASEE13036;SICEHATT3054Y;SQ42FTB5;EVRHAT2454.GN;SICEHATT2472Y;RTFLDT2460.GL.EN;RHATE13660.GY;SICHATBASEE22442;SICDBPB37;RTFXT2460.BC.EN;SICECHBC304866LH;RTFLPT2448.BC.NG;EVRHAT3666TFL.GN;CHATE12442.C.GN;RD36EB8;RTFXT1848.BC.NG;RHATE23666.GY;RHATE23666.GN;ECLHATE2604230.C.GN;RHATE13060.GY;SICECHBE1304872LH;RTFLPT2472.BC.NG;SICHATBASEC3666;SICEHATTTFL2454N;SICECHBE2244872LH;SICHATBASEE12466;RTFXT2460.BC.NN;RT3072EB0.NN;SICEHATTTFL3054N;SICECHBE1244872LH;RHATE12472.GN;EVRHAT2472TFL.GN;RT3048EB3.NN;ZFRDT42CLM;RTFXT1860.BC.EN;SICHATBASEE13048;RTFLDT2460.BC.NN;ZEFSQCHT30DSK.RDC;SICECHBE1244860;SICEHATTTFL3054Y;SICECHBE1304266LH;RHATE12472.GY;TTRT3060URE;RHATC2472.GN;RHATE23660.GN;SICHATBASEE23672;SICHATBASEC3072;ZEFSQT42DSK.RDC;TTHRT3672TFL.GY1;EVRHAT2460TFL.GY;TTHRT3672HPL.GY1;SICHATBASEC3672;SICECHBE1244260LH;SICECHBC304860;RHATC2472.GY;TTCMTP66;SICCEHATT3048Y.C;SICEHATT3048N;RDCH36DSK.RDC;SICECHBE2244860LH;ZFRDCHT36DSK.RDC;TTCMTP60;CHATE12448.S.GY;RHATE23066.GN;SICHATBASEE13054;SICEHATT3072Y;RHATE23054.GN;SQ24EB9;SICEHATT3048Y;RT4272EB8.NN;RHATC3666.GY;SICHATBASEC2448;TTMTLP24;SICECHBE1244872;RTFXT3060.GL.EN;TTLMOD72;TTFDTB28.BCB;HRFXT3060.BC.NN;RTFXT3660.GL.NG;RDCH42.GL;RTFXT2472.BC.NG;RTFLDT3660.GL.NN;SQCH42DSK.RDC;SICEHATTTFL2466Y;ZFSQT42;RHATE23066.GY;RTFXT2460.GL.NN;SICEHATT2460Y;SICHATBASEC2436;SQCH36DSK.RDC;EVRHAT2472.GN;RDTT42.GL;SICEHATTTFL3072N;RTFLDT3060.BC.NN;RT2472EB1.NN;SICEHATTTFL3048N;EVRHAT3054.GN;SICECHBC304272LH;RTFXT3660.BC.EN;SICHATBASEE13066;TTCMTP42;SQTT42DSK.RDC;EVRHAT3672.GN;ECLHATE2664224.C.GN;RTFXT1848.BC.EN;ECRHATC244272.C.GN;SICEHATTTFL3048Y;EVRHAT3054.GY;EVRHAT2448TFL.GN;CHATE12442.S.GN;RTDFXT3060.GL.EN;RTFLDT3672.BC.NG;RTFLDT3660.GL.EN;EVRHAT3672.GY;SICEHATT3072N;RHATE22454.GN;ECLHATE1604224.C.GN;ZEFRECT3672;SQ42EB5;EVRHAT2448TFL.GY;CHATE12442.S.GY;SICEHATT3066N;RTDFXT2460.GL.NN;RDCH36DSK.SDC;SICTTCB17.GL;TTMSHP48;RECTT3054DSK.RDC;RHATE22436.GN;SICHATBASEE13072;ECLHATC724230.C.GN;SQTT42.BC;SICECHBC304260;CHATE23042.C.GY;ZFRECT3672DSK;RTFLDT3060.BC.NG;SICECHBE2304866LH;TZFXT3060.GL.NN;RTFLDT3660.GL.NG;BT3672EB5.NN;RTFLPT2448.BC.NN;TTCMTP36;CHATE12436.C.GN;ZFRECT3672;SICHATBASEC3066;BT3060EB0.NN;SICCEHATT2448TFLY.S;TRGSQT42;EVRHAT2460TFL.GN;RT2460FTB5.NN;RTFXT2448.GL.NG;SICHATBASEE12460;SICHATBASEE12442;SICECHBE2304266LH;CHATE22448.C.GY;TZFLPT3060.BC.NN;ECRHATE2304272.C.GN;SICBPB20;RHATE13042.GY;EVCHAT2448TFL.S.GN;SICEHATTTFL3066N;EVRHAT3072.GN;SICEHATT3054N;SICBPB26;SICHATBASEE12436;TTRT2448URE;RHATC2448.GY;RHATE12454.GY;HRFXT3060.GL.NN;ECRHATE1244260.C.GN;EVCHAT2448TFL.S.GY;SICEHATTTFL3066Y;EVRHAT3072.GY;EVRHAT2466TFL.GN;RHATE12454.GN;RTFLDT3072.GL.NN;EVRHAT3666TFL.GY;SICECHBC244866LH;HRFXT3060.GL.EN;ZFRDT36DSK.SDC;RTFXT3672.GL.EN;TTMTLP66;RHATC2454.GY;SICEHATT2460N;EVRHAT2466TFL.GY;ZFSQCHT42DSK.SDC;HRFXT2448.BC.EN;RTDFXT3060.BC.NN;RTFXT1848.GL.NG;TTQR24HPL;SQCH42.GL;SICBPB31;RECTT3054DSK.SDC;SICECHBE1244866LH;SICHATBASEE23054;SICEHATTTFL2460Y;RTFXT3060.BC.NG;ZFSQT36CLM;TTFPTB22.BCB;RTFLDT3672.BC.NN;CHATE22448.S.GY;RTFXT3660.GL.NN;TTMTLP48;RHATE22454.GY;RTFXT2472.BC.NN;RT3054FTB4.NN;SICECHBC244260;CHATE23036.S.GN;RTFLDT2472.GL.EN;SICECHBE2244266LH;SQ36EB6;RTDFXT2448.GL.NG;SICECHBC244266;SICECHBE2304872;RDTT42DSK.SDC;RTFXT2472.GL.NG;RTFXT1860.GL.NN;RHATE13042.GN;CHATE23036.S.GY;TTFPTB28.BCB;EVCHAT2448.S.GY;SICEHATTTFL2460N;RHATC3666.GN;RHATE13660.GN;TTRT2472URE;RTFLPT1860.BC.EN;RHATE12448.GN;RTFLPT3060.BC.NG;RTDFXT3072.BC.EN;SICEHATT2472N;RHATC3042.GN;SICEHATTTFL2448Y;SICECHBE2244860;RTDFXT2472.BC.NG;RTFLPT3060.BC.NN;SICECHBC244260LH;RHATC3660.GN;SICECHBE1304872;SICECHBE2244866;RHATC2448.GN;RTDFXT2472.BC.NN;RT3060FTB4.NN;BT4284EB1.NN;RHATE23060.GY;RTDFXT2448.BC.NG;TTTZT3060TFL.GY1;RT3672FTB0.NN;TTRT3660URE;RTDFXT3060.GL.NN;RTFLDT3072.BC.NG;SICEHATT2454N;RTFXT2448.BC.NN;EVCHAT3048TFL.S.GN;RTFLDT3672.GL.NG;ECRHATE1304266.C.GN;SICECHBE2304866;RHATE22472.GN;ZFRDT42DSK.RDC;RDTT36.BC;RHATE12442.GY;TRGRECT4272SL.NN;SICEHATT2454Y;RHATE22448.GY;EVCHAT3048TFL.S.GY;ZEFSQT36CLM;SICECHBC244272LH;RT3696EB3.NN;RHATE22472.GY;RTFLPT1872.BC.NG;TTCMTP72;SICHATBASEE23036;SICHATBASEC2460;EVCHAT3048.S.GY;ECLHATE1724230.C.GN;RTFXT3060.BC.EN;RTFLPT1872.BC.NN;SICECHBC304872;RTFXT3660.GL.EN;RTFLPT2472.BC.EN;RT2472FTB2.NN;SICECHBE1304860LH;RHATE13060.GN;CHATE13042.C.GN;SQTT42.GL;RT4272FTB9.NN;CHATE12448.C.GN;SICECHBE2304860LH;RT3660EB1.NN;SICTTX33.BC;EVRHAT2460.GN;RHATE12466.GN;RTFLDT3060.GL.EN;SICHATBASEE12472;SICHATBASEE22436;RHATC3060.GN;RHATE23048.GN;RTFLDT2460.GL.NG;RTFLPT3048.BC.NG;RTFXT3672.GL.NN;SICEHATTTFL2454Y;EVRHAT2460.GY;RHATE12466.GY;ZEFRDCHT30DSK.RDC;RHATC2466.GN;RTFLPT3048.BC.NN;ZFRDCHT36DSK.SDC;TZFLPT2448.BC.EN;SICEHATTTFL3666N;TTRT3672URE;EVRHAT2466.GY;SICECHBE2244260LH;ZEFRDCHT36DSK.RDC;ECRHATE1304260.C.GN;ECRHATE1244266.C.GN;RHATC2466.GY;RTFLDT3660.BC.EN;RTDFXT3048.BC.NN;RDCH42DSK.RDC;SICECHBE1304260;EVRHAT2454.GY;SQTT30DSK.RDC;EVRHAT2466.GN;CHATE22436.C.GN;BT3060FTB0.NN;SICECHBE1304266;RTFXT1860.BC.NG;ZEFRDT42DSK.RDC;SICEHATTTFL3672Y;SICEHATT2448Y;TTTZT2448TFL.GY1;EVRHAT3060.GN;TTMMOD48;EVCHAT2448.C.GY;SQCH30DSK.RDC;ECLHATE1664224.C.GN;EVRHAT3060TFL.GY;RTFXT2448.GL.NN;EVCHAT3048.S.GN;CHATE22436.S.GN;RDCH36.GL;CHATE23042.C.GN;CHATE22448.S.GN;ZFRDT42DSK.SDC;RD42FTB7;ZFRDT42;RTFLDT3672.GL.NN;RTFXT2472.GL.EN;ZEFMT;EVRHAT3066TFL.GY;RHATC3054.GN;TTRT3048URE;CHATE12442.C.GY;SICEHATTTFL2472N;SICECHBE1304272;RT2460EB4.NN;SICEHATTTFL2448N;EVRHAT3048.GN;SICHATBASEE22454;RTDFXT2448.GL.NN;SQ36FTB6;TTLMOD48;EVCHAT2448.C.GN;EVRHAT3666.GN;SICEHATTTFL2472Y;TTHRT3060TFL.GY1;RTFXT3060.GL.NG;SICCEHATT3048N.C;EVRHAT3048.GY;SQTT36.BC;SICCEHATT2448TFLY.C;RDTT42DSK.RDC;RTFXT3072.BC.EN;RTFXT3060.GL.NN;HRFLPT3060.BC.EN;ZEFSQCHT42DSK.RDC;ZEFSQT36DSK.RDC;RTFLDT3672.GL.EN;RTFLDT3072.BC.EN;EVRHAT3066.GN;RHATE23042.GN;TTQR30TFL;SICEHATT2466N;SICCEHATT3048N.S;TZFXT2448.GL.NG;RTFXT3048.BC.NG;RTFXT3072.BC.NN;SICHATBASEE22460");
        }
    }
}
