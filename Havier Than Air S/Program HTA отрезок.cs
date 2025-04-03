using System;
using SFML.Window;
using SFML.Graphics;



class Program : Game
{
    //загрузка ресурсов

    //

    //ТЕКСТУРЫ
    static string backgroundLevel3 = LoadTexture("BackGroundLevel3.png");
    //static string backgroundLevel2 = LoadTexture("BackGroundLevel2.png");
    static string backgroundLevel1 = LoadTexture("BackGroundLevel1.png");
    static string uh61 = LoadTexture("uh61all.png");
    static string aiming = LoadTexture("aim.png");
    static string maimenutexture = LoadTexture("mainmenu.png");
    static string scoresprite = LoadTexture("score1back.png");


    static Random rnd = new Random();

    //ЗВУКИ
    static int warningdelay = 0;
    static int sounds = 1;
    static int volume = 85;
    static string rocketsound = LoadSound("rocket1.wav");
    static string click = LoadSound("buttonclick.wav"); //щелчек кнопки
    static string stopengine = LoadSound("hw_spindown.wav"); //щелчек кнопки
    static string bangsound = LoadSound("explode4.wav"); //взрыв
    //static string startengine = LoadSound("hw_spinup.wav"); //Запуск двигателя
    static string startenginesound = LoadSound("zapusk2.wav"); //Запуск двигателя
    static string helirotor1 = LoadSound("ap_rotor4on.wav"); //Вертолет включен
    static string helirotor2 = LoadSound("ap_rotor3down.wav"); //Вертолет падает
    static string helirotor3 = LoadSound("ap_rotor2earth.wav"); //
    static string helirotor4 = LoadSound("ap_rotorhigh.wav"); // Верталет ПЕРЕГРУЗКА
    static string helisound = LoadSound("hw_spindown.wav");
    static string proverupravlenie = LoadSound("FlightControls.wav");
    static string rubejvozvrata = LoadSound("Bingo.wav");
    static string sbrosoboroti = LoadSound("sbrosoboroti.wav");
    static string checkpointsound = LoadSound("mine_deploy.wav"); //чекпоинт, звук мины из хл
    static string tank1motorsound = LoadSound("rotormachine.wav"); //чекпоинт, звук мины из хл
    static string tank1motorsound2 = LoadSound("tankidle2.wav"); //чекпоинт, звук мины из хл
    static string helionpadsound = LoadSound("warn3.wav"); // верталет на базе
    static string metal1 = LoadSound("metal1.wav"); // касание земли
    static string metal2 = LoadSound("metal2.wav"); // касание земли 2
    static string pumper = LoadSound("pumper.wav"); // заправка
    static string zapmachine = LoadSound("zapmachine.wav"); // заправка
    static string cansel = LoadSound("button2.wav"); // заправка
    static string grass1 = LoadSound("glass3.wav"); // стекло
    static string grass2 = LoadSound("glass4.wav"); // стекло2
    static string pvosound = LoadSound("pvo1.wav"); //пво ракета
    static string minus = LoadSound("minus.wav"); //минус 1 на базе
    static string MissileMissile = LoadSound("MissileMissile.wav"); //определи направление угрозу
    static string MasterWarningsound = LoadSound("MasterWarning.wav"); //мастер предупреждение
    static string soundotkazHydro = LoadSound("Hydro.wav"); //гидростистема
    static string soundotkazols = LoadSound("OLS.wav"); //олс
    static string soundotkazpojar = LoadSound("EngineFire.wav"); //пожар
    static string enginerepairsound = LoadSound("signalgear1.wav"); //ремонт мотора

    static string Music3Level = LoadMusic("airvolfbig.wav"); // Музыка аирвольв
    static string Level1Music = LoadMusic("Level1Music.wav"); //Левел 1 музыка
    static string StoreMusic = LoadMusic("topgun3.wav"); //Магазинчик
    static string mainmenumusic = LoadMusic("mainmenumusic.wav"); //Вертолет рабочий режим звука
    static string finalmusic = LoadMusic("finalmusic.wav"); //Вертолет рабочий режим звука
    static string musicotkazsistem = LoadMusic("musicotkazsistem.wav"); //Музыка для напряженной обстановке

    //Звуки2
    static string kg500 = LoadSound("Fuel500.wav"); //500кг
    static string kg800 = LoadSound("Fuel800.wav"); //800кг
    static string puskrazreshen = LoadSound("ShootShoot.wav"); //Пуск разрешен
    static string nrrocketreloadsound = LoadSound("nrpusto.wav"); // ракеты заряжены
    static string proverpokazaniya = LoadSound("WarningWarning.wav"); // проверь показания приборов
    static string radaractive = LoadSound("tu_active.wav"); // Бук поиск цели
    static string collisionmet = LoadSound("ric_metal-2.wav"); // Столкновение с металлом
    // Плейлист
    static string playingmusic;// Текущая песня
    static string playlistmusic;// Текущая песня

    // Переменные доступные всем методам и функциям

    //Меню
    static int mainmenuSwitch = 1;
    static int levelchoise = 0;
    static int menuchoise2 = 0;
    static int newgame = 0;
    static int gameplaying = 0;
    static int menudelay = 50;
    static int podskazkaswitch = 1;



    //Настройки прицеливания
    static float aimlehght = 180;

    //Вычисление угла ГЕОМЕТРИЯ
    static float searchA = 0; //y
    static float searchB = 0; //x
    static float searchline = 0; // диагональ
    static float searchangle = 0; // угол
    static float x1 = 0; // координаты
    static float x2 = 0; // координаты
    static float y1 = 0; // координаты
    static float y2 = 0; // координаты
    static double d = 0; // расстояние между двумя точками
    static float aimangle = 0; // угол до цели

    //Параметры МИРА и ВЕРТАЛЕТА
    static float wind = 0; //Сила ветра
    static float ground = 700; //Уровень земли
    static float gravityweight = 20000; //Сила притяжения
    static float playerx = 50;
    static float playery = 400;
    static float speedx = 0;
    static float speedxmax = 2.5f;
    static float speedy = 0;
    static float powery = 0;
    static float enginespeed = 19500; //Обороты двигателя
    static float maxenginespeed = 60000; //Максимальные обороты двигателя
    static float enginespeedlimit = 45000; //Предельные обороты двигателя

    static float angle = 0; //угол атаки верталета

    static float airP = 0; //плотность воздуха
    static float boostv = 0; //ускорение вертикальное
    static float autopilotv = 0; // автопилот переменная, задает высоту полета
    static float autopilotswitchX = 0; //автопилот вертикальный, удерживает высоту
    static float autopilotzonax = 0; //Автопилот возврат в зону полета
    static float autopilotzonaangle = 0; //Автопилот возврат в зону полета
    static float autopilotzonaswitch = 0; //Автопилот возврат в зону полета
    static int g = 0;
    static int helidestroy = 0; // верталет разрушен
    static int helistop = 0; // вертолет обесточен


    //Настройки верталета

    static float helilife = 100;// жизни
    static float manageability = 5;// управляемость
    static float helilifemax = 300;// максимальные жизни Вертолета
    static float helienginelife = 100; //исправность двигателя Вертолета
    static int engineswitch = 1; // включение двигателя
    static int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
    static float fuelrashod = 1; // расход топлива

    static float altitude = 200; // Высота

    static float maxangle = 65; // Максимальный угол атаки
    static float helifuel = 950; // Топливо в баках
    static float helifuelmax = 1300; // Максимальное топливо в баках
    static int bang1 = 1;

    static float maxboost = 11250; // максимальное ускорение от двигателя


    // ИГРОК
    static float startx = 50; //Начальная позиция игрока
    static float starty = 400; //Начальная позиция игрока
    static float playerh = 35; // высота вертолета
    static float playerl = 50; // длина вертолета
    static float maxpowery = 300000; //Максимальная сила влияет на вертолет
    static float maxpowerx = 30000; // 
    static float shagengine = 75; // шаг увеличения мощности двигателя
    static float shagAngle = 2; // шаг изменения угла атаки
    static float maxspeedhor = 50;
    static float maxspeedvert = 300;
    static float maxheigh = 575; // потолок полета


    //ВООРУЖЕНИЕ ВЕРТАЛЕА
    static int gunmode = 0;

    // NR ракеты МОДЕ 2
    static float NRrocketlenght = 20;
    static float NRrocketpower = 47;
    static float NRrocketweight = 100; //вес ракеты
    static float NRrocketspeed = 4; // скорость NR неуправляемых ракет
    static int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
    static int nrfuel = 400; // запас хода NR неуправляемых ракет

    // Верталетная площадка PAD STORE   PAD STORE           PAD STORE       PAD STORE
    static float padx = 50;
    static float pady = 700;
    static float padsizex = 137;
    static float padsizey = 66;
    static float padswitch = 0;
    static int padload = 0;
    static int storechoise = 0;
    static int padstoreswitch = 0;
    static float paddelay = 100; //Время до загрузки следующей ракеты
    static int NRrocketchecklaunch = 0; //счетчик ракет
    static int donatswitch = 0; //счетчик ракет
    //gita
    static float gitadelay = 2000; //счетчик ракет
    static float G = 0; //счетчик ракет
    static int gitaswitch = 0; //счетчик ракет


    //цены
    static float fuelcost = 900; //цена топлива
    static float rocketcost = 800; //цена ракет
    static float partscost = 350; //цена запчастей

    //корзина
    static float fuelinbag = 100; //топливо на складе
    static float nrrocketsinbag = 100; //ракеты на складе
    static float partsinbag = 100; //Запчасти в корзине


    //ПРОТИВНИКИ
    //Переменные БУК1
    static float bukx = 1000;
    static float buky = 700;
    static float buk1sizey = 50; // высота
    static float buk1sizex = 80; // длина
    static float bukspeed = 1.5f; // длина
    static float bukhold = 0; // длина
    static float buklife = 500; // длина
    static float buk1maxquantity = 5; // длина

    static float buk1destroy = 0;
    static float bukcoursex = 350;

    //Параметры Штурмовика A10
    static float a10lenght = 100;
    static float a10high = 100;
    static float a10x = -300;
    static float a10y = 300;
    static float a10startx = 1500;
    static float a10starty = 200;
    static float a10speed = 3;
    static float a10ammo = 3;
    static float a10delay = 5; //Задержка между полетами штурмовиков
                               // A10Rockets
    static int a10rocketquantity = 20; //количество ракет в А10
    static float a10rocketdmg = 27; // урон от ракет A10
    static float a10rockethigh = 15; // колайдер У ракет А10
    static float a10rocketlenght = 57; // коллайдер Х ракет А10
    static float a10rocketspeed = 5; // скорость ракеты А10
    static float a10rocketpower = 10;

    //Параметры ПВО
    static float pvox = 0;
    static float pvoy = 0;
    static float pvospeed = 2f;
    static float pvoangle = 0;
    static float pvoturnability = 3;
    static float pvolenght = 25;
    static float pvofuel = 900;
    static int bukactivated = 0;
    static int pvodirectionx = 1;
    static int pvodirectiony = 1;
    static int pvorocketdirection = 0; //Направление полета ракеты
    static float pvopower = 30; //Направление полета ракеты

    //Параметры Танка1
    static float tank1x = 300;
    static float tank1y = ground;
    static float tank1sizex = 82;
    static float tank1sizey = 30;
    static float tank1live = 250;
    static float tank1speed = 2;
    static float tank1cource = 790;
    static float tank1destroy = 0;
    static int tank1maxquantity = 62;

    //Параметры воздушный шар

    static float airballonsizex = 90;
    static float airballonsizey = 90;



    //Эффекты
    static float explosivepower = 8;
    static float bangradius = 52;
    static float maxbangsquantity = 20; //максимальное количество взрывов одновременно


    //Миссии
    static int checkdelay = 50;
    static int missionswitch = 0;
    static int volnadelay = 0;
    static int volnadelay2 = 0;
    static int basedurability = 10;
    static int winpobeda = 0;



    //результаты
    static float resultsmenuswitch = 0; //меню результатов
    static float resultmenuchoise = 0; //меню результатов ывбор кнопки
    static float money = 0; //очки
    static float hiscore = 0; //рекорд очков
    static float flighttime = 0; //время нахождения в воздухе
    static float flighttimerecord = 0; //рекорд нахождения в воздухе
    static float landingquantity = 0; //количество посадок
    static float NRrocketslaunched = 0; //выпущено NR ракет количество
    static float targetbingos = 0; //попаданий по цели
    static float buk1destroyes = 0; //уничтожено буков1
    static float tank1destroyes = 0; //уничтожено танков1
    static float fuelusedup = 0; //израсходовано топлива
    static float repairings = 0; //Отремонтирован вертолет
    static float getdamages = 0; //Получено повреждений

    //награды
    static float tank1reward = 10000; //Получено повреждений
    static float buk1reward = 30000; //Получено повреждений
    //static float repairings = 0; //Отремонтирован вертолет

    //Поломки
    static int otkazhydrosis = 0; // Гидросистема
    static int otkazmasterwarning = 0; // Матерсвитч
    static int otkazols = 0; // Оптико локационная станция
    static int otkazraketasprava = 0; //ракета справа
    static int otkazraketasleva = 0; //Ракета слева
    static int otkazpojardvig = 0; // Пожар двигателя
    static int otkazsbrosoboroti = 0; //Пожар двигателя
    static int delayrita = 350; //Пожар двигателя
    static float ratioenginespeed = 1; //Пожар двигателя
    static float pojardelay = 1000; //Пожар двигателя начнется
    static int peregruzkamotora = 0; //Пожар двигателя начнется
    static float ritarandom = 1; //рандом для прицела



    static Random rnd1 = new Random(); //рандомчик

    // Массивы

    // NR неуправляемая ракета Верталета МОДЕ 2
    static float[,] R = new float[6, nrrocketsMaxquantity]; // NR ракета верталета (1=x ракеты, 2=y ракеты, 3=angle ракеты, 4=fuel ракеты, 5=ракета проявлена)

    static float[,] R10 = new float[5, a10rocketquantity]; // Ракета А10 (1=x ракеты, 2=y ракеты, 3=fuel ракеты, 4=ракета проявлена)

    static float[,] Bang1 = new float[7, (int)maxbangsquantity]; // Взрыв1 (1=x взрыва, 2=y взрыва, 3=спрайт взрыва, 4=взрыв проявлен,5=делей 6=волна актив)  // 1 проявлен 0 непроявлен

    static float[] checkpoints = new float[100]; // Чекпоинты Миссий Значения: 0 - задание провалено, 1 - задание скрыто, 2 - задание выполняется, 3 - задание выполнено

    static float[] checkpoints2 = new float[10]; // Чекпоинты подмиссий Значения: 0 - задание провалено, 1 - задание скрыто, 2 - задание выполняется, 3 - задание выполнено

    static float[,] airballonscicle = new float[6, 10]; // Шары Воздушные 1=х шара, 2=у шара, 3=шар проявлен, 4=х цели шара, 5=у цели шара

    static float[,] Tank1cicles = new float[8, 62]; // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)

    static float[,] Buk1cicles = new float[10, 15]; // Бук1 (1=x бука , 2=y бука, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость бука, 7=жизни, 8= делэй запуска)

    static float[,] pvocicles = new float[10, 10]; // ПВО ракета (1=x пво , 2=y пво, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость пво, 7=топливо, 8= угол полета)

    static float[] otkazcicle = new float[10]; //1= управляемость 2=шаг угла атаки 3=актив ошибка гидросист
    // Методы
    static void searchdistance() // Вычисление расстояния между двумя точками
    {
        d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

    }

    static void searchAB() //вычисляем поправки координат синусом и косинусом стороны А и Б прямоугольника (прицелы)
    {
        // вычисление y
        const float pi = 3.14f;
        float rad = searchangle / 180 * pi; //Радиальный угол
        double sin = Math.Sin(rad); //синус а
        double sin2 = Math.Sqrt(sin * sin);
        double g = searchline; //длина прицела, ракеты (расстояние без углов до крайней точки)
        double yside = g * sin2;
        searchB = (float)yside;//перевод во float, горизонтальная поправка для Y

        // вычисление x
        double cos = Math.Cos(rad); //косинус а
        double cos2 = Math.Sqrt(cos * cos);
        double xside = g * cos2;
        searchA = (float)xside; // вертикальная поправка для X

    }




