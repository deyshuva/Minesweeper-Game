using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MineSweeperFinal.Backend
{
    class Operation
    {
        public void saveDatainBackend(List<Tuple<int, int>> values)
        {
            generateMinefieldXml(values);
        }

        private void generateMinefieldXml(List<Tuple<int, int>> values)
        {
            var writer = XmlWriter.Create("../../../Minefield.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Fields");
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    writer.WriteStartElement("Field");
                    writer.WriteAttributeString("row", i.ToString());
                    writer.WriteAttributeString("column", j.ToString());

                    writer.WriteStartElement("Mine");
                    if (isMineExist(values, i, j))
                    {
                        writer.WriteAttributeString("active", "yes");

                    }
                    else
                    {
                        writer.WriteAttributeString("active", "no");
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            
        }

        private bool isMineExist(List<Tuple<int, int>> values, int row, int col)
        {
            foreach (Tuple<int,int> value in values)
            {
                if (value.Item1== row && value.Item2== col)
                {
                    return true;
                }
            }
            return false;            
        }
       
        public List<Tuple<int, int>> takeMineData()
        {
            List<Tuple<int, int>> values = new List<Tuple<int, int>>();
            XmlReader xReader = XmlReader.Create("../../../Minefield.xml");
            xReader.ReadToFollowing("Field");
            do
            {
                xReader.MoveToFirstAttribute();
                int row = Int32.Parse(xReader.Value);

                xReader.MoveToNextAttribute();
                int col = Int32.Parse(xReader.Value);

                xReader.ReadToFollowing("Mine");
                xReader.MoveToFirstAttribute();
                string value = xReader.Value;
                if(value=="yes")
                {
                    Tuple<int, int> t = Tuple.Create(row, col);
                    values.Add(t);
                }
            } while (xReader.ReadToFollowing("Field"));

            return values;
         
        }




    }
}
