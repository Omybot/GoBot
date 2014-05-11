using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot
{
    class BrasFruits
    {
        private static readonly int INIT_COUDE = 391;
        private static readonly int INIT_EPAULE = 410;

        private static double angleEpaule;
        private static double angleCoude;

        public static bool PositionEpaule(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_EPAULE;
            if (valeur >= 0 && valeur <= 1024)
            {
                angleEpaule = angle;
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsEpaule, valeur);
            }
            else
                return false;

            return true;
        }

        public static bool PositionCoude(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_COUDE;
            if (valeur >= 0 && valeur <= 1024)
            {
                angleCoude = angle;
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, valeur);
            }
            else
                return false;

            return true;
        }

        public static void PositionDeposeBouchon2()
        {
            PositionEpaule(70);
            PositionCoude(154);
        }

        public static void PositionDeposeBouchon1()
        {
            PositionEpaule(70);
            PositionCoude(164);
        }

        public static void PositionRange()
        {
            PositionEpaule(0);
            PositionCoude(180);
        }

        public static double Perimetre1()
        {
            double a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z;
            Angle alpha, beta, kappa, omega, delta, phi;

            b = 232.26;
            c = 232.26;
            e = 119.87;
            f = 150;
            g = 297.22;
            h = 150;
            
            omega = new Angle(52.24 + angleEpaule);
            kappa = new Angle(70.51 + 90 - angleEpaule);

            d = Math.Sqrt(g * g + h * h - 2 * g * h * Math.Cos(omega.AngleRadiansPositif));
            a = Math.Sqrt(e * e + f * f - 2 * e * f * Math.Cos(kappa.AngleRadiansPositif));
            double truc = (e * e + a * a + f * f) / (2 * a * f);

            alpha = new Angle(180 - 10.22 - angleCoude - (Math.Asin(e/(a/Math.Sin(kappa.AngleRadiansPositif)))) * 180 / Math.PI);
            beta = new Angle(360 - alpha.AngleDegresPositif - 10.22 - Math.Asin((Math.Sin(omega.AngleRadiansPositif) * g) / d) * 180 / Math.PI);

            double resultat = 720.64 + a * a + b * b - 2 * a * b * Math.Cos(alpha.AngleRadiansPositif)  + c * c + d * d - 2 * c * d * Math.Cos(beta.AngleRadiansPositif);

            return resultat;
        }
    }
}