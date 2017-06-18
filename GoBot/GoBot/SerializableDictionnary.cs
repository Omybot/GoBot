using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GoBot
{
    [XmlRoot("Dictionary")]
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;

            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                TKey key = default(TKey);
                TValue value = default(TValue);
                bool success = true;

                reader.ReadStartElement("Item");

                reader.ReadStartElement("Key");

                try
                {
                    key = (TKey)keySerializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    reader.Skip();
                    success = false;
                }

                reader.ReadEndElement();

                reader.ReadStartElement("Value");
                try
                {
                    value = (TValue)valueSerializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    reader.Skip();
                    success = false;
                }
                reader.ReadEndElement();

                if(success)
                    this.Add(key, value);

                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("Item");

                writer.WriteStartElement("Key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();

                writer.WriteStartElement("Value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }
        #endregion
    }
}