using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace VBATMRC.Models
{
    public class Announcements
    {


        //public Announcements()
        //{
        //    CreateXml();
        //}

        public static void CreateXml()
        {
            var dirPath = Infrastructure.Utils.MappedApplicationPath + "App_Data";
            var di = new DirectoryInfo(dirPath);
            //Using \r and \n characters as delimeters
            var delim = new[] { '\r', '\n' };


            var announcementsList = new List<Announcement>();
            foreach (var fi in di.GetFiles("*.txt"))
            {
                var announcement = new Announcement();
                announcement.Path = dirPath;
                using (var s = new StreamReader(dirPath + "\\" + fi.Name))
                {
                    var line = s.ReadToEnd();
                    line = line.Replace("\\r", "\r");
                    string[] arrFileContent = line.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                    announcement.Link = arrFileContent[0].ToString(CultureInfo.InvariantCulture);
                    announcement.Copy = arrFileContent[1].ToString(CultureInfo.InvariantCulture);
                    announcement.Title = arrFileContent[2].ToString(CultureInfo.InvariantCulture);
                }
                announcementsList.Add(announcement);
            }

            WriteXmlFile(announcementsList, dirPath + "\\" + "xmlFile.xml");
        }

        // Write XML File to selected directory folder
        public static void WriteXmlFile(List<Announcement> ballonList, string xmlPath)
        {
            if(File.Exists(xmlPath))
                File.Delete(xmlPath);
            var settings = new XmlWriterSettings {Indent = true};
            XmlWriter xmlFileWriter;
            using (xmlFileWriter = XmlWriter.Create(xmlPath, settings))
            {
                xmlFileWriter.WriteStartElement("Root");
                foreach (var item in ballonList)
                {
                    xmlFileWriter.WriteStartElement("Msg");
                    xmlFileWriter.WriteElementString("Title", item.Title);
                    xmlFileWriter.WriteElementString("Body", item.Copy);
                    xmlFileWriter.WriteElementString("Link", item.Link);
                    xmlFileWriter.WriteElementString("Path", item.Path);
                    xmlFileWriter.WriteEndElement();
                }
                xmlFileWriter.WriteEndElement();
                xmlFileWriter.Close();
            }
        }


    }







}