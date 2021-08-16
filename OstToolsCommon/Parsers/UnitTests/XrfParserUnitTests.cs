﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace OstToolsCommon.Parsers.UnitTests
{
    public class XrfParserUnitTests
    {

        /// <summary>
        /// Test the ParseString() method on XrfParser with XrfString const.
        /// Expected result of true
        /// </summary>
        [Fact]
        public void ParseString_XrfString_ReturnTrue()
        {
            var xrfParser = new XrfParser();
            var models = xrfParser.ParseString(XrfString).ToList();

            Assert.True(models.Count == 151);
        }

        /// <summary>
        /// Test the ParseFileAsync() method with XrfPath as the parameter.
        /// Expected result is True.
        /// </summary>
        [Fact]
        public void ParseFileAsync_XrfPath_ReturnTrue()
        {
            var xrfParser = new XrfParser();
            var models = xrfParser.ParseFileAsync(_xrfPath).Result.ToList();

            Assert.True(models.Count == 151);
        }

        /// <summary>
        /// Test the Parse All Lines with a array of lines.
        /// Expected result is true.
        /// </summary>
        [Fact]
        public void ParseAllLines_XrfLines_ReturnTrue()
        {
            var xrfParser = new XrfParser();
            var models = xrfParser.ParseAllLines(XrfLines()).ToList();

            Assert.True(models.Count == 151);
        }

        /// <summary>
        /// Path to locally stored XRF text file.
        /// </summary>
        private readonly string _xrfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"XRF.TXT");

        /// <summary>
        /// String representation of a XRF file
        /// </summary>
        private const string XrfString = @"PN=VFV252R120960
PV=12W PANEL
3D=3VFV252R120960
PN=VFV252R180960
PV=18W PANEL
3D=3VFV252R180960
PN=VFV252R240960
PV=24W PANEL
3D=3VFV252R240960
PN=VFV252R300960
PV=30W PANEL
3D=3VFV252R300960
PN=VFV252R360960
PV=36W PANEL
3D=3VFV252R360960
PN=VFV252R420960
PV=42W PANEL
3D=3VFV252R420960
PN=VFV252R480960
PV=48W PANEL
3D=3VFV252R480960
PN=VFV252R121080
PV=12W PANEL
3D=3VFV252R121080
PN=VFV252R181080
PV=18W PANEL
3D=3VFV252R181080
PN=VFV252R241080
PV=24W PANEL
3D=3VFV252R241080
PN=VFV252R301080
PV=30W PANEL
3D=3VFV252R301080
PN=VFV252R361080
PV=36W PANEL
3D=3VFV252R361080
PN=VFV252R421080
PV=42W PANEL
3D=3VFV252R421080
PN=VFV252R481080
PV=48W PANEL
3D=3VFV252R481080
PN=VFV252R121200
PV=12W PANEL
3D=3VFV252R121200
PN=VFV252R181200
PV=18W PANEL
3D=3VFV252R181200
PN=VFV252R241200
PV=24W PANEL
3D=3VFV252R241200
PN=VFV252R301200
PV=30W PANEL
3D=3VFV252R301200
PN=VFV252R361200
PV=36W PANEL
3D=3VFV252R361200
PN=VFV252R421200
PV=42W PANEL
3D=3VFV252R421200
PN=VFV252R481200
PV=48W PANEL
3D=3VFV252R481200
PN=VFV252T120960
PV=12W PANEL
3D=3VFV252T120960
PN=VFV252T180960
PV=18W PANEL
3D=3VFV252T180960
PN=VFV252T240960
PV=24W PANEL
3D=3VFV252T240960
PN=VFV252T300960
PV=30W PANEL
3D=3VFV252T300960
PN=VFV252T360960
PV=36W PANEL
3D=3VFV252T360960
PN=VFV252T420960
PV=42W PANEL
3D=3VFV252T420960
PN=VFV252T480960
PV=48W PANEL
3D=3VFV252T480960
PN=VFV252T121080
PV=12W PANEL
3D=3VFV252T121080
PN=VFV252T181080
PV=18W PANEL
3D=3VFV252T181080
PN=VFV252T241080
PV=24W PANEL
3D=3VFV252T241080
PN=VFV252T301080
PV=30W PANEL
3D=3VFV252T301080
PN=VFV252T361080
PV=36W PANEL
3D=3VFV252T361080
PN=VFV252T421080
PV=42W PANEL
3D=3VFV252T421080
PN=VFV252T481080
PV=48W PANEL
3D=3VFV252T481080
PN=VFV252T121200
PV=12W PANEL
3D=3VFV252T121200
PN=VFV252T181200
PV=18W PANEL
3D=3VFV252T181200
PN=VFV252T241200
PV=24W PANEL
3D=3VFV252T241200
PN=VFV252T301200
PV=30W PANEL
3D=3VFV252T301200
PN=VFV252T361200
PV=36W PANEL
3D=3VFV252T361200
PN=VFV252T421200
PV=42W PANEL
3D=3VFV252T421200
PN=VFV252T481200
PV=48W PANEL
3D=3VFV252T481200
PN=VFD252R1209607H
PV=12W PANEL
3D=3VFD252R1209607H
PN=VFD252R1809607H
PV=18W PANEL
3D=3VFD252R1809607H
PN=VFD252R2409607H
PV=24W PANEL
3D=3VFD252R2409607H
PN=VFD252R3009607H
PV=30W PANEL
3D=3VFD252R3009607H
PN=VFD252R3609607H
PV=36W PANEL
3D=3VFD252R3609607H
PN=VFD252R4209607H
PV=42W PANEL
3D=3VFD252R4209607H
PN=VFD252R4809607H
PV=48W PANEL
3D=3VFD252R4809607H
PN=VFD252R5409607H
PV=54W PANEL
3D=3VFD252R5409607H
PN=VFD252R6009607H
PV=60W PANEL
3D=3VFD252R6009607H
PN=VFD252R1210807H
PV=12W PANEL
3D=3VFD252R1210807H
PN=VFD252R1810807H
PV=18W PANEL
3D=3VFD252R1810807H
PN=VFD252R2410807H
PV=24W PANEL
3D=3VFD252R2410807H
PN=VFD252R3010807H
PV=30W PANEL
3D=3VFD252R3010807H
PN=VFD252R3610807H
PV=36W PANEL
3D=3VFD252R3610807H
PN=VFD252R4210807H
PV=42W PANEL
3D=3VFD252R4210807H
PN=VFD252R4810807H
PV=48W PANEL
3D=3VFD252R4810807H
PN=VFD252R5410807H
PV=54W PANEL
3D=3VFD252R5410807H
PN=VFD252R6010807H
PV=60W PANEL
3D=3VFD252R6010807H
PN=VFD252R1212007H
PV=12W PANEL
3D=3VFD252R1212007H
PN=VFD252R1812007H
PV=18W PANEL
3D=3VFD252R1812007H
PN=VFD252R2412007H
PV=24W PANEL
3D=3VFD252R2412007H
PN=VFD252R3012007H
PV=30W PANEL
3D=3VFD252R3012007H
PN=VFD252R3612007H
PV=36W PANEL
3D=3VFD252R3612007H
PN=VFD252R4212007H
PV=42W PANEL
3D=3VFD252R4212007H
PN=VFD252R4812007H
PV=48W PANEL
3D=3VFD252R4812007H
PN=VFD252R5412007H
PV=54W PANEL
3D=3VFD252R5412007H
PN=VFD252R6012007H
PV=60W PANEL
3D=3VFD252R6012007H
PN=VFD252R1210808H
PV=12W PANEL
3D=3VFD252R1210808H
PN=VFD252R1810808H
PV=18W PANEL
3D=3VFD252R1810808H
PN=VFD252R2410808H
PV=24W PANEL
3D=3VFD252R2410808H
PN=VFD252R3010808H
PV=30W PANEL
3D=3VFD252R3010808H
PN=VFD252R3610808H
PV=36W PANEL
3D=3VFD252R3610808H
PN=VFD252R4210808H
PV=42W PANEL
3D=3VFD252R4210808H
PN=VFD252R4810808H
PV=48W PANEL
3D=3VFD252R4810808H
PN=VFD252R5410808H
PV=54W PANEL
3D=3VFD252R5410808H
PN=VFD252R6010808H
PV=60W PANEL
3D=3VFD252R6010808H
PN=VFD252R1212008H
PV=12W PANEL
3D=3VFD252R1212008H
PN=VFD252R1812008H
PV=18W PANEL
3D=3VFD252R1812008H
PN=VFD252R2412008H
PV=24W PANEL
3D=3VFD252R2412008H
PN=VFD252R3012008H
PV=30W PANEL
3D=3VFD252R3012008H
PN=VFD252R3612008H
PV=36W PANEL
3D=3VFD252R3612008H
PN=VFD252R4212008H
PV=42W PANEL
3D=3VFD252R4212008H
PN=VFD252R4812008H
PV=48W PANEL
3D=3VFD252R4812008H
PN=VFD252R5412008H
PV=54W PANEL
3D=3VFD252R5412008H
PN=VFD252R6012008H
PV=60W PANEL
3D=3VFD252R6012008H
PN=VFD252R1212009H
PV=12W PANEL
3D=3VFD252R1212009H
PN=VFD252R1812009H
PV=18W PANEL
3D=3VFD252R1812009H
PN=VFD252R2412009H
PV=24W PANEL
3D=3VFD252R2412009H
PN=VFD252R3012009H
PV=30W PANEL
3D=3VFD252R3012009H
PN=VFD252R3612009H
PV=36W PANEL
3D=3VFD252R3612009H
PN=VFD252R4212009H
PV=42W PANEL
3D=3VFD252R4212009H
PN=VFD252R4812009H
PV=48W PANEL
3D=3VFD252R4812009H
PN=VFD252R5412009H
PV=54W PANEL
3D=3VFD252R5412009H
PN=VFD252R6012009H
PV=60W PANEL
3D=3VFD252R6012009H
PN=VFD252T1209607H
PV=12W PANEL
3D=3VFD252T1209607H
PN=VFD252T1809607H
PV=18W PANEL
3D=3VFD252T1809607H
PN=VFD252T2409607H
PV=24W PANEL
3D=3VFD252T2409607H
PN=VFD252T3009607H
PV=30W PANEL
3D=3VFD252T3009607H
PN=VFD252T3609607H
PV=36W PANEL
3D=3VFD252T3609607H
PN=VFD252T4209607H
PV=42W PANEL
3D=3VFD252T4209607H
PN=VFD252T4809607H
PV=48W PANEL
3D=3VFD252T4809607H
PN=VFD252T5409607H
PV=54W PANEL
3D=3VFD252T5409607H
PN=VFD252T6009607H
PV=60W PANEL
3D=3VFD252T6009607H
PN=VFD252T1210807H
PV=12W PANEL
3D=3VFD252T1210807H
PN=VFD252T1810807H
PV=18W PANEL
3D=3VFD252T1810807H
PN=VFD252T2410807H
PV=24W PANEL
3D=3VFD252T2410807H
PN=VFD252T3010807H
PV=30W PANEL
3D=3VFD252T3010807H
PN=VFD252T3610807H
PV=36W PANEL
3D=3VFD252T3610807H
PN=VFD252T4210807H
PV=42W PANEL
3D=3VFD252T4210807H
PN=VFD252T4810807H
PV=48W PANEL
3D=3VFD252T4810807H
PN=VFD252T5410807H
PV=54W PANEL
3D=3VFD252T5410807H
PN=VFD252T6010807H
PV=60W PANEL
3D=3VFD252T6010807H
PN=VFD252T1212007H
PV=12W PANEL
3D=3VFD252T1212007H
PN=VFD252T1812007H
PV=18W PANEL
3D=3VFD252T1812007H
PN=VFD252T2412007H
PV=24W PANEL
3D=3VFD252T2412007H
PN=VFD252T3012007H
PV=30W PANEL
3D=3VFD252T3012007H
PN=VFD252T3612007H
PV=36W PANEL
3D=3VFD252T3612007H
PN=VFD252T4212007H
PV=42W PANEL
3D=3VFD252T4212007H
PN=VFD252T4812007H
PV=48W PANEL
3D=3VFD252T4812007H
PN=VFD252T5412007H
PV=54W PANEL
3D=3VFD252T5412007H
PN=VFD252T6012007H
PV=60W PANEL
3D=3VFD252T6012007H
PN=VFD252T1210808H
PV=12W PANEL
3D=3VFD252T1210808H
PN=VFD252T1810808H
PV=18W PANEL
3D=3VFD252T1810808H
PN=VFD252T2410808H
PV=24W PANEL
3D=3VFD252T2410808H
PN=VFD252T3010808H
PV=30W PANEL
3D=3VFD252T3010808H
PN=VFD252T3610808H
PV=36W PANEL
3D=3VFD252T3610808H
PN=VFD252T4210808H
PV=42W PANEL
3D=3VFD252T4210808H
PN=VFD252T4810808H
PV=48W PANEL
3D=3VFD252T4810808H
PN=VFD252T5410808H
PV=54W PANEL
3D=3VFD252T5410808H
PN=VFD252T6010808H
PV=60W PANEL
3D=3VFD252T6010808H
PN=VFD252T1212008H
PV=12W PANEL
3D=3VFD252T1212008H
PN=VFD252T1812008H
PV=18W PANEL
3D=3VFD252T1812008H
PN=VFD252T2412008H
PV=24W PANEL
3D=3VFD252T2412008H
PN=VFD252T3012008H
PV=30W PANEL
3D=3VFD252T3012008H
PN=VFD252T3612008H
PV=36W PANEL
3D=3VFD252T3612008H
PN=VFD252T4212008H
PV=42W PANEL
3D=3VFD252T4212008H
PN=VFD252T4812008H
PV=48W PANEL
3D=3VFD252T4812008H
PN=VFD252T5412008H
PV=54W PANEL
3D=3VFD252T5412008H
PN=VFD252T6012008H
PV=60W PANEL
3D=3VFD252T6012008H
PN=VFD252T1212009H
PV=12W PANEL
3D=3VFD252T1212009H
PN=VFD252T1812009H
PV=18W PANEL
3D=3VFD252T1812009H
PN=VFD252T2412009H
PV=24W PANEL
3D=3VFD252T2412009H
PN=VFD252T3012009H
PV=30W PANEL
3D=3VFD252T3012009H
PN=VFD252T3612009H
PV=36W PANEL
3D=3VFD252T3612009H
PN=VFD252T4212009H
PV=42W PANEL
3D=3VFD252T4212009H
PN=VFD252T4812009H
PV=48W PANEL
3D=3VFD252T4812009H
PN=VFD252T5412009H
PV=54W PANEL
3D=3VFD252T5412009H
PN=VFD252T6012009H
PV=60W PANEL
3D=3VFD252T6012009H
PN=VFD254T1209607H
PV=12W PANEL
3D=3VFD252T1209607H";

        /// <summary>
        /// Get Xrf Lines from Xrf String
        /// </summary>
        /// <returns>Array with blank lines in XRF string</returns>
        private IEnumerable<string> XrfLines()
        {
            return XrfString.Split('\r', '\n');
        }

    }

}