    //ПРОТИВНИКИ //ПРОТИВНИКИ //ПРОТИВНИКИ //ПРОТИВНИКИ //ПРОТИВНИКИ



    // Шары Шары Шары
    static void airballondraw()

    {

        for (int i = 0; i < airballonscicle.GetLength(0); i++)
        {
            if (airballonscicle[3, i] == 1)
            {
                if (airballonscicle[4, i] < airballonscicle[1, i]) airballonscicle[1, i] = airballonscicle[1, i] - 0.5f;
                if (airballonscicle[4, i] > airballonscicle[1, i]) airballonscicle[1, i] = airballonscicle[1, i] + 0.5f;
                if (airballonscicle[5, i] < airballonscicle[2, i]) airballonscicle[2, i] = airballonscicle[2, i] - 0.5f;
                if (airballonscicle[5, i] > airballonscicle[2, i]) airballonscicle[2, i] = airballonscicle[2, i] + 0.5f;

                DrawSprite(uh61, airballonscicle[1, i] - 50, airballonscicle[2, i] - 50, 301, 569, 173, 180);

            }
        }

        for (int i = 0; i < airballonscicle.GetLength(0); i++)
        {
            //FillCircle(airballonscicle[1, i], airballonscicle[2, i], 2);
            //FillCircle(airballonscicle[1, i]+airballonsizex, airballonscicle[2, i]+airballonsizey, 2);
            if (airballonscicle[1, i] < playerx + playerl && airballonscicle[1, i] + airballonsizex > playerx && airballonscicle[2, i] < playery + playerh && airballonscicle[2, i] + airballonsizey > playery && helidestroy != 1)
            {
                helilife = helilife - 11;
                getdamages = getdamages + 11;
                if (playerx < airballonscicle[1, i]) playerx = playerx - 35;
                if (playerx > airballonscicle[1, i]) playerx = playerx + 35;
                if (playery < airballonscicle[2, i]) playery = playery - 80;
                if (playery > airballonscicle[2, i]) playery = playery + 70;
                PlaySound(bangsound);

            }

        }

    }


    // Танк1
    static void tank1move()
    {
        //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
        for (int i = 0; i < Tank1cicles.GetLength(1); i++)
        {
            if (Tank1cicles[3, i] == 1)
            {
                if (Tank1cicles[1, i] + 3 < Tank1cicles[4, i]) { Tank1cicles[1, i] = Tank1cicles[1, i] + Tank1cicles[6, i]; PlaySound(tank1motorsound, volume - 30); } // цель справа
                if (Tank1cicles[1, i] - 3 > Tank1cicles[4, i]) { Tank1cicles[1, i] = Tank1cicles[1, i] - Tank1cicles[6, i]; PlaySound(tank1motorsound, volume - 30); } // цель справа
                if (Tank1cicles[1, i] < -150) { Tank1cicles[3, i] = 0; basedurability = basedurability - 1; PlaySound(minus); }
            }


        }


    }
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


