using Battle_CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_CS
{
    struct MinMax
    {
        public double min;
        public double max;
        public MinMax(double min, double max){ this.min = min;this.max = max; }
    }
    internal class CombatVehicleCreator : IVehicleCreate
    {
        Random rnd;
        private static readonly MinMax tank_rec_time = new MinMax(1.5, 2);
        private static readonly MinMax tank_health   = new MinMax(1800,2000);
        private static readonly MinMax tank_chot_accurency = new MinMax(2, 3);
        private static readonly MinMax tank_armor = new MinMax(30, 50);
        private readonly string[] tank_models = { "M1A1 Abrams", "Leopard", "T-64BM Oplot", "Merkava", "Leclerc" };

        private static readonly MinMax ac_wcount = new MinMax(2,2.5);
        private static readonly MinMax ac_speed = new MinMax(40,60);
        private static readonly MinMax ac_health = new MinMax(1000,1200);
        private readonly string[] ac_models = { "Hammer","Husky","Oncilla","Varta","Dozor-B" };

        private static readonly MinMax adv_range = new MinMax(100, 150);
        private static readonly MinMax adv_fire = new MinMax(5, 10);
        private static readonly MinMax adv_mobility = new MinMax(1.5, 2);
        private static readonly MinMax adv_health = new MinMax(700, 800);
        private static readonly string[] adv_models = { "Himars","Uragan","Vulkan","Neptun","NASAMS" };


public CombatVehicleCreator()
        {
            rnd = new Random();
        }

        public CombatVehicle GetCombatVehical(CombatVehicleType type)
        {
            switch (type)
            {
                case CombatVehicleType.AirDefense:
                    return new AirDefenseVehicle(adv_models[rnd.Next(0, adv_models.Length)],
                                          GetDoubleRnd(adv_health.min, adv_health.max),
                                          GetDoubleRnd(adv_range.min, adv_range.max),
                                          GetDoubleRnd(adv_fire.min, adv_fire.max),
                                          GetDoubleRnd(adv_mobility.min, adv_mobility.max));
                case CombatVehicleType.ArmoredCar:
                    return new ArmoredCar(ac_models[rnd.Next(0, ac_models.Length)],
                                          GetDoubleRnd(ac_health.min, ac_health.max),
                                          GetDoubleRnd(ac_wcount.min, ac_wcount.max),
                                          GetDoubleRnd(ac_speed.min, ac_speed.max));
               
                case CombatVehicleType.Tank:
                    return new Tank(tank_models[rnd.Next(0,tank_models.Length)],
                                    GetDoubleRnd(tank_health.min,tank_health.max),
                                    GetDoubleRnd(tank_rec_time.min, tank_rec_time.max),
                                    GetDoubleRnd(tank_chot_accurency.min, tank_chot_accurency.max),
                                    GetDoubleRnd(tank_armor.min, tank_armor.max));
                 
                default: throw new ApplicationException(" Error creation type parameter...");
            }
        }

        double GetDoubleRnd(double min, double max) => rnd.NextDouble() * (max - min) + min;
    }
}
