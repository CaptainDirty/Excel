using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel.Models
{
    public class FormulasViewModel
    {
        public bool isShow = false;
        /// <summary>
        /// Коэффициент теплопроводности материала огнеупорной стенки (λогн), Вт/(м*°C);
        /// </summary>
        public double AlfaOgn { get; set; }
        /// <summary>
        /// Коэффициент теплопроводности 1-го материала изоляции (λ1), Вт/(м*°C);
        /// </summary>
        public double Alfa1 { get; set; }
        /// <summary>
        /// Коэффициент теплопроводности 2-го материала изоляции (λ2), Вт/(м*°C);
        /// </summary>
        public double Alfa2 { get; set; }
        /// <summary>
        /// Стоимость материала изоляции, усл.ед./м2 , 1-го материала (С1);
        /// </summary>
        public double C1 { get; set; }
        /// <summary>
        /// Стоимость материала изоляции, усл.ед./м2, 2-го материала (С2);
        /// </summary>
        public double C2 { get; set; }
        /// <summary>
        /// Стоимость материала изоляции, усл.ед./м2, Суммарная толщина изоляции, м (X0);
        /// </summary>
        public double X0 { get; set; }
        /// <summary>
        /// Температура, °С: рабочей среды в печи (t');
        /// </summary>
        public double t1 { get; set; }
        /// <summary>
        /// Температура, °С: окружающей среды (t'');
        /// </summary>
        public double t2 { get; set; }
        /// <summary>
        /// Температура, °С: наружной поверхности (tНПmax )
        /// </summary>
        public double tmax { get; set; }
        /// <summary>
        /// Коэффициент теплоотдачи, Вт/(м2*°С): внутренний (aраб);
        /// </summary>
        public double AlfaRab { get; set; }
        /// <summary>
        /// Коэффициент теплоотдачи, Вт/(м2*°С): наружный (αнар)
        /// </summary>
        public double AlfaNar { get; set; }
        /// <summary>
        /// Коэффициент теплоотдачи, Вт/(м2*°С): Толщина огнеупорной стенки, м
        /// </summary>
        public double Tolsh { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
        /// <summary>
        /// Сумма толщины слоёв, м
        /// </summary>
        public double Sum { get => x1 + x2; }
        /// <summary>
        /// Целевая функция, у.е.
        /// </summary>
        public double CelFunc { get => x1 * C1 + x2 * C2; }
        /// <summary>
        /// Ограничение на температуру наружной стенки
        /// </summary>
        public double Ogran { get => t2 + ((t1 - t2) / ((1 / AlfaRab + Tolsh / AlfaOgn + x1 / Alfa1 + x2 / Alfa2 + 1 / AlfaNar) * AlfaNar));}
    }
}