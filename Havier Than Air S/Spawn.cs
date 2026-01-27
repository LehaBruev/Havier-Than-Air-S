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

        Vector2f spawnPosition = new Vector2f(1300,700);

        Marshrut marsh;

        GameObject[] tanks;

        public Spawn()
        {
            spawnSprite = new Sprite(new Texture("Flag.png"));
            spawnSprite.Scale = new Vector2f(0.3f, 0.3f);
            spawnSprite.Origin = new Vector2f(50, 50);
            spawnSprite.Position = spawnPosition;

            marsh = new Marshrut();
            LoadMarshrutToEnemy();
        }

        private void LoadMarshrutToEnemy()
        {
            marsh.marshrutPoints = new Vector2f[19]
            {
             new Vector2f(1305 , 753 ),
             new Vector2f(1199, 756),
             new Vector2f(1058, 741),
             new Vector2f(950, 737),
             new Vector2f(796, 743),
             new Vector2f(704, 763),
             new Vector2f(629, 762),
             new Vector2f(568, 753),
             new Vector2f(510, 738),
             new Vector2f(348, 730),
             new Vector2f(285, 744),
             new Vector2f(253, 753),
             new Vector2f(124, 768),
             new Vector2f(81, 771),
             new Vector2f(-93, 752),
             new Vector2f(-186, 755),
             new Vector2f(-307, 757),
             new Vector2f(-525, 764),
             new Vector2f(-1001, 772)
        };

        }

        public void Update()
        {
            Program.window.Draw(spawnSprite);


        }

        public void SpawnEnemy()
        {
            Program.m_PullObjects.StartObject(spawnPosition, 0, new Vector2f(50,0), TypeOfObject.enemy);
        }


    }
}
