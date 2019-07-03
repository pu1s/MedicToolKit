namespace Medic.Tools.Kit
{
    /*
    И́ндекс ма́ссы те́ла(англ.body mass index (BMI), ИМТ) — величина, 
    позволяющая оценить степень соответствия массы человека и его
    роста и тем самым косвенно оценить, является ли масса недостаточной, 
    нормальной или избыточной.Важен при определении показаний для необходимости лечения.

    Индекс массы тела рассчитывается по формуле:

    {\displaystyle I = {\frac { m }{ h ^{ 2 } } }}
    I={\frac  {m}{h^{2}}},
    где:

    m — масса тела в килограммах
    h — рост в метрах,
    и измеряется в кг/м².
    Источник https://ru.wikipedia.org/wiki/Индекс_массы_тела
    */
    public static class BodyMassIndex
    {
        public static float Calculate(ref float weight, ref float height)
        {
            float result = weight / (height * height);
            return result;
        }
    }
}
