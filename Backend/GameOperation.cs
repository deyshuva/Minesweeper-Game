using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MineSweeperFinal.Backend
{
    class GameOperation
    {
        private XmlWriter writer;
        int id;

        public GameOperation()
        {
            writer= XmlWriter.Create("../../../game.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Game");
            writer.WriteStartElement("Move");
            id = 1;

        }

        public void addStep(int time, string playerType, string playerID, int row, int col)
        {
            writer.WriteStartElement("Step");
            writer.WriteAttributeString("id", id.ToString());
            id++;
            writer.WriteAttributeString("time", time.ToString());

            writer.WriteStartElement("Player");
            writer.WriteAttributeString("type", playerType);
            writer.WriteEndElement();

            writer.WriteStartElement("Play");
            writer.WriteAttributeString("sign", playerID);
            writer.WriteString(row.ToString());
            writer.WriteString(col.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();

        }

        public void closeWriter()
        {
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
   
        }

    }
}
