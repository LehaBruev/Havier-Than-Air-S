using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Enemies
{
    public class Tnk1: IMoovable
    {
        bool colliderStatus;

        RectangleShape shape;
        PullStatus status = PullStatus.inPool;
        TypeOfObject typeofObject = TypeOfObject.enemy;
        // Параметры Танка1
        float maxLifes = 100;

        // Переменные 
        float currentLifes;

         float tank1sizex = 82;
         float tank1sizey = 30;
         float tank1live = 250;
         float tank1speed = 5;
         float tank1cource = 790;
         float tank1destroy = 0;
         int tank1maxquantity = 62;
        Vector2f tankPosition;
        float tankAngle;

        Image allImage = new Image("uh61all.png");
        Texture body;
        Texture head;
        Texture Gun;

        Sprite bodySprite;
        Sprite headSprite;
        Sprite gunSprite;

        Vector2f headPosition = new Vector2f(35,-10); 
        Vector2f gunPosition = new Vector2f(5,8);
        float gunAngle = 35;

        int napravlenie = 1;



        //marker
        Marker marker;
        Text lifeText;


        public Tnk1()
        {
            

            body = new Texture(allImage, new IntRect(39, 884, 85, 24));
            head = new Texture(allImage, new IntRect(159, 878, 45, 12));
            Gun = new Texture(allImage, new IntRect(154, 857, 59, 6));

            bodySprite = new Sprite(body);
            headSprite = new Sprite(head);
            gunSprite = new Sprite(Gun);
            gunSprite.Origin = new Vector2f(58, 3);

            shape = new RectangleShape(new Vector2f(85,24));
            
            marker = new Marker(shape,Color.Yellow,3);
            
            
        }

        Random rand;
        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            rand = new Random();
            currentLifes = rand.Next(50,200);
            tankPosition = pos;
            tankAngle = angle;
            tank1speed = speed.X;//speed.X;
            status = PullStatus.inAir;
            colliderStatus = true;
        }

        public void Update()
        {
            tankPosition = new Vector2f(tankPosition.X - tank1speed*Program.deltaTimer.Delta(),tankPosition.Y);
            shape.Position = tankPosition;



            bodySprite.Position = tankPosition;
            headSprite.Position = bodySprite.Position + headPosition;
            gunSprite.Position = headSprite.Position + gunPosition;
            gunSprite.Rotation = gunAngle;
            Program.window.Draw(bodySprite);
            Program.window.Draw(headSprite);
            Program.window.Draw(gunSprite);
            marker.UpdatePoints(shape);
            marker.Update();
            
            lifeText = new Text(currentLifes.ToString(), Program.font, 10);
            lifeText.Position = tankPosition + new Vector2f(50, -10);
            lifeText.FillColor = Color.Yellow;
            Program.window.Draw(lifeText);

        }



        public TypeOfObject GetTypeOfObject()
        {
            return typeofObject;
        }

        public PullStatus GetCurrentPullStatus()
        {
            return status;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public Vector2f GetPosition()
        {
            return tankPosition;
        }




        public void SetDamage(IMoovable obj)
        {
            if (obj is Projectile)
            {
                currentLifes -= (obj as Projectile).projectileDamage;

            }

            if (currentLifes<=0)
            {
                ReturnToPull();
            }

        }

        private void ReturnToPull()
        {
            status = PullStatus.inPool;
            tankPosition = Program.m_PullObjects.position;

        }

        public bool GetColliderStatus()
        {
            return colliderStatus;
        }



        /*
static void tank1Draw() // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=жизни танка) [1=проявлен 2=побдит]
{

for (int i = 0; i < Tank1cicles.GetLength(1); i++)
{
if (Tank1cicles[3, i] == 1) // танк целый
{
PlaySound(tank1motorsound2, volume);
DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 8, 462, 120, 42); // спрайт танка
                                                                       //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                       //FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);
SetFillColor(Color.Yellow);
DrawText((int)Tank1cicles[1, i] - 20, (int)Tank1cicles[2, i] - 20, "" + Tank1cicles[7, i], 12);
}

if (Tank1cicles[3, i] == 2) //танк разрушен
{

DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 135, 519, 114, 35); // спрайт танка разрушенного
                                                                         //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                         // FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);

}

}

}
*/
    }
}