    static void
        explosion()
    { // Взрыв1 (1=x взрыва, 2=y взрыва, 3=спрайт взрыва, 4=взрыв проявлен, 5=делей)  // 1 проявлен 0 непроявлен

        for (int i = 0; i < Bang1.GetLength(1); i++)
        {
            if (Bang1[4, i] == 1)
            {
                if (Bang1[3, i] == 0) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 841, 27, 54, 50); //2 спрайт
                if (Bang1[3, i] == 1) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 841, 27, 54, 50); //2 спрайт
                if (Bang1[3, i] == 2) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 957, 27, 53, 57); //2 спрайт
                if (Bang1[3, i] == 3) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1184, 22, 59, 64); //2 спрайт
                if (Bang1[3, i] == 4) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1414, 23, 62, 68); //2 спрайт
                if (Bang1[3, i] == 5) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 820, 126, 91, 85); //2 спрайт
                if (Bang1[3, i] == 6) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1285, 126, 99, 81); //2 спрайт
                if (Bang1[3, i] == 7) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 706, 240, 99, 87); //2 спрайт
                if (Bang1[3, i] == 8) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1050, 238, 97, 91); //2 спрайт
                if (Bang1[3, i] == 9) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1280, 354, 97, 93); //2 спрайт
                if (Bang1[3, i] == 10) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1280, 354, 97, 93); //2 спрайт
                if (Bang1[3, i] == 11) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1280, 354, 97, 93); //2 спрайт
                if (Bang1[3, i] == 12) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1280, 354, 97, 93); //2 спрайт
                if (Bang1[3, i] == 13) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1511, 353, 99, 99); //2 спрайт
                if (Bang1[3, i] == 14) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 705, 467, 103, 95); //2 спрайт
                if (Bang1[3, i] == 15) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 933, 467, 106, 92); //2 спрайт
                if (Bang1[3, i] == 16) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1163, 468, 108, 90); //2 спрайт
                if (Bang1[3, i] == 17) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1284, 470, 91, 85); //2 спрайт
                if (Bang1[3, i] == 18) DrawSprite(uh61, Bang1[1, i] - 40, Bang1[2, i] - 40, 1398, 470, 100, 89); //2 спрайт
            }
            Bang1[5, i] = Bang1[5, i] + 1;



            Bang1[3, i] = Bang1[5, i];
            if (Bang1[5, i] > 18) Bang1[4, i] = 0;


        }






    } // АНИМАЦИЯ ВЗРЫВА

    static void loterea()
    {

        int n = rnd1.Next(1, 8);

        if (n == 1) otkazhydrosis = 1;
        if (n == 2) otkazols = 1;
        if (n == 3) otkazpojardvig = 1;
        if (n == 4) helienginelife = helienginelife - rnd.Next(5, 10);
        if (n == 5) helienginelife = helienginelife - rnd.Next(10, 15);



    }

    static void rita()
    {
        delayrita = delayrita - 1;
        if (delayrita < 0) delayrita = 400;

        if (otkazhydrosis == 1 && delayrita == 100) PlaySound(soundotkazHydro);
        if (otkazols == 1 && delayrita == 200) PlaySound(soundotkazols);
        if (otkazpojardvig == 1 && delayrita == 300) PlaySound(soundotkazpojar);
        if (otkazsbrosoboroti == 1 && delayrita == 400) PlaySound(sbrosoboroti);


        if (helilife < 80 || helifuel < 100) PlaySound(MasterWarningsound);

        //пожар мотора
        if (otkazpojardvig == 1) helienginelife = helienginelife - 0.03f;
        if (helienginelife < 28) helienginelife = 28;


        //Перегрузка мотора overlimit
        if (enginespeed > enginespeedlimit)
        {
            pojardelay = pojardelay - 1;
            if (pojardelay < 0) otkazpojardvig = 1;
            otkazsbrosoboroti = 1;
        }
        else { pojardelay = 650; otkazsbrosoboroti = 0; }

        //отказ гидростистемы
        if (otkazhydrosis == 1 && otkazcicle[3] != 1)
        {
            otkazcicle[1] = manageability;
            otkazcicle[2] = shagAngle;
            otkazcicle[3] = 1;

            manageability = 4; //управляемость
            shagAngle = 0.8f; // угол атаки
        }

        if (otkazols == 1)
        {
            if (delayrita == 50 || delayrita == 250) ritarandom = rnd1.Next(-30, 30);

        }
        else ritarandom = 1;
    }

    //Бук1

    static void buk1Move() // Бук перемещение гусеничной платформы + ЗАПУСК ПВО БУК1
    {// Бук1 (1=x бука , 2=y бука, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость бука, 7=жизни, 8= делэй запус

        for (int i = 0; i < Buk1cicles.GetLength(1); i++)
        {
            if (Buk1cicles[3, i] == 1) Buk1cicles[8, i] = Buk1cicles[8, i] - 1; //delay
            if (Buk1cicles[8, i] == 100 && helilife > 0)
            {
                bukactivated = 1;
                PlaySound(MissileMissile);
                PlaySound(pvosound);
                pvox = Buk1cicles[1, i];
                pvoy = Buk1cicles[2, i];
                pvoangle = 45;
                pvofuel = 2000;

            }// запуск ракеты

            if (Buk1cicles[3, i] == 1 && Buk1cicles[8, i] <= 0) //
            {

                if (Buk1cicles[1, i] + 3 < Buk1cicles[4, i]) Buk1cicles[1, i] = Buk1cicles[1, i] + Buk1cicles[6, i];
                if (Buk1cicles[1, i] - 3 > Buk1cicles[4, i]) Buk1cicles[1, i] = Buk1cicles[1, i] - Buk1cicles[6, i];

            }
            //задержка перед пуском
            if (Buk1cicles[1, i] <= Buk1cicles[4, i] + 4 && Buk1cicles[1, i] >= Buk1cicles[4, i] - 4 && Buk1cicles[8, i] <= 0)
            {

                Buk1cicles[8, i] = rnd1.Next(300, 500);
                Buk1cicles[4, i] = rnd1.Next(150, 1000);
            }




        }



    }
    // Бук1 отрисовка
    static void buk1Draw()
    {

        for (int i = 0; i < Buk1cicles.GetLength(1); i++)
        {
            if (Buk1cicles[3, i] == 2)
            {
                DrawSprite(uh61, Buk1cicles[1, i], Buk1cicles[2, i] - 3, 30, 391, 89, 65);
            }


        }


        for (int i = 0; i < Buk1cicles.GetLength(1); i++)
        {

            if (Buk1cicles[3, i] == 1)
            {
                DrawSprite(uh61, Buk1cicles[1, i], Buk1cicles[2, i] - 3, 18, 304, 109, 72);
                if (sounds == 1) PlaySound(radaractive, volume - 20);
                SetFillColor(Color.Yellow);
                DrawText((int)Buk1cicles[1, i] - 20, (int)Buk1cicles[2, i] - 20, "" + Buk1cicles[7, i], 12);
            }


        }


    }

    // ПВО
    static void pvomoveANDdraw() //  ракета ПВО БУК1
    {
        // ПВО ракета(1 = x пво , 2 = y пво, 3 = проявлен, 4 = х назначения, 5 = у назначения, 6 = скорость пво, 7 = топливо, 8 = угол полета)

        // bukactivated

        if (bukactivated == 1) // пуск ПВО и передача параметров от Бука
        {
            for (int i = 0; i < pvocicles.GetLength(1); i++)
            {
                if (pvocicles[3, i] != 1)
                {
                    bukactivated = 0;
                    //МОЖНО ВСТАВИТЬ ЗВУК ЗАПУСКА
                    pvocicles[3, i] = 1;
                    pvocicles[1, i] = pvox;
                    pvocicles[2, i] = pvoy;
                    pvocicles[7, i] = pvofuel;
                    pvocicles[8, i] = pvoangle;
                    break;

                }
            }
        }

        for (int i = 0; i < pvocicles.GetLength(1); i++)
        {
            if (pvocicles[3, i] == 1)
            {
                PlaySound(MasterWarningsound);

                searchline = pvolenght;
                searchangle = pvocicles[8, i];
                searchAB();

                //отрисовка ПВО
                SetFillColor(Color.Red); // Цвет ракеты ПВО
                if (pvocicles[8, i] >= 0 && pvocicles[8, i] < 90)
                {
                    DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] + searchB, pvocicles[2, i] - searchA, 5);
                }
                if (pvocicles[8, i] >= 90 && pvocicles[8, i] < 180)
                {
                    DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] + searchB, pvocicles[2, i] + searchA, 5);
                }
                if (pvocicles[8, i] >= 180 && pvocicles[8, i] < 270)
                {
                    DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] - searchB, pvocicles[2, i] + searchA, 5);
                }
                if (pvocicles[8, i] >= 270 && pvocicles[8, i] < 360)
                {
                    DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] - searchB, pvocicles[2, i] - searchA, 5);
                }



                //изменение положения ракеты
                searchline = pvospeed;
                searchAB();

                if (pvocicles[8, i] >= 0 && pvocicles[8, i] < 90)
                {
                    pvocicles[1, i] = pvocicles[1, i] + searchB;
                    pvocicles[2, i] = pvocicles[2, i] - searchA;
                }
                if (pvocicles[8, i] >= 90 && pvocicles[8, i] < 180)
                {
                    pvocicles[1, i] = pvocicles[1, i] + searchB;
                    pvocicles[2, i] = pvocicles[2, i] + searchA;
                }
                if (pvocicles[8, i] >= 180 && pvocicles[8, i] < 270)
                {
                    pvocicles[1, i] = pvocicles[1, i] - searchB;
                    pvocicles[2, i] = pvocicles[2, i] + searchA;
                }
                if (pvocicles[8, i] >= 270 && pvocicles[8, i] < 360)
                {
                    pvocicles[1, i] = pvocicles[1, i] - searchB;
                    pvocicles[2, i] = pvocicles[2, i] - searchA;
                }

                pvocicles[7, i] = pvocicles[7, i] - 1;

                // Изменение угла ПВО
                //поиск диагонали
                x1 = playerx;
                x2 = pvocicles[1, i];
                y1 = playery;
                y2 = pvocicles[2, i];
                searchdistance();
                searchline = (float)d;
                //Ищем угол до цели

                if (playerx <= pvocicles[1, i])
                {
                    aimangle = (float)((-playery + pvocicles[2, i]) / searchline) * 90 + 270; //sin
                }
                if (playerx > pvocicles[1, i])
                {
                    aimangle = 90 + (float)((playery - pvocicles[2, i]) / searchline) * 90; //sin

                }

                //if (GetKey(Keyboard.Key.Up) == true) pvoangle = pvoangle + 5;
                //if (GetKey(Keyboard.Key.Down) == true) pvoangle = pvoangle - 5;

                if (pvocicles[8, i] < aimangle)
                {


                    if (pvocicles[8, i] + (360 - aimangle) < 360 - (360 - aimangle) - pvocicles[8, i])
                    {


                        if (pvocicles[8, i] <= 0) pvocicles[8, i] = pvocicles[8, i] + 360;
                        pvocicles[8, i] = pvocicles[8, i] - pvoturnability;

                    }
                    if (pvocicles[8, i] + (360 - aimangle) > 360 - (360 - aimangle) - pvocicles[8, i])
                    {

                        if (pvocicles[8, i] >= 360) pvocicles[8, i] = pvocicles[8, i] - 360;
                        pvocicles[8, i] = pvocicles[8, i] + pvoturnability;

                    }
                }
                if (pvocicles[8, i] >= aimangle)
                {

                    if (aimangle + (360 - pvocicles[8, i]) < 360 - (360 - pvocicles[8, i]) - aimangle)
                    {

                        if (pvocicles[8, i] >= 360) pvocicles[8, i] = pvocicles[8, i] - 360;
                        pvocicles[8, i] = pvocicles[8, i] + pvoturnability;

                    }

                    if (aimangle + (360 - pvocicles[8, i]) > 360 - (360 - pvocicles[8, i]) - aimangle)
                    {


                        if (pvocicles[8, i] <= 0) pvocicles[8, i] = pvocicles[8, i] + 360;
                        pvocicles[8, i] = pvocicles[8, i] - pvoturnability;

                    }
                }


            }
            if (pvocicles[7, i] < 0) pvocicles[3, i] = 0;
        }



    }





    static void MishenDraw() // СВОБОДНО
    {


    }


    static void DrawNRrocket() // **МОДЕ 2 неуправляемая ракета НР отрисовка
    {



    }

    static void MoveNRrocket() // неуправляемая ракета НР движение и отрисовка

    {

        for (int i = 0; i < R.GetLongLength(1); i++) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена(1 в кассете, 2 в полете, 0 потрачено)
        {
            //положение ракеты
            // вычисление х2 и у2 для отрисовки ракеты
            if (R[5, i] == 2)
            {
                searchangle = R[3, i];
                searchline = NRrocketlenght;
                searchAB();
                float a = searchA;
                float b = searchB;

                // вычисление х3 и у3 для перемещения ракеты
                searchline = NRrocketspeed;
                searchAB();

                //цвет ракеты
                SetFillColor(255, 161, 0);

                //отрисовка ракеты
                if (R[3, i] > 0 && R[3, i] < 70)
                {
                    DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] + b, 4);
                    R[1, i] = R[1, i] + searchA;
                    R[2, i] = R[2, i] + searchB;

                }
                if (R[3, i] > -70 && R[3, i] < -15)
                {
                    DrawLine(R[1, i], R[2, i], R[1, i] - a, R[2, i] + b, 4);
                    R[1, i] = R[1, i] - searchA;
                    R[2, i] = R[2, i] + searchB;
                }
                if (R[3, i] >= -15 && R[3, i] <= 0)
                {
                    DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] - b, 4);
                    R[1, i] = R[1, i] + searchA;
                    R[2, i] = R[2, i] - searchB;
                }
                R[4, i] = R[4, i] - 1; // расход топлива ракеты
                if (R[4, i] < 0)
                {
                    R[5, i] = 0;

                }


            }
        }

    }

    // ПРОТИВНИКИ ПРОТИВНИКИ ПРОТИВНИКИ


    static void a10move() // A10 движение отрисовка и запуск РАКЕТЫ
    {

        DrawSprite(uh61, a10x, a10y, 313, 438, 169, 39); // Самолет А10

        a10x = a10x - a10speed;

        for (int i = 0; i < R10.GetLength(1); i++)
        {
            if (R10[4, i] == 2)
            {

                DrawSprite(uh61, R10[1, i], R10[2, i], 391, 362, 57, 15); // Ракета А10
                                                                          // Изменяем положение ракеты
                R10[1, i] = R10[1, i] - a10rocketspeed;
                if (R10[2, i] > R10[3, i]) R10[2, i] = R10[2, i] - rnd1.Next(1, 5);
                if (R10[2, i] < R10[3, i]) R10[2, i] = R10[2, i] + rnd1.Next(1, 5);



            }

        }



    }


    // СТОЛКНОВЕНИЯ СТОЛКНОВЕНИЯ СТОЛКНОВЕНИЯ
    static void SearchConflict() // Поиск столкновений и коллизий ( Bx1 < Ax2 && Bx 2> Ax1 ) формула
    {


        //Взрывная волна
        for (int i = 0; i < Bang1.GetLength(1); i++)
        {
            if (Bang1[4, i] == 1 && Bang1[6, i] == 1)
            {
                for (int j = 0; j < Tank1cicles.GetLength(1); j++) // рикошет по танкам
                {
                    if (Tank1cicles[3, j] == 1)
                    {
                        if (Tank1cicles[1, j] < Bang1[1, i] + bangradius && Tank1cicles[1, j] + tank1sizex > Bang1[1, i] - bangradius && Tank1cicles[2, j] < Bang1[2, i] + bangradius && Tank1cicles[2, j] + tank1sizey > Bang1[2, i] - bangradius)
                        {


                            Tank1cicles[7, j] = Tank1cicles[7, j] - explosivepower;
                            if (Tank1cicles[7, j] <= 0) Tank1cicles[3, j] = 2; //танк уничтожен
                        }

                    }

                } //танк

                for (int j = 0; j < Buk1cicles.GetLength(1); j++) //рикошет по пво
                {
                    if (Buk1cicles[3, j] == 1)
                    {
                        if (Buk1cicles[1, j] < Bang1[1, i] + bangradius && Buk1cicles[1, j] + buk1sizex > Bang1[1, i] - bangradius && Buk1cicles[2, j] < Bang1[2, i] + bangradius && Buk1cicles[2, j] + buk1sizey > Bang1[2, i] - bangradius)
                        {


                            Buk1cicles[7, j] = Buk1cicles[7, j] - (explosivepower + 5);
                            if (Buk1cicles[7, j] < 0) Buk1cicles[3, j] = 2;
                        }

                    }

                } //бук1


                if (playerx < Bang1[1, i] + bangradius && playerx + playerl > Bang1[1, i] - bangradius && playery < Bang1[2, i] + bangradius && playery + playerh > Bang1[2, i] - bangradius)
                {


                    helilife = helilife - explosivepower * 2;
                    getdamages = getdamages + explosivepower * 2;
                    loterea();


                }




                Bang1[6, i] = 0;//волна прошла

            }


        }


        //Столкновение с ракетами А10
        for (int i = 0; i < R10.GetLongLength(1); i++)
        {
            if (R10[1, i] < playerx + playerl && R10[1, i] + a10rocketlenght > playerx && R10[2, i] < playery + playerh && R10[2, i] + a10rockethigh > playery && R10[4, i] == 2)
            {
                // взрыв
                for (int k = 0; k < Bang1.GetLength(1); k++)
                {
                    if (Bang1[4, k] != 1)
                    {
                        Bang1[4, k] = 1;
                        Bang1[1, k] = playerx;
                        Bang1[2, k] = playery;
                        Bang1[5, k] = 1;
                        Bang1[6, i] = 1;
                        PlaySound(bangsound);
                        break;
                    }
                }

                playerx -= rnd1.Next(8, 20);
                playery += rnd1.Next(-25, 5);
                helilife -= a10rocketpower;
                loterea();
                getdamages = getdamages + a10rocketpower;
                R10[4, i] = 0;

            }
        }

        //Столкновение Бук1 с ракетой NR
        for (int i = 0; i < R.GetLongLength(1); i++)
        {

            if (R[5, i] == 2)
            {
                searchline = NRrocketlenght;
                searchangle = R[3, i];
                searchAB();

                for (int j = 0; j < Buk1cicles.GetLength(1); j++)
                {

                    if (R[1, i] < Buk1cicles[1, j] + buk1sizex && R[1, i] + searchA > Buk1cicles[1, j] && R[2, i] < Buk1cicles[2, j] + buk1sizey && R[2, i] + searchB > Buk1cicles[2, j])
                    {
                        PlaySound(collisionmet);
                        targetbingos = targetbingos + 1;
                        buk1destroyes = buk1destroyes + 1;
                        // взрыв
                        for (int k = 0; k < Bang1.GetLength(1); k++)
                        {
                            if (Bang1[4, k] != 1)
                            {
                                Bang1[4, k] = 1;
                                Bang1[1, k] = Buk1cicles[1, j];
                                Bang1[2, k] = Buk1cicles[2, j];
                                Bang1[5, k] = 1;
                                Bang1[6, k] = 1;
                                PlaySound(bangsound);
                                break;
                            }
                        }


                        Buk1cicles[1, j] -= rnd1.Next(-15, 15);
                        R[5, i] = 0;
                        Buk1cicles[7, j] = Buk1cicles[7, j] - NRrocketpower;

                        if (Buk1cicles[7, j] <= 0 && Buk1cicles[3, j] == 1) { Buk1cicles[3, j] = 2; money = money + buk1reward; } //Бук уничтожен



                    }
                }
            }


            //  Buk1cicles[1, i]
        }

        //Столкновение Ракет NR верталета МОДЕ 2 с Танком 1
        for (int i = 0; i < R.GetLongLength(1); i++)
        {
            if (R[5, i] == 2)
            {
                searchline = NRrocketlenght;
                searchangle = R[3, i];
                searchAB();

                for (int j = 0; j < Tank1cicles.GetLength(1); j++)
                {

                    if (R[1, i] < Tank1cicles[1, j] + tank1sizex && R[1, i] + searchA > Tank1cicles[1, j] && R[2, i] < Tank1cicles[2, j] + tank1sizey && R[2, i] + searchB > Tank1cicles[2, j])
                    {
                        PlaySound(collisionmet);
                        targetbingos = targetbingos + 1;
                        tank1destroyes = tank1destroyes + 1;
                        // взрыв
                        for (int k = 0; k < Bang1.GetLength(1); k++)
                        {
                            if (Bang1[4, k] != 1)
                            {
                                Bang1[4, k] = 1;
                                Bang1[1, k] = R[1, i];
                                Bang1[2, k] = R[2, i];
                                Bang1[5, k] = 1;
                                Bang1[6, k] = 1;
                                PlaySound(bangsound);
                                break;
                            }
                        }
                        Tank1cicles[1, j] -= rnd1.Next(-15, 15);
                        R[5, i] = 0;
                        Tank1cicles[7, j] = Tank1cicles[7, j] - NRrocketpower;

                        if (Tank1cicles[7, j] <= 0 && Tank1cicles[3, j] == 1) { Tank1cicles[3, j] = 2; money = money + tank1reward; } //танк уничтожен



                    }
                }
            }
        }

        /* //Столкновение Ракет NR верталета МОДЕ 2 с БУК1
         for (int i = 0; i < R.GetLongLength(1); i++)
         {
             if (R[5, i] == 2)
             {
                 searchline = NRrocketlenght;
                 searchangle = R[3, i];
                 searchAB();

                 if (R[1, i] < bukx + buk1sizex && R[1, i] + searchA > bukx && R[2, i] < buky + buk1sizex && R[2, i] + searchB > buky)
                 {
                     PlaySound(collisionmet);
                     bukx -= rnd1.Next(-15, 15);
                     R[5, i] = 0;
                     buklife = buklife - NRrocketpower;
                     if (buklife < 0) buk1destroy = 1;

                 }
             }
         }
        // FillCircle(playerx, playery,2); //верталет
        // FillCircle(playerx + playerl, playery + playerh,2); //верталет
        // FillCircle(bukx, buky, 10); //Бук
        // FillCircle(bukx+buk1sizex, buky+buk1sizey, 2); //Бук
          */


        //Столкновение Ракет NR верталета МОДЕ 2 с Землей
        for (int i = 0; i < R.GetLongLength(1); i++)
        {
            if (R[5, i] == 2)
            {
                searchline = NRrocketlenght;
                searchangle = R[3, i];
                searchAB();

                if (R[2, i] - 35 > ground && R[2, i] + searchB - 45 > ground)
                {
                    // взрыв
                    for (int k = 0; k < Bang1.GetLength(1); k++)
                    {
                        if (Bang1[4, k] != 1)
                        {
                            Bang1[4, k] = 1;
                            Bang1[1, k] = R[1, i];
                            Bang1[2, k] = R[2, i];
                            Bang1[5, k] = 1;
                            Bang1[6, k] = 1;
                            PlaySound(bangsound);
                            break;
                        }
                    }
                    ////////// ВЗРЫВ ДОЛЖЕН ПОЯВИТЬСЯ ЗДЕСЬ!!! И ВОРОНКА ОТ ВЗРЫВА
                    R[5, i] = 0;



                }
            }
        }



        // Столкновение Вертолета и БУК1 ПВО ракеты
        for (int i = 0; i < pvocicles.GetLength(1); i++)
        {
            if (pvocicles[3, i] == 1)
            {
                if (pvocicles[1, i] < playerx + playerl && pvocicles[1, i] + pvolenght > playerx && pvocicles[2, i] < playery + playerh && pvocicles[2, i] + pvolenght > playery)
                {

                    playery += 35;
                    helilife -= pvopower;
                    loterea();
                    getdamages = getdamages + pvopower;
                    PlaySound(collisionmet);
                    // взрыв
                    // взрыв
                    for (int k = 0; k < Bang1.GetLength(1); k++)
                    {
                        if (Bang1[4, k] != 1)
                        {
                            Bang1[4, k] = 1;
                            Bang1[1, k] = playerx;
                            Bang1[2, k] = playery;
                            Bang1[5, k] = 1;
                            Bang1[6, k] = 1;
                            PlaySound(bangsound);
                            break;
                        }
                    }

                    pvocicles[3, i] = 0;


                }
            }
        }

        if (helilife <= 0) helidestroy = 1;

        // Приземление на площадку
        if (padx < playerx + playerl && padx + padsizex > playerx && pady < playery + playerh && pady + padsizey > playery && helidestroy != 1)
        {

            padswitch = 1;
            if (padstoreswitch != 1) PlaySound(helionpadsound, volume - 30);
        }
        else padswitch = 0;

        // FillCircle(padx, pady, 3);
        // FillCircle(padx+ padsizex, pady+ padsizey, 3);

    }

    static void PlayerDraw() // отрисовка Верталета
    {

        DrawSprite(uh61, padx, pady, 147, 603, 137, 66); // Верталетная площадка
        //цветы

        if (helilife <= 0) DrawSprite(uh61, playerx - 41, playery - 17, 408, 101, 91, 43);
        else
        {
            if (angle >= 0 && angle <= 10) DrawSprite(uh61, playerx - 95, playery - 26, 0, 0, 130, 57);
            if (angle > 10 && angle <= 30) DrawSprite(uh61, playerx - 96, playery - 30, 0, 56, 127, 59);
            if (angle > 30 && angle <= 45) DrawSprite(uh61, playerx - 75, playery - 68, 23, 184, 105, 106);
            if (angle > 45 && angle <= 70) DrawSprite(uh61, playerx - 61, playery - 83, 150, 1, 93, 125);

            if (angle >= -15 && angle < 0) DrawSprite(uh61, playerx - 98, playery - 23, 403, 28, 134, 53);
            if (angle >= -30 && angle < -15) DrawSprite(uh61, playerx - 35, playery - 27, 272, 68, 127, 59);
            if (angle >= -45 && angle < -30) DrawSprite(uh61, playerx - 29, playery - 66, 277, 163, 103, 105);
            if (angle >= -70 && angle < -45) DrawSprite(uh61, playerx - 25, playery - 86, 160, 147, 79, 122);
        } //отрисовка спрайтов Вертолета

        FillCircle(playerx, playery, 3);


        // Отрисовка прицела МОДЕ 2
        if (gunmode == 2) // Оружие МОДЕ 2. Прицел.
        {

            //Вычисление поправок
            searchline = aimlehght + ritarandom - 1;
            searchangle = angle + ritarandom - 1;
            searchAB();

            if (angle > 0 && angle < 70)
            {
                DrawSprite(uh61, playerx + searchA, playery + searchB * ritarandom, 305, 302, 35, 37);

            }
            if (angle > -70 && angle < -15)
            {
                DrawSprite(uh61, playerx - searchA * ritarandom - 50, playery + searchB, 305, 302, 35, 37);

            }
            if (angle >= -15 && angle <= 0)
            {
                DrawSprite(uh61, playerx + searchA, playery * ritarandom - searchB, 305, 302, 35, 37);
            }

        }// Отрисовка прицела МОДЕ 2

        // Мышка
        FillCircle(MouseX, MouseY, 3);
        if (gunmode == 3) DrawSprite(aiming, MouseX - 50, MouseY - 50);
        FillCircle(MouseX, MouseY, 3);
        //Вращение винта

        //звуки верталета
        //ПРЕДЕЛЬНАЯ ВЫСОТА
        if (enginespeed > enginespeedlimit)
        {
            PlaySound(helirotor4);
            enginespeed = enginespeed - 50;
            otkazsbrosoboroti = 1;


        } // в небе
        else otkazsbrosoboroti = 0;


        if (altitude > 50) PlaySound(helirotor1);
        if (altitude <= 50 && helistop != 1 && helidestroy != 1) PlaySound(helirotor2); // у земли

        if (helilife <= 0 && playery + 10 >= ground) DrawSprite(uh61, playerx - 570, playery - 540, 1685, 4, 705, 568);

        //цветы
        DrawSprite(uh61, 170, 700, 455, 165, 43, 37);
        DrawSprite(uh61, 200, 710, 455, 165, 43, 37);
        DrawSprite(uh61, 250, 690, 455, 165, 43, 37);
        // Верталетная площадка 


    }

    static void PlayerMove() // расчет движений Верталета
    {

        ratioenginespeed = helienginelife * 1.25f / 100;
        if (ratioenginespeed > 1) ratioenginespeed = 1;

        //Данные для учета столкновения с землей
        float s = speedy;

        //расчет плотности воздуха, на выходе получаем =airP
        altitude = (768 - playery) - (768 - ground);

        airP = (float)Math.Sqrt(playery) * 2 * 3;

        if (altitude > 0) flighttime = flighttime + 1;

        // Автопилот висение 
        if (GetKeyDown(Keyboard.Key.H) == true)
        {
            autopilotv = (768 - playery) - (768 - ground);
            int A = autopilotswitch;
            if (A == 1) autopilotswitch = 0;
            if (A == 0) autopilotswitch = 1;
        }
        if (autopilotswitch == 1)
        {

            if (altitude < autopilotv)
            {
                if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                    enginespeed = enginespeed + shagengine;
                else enginespeed = enginespeed + shagengine / 4;
            }
            if (altitude > autopilotv)
            {
                if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                    enginespeed = enginespeed - shagengine;
                else enginespeed = enginespeed + shagengine / 4;
            }
        }


        if (maxenginespeed < enginespeed) enginespeed = maxenginespeed;

        // вкл/выкл двигателя
        if (GetKeyDown(Keyboard.Key.I) == true)

        {

            int j = engineswitch;
            if (j == 1) engineswitch = 0;
            if (j == 0) engineswitch = 1;

            if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
            {
                PlaySound(startenginesound);
            }

        }
        if (engineswitch == 0 || helifuel <= 0 || helidestroy == 1) //отключение двигателя
        {
            if (enginespeed > 0)
            {

                enginespeed = enginespeed - 200;
                if (helistop != 1)
                {
                    helistop = 1;
                    PlaySound(stopengine);
                }

            }
            if (enginespeed < 0) enginespeed = 0;
        }

        if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
        {
            if (enginespeed < 12000)
            {
                enginespeed = enginespeed + shagengine / 2;
                if (helistop == 1)
                {
                    helistop = 0;

                }
            }

        }

        //Расход топлива
        helifuel = helifuel - (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
        fuelusedup = fuelusedup + (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
        if (helifuel < 0) helifuel = 0;
        if (helifuel < 510 && helifuel > 507) PlaySound(kg500);
        if (helifuel < 810 && helifuel > 805) PlaySound(kg800);


        //ОСНОВНЫЕ ПАРАМЕТРЫ   ДВИЖЕНИЕ WSDA
        if (GetKey(Keyboard.Key.W) == true) enginespeed = (enginespeed + shagengine);
        if (enginespeed > maxenginespeed) enginespeed = maxenginespeed;
        if (GetKey(Keyboard.Key.S) == true) enginespeed = (enginespeed - shagengine * 1.5f);
        if (enginespeed < 0) enginespeed = 0;


        //расчет вертикальной скорости

        //расчет подъемной силы
        //Масса ракет
        int n = 0;
        for (int i = 0; i < R.GetLength(1); i++)
        {
            if (R[5, i] == 1)
                n = n + 1;

        }
        //угол атаки уменьшает подъемную силу
        powery = (enginespeed * ratioenginespeed / 114 * airP) - gravityweight - helifuel * 6 - n * NRrocketweight; // подъемная сила

        boostv = powery / 200;       // вертиклаьное ускорение
        if (boostv > (maxenginespeed / 100 * 75)) boostv = maxboost;

        speedy = (boostv / 10); // вертикальная скорость

        playery = (playery - speedy);

        //ЗЕМЛЯ столкновение
        if (playery >= ground)
        {
            g = 1;

            playery = ground;
            speedx = 0;
            boostv = 0;
            powery = 0;
            speedy = 0;
            angle = 0;

        }
        if (g == 1)
        {
            if (s < -1) { helilife = helilife - 19; PlaySound(metal1, volume); getdamages = getdamages - 19; }
            if (s < -2) { helilife = helilife - 88; PlaySound(metal2); PlaySound(grass1); getdamages = getdamages - 89; loterea(); }
            if (helilife <= 0)
            {
                helidestroy = 1;
                if (bang1 == 1)
                {
                    PlaySound(bangsound);
                    bang1 = 0;
                }
            }
            g = 0;
        }

        // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
        // Вылет за зону полётов
        //Управление углом атаки
        if (GetKey(Keyboard.Key.D) == true) angle = (angle + shagAngle);
        if (angle > maxangle) angle = maxangle;
        if (GetKey(Keyboard.Key.A) == true) angle = (angle - shagAngle);
        if (angle < -maxangle) angle = -maxangle;

        speedx = speedx + enginespeed / 114 * airP / 100 * angle * DeltaTime / gravityweight * manageability; // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
        if (speedx > speedxmax) speedx = speedxmax;
        if (speedx < -speedxmax) speedx = -speedxmax;


        playerx = playerx + speedx + wind;
        if (GetKeyDown(Keyboard.Key.V) == true)
        {
            float v = autopilotswitchX;
            if (v == 1) autopilotswitchX = 0;
            if (v == 0) autopilotswitchX = 1;

        }

        if (autopilotswitchX == 1)
        {
            if (angle > 0) angle -= 1;
            if (angle < 0) angle += 1;

        }
        //Включение автопилота возврата в зону полета АВТОПИЛОТЫ ЗОНЫ
        if (playerx >= 1025 && autopilotzonaswitch == 0) //верталет уходит вправо
        {
            autopilotzonaangle = -45;
            autopilotzonaswitch = 1;
            autopilotzonax = 1000;
            PlaySound(proverupravlenie);

        }
        if (playerx <= -5 && autopilotzonaswitch == 0) //верталет уходит влево
        {
            autopilotzonaangle = 45;
            autopilotzonaswitch = 2;
            autopilotzonax = 50;
            PlaySound(proverupravlenie);

        }
        // Автопилот возврата в зону полета
        if (autopilotzonaswitch == 1)
        {
            if (autopilotzonax < playerx) angle = angle - 1f;
            if (autopilotzonax > playerx)
            {
                if (angle > autopilotzonaangle) angle = angle + 0.5f;
                if (angle < autopilotzonaangle) angle = angle - 0.5f;
                if (angle < autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                {
                    angle = autopilotzonaangle;
                    autopilotzonaswitch = 0;
                }
            }


        }
        if (autopilotzonaswitch == 2)
        {
            if (autopilotzonax > playerx) angle = angle + 1f;
            if (autopilotzonax < playerx)
            {
                if (angle < autopilotzonaangle) angle = angle + 0.5f;
                if (angle > autopilotzonaangle) angle = angle - 0.5f;
                if (angle > autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                {
                    angle = autopilotzonaangle;
                    autopilotzonaswitch = 0;
                }
            }


        }


        //Вывод параметров в консоль. Информация



    }



    //МИССИИ МИССИИ МИССИИ
    static void Mission1() // 1. ТРЕНИРОВКА Взлет, полет, посадка. 2. Дозаправка 3. Облет препятствий 4. Стрельба по мишеням
                           // Значения: 0 - задание провалено, 1 - задание скрыто, 2 - задание выполняется, 3 - задание выполнено
    {
        //checkpoints[0] = 3;
        // checkpoints[1] = 3;
        //checkpoints[2] = 3;
        //checkpoints[3] = 3;
        //checkpoints[4] = 3;
        //checkpoints[5] = 3;
        //checkpoints[6] = 3;



        for (int i = 0; i < checkpoints.GetLength(0); i++)
        {
            if (checkpoints[i] == 2) break;
            if (checkpoints[i] == 1)
            {
                if (checkdelay < 0)
                {
                    checkpoints[i] = 2;
                }

                break;
            }

        }
        checkdelay = checkdelay - 1;
        // ЗАДАНИЯ НА МИССИЮ
        // 1. Вкл двигатель
        if (checkpoints[0] == 2)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);

            DrawText(330, 265, "Включи двигатель! Нажми \"i\"", 32);

            // Условие победы
            if (engineswitch == 1) { checkpoints[0] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }

        }
        // 2. Подняться на высоту 5000

        if (checkpoints[1] == 2)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);

            DrawText(330, 265, "Подними вертолет на 4000,", 32);
            DrawText(330, 300, "     клавиша \"W\"", 32);


            // Условие победы
            if (altitude > 400) { checkpoints[1] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


        }

        // 3. Приземлить верталет и заглушить двигатель

        if (checkpoints[2] == 2)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 265, "Приземли вертолет на базе. (S)", 32);
            DrawText(330, 300, "и заглуши двигатель. (i)", 32);



            // Условие победы
            if (padswitch == 1 && engineswitch == 0) { checkpoints[2] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }

        }

        // 4. Купить топливо и ракеты

        if (checkpoints[3] == 2)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 265, "Заправься и купи ракеты,", 32);
            DrawText(330, 300, "почини вертолет. Жми \"R\"", 32);

            // Условие победы
            if (padstoreswitch == 1) { checkpoints[3] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


        }

        //5. Выход из магазина
        if (checkpoints[4] == 2 && helifuel >= helifuelmax - 10)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 265, "Заведи мотор, клавиша \"i\"", 32);
            DrawText(330, 300, "Выходи из магазина, \"R\"", 32);

            // Условие победы
            if (engineswitch == 1 && padstoreswitch == 0) { checkpoints[4] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


        }

        //6. Облететь воздушные шары

        if (checkpoints[5] == 2)
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            if (podskazkaswitch == 1)
            {

                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Облети все воздушные шары.", 32);
                DrawText(330, 300, "Столкнешься - чинись на базе. ", 32);
                DrawText(330, 340, "(Понял! - жми \"Y\", не понял... жми \"Y\".)", 16);

            }
            if (missionswitch == 0)
            {
                airballonscicle[1, 1] = 1100; //1
                airballonscicle[2, 1] = 700;  //1
                airballonscicle[4, 1] = 270;  //1
                airballonscicle[5, 1] = 570;  //1
                airballonscicle[3, 1] = 1;  //1

                airballonscicle[1, 2] = 1100; //2
                airballonscicle[2, 2] = 700;  //2
                airballonscicle[4, 2] = 310;  //2
                airballonscicle[5, 2] = 310;  //2
                airballonscicle[3, 2] = 1;  //2

                airballonscicle[1, 3] = 1100; //3
                airballonscicle[2, 3] = 700;  //3
                airballonscicle[4, 3] = 480;  //3
                airballonscicle[5, 3] = 300;  //3
                airballonscicle[3, 3] = 1;  //3

                airballonscicle[1, 4] = 1100; //4
                airballonscicle[2, 4] = 700;  //4
                airballonscicle[4, 4] = 700;  //4
                airballonscicle[5, 4] = 166;  //4
                airballonscicle[3, 4] = 1;  //4

                missionswitch = 1;
            }

            airballondraw();

            if (checkpoints2[3] == 1)
            {
                SetFillColor(Color.Cyan);
                FillCircle(670, 560, 70);
                SetFillColor(Color.Black);
                DrawText(612, 562, "Лети сюда 3", 18);
            }


            if (checkpoints2[2] == 1)
            {
                SetFillColor(Color.Cyan);
                FillCircle(880, 50, 70);
                SetFillColor(Color.Black);
                DrawText(825, 50, "Лети сюда 2", 18);
            }
            if (checkpoints2[1] == 1)
            {
                SetFillColor(Color.Cyan);
                FillCircle(100, 240, 70);
                SetFillColor(Color.Black);
                DrawText(40, 240, "Лети сюда 1", 18);
            }

            if (0 < playerx + playerl && 200 > playerx && 200 < playery + playerh && 350 > playery && helidestroy != 1 && checkpoints2[1] == 1) { checkpoints2[1] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }
            if (800 < playerx + playerl && 1000 > playerx && 0 < playery + playerh && 150 > playery && helidestroy != 1 && checkpoints2[2] == 1) { checkpoints2[2] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }
            if (550 < playerx + playerl && 700 > playerx && 500 < playery + playerh && 650 > playery && helidestroy != 1 && checkpoints2[3] == 1) { checkpoints2[3] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }

            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            if (podskazkaswitch == 1)
            {

                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                SetFillColor(Color.Blue);
                DrawText(330, 265, "Облети все воздушные шары.", 32);
                DrawText(330, 300, "Столкнешься - чинись на базе. ", 32);
                DrawText(330, 340, "(Понял! - жми \"Y\", не понял... жми \"Y\".)", 16);

            }

            // Шары улетают влево вверх
            if (checkpoints2[1] == 0 && checkpoints2[2] == 0 && checkpoints2[3] == 0)
            {
                airballonscicle[4, 1] = -400;
                airballonscicle[5, 1] = -400;
                airballonscicle[4, 2] = -400;
                airballonscicle[5, 2] = -400;
                airballonscicle[4, 3] = -400;
                airballonscicle[5, 3] = -400;
                airballonscicle[4, 4] = -400;
                airballonscicle[5, 4] = -400;


            }
            // Условие победы чек 6

            if (checkpoints2[1] == 0 && checkpoints2[2] == 0 && checkpoints2[3] == 0 && airballonscicle[1, 1] <= -300)
            {
                checkpoints[5] = 3; checkdelay = 200; missionswitch = 0; PlaySound(checkpointsound, volume); podskazkaswitch = 1;
            }
        }

        //7. Выбрать режим 2 и разнести два танка

        if (checkpoints[6] == 2)
        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            if (podskazkaswitch == 1)
            {
                SetFillColor(Color.Blue);

                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 260, "Выбери ракеты Воздух-Земля,", 32);
                DrawText(330, 295, "нажми цифру \"2\".", 32);
                DrawText(330, 335, "(Перезарядка на базе)", 26);
                DrawText(330, 372, "(Убрать сообщение Y, магазин на базе R)", 16);
            }

            //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
            if (missionswitch == 0)
            {
                Tank1cicles[3, 1] = 1;
                Tank1cicles[6, 1] = 1;    //скорость танка
                Tank1cicles[1, 1] = 1100; //где появится танк
                Tank1cicles[2, 1] = 698;
                Tank1cicles[4, 1] = 800; //куда поедет танк
                Tank1cicles[7, 1] = 100; //жизни


                Tank1cicles[3, 2] = 1;
                Tank1cicles[6, 2] = 0.2f; //скорость танка
                Tank1cicles[1, 2] = 1100; //где появится танк
                Tank1cicles[2, 2] = 700;
                Tank1cicles[4, 2] = 300; //куда поедет танк
                Tank1cicles[7, 2] = 400; //жизни


                Tank1cicles[3, 3] = 1;
                Tank1cicles[6, 3] = 0.5f; //скорость танка
                Tank1cicles[1, 3] = 1100; //где появится танк
                Tank1cicles[2, 3] = 703;
                Tank1cicles[4, 3] = 500; //куда поедет танк
                Tank1cicles[7, 3] = 200; //жизни


                missionswitch = 1;


            }
            tank1move();


            // Условие победы
            int n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;

            }
            if (n == 0)
            { checkpoints[6] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }



        }

        //8. Окончание тренировки

        if (checkpoints[7] == 2)
        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            if (podskazkaswitch == 1)
            {
                SetFillColor(Color.Blue);

                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 260, "Можно взять 16 ракет,", 32);
                DrawText(330, 295, "Окончить обучение - жми \"L\"", 32);

                DrawText(330, 372, "(Убрать сообщение Y, магазин на базе R)", 16);
            }

            //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
            if (missionswitch == 0)
            {
                nrrocketsMaxquantity = 16;


                Tank1cicles[3, 1] = 1;
                Tank1cicles[6, 1] = 1;    //скорость танка
                Tank1cicles[1, 1] = 1100; //где появится танк
                Tank1cicles[2, 1] = 698;
                Tank1cicles[4, 1] = 800; //куда поедет танк
                Tank1cicles[7, 1] = 100; //жизни


                Tank1cicles[3, 2] = 1;
                Tank1cicles[6, 2] = 0.2f; //скорость танка
                Tank1cicles[1, 2] = 1100; //где появится танк
                Tank1cicles[2, 2] = 700;
                Tank1cicles[4, 2] = 300; //куда поедет танк
                Tank1cicles[7, 2] = 400; //жизни


                Tank1cicles[3, 3] = 1;
                Tank1cicles[6, 3] = 0.5f; //скорость танка
                Tank1cicles[1, 3] = 1100; //где появится танк
                Tank1cicles[2, 3] = 703;
                Tank1cicles[4, 3] = 500; //куда поедет танк
                Tank1cicles[7, 3] = 200; //жизни

                Tank1cicles[3, 4] = 1;
                Tank1cicles[6, 4] = 3; //скорость танка
                Tank1cicles[1, 4] = -200; //где появится танк
                Tank1cicles[2, 4] = 703;
                Tank1cicles[4, 4] = 600; //куда поедет танк
                Tank1cicles[7, 4] = 100; //жизни

                Tank1cicles[3, 5] = 1;
                Tank1cicles[6, 5] = 0.3f; //скорость танка
                Tank1cicles[1, 5] = -300; //где появится танк
                Tank1cicles[2, 5] = 703;
                Tank1cicles[4, 5] = 900; //куда поедет танк
                Tank1cicles[7, 5] = 350; //жизни

                Tank1cicles[3, 6] = 1;
                Tank1cicles[6, 6] = 0.5f; //скорость танка
                Tank1cicles[1, 6] = 1100; //где появится танк
                Tank1cicles[2, 6] = 703;
                Tank1cicles[4, 6] = 800; //куда поедет танк
                Tank1cicles[7, 6] = 100; //жизни

                Tank1cicles[3, 7] = 1;
                Tank1cicles[6, 7] = 0.5f; //скорость танка
                Tank1cicles[1, 7] = 1100; //где появится танк
                Tank1cicles[2, 7] = 703;
                Tank1cicles[4, 7] = 500; //куда поедет танк
                Tank1cicles[7, 7] = 300; //жизни


                missionswitch = 1;


            }
            tank1move();


            // Условие победы
            int n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;

            }

            if (n == 0 || GetKeyDown(Keyboard.Key.L) == true)
            {
                checkpoints[7] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0;
                resultsmenuswitch = 1; gameplaying = 0;

            }


        }
    }

    static void Mission2() // 2. МИССИИ 
    {



    }

    static void Mission3() // 3. Волны врагов
    {
        if (basedurability < 0) for (int i = 0; i < checkpoints.GetLength(0); i++) checkpoints[i] = 0;

        //checkpoints[0] = 3;
        //checkpoints[1] = 3;
        //checkpoints[2] = 3;
        //checkpoints[3] = 3;
        //checkpoints[4] = 3;
        //checkpoints[5] = 3;
        //checkpoints[6] = 3;
        //checkpoints[7] = 3;

        int n = 0;
        int m = 0;

        for (int i = 0; i < checkpoints.GetLength(0); i++)
        {
            if (checkpoints[i] == 2) break;
            if (checkpoints[i] == 1)
            {
                if (checkdelay < 0)
                {
                    checkpoints[i] = 2;
                }

                break;
            }

        }
        checkdelay = checkdelay - 1;

        // Волны противника
        // 1.  2 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[0] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 5000;
                volnadelay = 4000;
                nrrocketsMaxquantity = 8;

                Tank1cicles[3, 1] = 1;
                Tank1cicles[1, 1] = 1100; //х
                Tank1cicles[2, 1] = 698; //у
                Tank1cicles[4, 1] = -200; //куда едет
                Tank1cicles[6, 1] = 0.5f; // скорость
                Tank1cicles[7, 1] = 100;


                Tank1cicles[3, 2] = 1;
                Tank1cicles[1, 2] = 1200; //х
                Tank1cicles[2, 2] = 698; //у
                Tank1cicles[4, 2] = -200; //куда едет
                Tank1cicles[6, 2] = 0.5f; // скорость
                Tank1cicles[7, 2] = 100;
                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 1, 16);
            DrawText(25, 170, "След волна через: " + volnadelay, 16);

            tank1move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            if (n == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);

            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[0] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        //2. 3 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[1] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 5000;
                nrrocketsMaxquantity = 16;

                Tank1cicles[3, 3] = 1;
                Tank1cicles[1, 3] = 1100; //х
                Tank1cicles[2, 3] = 698; //у
                Tank1cicles[4, 3] = -200; //куда едет
                Tank1cicles[6, 3] = 0.5f; // скорость
                Tank1cicles[7, 3] = 100;


                Tank1cicles[3, 4] = 1;
                Tank1cicles[1, 4] = 1200; //х
                Tank1cicles[2, 4] = 700; //у
                Tank1cicles[4, 4] = -200; //куда едет
                Tank1cicles[6, 4] = 0.5f; // скорость
                Tank1cicles[7, 4] = 100;

                Tank1cicles[3, 5] = 1;
                Tank1cicles[1, 5] = 1200; //х
                Tank1cicles[2, 5] = 703; //у
                Tank1cicles[4, 5] = -200; //куда едет
                Tank1cicles[6, 5] = 1f; // скорость
                Tank1cicles[7, 5] = 80; //жизней
                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 2, 16);

            tank1move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            if (n == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[1] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 3. 5 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[2] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 5000;
                nrrocketsMaxquantity = 24;

                Tank1cicles[3, 6] = 1;
                Tank1cicles[1, 6] = 1100; //х
                Tank1cicles[2, 6] = 698; //у
                Tank1cicles[4, 6] = -200; //куда едет
                Tank1cicles[6, 6] = 0.5f; // скорость
                Tank1cicles[7, 6] = 110;


                Tank1cicles[3, 7] = 1;
                Tank1cicles[1, 7] = 1200; //х
                Tank1cicles[2, 7] = 700; //у
                Tank1cicles[4, 7] = -200; //куда едет
                Tank1cicles[6, 7] = 0.5f; // скорость
                Tank1cicles[7, 7] = 110;

                Tank1cicles[3, 8] = 1;
                Tank1cicles[1, 8] = 1200; //х
                Tank1cicles[2, 8] = 703; //у
                Tank1cicles[4, 8] = -200; //куда едет
                Tank1cicles[6, 8] = 1f; // скорость
                Tank1cicles[7, 8] = 80; //жизней

                Tank1cicles[3, 9] = 1;
                Tank1cicles[1, 9] = 1250; //х
                Tank1cicles[2, 9] = 702; //у
                Tank1cicles[4, 9] = -200; //куда едет
                Tank1cicles[6, 9] = 0.3f; // скорость
                Tank1cicles[7, 9] = 180; //жизней

                Tank1cicles[3, 10] = 1;
                Tank1cicles[1, 10] = 1300; //х
                Tank1cicles[2, 10] = 695; //у
                Tank1cicles[4, 10] = -200; //куда едет
                Tank1cicles[6, 10] = 0.3f; // скорость
                Tank1cicles[7, 10] = 180; //жизней


                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 3, 16);

            tank1move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            if (n == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[2] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 4. 10 танков  (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[3] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 7000;
                nrrocketsMaxquantity = 64;

                Tank1cicles[3, 16] = 1;
                Tank1cicles[1, 16] = 1100; //х
                Tank1cicles[2, 16] = 698; //у
                Tank1cicles[4, 16] = -200; //куда едет
                Tank1cicles[6, 16] = 0.5f; // скорость
                Tank1cicles[7, 16] = 110;


                Tank1cicles[3, 17] = 1;
                Tank1cicles[1, 17] = 1200; //х
                Tank1cicles[2, 17] = 700; //у
                Tank1cicles[4, 17] = -200; //куда едет
                Tank1cicles[6, 17] = 0.5f; // скорость
                Tank1cicles[7, 17] = 110;

                Tank1cicles[3, 18] = 1;
                Tank1cicles[1, 18] = 1200; //х
                Tank1cicles[2, 18] = 703; //у
                Tank1cicles[4, 18] = -200; //куда едет
                Tank1cicles[6, 18] = 1f; // скорость
                Tank1cicles[7, 18] = 80; //жизней

                Tank1cicles[3, 19] = 1;
                Tank1cicles[1, 19] = 1250; //х
                Tank1cicles[2, 19] = 702; //у
                Tank1cicles[4, 19] = -200; //куда едет
                Tank1cicles[6, 19] = 0.3f; // скорость
                Tank1cicles[7, 19] = 220; //жизней

                Tank1cicles[3, 30] = 1;
                Tank1cicles[1, 30] = 1300; //х
                Tank1cicles[2, 30] = 695; //у
                Tank1cicles[4, 30] = -200; //куда едет
                Tank1cicles[6, 30] = 0.3f; // скорость
                Tank1cicles[7, 30] = 280; //жизней

                Tank1cicles[3, 11] = 1;
                Tank1cicles[1, 11] = 1100; //х
                Tank1cicles[2, 11] = 698; //у
                Tank1cicles[4, 11] = -200; //куда едет
                Tank1cicles[6, 11] = 0.5f; // скорость
                Tank1cicles[7, 11] = 120;

                Tank1cicles[3, 12] = 1;
                Tank1cicles[1, 12] = 1200; //х
                Tank1cicles[2, 12] = 700; //у
                Tank1cicles[4, 12] = -200; //куда едет
                Tank1cicles[6, 12] = 0.5f; // скорость
                Tank1cicles[7, 12] = 130;

                Tank1cicles[3, 13] = 1;
                Tank1cicles[1, 13] = 1200; //х
                Tank1cicles[2, 13] = 703; //у
                Tank1cicles[4, 13] = -200; //куда едет
                Tank1cicles[6, 13] = 1.1f; // скорость
                Tank1cicles[7, 13] = 80; //жизней

                Tank1cicles[3, 14] = 1;
                Tank1cicles[1, 14] = 1100; //х
                Tank1cicles[2, 14] = 702; //у
                Tank1cicles[4, 14] = -200; //куда едет
                Tank1cicles[6, 14] = 1.6f; // скорость
                Tank1cicles[7, 14] = 70; //жизней

                Tank1cicles[3, 15] = 1;
                Tank1cicles[1, 15] = 1100; //х
                Tank1cicles[2, 15] = 695; //у
                Tank1cicles[4, 15] = -200; //куда едет
                Tank1cicles[6, 15] = 1.5f; // скорость
                Tank1cicles[7, 15] = 90; //жизней


                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 4, 16);

            tank1move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            if (n == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[3] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 5. 5 быстрых танков и бук (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[4] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 8000;
                nrrocketsMaxquantity = 64;

                Tank1cicles[3, 46] = 1;
                Tank1cicles[1, 46] = 1100; //х
                Tank1cicles[2, 46] = 698; //у
                Tank1cicles[4, 46] = -200; //куда едет
                Tank1cicles[6, 46] = 1.5f; // скорость
                Tank1cicles[7, 46] = 70;

                Tank1cicles[3, 47] = 1;
                Tank1cicles[1, 47] = 1200; //х
                Tank1cicles[2, 47] = 700; //у
                Tank1cicles[4, 47] = -200; //куда едет
                Tank1cicles[6, 47] = 2f; // скорость
                Tank1cicles[7, 47] = 50;

                Tank1cicles[3, 48] = 1;
                Tank1cicles[1, 48] = 1200; //х
                Tank1cicles[2, 48] = 703; //у
                Tank1cicles[4, 48] = -200; //куда едет
                Tank1cicles[6, 48] = 1.4f; // скорость
                Tank1cicles[7, 48] = 80; //жизней

                Tank1cicles[3, 49] = 1;
                Tank1cicles[1, 49] = 1250; //х
                Tank1cicles[2, 49] = 702; //у
                Tank1cicles[4, 49] = -200; //куда едет
                Tank1cicles[6, 49] = 1.3f; // скорость
                Tank1cicles[7, 49] = 110; //жизней

                Tank1cicles[3, 50] = 1;
                Tank1cicles[1, 50] = 1300; //х
                Tank1cicles[2, 50] = 695; //у
                Tank1cicles[4, 50] = -200; //куда едет
                Tank1cicles[6, 50] = 1.3f; // скорость
                Tank1cicles[7, 50] = 100; //жизней

                Buk1cicles[3, 1] = 1; //БУК1 проявлен
                Buk1cicles[1, 1] = 1200; //х
                Buk1cicles[2, 1] = 691; //у
                Buk1cicles[4, 1] = 400; //куда едет
                Buk1cicles[6, 1] = 1.7f; //скорость
                Buk1cicles[7, 1] = 500; //жизней
                Buk1cicles[8, 1] = 0; //задержка перед выстрелом


                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 5, 16);

            tank1move();
            buk1Move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            if (n == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[4] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 6. 2 бука (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[5] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 8000;
                nrrocketsMaxquantity = 64;



                Buk1cicles[3, 2] = 1; //БУК1 проявлен
                Buk1cicles[1, 2] = 1150; //x
                Buk1cicles[2, 2] = 690; //у
                Buk1cicles[4, 2] = 700; //куда едет
                Buk1cicles[6, 2] = 1.7f; //скорость
                Buk1cicles[7, 2] = 500; //жизней
                Buk1cicles[8, 2] = 0; //задержка перед выстрелом

                Buk1cicles[3, 3] = 1; //БУК1 проявлен
                Buk1cicles[1, 3] = 1300; //ч
                Buk1cicles[2, 3] = 693; //у
                Buk1cicles[4, 3] = 400; //куда едет
                Buk1cicles[6, 3] = 2.5f; //скорость
                Buk1cicles[7, 3] = 500; //жизней
                Buk1cicles[8, 3] = 0; //задержка перед выстрелом


                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 6, 16);

            tank1move();
            buk1Move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            m = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) m = m + 1;
            }
            if (n == 0 && m == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0)) { checkpoints[5] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 7. Самолет и 10 танков (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[6] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 8000;
                nrrocketsMaxquantity = 64;

                tank1reward = 6000;
                volnadelay = 7000;
                nrrocketsMaxquantity = 64;
                a10rocketquantity = 2;

                Tank1cicles[3, 20] = 1;
                Tank1cicles[1, 20] = 1100; //х
                Tank1cicles[2, 20] = 698; //у
                Tank1cicles[4, 20] = -200; //куда едет
                Tank1cicles[6, 20] = 0.5f; // скорость
                Tank1cicles[7, 20] = 110;


                Tank1cicles[3, 21] = 1;
                Tank1cicles[1, 21] = 1200; //х
                Tank1cicles[2, 21] = 700; //у
                Tank1cicles[4, 21] = -200; //куда едет
                Tank1cicles[6, 21] = 0.5f; // скорость
                Tank1cicles[7, 21] = 110;

                Tank1cicles[3, 22] = 1;
                Tank1cicles[1, 22] = 1200; //х
                Tank1cicles[2, 22] = 703; //у
                Tank1cicles[4, 22] = -200; //куда едет
                Tank1cicles[6, 22] = 1f; // скорость
                Tank1cicles[7, 22] = 80; //жизней

                Tank1cicles[3, 23] = 1;
                Tank1cicles[1, 23] = 1250; //х
                Tank1cicles[2, 23] = 702; //у
                Tank1cicles[4, 23] = -200; //куда едет
                Tank1cicles[6, 23] = 0.3f; // скорость
                Tank1cicles[7, 23] = 220; //жизней

                Tank1cicles[3, 24] = 1;
                Tank1cicles[1, 24] = 1300; //х
                Tank1cicles[2, 24] = 695; //у
                Tank1cicles[4, 24] = -200; //куда едет
                Tank1cicles[6, 24] = 0.3f; // скорость
                Tank1cicles[7, 24] = 280; //жизней

                Tank1cicles[3, 25] = 1;
                Tank1cicles[1, 25] = 1100; //х
                Tank1cicles[2, 25] = 698; //у
                Tank1cicles[4, 25] = -200; //куда едет
                Tank1cicles[6, 25] = 0.5f; // скорость
                Tank1cicles[7, 25] = 120;

                Tank1cicles[3, 26] = 1;
                Tank1cicles[1, 26] = 1200; //х
                Tank1cicles[2, 26] = 700; //у
                Tank1cicles[4, 26] = -200; //куда едет
                Tank1cicles[6, 26] = 0.5f; // скорость
                Tank1cicles[7, 26] = 130;

                Tank1cicles[3, 27] = 1;
                Tank1cicles[1, 27] = 1200; //х
                Tank1cicles[2, 27] = 703; //у
                Tank1cicles[4, 27] = -200; //куда едет
                Tank1cicles[6, 27] = 1.1f; // скорость
                Tank1cicles[7, 27] = 80; //жизней

                Tank1cicles[3, 28] = 1;
                Tank1cicles[1, 28] = 1100; //х
                Tank1cicles[2, 28] = 702; //у
                Tank1cicles[4, 28] = -200; //куда едет
                Tank1cicles[6, 28] = 1.6f; // скорость
                Tank1cicles[7, 28] = 70; //жизней

                Tank1cicles[3, 29] = 1;
                Tank1cicles[1, 29] = 1100; //х
                Tank1cicles[2, 29] = 695; //у
                Tank1cicles[4, 29] = -200; //куда едет
                Tank1cicles[6, 29] = 1.5f; // скорость
                Tank1cicles[7, 29] = 90; //жизней



                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 7, 16);

            tank1move();
            buk1Move();

            //Противник А10

            if (a10x < -400)
            {
                for (int i = 0; i < a10rocketquantity; i++)
                {
                    R10[4, i] = 1;

                }
                a10x = 1500;
                a10delay = 0; // задержка между ракетами
                a10y = rnd.Next(30, 250);
            }
            if (a10x < 1100) // А10 сброс ракет 
            {
                a10delay = a10delay - 1;
                for (int i = 0; i < R10.GetLongLength(1); i++) // Ракета А10(1 = x ракеты, 2 = y ракеты, 3 = высота полета ракеты ракеты, 4 = ракета проявлена)
                {
                    if (R10[4, i] == 1 && a10delay <= 0)
                    {
                        R10[1, i] = a10x;
                        R10[2, i] = a10y;
                        R10[3, i] = rnd.Next(5, 550);
                        R10[4, i] = 2;
                        a10delay = rnd.Next(10, 60); // задержа до следующего пуска
                        break;
                    }
                }

            }
            a10move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            m = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) m = m + 1;
            }
            if (n == 0 && m == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0)) { checkpoints[6] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 8. Самолет и 10 танков и 2 зенитки (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[7] == 2)
        {
            if (missionswitch == 0)
            {
                tank1reward = 6000;
                volnadelay = 8000;
                nrrocketsMaxquantity = 64;

                tank1reward = 6000;
                volnadelay = 7000;
                nrrocketsMaxquantity = 64;
                a10rocketquantity = 5;

                Tank1cicles[3, 20] = 1;
                Tank1cicles[1, 20] = 1100; //х
                Tank1cicles[2, 20] = 698; //у
                Tank1cicles[4, 20] = -200; //куда едет
                Tank1cicles[6, 20] = 0.5f; // скорость
                Tank1cicles[7, 20] = 110;


                Tank1cicles[3, 21] = 1;
                Tank1cicles[1, 21] = 1200; //х
                Tank1cicles[2, 21] = 700; //у
                Tank1cicles[4, 21] = -200; //куда едет
                Tank1cicles[6, 21] = 0.5f; // скорость
                Tank1cicles[7, 21] = 110;

                Tank1cicles[3, 22] = 1;
                Tank1cicles[1, 22] = 1200; //х
                Tank1cicles[2, 22] = 703; //у
                Tank1cicles[4, 22] = -200; //куда едет
                Tank1cicles[6, 22] = 1f; // скорость
                Tank1cicles[7, 22] = 80; //жизней

                Tank1cicles[3, 23] = 1;
                Tank1cicles[1, 23] = 1250; //х
                Tank1cicles[2, 23] = 702; //у
                Tank1cicles[4, 23] = -200; //куда едет
                Tank1cicles[6, 23] = 0.3f; // скорость
                Tank1cicles[7, 23] = 220; //жизней

                Tank1cicles[3, 24] = 1;
                Tank1cicles[1, 24] = 1300; //х
                Tank1cicles[2, 24] = 695; //у
                Tank1cicles[4, 24] = -200; //куда едет
                Tank1cicles[6, 24] = 0.3f; // скорость
                Tank1cicles[7, 24] = 280; //жизней

                Tank1cicles[3, 25] = 1;
                Tank1cicles[1, 25] = 1100; //х
                Tank1cicles[2, 25] = 698; //у
                Tank1cicles[4, 25] = -200; //куда едет
                Tank1cicles[6, 25] = 0.5f; // скорость
                Tank1cicles[7, 25] = 120;

                Tank1cicles[3, 26] = 1;
                Tank1cicles[1, 26] = 1200; //х
                Tank1cicles[2, 26] = 700; //у
                Tank1cicles[4, 26] = -200; //куда едет
                Tank1cicles[6, 26] = 0.5f; // скорость
                Tank1cicles[7, 26] = 130;

                Tank1cicles[3, 27] = 1;
                Tank1cicles[1, 27] = 1200; //х
                Tank1cicles[2, 27] = 703; //у
                Tank1cicles[4, 27] = -200; //куда едет
                Tank1cicles[6, 27] = 1.1f; // скорость
                Tank1cicles[7, 27] = 80; //жизней

                Tank1cicles[3, 28] = 1;
                Tank1cicles[1, 28] = 1100; //х
                Tank1cicles[2, 28] = 702; //у
                Tank1cicles[4, 28] = -200; //куда едет
                Tank1cicles[6, 28] = 1.6f; // скорость
                Tank1cicles[7, 28] = 70; //жизней

                Tank1cicles[3, 29] = 1;
                Tank1cicles[1, 29] = 1100; //х
                Tank1cicles[2, 29] = 695; //у
                Tank1cicles[4, 29] = -200; //куда едет
                Tank1cicles[6, 29] = 1.5f; // скорость
                Tank1cicles[7, 29] = 90; //жизней

                Buk1cicles[3, 4] = 1; //БУК1 проявлен
                Buk1cicles[1, 4] = 1300; //ч
                Buk1cicles[2, 4] = 693; //у
                Buk1cicles[4, 4] = 400; //куда едет
                Buk1cicles[6, 4] = 3f; //скорость
                Buk1cicles[7, 4] = 500; //жизней
                Buk1cicles[8, 4] = 0; //задержка перед выстрелом


                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Волна: " + 8, 16);

            tank1move();
            buk1Move();

            //Противник А10

            if (a10x < -400)
            {
                for (int i = 0; i < a10rocketquantity; i++)
                {
                    R10[4, i] = 1;

                }
                a10x = 1500;
                a10delay = 0; // задержка между ракетами
                a10y = rnd.Next(30, 250);
            }
            if (a10x < 1100) // А10 сброс ракет 
            {
                a10delay = a10delay - 1;
                for (int i = 0; i < R10.GetLongLength(1); i++) // Ракета А10(1 = x ракеты, 2 = y ракеты, 3 = высота полета ракеты ракеты, 4 = ракета проявлена)
                {
                    if (R10[4, i] == 1 && a10delay <= 0)
                    {
                        R10[1, i] = a10x;
                        R10[2, i] = a10y;
                        R10[3, i] = rnd.Next(5, 550);
                        R10[4, i] = 2;
                        a10delay = rnd.Next(10, 60); // задержа до следующего пуска
                        break;
                    }
                }

            }
            a10move();

            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            m = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) m = m + 1;
            }
            if (n == 0 && m == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (volnadelay <= 0 || (n == 0 && m == 0)) { checkpoints[7] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }

        // 9. Победа! (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
        if (checkpoints[8] == 2)
        {
            if (missionswitch == 0)
            {
                checkpoints2[1] = 0;
                winpobeda = 1;
                missionswitch = 1;
            }

            volnadelay = volnadelay - 1;
            SetFillColor(Color.White);
            DrawText(25, 150, "Победа!", 16);

            tank1move();
            buk1Move();



            n = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) n = n + 1;
            }
            m = 0;
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) m = m + 1;
            }
            if (n == 0 && m == 0)
                DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
            // Условие победы
            if (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0) { checkpoints[8] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

        }
        DrawText(25, 170, "След волна через: " + volnadelay, 16);
        DrawText(25, 215, "Теперь можете загрузить " + nrrocketsMaxquantity + " ракет!", 16);
        DrawText(25, 240, "Оборона базы выдержит: " + basedurability + " танков!", 16);


        if (checkpoints2[1] == 0)
        {
            SetFillColor(Color.Green);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 265, "Вы победили всех врагов!", 32);
            DrawText(330, 300, "Нажми Escape, для выхода. ", 32);


        }


        if (basedurability < 0 || helidestroy == 1)
        {

            gitadelay = 200;
            gitaswitch = 1;
            G = rnd.Next(1, 6);
            SetFillColor(Color.Green);
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 265, "Танки захватили Вашу базу.", 32);
            DrawText(330, 300, "Нажми Escape, для выхода. ", 32);

        }

    }

    static void PanelInstrument() // параметры приборной панели и отрисовка
    {
        SetFillColor(Color.Red);

        DrawSprite(uh61, 0, 0, 139, 679, 159, 131);
        DrawSprite(uh61, 175, 0, 139, 679, 159, 131);

        //Параметры верталета
        SetFillColor(Color.White);
        


        DrawText(25, 15, "Heli Life: " + (int)helilife, 14);
        if (helilife < 90) { SetFillColor(Color.Red); DrawText(25, 15, "Heli Life: " + (int)helilife, 14); SetFillColor(Color.White); }
        DrawText(200, 30, "Engine Switch: " + engineswitch, 14);
        DrawText(25, 30, "Altitude: " + (int)altitude * 10, 14);
        DrawText(25, 45, "Angle: " + (int)angle, 14);
        DrawText(25, 60, "Автопилот V: " + autopilotswitchX, 14);
        DrawText(25, 75, "Автопилот H: " + autopilotswitch, 14);


        //Двигаетль
        DrawText(200, 15, "Engine S.: " + (int)enginespeed, 14);
        if (enginespeed > enginespeedlimit) { SetFillColor(Color.Red); DrawText(200, 15, "Engine S.: " + (int)enginespeed, 14); SetFillColor(Color.White); }
        DrawText(200, 30, "Engine Switch: " + engineswitch, 14);
        if (engineswitch == 1) { SetFillColor(Color.Green); DrawText(200, 30, "Engine Switch: " + engineswitch, 14); SetFillColor(Color.White); }
        DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14);
        if (helienginelife < 75 || otkazpojardvig == 1) { SetFillColor(Color.Yellow); DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14); SetFillColor(Color.White); }
        if (helienginelife < 53 || otkazpojardvig == 1) { SetFillColor(Color.Red); DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14); SetFillColor(Color.White); }
        DrawText(200, 60, "Fuel: " + (int)helifuel, 14);
        if (helifuel < 150) { SetFillColor(Color.Yellow); DrawText(200, 60, "Fuel: " + (int)helifuel, 14); SetFillColor(Color.White); }

        //Вооружение
        DrawText(400, 5, "Режим: " + gunmode, 18);

        int n = 0;
        for (int i = 0; i < R.GetLength(1); i++)
        {
            if (R[5, i] == 1) n = n + 1;

        }
        DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18);
        if (n <= 3) { SetFillColor(Color.Yellow); DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18); SetFillColor(Color.White); }



        //Окруж среда
        DrawText(600, 5, "Плотность воздуха: " + gunmode, 14);
        DrawText(600, 20, "Ветер " + wind, 14);


        //Очки
        DrawText(800, 35, "Money: " + money, 18);
        DrawText(800, 55, "Record: " + hiscore, 18);
        DrawText(800, 15, "Flight: time " + flighttime, 18);

        if (helifuel < 150 && helifuel > 145) PlaySound(rubejvozvrata); //рубеж возврата предупреждение голосовое

    }

    static void padstoredraw()
    {



        if (padstoreswitch == 1)
        {

            gunmode = 0;
            //музыка 
            magnitola();


            //ДОЗАПРАВКА и ремонт
            if (enginespeed < 1 && engineswitch == 0)
            {
                if (helienginelife < 100 && partsinbag > 0) //мотор
                {
                    helienginelife = helienginelife + 0.01f;
                    partsinbag = partsinbag - 0.1f;
                    PlaySound(enginerepairsound, volume - 30);
                    otkazpojardvig = 0;
                }

                if (helilife < helilifemax && partsinbag > 0) //жизни верталета
                {
                    helilife = helilife + 0.1f;
                    partsinbag = partsinbag - 0.1f;
                    PlaySound(zapmachine, volume - 50);
                }

                if (helifuel < helifuelmax && fuelinbag > 0) //топливо
                {
                    helifuel = helifuel + 0.5f;
                    fuelinbag = fuelinbag - 0.5f;
                    PlaySound(pumper, volume);

                }
                paddelay = paddelay - 1;

                for (int i = 0; i < nrrocketsMaxquantity; i++) // ракеты
                {
                    if (R[5, i] == 0 && paddelay < 1 && nrrocketsinbag >= 1)
                    {

                        R[5, i] = 1;
                        paddelay = 50;
                        nrrocketsinbag = nrrocketsinbag - 1;
                        PlaySound(nrrocketreloadsound, volume - 20);
                        break;
                    }

                }

            }
            NRrocketchecklaunch = 0;
            for (int i = 0; i < R.GetLength(1); i++)
            {
                if (R[5, i] == 1) NRrocketchecklaunch = NRrocketchecklaunch + 1;
            }
            SetFillColor(47, 55, 68);
            FillRectangle(350, 150, 1024 - 350, 500);


            //Параметры верталета
            SetFillColor(255, 187, 0);
            DrawText(400, 540, "HeliParts: " + (int)helilife, 18);
            DrawText(400, 300, "Fuel: " + (int)helifuel, 18);
            DrawText(400, 430, "Rockets: " + (int)NRrocketchecklaunch, 18);
            DrawText(620, 300, "" + (int)fuelinbag, 18);
            DrawText(620, 430, "" + (int)nrrocketsinbag, 18);
            DrawText(620, 540, "" + (int)partsinbag, 18);

            if (helifuel >= helifuelmax - 5) DrawSprite(uh61, 535, 300, 568, 15, 123, 87); //готово топлива
            if (NRrocketchecklaunch >= nrrocketsMaxquantity) DrawSprite(uh61, 535, 430, 568, 15, 123, 87); //готово топлива
            if (helilife >= helilifemax - 5)
            {
                DrawSprite(uh61, 535, 540, 568, 15, 123, 87); //готово топлива

                //Обнуление ошибок

                //Ремонт гидросистемы
                if (otkazcicle[3] == 1)
                {
                    otkazhydrosis = 0;
                    otkazcicle[3] = 0;
                    manageability = otkazcicle[1];
                    shagAngle = otkazcicle[2];
                }
                //ремонт ОЛС
                otkazols = 0;


            }

            DrawSprite(uh61, 790, 257, 967, 583, 142, 105); // топливо спрайт
            DrawSprite(uh61, 790, 257 + 105 + 15, 972, 824, 134, 103); // ракеты
            DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти

            if (MouseX > 780 && MouseX < 940 && MouseY > 250 && MouseY < 360) // ПОКУПКА ТОПЛИВА
            {
                if (storechoise != 1)
                {
                    storechoise = 1;
                    PlaySound(click);
                }


            }
            else
            {
                if (MouseX > 780 && MouseX < 940 && MouseY > 366 && MouseY < 476) // ПОКУПКА РАКЕТ
                {
                    if (storechoise != 2)
                    {
                        storechoise = 2;
                        PlaySound(click);
                    }
                }
                else
                {
                    if (MouseX > 780 && MouseX < 940 && MouseY > 491 && MouseY < 615) // ПОКУПКА ЗАПЧАСТЕЙ
                    {
                        if (storechoise != 3)
                        {
                            storechoise = 3;
                            PlaySound(click);
                        }


                    }
                    else storechoise = 0;
                }

            }

            if (storechoise == 1) //топливо
            {
                DrawSprite(uh61, 720, 281, 1143, 573, 57, 75); // стрелочка
                if (GetMouseButtonDown(Mouse.Button.Left) == true)
                {
                    if (money >= fuelcost)
                    {
                        fuelinbag = fuelinbag + 100; //топливо на складе
                        money = money - fuelcost;
                        PlaySound(click);
                    }
                    else { donatswitch = 1; PlaySound(cansel); } //заправка
                }
            }

            if (storechoise == 2) // ракеты нр
            {
                DrawSprite(uh61, 720, 394, 1143, 573, 57, 75); // стрелочка
                if (GetMouseButtonDown(Mouse.Button.Left) == true)
                {
                    if (money >= rocketcost)
                    {
                        nrrocketsinbag = nrrocketsinbag + 1; //ракеты на складе
                        money = money - rocketcost;
                        PlaySound(click);
                    }
                    else { donatswitch = 1; PlaySound(cansel); }
                }
            }


            if (storechoise == 3) // запчасти
            {
                DrawSprite(uh61, 720, 517, 1143, 573, 57, 75); // стрелочка
                if (GetMouseButtonDown(Mouse.Button.Left) == true)
                {
                    if (money >= partscost)
                    {
                        partsinbag = partsinbag + 10; //Запчасти в корзине
                        money = money - partscost;
                        PlaySound(click);
                    }
                    else { donatswitch = 1; PlaySound(cansel); }


                }
            }



            DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти
            DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти

            //меню надписи
            SetFillColor(Color.White);
            DrawText(820, 220, "Store          Price", 22);
            DrawText(400, 220, "In Heli", 22);
            DrawText(601, 220, "At the Base", 22);
            DrawText(450, 170, "Your Money: " + money, 30);
            //прайс
            DrawText(950, 300, "" + (int)fuelcost, 18);
            DrawText(950, 430, "" + (int)rocketcost, 18);
            DrawText(950, 540, "" + (int)partscost, 18);


            if (engineswitch == 1)
            {
                SetFillColor(Color.Red);
                DrawText(380, 600, "Press \"i\" to turn off Engine", 28);
            }

            //отступление для обучающей миссии
            if (checkpoints[4] == 2 && helifuel >= helifuelmax - 10 && levelchoise == 1)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Заведи мотор, клавиша \"i\"", 32);
                DrawText(330, 300, "Выходи из магазина, \"R\"", 32);

                // Условие победы
                if (engineswitch == 1 && padstoreswitch == 0) { checkpoints[4] = 3; checkdelay = 200; }


            }





        }

    }


    //Пожертвования
    static void donat()
    {
        SetFillColor(Color.Blue);
        DrawSprite(uh61, 840, 300, 1215, 575, 221, 235);
        DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
        DrawText(330, 240, "Не хватает денег,", 30);
        DrawText(330, 268, "я дарю Тебе 20000 money. ", 30);
        DrawText(330, 296, "Cкоро разбогатеешь!;) Жми \"K\"!", 30);
        DrawText(330, 335, "Донат и обраная связь  ", 18);
        DrawText(330, 350, "по телефону 89500808627  ", 18);
        DrawText(330, 365, "(сбер: Алексей тимофеевич Б.)", 18);

        if (GetKeyDown(Keyboard.Key.K) == true)
        {
            money = money + 20000;
            donatswitch = 0;
        }

    }


    static void mainmenuDraw()
    {

        DrawSprite(maimenutexture, 0, 0);

        if (mainmenuSwitch == 1) //switch 1

        {

            SetFillColor(Color.Green);
            DrawText(220, 330, "1. Get pilot license", 18);
            DrawText(222, 370, "2. Missions", 18);
            DrawText(224, 410, "3. Free flight ", 18);

            //Мышь на меню 1
            if (MouseX > 217 && MouseX < 423 && MouseY > 332 && MouseY < 353)
            {
                SetFillColor(Color.Red);
                DrawText(220, 330, "1. Get pilot license", 18);
                if (levelchoise != 1) PlaySound(click);
                levelchoise = 1;
                Delay(2);
            }
            else //Меню на 2
            {
                if (MouseX > 221 && MouseX < 341 && MouseY > 369 && MouseY < 388)
                {
                    SetFillColor(Color.Red);
                    DrawText(222, 370, "2. Missions", 18);
                    if (levelchoise != 2) PlaySound(click);
                    levelchoise = 2;
                    Delay(2);
                }
                else //Меню на 3
                {
                    if (MouseX > 221 && MouseX < 370 && MouseY > 410 && MouseY < 430)
                    {
                        SetFillColor(Color.Red);
                        DrawText(224, 410, "3. Free flight ", 18);
                        if (levelchoise != 3) PlaySound(click);
                        levelchoise = 3;
                        Delay(2);
                    }
                    else
                    {
                        levelchoise = 0;
                        Delay(2);
                    }
                }
            }
        } // switch 1
        if (mainmenuSwitch == 2)
        {

            SetFillColor(Color.Green);
            DrawText(220, 330, "1. Continium", 18);
            DrawText(232, 410, "2. Exit", 18);

            if (MouseX > 217 && MouseX < 328 && MouseY > 327 && MouseY < 353) // contin
            {
                SetFillColor(Color.Red);
                DrawText(220, 330, "1. Continium", 18);
                if (menuchoise2 != 1) PlaySound(click);
                menuchoise2 = 1;
                Delay(2);
            }
            else //Меню на exit
            {
                if (MouseX > 223 && MouseX < 296 && MouseY > 407 && MouseY < 431) // exit
                {
                    SetFillColor(Color.Red);
                    DrawText(232, 410, "2. Exit", 18);
                    if (menuchoise2 != 2) PlaySound(click);
                    menuchoise2 = 2;
                    Delay(2);
                }

            }

        }

    }




    // ЭФФЕКТЫ ЭФФЕКТЫ ЭФФЕКТЫ

    static int GetbangNumber(int number)
    {

        return number;
    }

    static void BangDraw() // Взрыв1 (1=x взрыва, 2=y взрыва, 3=спрайт взрыва, 4=взрыв проявлен)  // 1 проявлен 0 непроявлен
    {

        for (int i = 0; i < Bang1.GetLength(1); i++)
        {
            if (Bang1[4, i] == 1)
            {


                // DrawSprite(uh61, Bang1[1, i], Bang1[2, i],)




            }


        }

    }


    //РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ
    static void resultsDraw()
    {

        DrawSprite(scoresprite, 0, 0);
        SetFillColor(Color.White);

        DrawText(500, 310, "Results", 30);
        DrawText(400, 345, "Score: " + money, 20); //score
        DrawText(400, 365, "Flight Time: " + flighttime, 20); //полетное время
        DrawText(400, 385, "NR ракет запущено: " + NRrocketslaunched, 20);
        DrawText(400, 405, "Попаданий ракетами: " + targetbingos, 20);
        DrawText(400, 425, "Поражено ПВО: " + buk1destroyes, 20);
        DrawText(400, 445, "Поражено Танков: " + tank1destroyes, 20);
        DrawText(400, 465, "Израсходовано топлива: " + fuelusedup, 20);
        DrawText(400, 485, "Получено повреждений: " + getdamages, 20);

        DrawText(380, 644, "В МЕНЮ ", 24);
        DrawText(725, 644, "ПОВТОРИТЬ", 24);

        if (MouseX > 377 && MouseX < 495 && MouseY > 641 && MouseY < 673)  // в меню
        {
            if (resultmenuchoise != 1) PlaySound(click);

            resultmenuchoise = 1;

            SetFillColor(Color.Green);
            DrawText(380, 644, "В МЕНЮ ", 24);

        }

        else
        {
            if (MouseX > 714 && MouseX < 878 && MouseY > 642 && MouseY < 673)  // переиграть
            {
                if (resultmenuchoise != 2) PlaySound(click);

                resultmenuchoise = 2;
                SetFillColor(Color.Green);
                DrawText(725, 644, "ПОВТОРИТЬ", 24);



            }
            else resultmenuchoise = 0;

        }
    }

    static void magnitola()
    {



        if (mainmenuSwitch != 0 || resultsmenuswitch != 0) //меню
        {
            playlistmusic = mainmenumusic;

        }

        if (levelchoise == 1 && mainmenuSwitch == 0 && resultsmenuswitch == 0) // музыка левел1
        {

            if (winpobeda == 1) playlistmusic = finalmusic;
            else
            {
                playlistmusic = Level1Music;
                if (padstoreswitch == 1) playlistmusic = StoreMusic;
            }


        }
        if (levelchoise == 3 && mainmenuSwitch == 0 && resultsmenuswitch == 0) // музыка левел3
        {


            if (winpobeda == 1) playlistmusic = finalmusic;
            else
            {
                if (padstoreswitch == 1) playlistmusic = StoreMusic;
                else playlistmusic = Music3Level;


            }

        }
        //Напряженная обстановка
        if ((otkazhydrosis == 1 && otkazols == 1) || (otkazhydrosis == 1 && helienginelife < 75) || helienginelife < 65 || helilife <= 0 || otkazpojardvig == 1)
        {
            playlistmusic = musicotkazsistem;
        }



        if (playingmusic != playlistmusic) // смена музыки
        {
            if (playingmusic != "")
            {
                StopMusic(playingmusic);
                Delay(20);
                PlayMusic(playlistmusic, volume + 20);
                Delay(20);
                playingmusic = playlistmusic;
            }
            if (playingmusic == "")
            {
                PlayMusic(mainmenumusic, volume + 20);
                playingmusic = mainmenumusic;

            }

        }


    }


    static void Main(string[] args) // ПРОГРАММА
    {
        //Настройки экрана
        InitWindow(1024, 768, "Havier Than Air"); // Экран
        SetFont("comic.ttf"); // Шрифт
        PlayMusic(mainmenumusic, volume);
        playingmusic = mainmenumusic;


        // GAME
        while (true) // Цикл начиная от меню ВСЯ ИГРА
        {


            ClearWindow();
            DispatchEvents();

            while (mainmenuSwitch == 1 || mainmenuSwitch == 2) // ТОЛЬКО ГЛАВНОЕ МЕНЮ или ПОДМЕНЮ выбор мышью
            {

                DispatchEvents();
                ClearWindow();
                mainmenuDraw();

                magnitola();



                if (menudelay <= 0)
                {
                    if (GetMouseButtonDown(Mouse.Button.Left) == true && levelchoise != 0)
                    {
                        if (mainmenuSwitch == 1)
                        {
                            mainmenuSwitch = 0;
                            StopMusic(mainmenumusic);
                            newgame = 1;
                            gameplaying = 1;
                            Delay(500);
                        }

                        if (mainmenuSwitch == 2) // меню во время игры
                        {
                            if (menuchoise2 == 2) // выход
                            {
                                mainmenuSwitch = 0;
                                resultsmenuswitch = 1;
                                gameplaying = 0;
                                Delay(500);
                            }
                            if (menuchoise2 == 1) //продолжаем
                            {
                                mainmenuSwitch = 0;
                                resultsmenuswitch = 0;
                                Delay(500);
                                StopMusic(mainmenumusic);
                            }
                        }

                    }


                }
                menudelay = menudelay - 1;
                DisplayWindow();
                Delay(15);

            }

            while (resultsmenuswitch == 1) //меню РЕЗУЛЬТАТОВ
            {

                DispatchEvents();
                ClearWindow();

                resultsDraw();

                if (GetMouseButtonDown(Mouse.Button.Left) == true)
                {
                    if (resultmenuchoise == 1) // в меню
                    {
                        mainmenuSwitch = 1;
                        resultmenuchoise = 0;
                        resultsmenuswitch = 0;
                        gameplaying = 0;
                    }
                    if (resultmenuchoise == 2) // переиграть
                    {
                        mainmenuSwitch = 0;
                        resultmenuchoise = 0;
                        resultsmenuswitch = 0;
                        newgame = 1;
                        gameplaying = 1;
                        break;
                    }

                }


                DisplayWindow();


            }


            //Левел1
            if (levelchoise == 1 && mainmenuSwitch == 0 && gameplaying == 1) // Левел 1 Тренировка НАЧАЛО
            {
                if (newgame == 1)
                {
                    //Начальные настройки верталета
                    playerx = 120;
                    playery = 700;
                    engineswitch = 0;
                    enginespeed = 0;
                    helistop = 1;
                    helifuel = 900;
                    helifuelmax = 900;
                    helilife = 300;
                    speedxmax = 2.5f;
                    manageability = 10; //управляемость
                    shagAngle = 1.5f; // угол атаки
                    nrrocketsMaxquantity = 8; //максимально ракет
                    padstoreswitch = 0;
                    helidestroy = 0;
                    donatswitch = 0;
                    money = 0;
                    missionswitch = 0;
                    podskazkaswitch = 0;
                    otkazcicle[1] = manageability;
                    otkazcicle[2] = shagAngle;
                    otkazcicle[3] = 0;
                    winpobeda = 0;
                    enginespeedlimit = 35000;


                    flighttime = 0; //время нахождения в воздухе


                    //Поломки
                    helienginelife = 100;
                    otkazhydrosis = 0; // Гидросистема
                    otkazmasterwarning = 0; // Матерсвитч
                    otkazols = 0; // Оптико локационная станция
                    otkazraketasprava = 0; //ракета справа
                    otkazraketasleva = 0; //Ракета слева
                    otkazpojardvig = 0; // Пожар двигателя
                    otkazsbrosoboroti = 0; //Пожар двигателя

                    peregruzkamotora = 0; //Пожар двигателя начнется
                    ritarandom = 1; //рандом для прицела

                    //результаты
                    landingquantity = 0; //количество посадок
                    NRrocketslaunched = 0; //выпущено NR ракет количество
                    targetbingos = 0; //попаданий по цели
                    buk1destroyes = 0; //уничтожено буков1
                    tank1destroyes = 0; //уничтожено танков1
                    fuelusedup = 0; //израсходовано топлива
                    repairings = 0; //Отремонтирован вертолет
                    getdamages = 0; //Получено повреждений
                    //Начальное вооружение 0
                    //for (int i = 0; i < R.GetLongLength(1); i++) R[5, i] = 1; // 5. Моде 2 NR Ракеты готовы к пуску
                    //Начальные задания
                    for (int i = 0; i < checkpoints.GetLength(0); i++) checkpoints[i] = 1;
                    for (int i = 0; i < checkpoints2.GetLength(0); i++) checkpoints2[i] = 1;
                    for (int i = 0; i < Buk1cicles.GetLength(1); i++) Buk1cicles[3, i] = 0;
                    for (int i = 0; i < Tank1cicles.GetLength(1); i++) Tank1cicles[3, i] = 0;
                    for (int i = 0; i < R.GetLength(1); i++) R[5, i] = 0;
                    for (int i = 0; i < R10.GetLength(1); i++) R10[4, i] = 0;
                    newgame = 0;

                    //запасы склада
                    fuelinbag = 0; //топливо на складе
                    nrrocketsinbag = 0; //ракеты на складе
                    partsinbag = 0; //Запчасти в корзине


                }


                while (gameplaying == 1)
                {
                    playlistmusic = Level1Music;

                    magnitola();

                    DispatchEvents();
                    ClearWindow();
                    //mainmenuSwitch = 1;
                    DrawSprite(backgroundLevel1, 0, 0);

                    PlayerMove();

                    PlayerDraw();


                    //Задания

                    Mission1();
                    SearchConflict();

                    //Перезарядка
                    if (GetKeyDown(Keyboard.Key.R) == true)
                    {
                        int s = padstoreswitch;
                        if (s == 1)
                        {
                            padstoreswitch = 0;
                            gitaswitch = 0;


                        }
                        if (s == 0 && padswitch == 1)
                        {
                            padstoreswitch = 1;
                            gitadelay = 2000;
                            gitaswitch = 1;
                            G = rnd.Next(1, 6);
                            podskazkaswitch = 1;
                        }

                    }
                    gitadelay = gitadelay - 1;
                    padstoredraw();

                    if (gitaswitch == 1 && gitadelay < 0)
                    {


                        if (G == 1)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 265, "Знай же: то, чем пронизано материальное тело, неразрушимо.", 14);
                                DrawText(330, 285, "Никто не может уничтожить бессмертную душу. ", 14);
                                DrawText(330, 340, "(\"Y\" чтобы скрыть наставление.)", 14);

                            }

                        }
                        if (G == 2)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 260, "Материальное тело вечного, неуничтожимого и", 16);
                                DrawText(330, 290, "неизмеримого живого существа обречено на смерть. ", 16);
                                DrawText(330, 320, "Поэтому сражайся, о потомок Бхараты! ", 16);
                                DrawText(330, 370, "(\"Y\" чтобы скрыть наставление.)", 14);

                            }

                        }
                        if (G == 3)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 240, "Душа не рождается и не умирает.", 16);
                                DrawText(330, 270, "Она никогда не возникала, не возникает и не возникнет. ", 16);
                                DrawText(330, 300, "Она нерожденная, вечная, всегда существующая и изначальная. ", 16);
                                DrawText(330, 330, "Она не гибнет, когда погибает тело. ", 16);
                                DrawText(330, 370, "(\"Y\" чтобы скрыть наставление.)", 14);

                            }

                        }
                        if (G == 4)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 245, "Как человек, снимая старые одежды, надевает новые,", 14);
                                DrawText(330, 270, "так и душа входит в новые материальные тела, ", 14);
                                DrawText(330, 305, "оставляя старые и бесполезные. ", 14);

                                DrawText(330, 335, "(\"Y\" чтобы скрыть наставление.)", 14);

                            }

                        }
                        if (G == 5)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 245, "Душу нельзя рассечь никаким оружием,", 16);
                                DrawText(330, 275, "сжечь огнем, намочить водой ", 16);
                                DrawText(330, 310, "или иссушить ветром.", 16);

                                DrawText(330, 335, "(\"Y\" чтобы скрыть наставление.)", 14);

                            }

                        }
                        //string g1 = "Знай же: то, чем пронизано материальное тело, неразрушимо. Никто не может уничтожить бессмертную душу.";
                        //string g2 = "Материальное тело вечного, неуничтожимого и неизмеримого живого существа обречено на смерть. Поэтому сражайся, о потомок Бхараты!";
                        // string g3 = "Душа не рождается и не умирает. Она никогда не возникала, не возникает и не возникнет. Она нерожденная, вечная, всегда существующая и изначальная. Она не гибнет, когда погибает тело.";
                        // string g4 = "Как человек, снимая старые одежды, надевает новые, так и душа входит в новые материальные тела, оставляя старые и бесполезные.";
                        // string g4 = "Душу нельзя рассечь никаким оружием, сжечь огнем, намочить водой или иссушить ветром.";


                    }


                    rita();

                    if (GetKeyDown(Keyboard.Key.Y) == true)
                    {
                        int u = podskazkaswitch;
                        if (u == 0) podskazkaswitch = 1;
                        if (u == 1) podskazkaswitch = 0;

                    }




                    tank1Draw();

                    explosion();
                    padstoredraw();
                    //Оружие и прицеливание


                    if (GetKeyDown(Keyboard.Key.Num1) == true) // Моде 1 ВЫБОР
                    {
                        gunmode = 1; // пулемет
                        PlaySound(click);
                    }

                    if (GetKeyDown(Keyboard.Key.Num2) == true) // Моде 2 ВЫБОР
                    {
                        gunmode = 2; // ракета
                        PlaySound(click);
                        int PRNR = 0; // Пуск Разрешен
                        for (int i = 0; i < R.GetLongLength(1); i++)
                        {
                            if (R[5, i] == 1)
                            {
                                PlaySound(puskrazreshen);
                                PRNR = 1;
                                break;

                            }

                        }
                        if (PRNR == 0) PlaySound(proverpokazaniya);

                    }// Моде 2 ВЫБОР

                    if (GetKeyDown(Keyboard.Key.Num3) == true)
                    {
                        gunmode = 3; // самонаводящаяся ракета 
                        PlaySound(click);

                    }

                    if (GetMouseButtonDown(Mouse.Button.Left) == true) // ОГОНЬ!
                    {
                        if (gunmode == 1)
                        {



                        }
                        if (gunmode == 2) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
                        {
                            NRrocketchecklaunch = 0;
                            for (int i = 0; i < R.GetLongLength(1); i++)
                            {

                                if (R[5, i] == 0 || R[5, i] == 2) continue;
                                if (R[5, i] == 1)
                                {
                                    R[1, i] = playerx;
                                    R[2, i] = playery;
                                    R[3, i] = angle;
                                    R[4, i] = nrfuel;
                                    R[5, i] = 2; // ракета отрисовывается
                                    NRrocketchecklaunch = 1;
                                    PlaySound(rocketsound);
                                    break;
                                }

                            }
                            if (NRrocketchecklaunch == 0)
                            {
                                PlaySound(click);
                                PlaySound(proverpokazaniya);
                            }
                        }//(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
                        if (gunmode == 3)
                        {

                            PlaySound(rocketsound);

                        }

                    }
                    MoveNRrocket();
                    SearchConflict();

                    //Выход в меню
                    if (GetKeyDown(Keyboard.Key.Escape) == true)
                    {
                        mainmenuSwitch = 2;
                        break;


                    }


                    PanelInstrument();

                    if (donatswitch == 1)
                    {
                        SetFillColor(Color.Blue);
                        DrawSprite(uh61, 840, 300, 1215, 575, 221, 235);
                        DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                        DrawText(330, 240, "Не хватает денег,", 30);
                        DrawText(330, 268, "я дарю Тебе 20000 money. ", 30);
                        DrawText(330, 296, "Cкоро разбогатеешь!;) Жми \"K\"!", 30);
                        DrawText(330, 335, "Донат и обраная связь  ", 18);
                        DrawText(330, 350, "по телефону 89500808627  ", 18);
                        DrawText(330, 365, "(сбер: Алексей тимофеевич Б.)", 18);

                        if (GetKeyDown(Keyboard.Key.K) == true)
                        {
                            money = money + 20000;
                            donatswitch = 0;
                        }
                    }

                    DisplayWindow();
                    Delay(5);




                }

            } // Левел 1 Тренировка



            // Левел 2 Миссии не прописана
            if (levelchoise == 2 && gameplaying == 1) // Левел 2 Миссии

            {
                DispatchEvents();
                PlaySound(grass1);
                mainmenuSwitch = 1;
                gameplaying = 0;
                //Ландшафт

                //Противники

                //Верталет игрока
                // 2. Вооружение - взведение ракет (1=x ракеты, 2=y ракеты, 3=angle ракеты, 4=fuel ракеты, 5=ракета проявлена)




            }// Левел 2 Миссии



            // Левел 3 Свободный полет
            if (levelchoise == 3 && mainmenuSwitch == 0 && gameplaying == 1) // Левел 3 Свободный полет
            {

                if (newgame == 1)
                {
                    //Начальные настройки верталета
                    playerx = 120;
                    playery = 700;
                    engineswitch = 0;
                    enginespeed = 0;
                    helistop = 1;
                    helifuel = 1000;
                    helifuelmax = 1300;
                    helilife = 300;
                    helilifemax = 300;
                    speedxmax = 3f;
                    manageability = 9; //управляемость
                    shagAngle = 1.7f; // угол атаки
                    nrrocketsMaxquantity = 8; //максимально ракет
                    padstoreswitch = 0;
                    helidestroy = 0;
                    money = 0;
                    volnadelay = 0;
                    basedurability = 12;
                    missionswitch = 0;
                    podskazkaswitch = 0;
                    NRrocketslaunched = 0;
                    shagengine = 75; //шаг увелич мощности двигателя
                    enginespeedlimit = 35000; //лимит оборотов двигателя
                    fuelrashod = 1.7f; // расход топлива
                    otkazcicle[1] = manageability;
                    otkazcicle[2] = shagAngle;
                    otkazcicle[3] = 0;
                    winpobeda = 0;

                    //результаты
                    //Поломки
                    helienginelife = 100;
                    otkazhydrosis = 0; // Гидросистема
                    otkazmasterwarning = 0; // Матерсвитч
                    otkazols = 0; // Оптико локационная станция
                    otkazraketasprava = 0; //ракета справа
                    otkazraketasleva = 0; //Ракета слева
                    otkazpojardvig = 0; // Пожар двигателя
                    otkazsbrosoboroti = 0; //Пожар двигателя

                    peregruzkamotora = 0; //Пожар двигателя начнется
                    ritarandom = 1; //рандом для прицела


                    flighttime = 0; //время нахождения в воздухе

                    landingquantity = 0; //количество посадок
                    NRrocketslaunched = 0; //выпущено NR ракет количество
                    targetbingos = 0; //попаданий по цели
                    buk1destroyes = 0; //уничтожено буков1
                    tank1destroyes = 0; //уничтожено танков1
                    fuelusedup = 0; //израсходовано топлива
                    repairings = 0; //Отремонтирован вертолет
                    getdamages = 0; //Получено повреждений


                    //Начальное вооружение 8
                    for (int i = 0; i < nrrocketsMaxquantity; i++) R[5, i] = 1; // 5. Моде 2 NR Ракеты готовы к пуску
                    //Начальные задания
                    for (int i = 0; i < checkpoints.GetLength(0); i++) checkpoints[i] = 1;
                    for (int i = 0; i < checkpoints2.GetLength(0); i++) checkpoints2[i] = 1;


                    for (int i = 0; i < Buk1cicles.GetLength(1); i++) { Buk1cicles[3, i] = 0; Buk1cicles[1, i] = 1200; }
                    for (int i = 0; i < Tank1cicles.GetLength(1); i++) { Tank1cicles[3, i] = 0; Tank1cicles[1, i] = 1200; }
                    for (int i = 0; i < R.GetLength(1); i++) R[5, i] = 0;
                    for (int i = 0; i < R10.GetLength(1); i++) R10[4, i] = 0;
                    newgame = 0;

                    //запасы склада
                    fuelinbag = 2000; //топливо на складе
                    nrrocketsinbag = 20; //ракеты на складе
                    partsinbag = 500; //Запчасти в корзине


                }



                while (true)
                {

                    DispatchEvents();
                    //Расчеты 

                    //Очистка буфера

                    ClearWindow();
                    DrawSprite(backgroundLevel3, 0, 0);

                    //Музыка
                    magnitola();

                    PlayerMove();
                    PlayerDraw();


                    //Оружие и прицеливание


                    if (GetKeyDown(Keyboard.Key.Num1) == true) // Моде 1 ВЫБОР
                    {
                        gunmode = 1; // пулемет
                        PlaySound(click);
                    }

                    if (GetKeyDown(Keyboard.Key.Num2) == true) // Моде 2 ВЫБОР
                    {
                        gunmode = 2; // ракета
                        PlaySound(click);
                        int PRNR = 0; // Пуск Разрешен
                        for (int i = 0; i < R.GetLongLength(1); i++)
                        {
                            if (R[5, i] == 1)
                            {
                                PlaySound(puskrazreshen);
                                PRNR = 1;
                                break;

                            }

                        }
                        if (PRNR == 0) PlaySound(proverpokazaniya);

                    }// Моде 2 ВЫБОР

                    if (GetKeyDown(Keyboard.Key.Num3) == true)
                    {
                        gunmode = 3; // самонаводящаяся ракета 
                        PlaySound(click);

                    }

                    // Выстрел
                    if (GetMouseButtonDown(Mouse.Button.Left) == true) // ОГОНЬ!
                    {
                        if (gunmode == 1)
                        {



                        }
                        if (gunmode == 2) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
                        {
                            NRrocketchecklaunch = 0;
                            for (int i = 0; i < R.GetLongLength(1); i++)
                            {

                                if (R[5, i] == 0 || R[5, i] == 2) continue;
                                if (R[5, i] == 1)
                                {
                                    R[1, i] = playerx;
                                    R[2, i] = playery;
                                    R[3, i] = angle;
                                    R[4, i] = nrfuel;
                                    R[5, i] = 2; // ракета отрисовывается
                                    NRrocketchecklaunch = 1;
                                    PlaySound(rocketsound);
                                    NRrocketslaunched = NRrocketslaunched + 1;
                                    break;
                                }

                            }
                            if (NRrocketchecklaunch == 0)
                            {
                                PlaySound(click);
                                PlaySound(proverpokazaniya);
                            }
                        }//(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
                        if (gunmode == 3)
                        {

                            PlaySound(rocketsound);

                        }

                    }

                    MoveNRrocket();

                    Mission3();
                    tank1Draw();
                    buk1Draw();
                    pvomoveANDdraw();
                    explosion();

                    //Проверка соприкосновений
                    SearchConflict();




                    //Перезарядка
                    if (GetKeyDown(Keyboard.Key.R) == true)
                    {
                        int s = padstoreswitch;
                        if (s == 1)
                        {
                            padstoreswitch = 0;
                            gitaswitch = 0;

                        }
                        if (s == 0 && padswitch == 1)
                        {
                            padstoreswitch = 1;
                            gitadelay = 1500;
                            gitaswitch = 1;
                            G = rnd.Next(1, 6);
                            podskazkaswitch = 1;
                        }

                    }
                    gitadelay = gitadelay - 1;
                    padstoredraw();

                    if (gitaswitch == 1 && gitadelay < 0)
                    {


                        if (G == 1)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 265, "Знай же: то, чем пронизано материальное тело, неразрушимо.", 16);
                                DrawText(330, 290, "Никто не может уничтожить бессмертную душу. ", 16);
                                DrawText(330, 330, "(\"Y\" чтобы скрыть)", 16);

                            }

                        }
                        if (G == 2)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 260, "Материальное тело вечного, неуничтожимого и", 16);
                                DrawText(330, 290, "неизмеримого живого существа обречено на смерть. ", 16);
                                DrawText(330, 320, "Поэтому сражайся, о потомок Бхараты! ", 16);
                                DrawText(330, 360, "(\"Y\" чтобы скрыть)", 14);

                            }

                        }
                        if (G == 3)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 240, "Душа не рождается и не умирает.", 16);
                                DrawText(330, 270, "Она никогда не возникала, не возникает и не возникнет. ", 16);
                                DrawText(330, 300, "Она нерожденная, вечная, всегда существующая и изначальная. ", 16);
                                DrawText(330, 330, "Она не гибнет, когда погибает тело. ", 16);
                                DrawText(330, 370, "(\"Y\" чтобы скрыть)", 14);

                            }

                        }
                        if (G == 4)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 245, "Как человек, снимая старые одежды, надевает новые,", 14);
                                DrawText(330, 270, "так и душа входит в новые материальные тела, ", 14);
                                DrawText(330, 295, "оставляя старые и бесполезные. ", 14);

                                DrawText(330, 335, "(\"Y\" чтобы скрыть)", 12);

                            }

                        }
                        if (G == 5)
                        {

                            if (podskazkaswitch == 1)

                            {
                                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                                SetFillColor(Color.Red);
                                DrawText(330, 245, "Душу нельзя рассечь никаким оружием,", 16);
                                DrawText(330, 275, "сжечь огнем, намочить водой ", 16);
                                DrawText(330, 305, "или иссушить ветром.", 16);

                                DrawText(330, 335, "(\"Y\" чтобы скрыть)", 14);

                            }

                        }
                        //string g1 = "Знай же: то, чем пронизано материальное тело, неразрушимо. Никто не может уничтожить бессмертную душу.";
                        //string g2 = "Материальное тело вечного, неуничтожимого и неизмеримого живого существа обречено на смерть. Поэтому сражайся, о потомок Бхараты!";
                        // string g3 = "Душа не рождается и не умирает. Она никогда не возникала, не возникает и не возникнет. Она нерожденная, вечная, всегда существующая и изначальная. Она не гибнет, когда погибает тело.";
                        // string g4 = "Как человек, снимая старые одежды, надевает новые, так и душа входит в новые материальные тела, оставляя старые и бесполезные.";
                        // string g4 = "Душу нельзя рассечь никаким оружием, сжечь огнем, намочить водой или иссушить ветром.";


                    }


                    rita(); //звуковые предупреждения

                    if (GetKeyDown(Keyboard.Key.Y) == true)
                    {
                        int u = podskazkaswitch;
                        if (u == 0) podskazkaswitch = 1;
                        if (u == 1) podskazkaswitch = 0;

                    }


                    //Панель приборов
                    PanelInstrument();

                    if (GetKeyDown(Keyboard.Key.Escape) == true)
                    {
                        mainmenuSwitch = 2;
                        break;
                    }

                    DisplayWindow();
                    // 4. Ожидание
                    Delay(1);
                }
            } // Левел 3 Свободный полет

        } //Цикл меню
    } // Игра 
}//Программа


