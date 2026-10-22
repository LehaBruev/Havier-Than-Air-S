using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Enemies
{
    public class Base_Vehicle
    {
        //Тип объекта
        public TypeOfObject typeofObject;

        //Запчасти
        public Detal[] detaly;
        public Vector2f[] detalyPoints;

        //Маршрут движения
        public Marshrut marshrut;
        public int currentMarshrutPoint = 0;
        public float minDistToMarshPoint = 5f;

        // Параметры 
        public float maxLifes = 100;
        public float tank1speed = 15;

        // Переменные 
        public float currentLifes = 0;
        public float angle = 0;
        public Vector2f position = new Vector2f(0, 0);


        //Параметры формы коллайдера
        public RectangleShape colliderShape;
        public Collider collider;


        //marker
        public Marker marker;
        public Text lifeText;

        //Наклон на кочках
        public float targetAngleNaklon = 0;
        public float angleNaklonSpeed = 1;

        public Vector2f centerOfMass = new Vector2f(54, 63);

        public Texture textureBody;

        public Sprite spriteBody;
    }
}
