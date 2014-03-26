using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelReader.GameFrameWork
{
 /// <summary>
 /// THis class is used to draw tiled based maps contained in a TiledMap class
 /// supported Position,  scale, draw
 /// </summary>
    class MapObject : SpriteObject
    {
        private TiledMap _tiledMap;
        private SpriteFont _font;


        public MapObject(GameHost game) : base(game)
        {
        }

        public MapObject(GameHost game, Vector2 position) : base(game, position)
        {
        }

        public MapObject(GameHost game, Vector2 position, Texture2D texture, TiledMap tiledMap) : base(game, position, texture)
        {
            _tiledMap = tiledMap;
            
        }
        public MapObject(GameHost game, Vector2 position, Texture2D texture, TiledMap tiledMap, SpriteFont font)
            : base(game, position, texture)
        {
            _font = font;
            _tiledMap = tiledMap;

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            
            //draw the first layer from the tiledMap

            for (int i = 0; i < _tiledMap.Width; i++)
            {
                for (int j = 0; j < _tiledMap.Height; j++)
                {
                    int gidValue = _tiledMap.Layers[_tiledMap.LayerNames[0]][j, i];

                    if (gidValue != 0)
                    {
                        int x = (gidValue-1)%12*72;
                        int y = (int) ((gidValue - 1)/12)*72;
                        spriteBatch.Draw(
                            SpriteTexture,
                            new Vector2(i*70*ScaleX+PositionX, j*70*ScaleY+PositionY),
                            new Rectangle(x, y, 70, 70),
                            Color.White,
                            0f,
                            new Vector2(0, 0),
                            Scale,
                            SpriteEffects.None,
                            0f);
                    }
                }
            }

            //for (int i = 0; i < _tiledMap.Width; i++)
            //{
            //    for (int j = 0; j < _tiledMap.Height; j++)
            //    {
                  
            //        int gidValue = _tiledMap.Layers[_tiledMap.LayerNames[0]][j, i];

            //        int x = (gidValue % 12 - 1) * 72;
            //        int y = (int)((gidValue - 1) / 12) * 72;

            //        spriteBatch.DrawString(_font, gidValue.ToString(), new Vector2(i*70, j*70), Color.White);
            //        spriteBatch.DrawString(_font, "{"+x+";"+y+"}", new Vector2(70*i, 70*j+20), Color.Orange );
             
            //    }
            //}
        }
    }
}
