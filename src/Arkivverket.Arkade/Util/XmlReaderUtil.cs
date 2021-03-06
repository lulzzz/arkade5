﻿using System.IO;
using System.Xml;

namespace Arkivverket.Arkade.Util
{
    public class XmlReaderUtil
    {
        // Ignore DTD in XML
        private static readonly XmlReaderSettings Settings = new XmlReaderSettings
        {
            XmlResolver = null,
            DtdProcessing = DtdProcessing.Parse
        };

        public static XmlReader Read(Stream s)
        {
            return XmlReader.Create(s, Settings);
        }

        public static XmlReader Read(StringReader s)
        {
            return XmlReader.Create(s, Settings);
        }

        public static XmlReader Read(string xml)
        {
            return Read(new StringReader(xml));
        }
    }
}