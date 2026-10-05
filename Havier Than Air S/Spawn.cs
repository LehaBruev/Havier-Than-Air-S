using Havier_Than_Air_S.Enemies;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Spawn
    {
        Sprite spawnSprite;

        Vector2f spawnPosition = new Vector2f(1300,750);

        public Spawn()
        {
            spawnSprite = new Sprite(new Texture("Images\\Flag.png"));
            spawnSprite.Scale = new Vector2f(0.3f, 0.3f);
            spawnSprite.Origin = new Vector2f(50, 50);
            spawnSprite.Position = spawnPosition + new Vector2f(0,-50);

            
        }

       

        public void Update()
        {
            Program.window.Draw(spawnSprite);
        }

        public void SpawnEnemy()
        {
            Program.m_PullObjects.StartObject(spawnPosition, 0, new Vector2f(50,0), TypeOfObject.enemyPVO);
        }


    }
}
