using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace LevelReader.GameFrameWork
{
    public class TiledMap
    {

        #region Variables
        private Dictionary<String, int[,]> _layers;
        private String[] _layerNames;
        private int _width;
        private int _height;
        private int _tileWidth;
        private int _tileHeight;
        #endregion

        #region Properties
        public int NumberOfLevels { get {return _layers.Count;} }

        public Dictionary<string, int[,]> Layers { get { return _layers; } }

        public int Width { get { return _width; } }

        public int Height { get { return _height; } } 

        public String[] LayerNames { get { return _layerNames; } }

        public int TileWidth { get { return _tileWidth; } }

        public int TileHeight { get { return _tileHeight; } }
        #endregion

        #region Constructor
        public TiledMap(String xmlFile)
        {
            try
            {
                XmlReader reader = XmlReader.Create(xmlFile);

                while (reader.Read())
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "map")
                        {
                            _width = Convert.ToInt32(reader.GetAttribute("width"));
                            _height = Convert.ToInt32(reader.GetAttribute("height"));
                            _tileWidth = Convert.ToInt32(reader.GetAttribute("tilewidth"));
                            _tileHeight = Convert.ToInt32(reader.GetAttribute("tileheight"));
                        }

                        if (reader.Name == "layer")
                        {
                            // read the layer into layers
                        }
                    }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Path to tmx level is wrong, make sure");
            }
            catch (Exception )
            {
                //throw new FormatException("Tmx level has wrong format - did you use xml as output");
            }
        }
        #endregion
    }
}
